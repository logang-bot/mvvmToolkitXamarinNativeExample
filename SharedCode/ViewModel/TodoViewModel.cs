using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SharedCode.Model;
using SharedCode.Repository;

namespace SharedCode.ViewModel
{
	public partial class TodoViewModel : ObservableRecipient
	{
		private readonly IUserRepository repository;

		public ObservableCollection<object> Todos { get; }

		[ObservableProperty]
		private ObservableTodo todo;

        //[ObservableProperty]
        private Comment singleComment;

        public ICommand LoadSingleCommentCommand { get; }

        //[ObservableProperty]
        //private bool isLoading;	

        public TodoViewModel(IUserRepository repo)
		{
			this.repository = repo;
            LoadSingleCommentCommand = new AsyncRelayCommand<string>(async (s) => await LoadSingleComment(s));
            WeakReferenceMessenger.Default.Register<TodoViewModel, CommentRequestMessage>(this, (r, m) =>
            {
                //await LoadSingleComment("3");
                m.Reply(r.LoadSingleComment("3"));
            });
		}

		[RelayCommand]
		public async void LoadSingleTodo()
		{
            //IsLoading = true;
            try
            {
                await Task.Delay(2000);
                var data = await repository.GetSingleTodo();
				this.Todo = new ObservableTodo(data);
            }
            finally
            {
                //IsLoading = false;
            }
        }

		public async Task<Comment> LoadSingleComment(string id = "1")
		{
            //IsLoading = true;
            try
            {
                //await Task.Delay(4000);
                var data = await repository.GetSingleComment(id);
                singleComment = data;
                WeakReferenceMessenger.Default.Send(new CommentChangedMessage(data));
                return singleComment;
            }
            finally
            {
                //IsLoading = false;
            }
        }
	}
}

