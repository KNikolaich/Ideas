using Newtonsoft.Json;
using System.ComponentModel;

namespace NanopoolApi.Response
{
	public class Response : INotifyPropertyChanged
	{
		private string _error { get; set; }
		private bool _status { get; set; }

		[JsonProperty("error")]
		public string Error
		{
			get
			{
				return _error;
			}

			set
			{
				if (_error == value) return;

				_error = value;
				OnPropertyChanged(nameof(Error));
			}
		}

		[JsonProperty("status")]
		public bool Status
		{
			get
			{
				return _status;
			}

			set
			{
				if (_status == value) return;

				_status = value;
				OnPropertyChanged(nameof(Status));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}