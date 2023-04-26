using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using SharedCode.Model;

namespace SharedCode.ViewModel
{
    public class CommentChangedMessage : ValueChangedMessage<Comment>
    {
        public CommentChangedMessage(Comment comment) : base(comment) {
        }
    }

    public class CommentRequestMessage : AsyncRequestMessage<Comment>
    {

    }

    public sealed class CommentViewModel : ObservableRecipient, IRecipient<CommentChangedMessage>
    {
        private Comment comment;

        public Comment Comment
        {
            get => comment;
            private set => SetProperty(ref comment, value);
        }

        public CommentViewModel()
        {
            WeakReferenceMessenger.Default.Register<CommentChangedMessage>(this);
        }

        public void Receive(CommentChangedMessage message)
        {
            Console.WriteLine("receiving");
            Comment = message.Value;
        }

        public async void RequestNewComment()
        {
            Comment = await WeakReferenceMessenger.Default.Send<CommentRequestMessage>();
        }
    }
}

