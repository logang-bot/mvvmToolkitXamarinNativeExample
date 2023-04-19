using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using SharedCode.DI;
using SharedCode.ViewModel;

namespace MvvmToolkitDemoAppAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView tvUsersCant;
        private ProgressBar pbLoading;

        private UserViewModel viewModel = IocService.GetService<UserViewModel>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            tvUsersCant = FindViewById<TextView>(Resource.Id.tvUsersCant);
            pbLoading = FindViewById<ProgressBar>(Resource.Id.pbLoading);

            viewModel.PropertyChanged += updateLoading;

            viewModel.LoadPostsCommand.Execute(null);
                
            //viewModel.Users.ContinueWith(async result => Log.Debug("testing", (await result).Count.ToString()));

        }

        public void updateLoading(object sender, EventArgs e)
        {
            //tvUsersCant.Text = (await viewModel.Users).Count.ToString();
            tvUsersCant.Text = viewModel.Posts.Count.ToString();
            if (viewModel.IsLoading)
            {
                pbLoading.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                pbLoading.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
