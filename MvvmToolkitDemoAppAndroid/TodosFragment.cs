
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using SharedCode.DI;
using SharedCode.ViewModel;

namespace MvvmToolkitDemoAppAndroid
{
    [Obsolete]
    public class TodosFragment : Fragment
	{
        private TextView tvUsersCant;
        private ProgressBar pbLoading;

        private UserViewModel viewModel = IocService.GetService<UserViewModel>();

        [Obsolete]
        public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

            // Create your fragment here
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            tvUsersCant = View.FindViewById<TextView>(Resource.Id.tvUsersCant);
            pbLoading = View.FindViewById<ProgressBar>(Resource.Id.pbLoading);


            viewModel.PropertyChanged += updateLoading;

            viewModel.LoadPostsCommand.Execute(null);

        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			return inflater.Inflate(Resource.Layout.todos_fragment, container, false);
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
    }
}

