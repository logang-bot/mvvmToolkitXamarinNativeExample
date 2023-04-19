#nullable enable
using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SharedCode.Model;

namespace SharedCode.Util
{
	public class ObservableWrapper<T> : ObservableObject
	{
		private T? value;
		public T? Value {
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				OnPropertyChanged(typeof(T).Name);
			}
		}

		public ObservableWrapper(T? ins = default(T))
		{
			this.Value = ins;
		}

		public void AddObserver(Action<T?> observer)
		{
			this.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
			{
				observer(this.Value);
			};
		}
	}
}

