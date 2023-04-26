using System;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using SharedCode.DI;

namespace MvvmTookitDemoAppiOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
        }

        protected override IMvxIocOptions CreateIocOptions()
        {
            return new MvxIocOptions
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }
    }
}

