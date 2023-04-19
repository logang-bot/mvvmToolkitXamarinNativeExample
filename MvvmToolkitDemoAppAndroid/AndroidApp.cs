using System;
using Android.App;
using static Android.Media.Audiofx.DynamicsProcessing;
using System.ComponentModel;
using SharedCode.DI;

namespace MvvmToolkitDemoAppAndroid
{
    [Application]
    public class AndroidApplication : Application
    {
        public AndroidApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

        }
    }
}

