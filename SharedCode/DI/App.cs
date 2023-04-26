using System;
using MvvmCross;
using MvvmCross.ViewModels;
using SharedCode.Repository;
using SharedCode.Services;
using SharedCode.ViewModel;

namespace SharedCode.DI
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IUserRepository, UserRepository>();
            Mvx.IoCProvider.RegisterType<INetworkService, NetworkService>();
            RegisterAppStart<UserViewModelCross>();
        }
    }
}

