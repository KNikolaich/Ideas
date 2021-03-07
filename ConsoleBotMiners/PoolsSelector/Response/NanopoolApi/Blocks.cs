using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PoolsSelector.Response.NanopoolApi
{
    public class Blocks : Response
	{
		private ObservableCollection<Data.NanopoolApi.Blocks> _data { get; set; }

		[JsonProperty("data")]
		public ObservableCollection<Data.NanopoolApi.Blocks> Data
		{
			get
			{
				return _data;
			}

			set
			{
				if (_data == value) return;

				_data = value;
				_data.CollectionChanged += _data_CollectionChanged;

				OnPropertyChanged(nameof(Data));
			}
		}

		public Blocks()
		{
			_data = new ObservableCollection<Data.NanopoolApi.Blocks>();
			_data.CollectionChanged += _data_CollectionChanged;
		}

		private void _data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged(nameof(Data));
		}
	}
}