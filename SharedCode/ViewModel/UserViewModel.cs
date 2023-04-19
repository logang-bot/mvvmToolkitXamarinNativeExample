using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedCode.Model;
using SharedCode.Repository;
using SharedCode.Util;

namespace SharedCode.ViewModel
{
	public class UserViewModel : ObservableObject
	{
		private readonly IUserRepository userRepository;

		private TaskNotifier<List<User>> users;
		private List<Post> posts;
		private bool isLoading;
		private User singleUser;

		[Required]
		public ObservableWrapper<Post> SinglePost = new ObservableWrapper<Post>();

		public ICommand LoadUsersCommand { get; }
		public ICommand LoadPostsCommand { get; }
		public ICommand LoadSingleUserCommand { get; }
		public ICommand LoadSinglePostCommand { get; }

		public Task<List<User>> Users
		{
			get => users;
			set => SetPropertyAndNotifyOnCompletion(ref users, value);
		}

		public List<Post> Posts
		{
			get => posts;
			set => SetProperty(ref posts, value);
		}

		public bool IsLoading
		{
			get => isLoading;
			set => SetProperty(ref isLoading, value);
		}

		public User SingleUser
		{
			get => singleUser;
			set => SetProperty(ref singleUser, value);
		}

		public UserViewModel(IUserRepository userRepo)
		{
			this.userRepository = userRepo;
			IsLoading = false;
			LoadUsersCommand = new RelayCommand(LoadUsers);
			LoadPostsCommand = new RelayCommand(LoadPosts);
			LoadSingleUserCommand = new RelayCommand(LoadSingleUser);
			LoadSinglePostCommand = new RelayCommand(LoadSinglePost);
		}

		private async void LoadUsers()
		{
			IsLoading = true;
			try
			{
				Users = userRepository.GetUsersFromNetwork();
				await Task.Delay(2000);
			}
			finally
			{
				IsLoading = false;
			}
		}

		private async void LoadPosts()
		{
            IsLoading = true;
            try
            {
				await Task.Delay(2000);
                Posts = await userRepository.GetPostsFromNetwork();
            }
            finally
            {
                IsLoading = false;
			}
		}

		private async void LoadSingleUser()
		{
            IsLoading = true;
            try
            {
                await Task.Delay(2000);
                SingleUser = await userRepository.GetSingleUser();
				//singleUser.PropertyChanged += UpdateSingleUser;
			}
            finally
            {
                IsLoading = false;
            }
        }

		private async void LoadSinglePost()
		{
            IsLoading = true;
            try
            {
                await Task.Delay(2000);
                SinglePost.Value = await userRepository.GetSinglePost();
            }
            finally
            {
                IsLoading = false;
            }
        }

		//private void UpdateSingleUser(object sender, EventArgs e)
		//{
		//	OnPropertyChanged("SingleUser");
		//}
	}
}
