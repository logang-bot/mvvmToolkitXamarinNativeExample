﻿using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SharedCode.Repository;
using SharedCode.Services;
using SharedCode.ViewModel;

namespace SharedCode.DI
{
    public sealed class IocService
    {
        private static IocService _instance;

        public static IocService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IocService();
                }
                return _instance;
            }
        }

        public IServiceProvider Services { get; }
        private IocService()
        {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<INetworkService, NetworkService>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddTransient<UserViewModel>();

            return services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return Instance.Services.GetService<T>();
        }
    }
}

