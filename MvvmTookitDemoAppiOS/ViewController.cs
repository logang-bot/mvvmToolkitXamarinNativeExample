using Foundation;
using SharedCode.DI;
using SharedCode.Model;
using SharedCode.ViewModel;
using System;
using System.ComponentModel;
using UIKit;

namespace MvvmTookitDemoAppiOS
{
    public partial class ViewController : UIViewController
    {
        private UserViewModel viewModel = IocService.GetService<UserViewModel>();
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            viewModel.PropertyChanged += updateLoading;
            dataStackView.Hidden = true;
            fetchDataButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                viewModel.LoadUsersCommand.Execute(null);
            };
            updateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                viewModel.SingleUser.Name = "test";
                viewModel.SingleUser.Id += 111;
                viewModel.SingleUser.Username = "testusername";
            };

            viewModel.SinglePost.AddObserver((singPost) =>
            {
                if (singPost == null) return;
                dataStackView.Hidden = false;
                usersCountLabel.Text = "1";
                nameLabel.Text = singPost.userId.ToString();
                usernameLabel.Text = singPost.id.ToString();
                emailLabel.Text = singPost.title.ToString();
                idLabel.Text = singPost.body.ToString();
            });
            //viewModel.LoadPostsCommand.Execute(null);
            //viewModel.LoadSingleUserCommand.Execute(null);
            viewModel.LoadSinglePostCommand.Execute(null);

        }

        public void updateLoading(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
            switch (e.PropertyName)
            {
                case "Posts":
                    if (viewModel.Posts != null)
                    {
                        dataStackView.Hidden = false;
                        usersCountLabel.Text = viewModel.Posts.Count.ToString();
                    }
                    else
                    {
                        dataStackView.Hidden = true;
                    }
                    break;
                case "IsLoading":
                    if (viewModel.IsLoading)
                    {
                        progressActivityIndicator.StartAnimating();
                        progressActivityIndicator.Hidden = false;
                    }
                    else
                    {
                        progressActivityIndicator.StopAnimating();
                        progressActivityIndicator.Hidden = true;
                    }
                    break;
                case "SingleUser":
                    if (viewModel.SingleUser != null)
                    {
                        dataStackView.Hidden = false;
                        usersCountLabel.Text = "1";
                        nameLabel.Text = viewModel.SingleUser.Name;
                        usernameLabel.Text = viewModel.SingleUser.Username;
                        emailLabel.Text = viewModel.SingleUser.email;
                        idLabel.Text = viewModel.SingleUser.Id.ToString();
                        viewModel.SingleUser.PropertyChanged += updateUser;
                    }
                    else
                    {
                        dataStackView.Hidden = true;
                    }
                    break;
            }
        }

        public void updateUser(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Updating user");
            switch (e.PropertyName)
            {
                case "Name":
                    nameLabel.Text = viewModel.SingleUser.Name;
                    break;
                case "Username":
                    usernameLabel.Text = viewModel.SingleUser.Username;
                    break;
                case "Id":
                    idLabel.Text = viewModel.SingleUser.Id.ToString();
                    break;
            }
        }
    }
}
