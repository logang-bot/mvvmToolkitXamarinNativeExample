using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SharedCode.Model
{
    public class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }

    public class ObservableTodo : ObservableObject
    {
        private readonly Todo todo;

        public ObservableTodo(Todo todo) => this.todo = todo;

        public int Id
        {
            get => todo.id;
            set => SetProperty(todo.id, value, todo, (u, n) => u.id = n);
        }

        public int UserId
        {
            get => todo.userId;
            set => SetProperty(todo.userId, value, todo, (u, n) => u.userId = n);
        }

        public string Title
        {
            get => todo.title;
            //set => SetProperty(todo.title, value, todo, (u, n) => u.title = n);
            set => SetProperty(todo.title, value, todo, updateTitleCallback);
        }

        private void updateTitleCallback(Todo t, string newTitle)
        {
            Console.WriteLine(t.title);
            t.title = newTitle;
        }

        public bool Completed
        {
            get => todo.completed;
            set => SetProperty(todo.completed, value, todo, (u, n) => u.completed = n);
        }
    }
}

