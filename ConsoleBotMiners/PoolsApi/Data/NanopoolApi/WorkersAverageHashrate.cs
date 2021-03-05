using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NanopoolApi.Data
{
	public class WorkersAverageHashrate : Data
	{
		private ObservableCollection<WorkerHashrateValue> _h1 { get; set; }
		private ObservableCollection<WorkerHashrateValue> _h3 { get; set; }
		private ObservableCollection<WorkerHashrateValue> _h6 { get; set; }
		private ObservableCollection<WorkerHashrateValue> _h12 { get; set; }
		private ObservableCollection<WorkerHashrateValue> _h24 { get; set; }

		[JsonProperty("h1")]
		public ObservableCollection<WorkerHashrateValue> H1
		{
			get
			{
				return _h1;
			}

			set
			{
				if (_h1 == value) return;

				_h1 = value;
				_h1.CollectionChanged += _h1_CollectionChanged;

				OnPropertyChanged(nameof(H1));
			}
		}

		[JsonProperty("h3")]
		public ObservableCollection<WorkerHashrateValue> H3
		{
			get
			{
				return _h3;
			}

			set
			{
				if (_h3 == value) return;

				_h3 = value;
				_h3.CollectionChanged += _h3_CollectionChanged;

				OnPropertyChanged(nameof(H3));
			}
		}

		[JsonProperty("h6")]
		public ObservableCollection<WorkerHashrateValue> H6
		{
			get
			{
				return _h6;
			}

			set
			{
				if (_h6 == value) return;

				_h6 = value;
				_h6.CollectionChanged += _h6_CollectionChanged;

				OnPropertyChanged(nameof(H6));
			}
		}

		[JsonProperty("h12")]
		public ObservableCollection<WorkerHashrateValue> H12
		{
			get
			{
				return _h12;
			}

			set
			{
				if (_h12 == value) return;

				_h12 = value;
				_h12.CollectionChanged += _h12_CollectionChanged;

				OnPropertyChanged(nameof(H12));
			}
		}

		[JsonProperty("h24")]
		public ObservableCollection<WorkerHashrateValue> H24
		{
			get
			{
				return _h24;
			}

			set
			{
				if (_h24 == value) return;

				_h24 = value;
				_h24.CollectionChanged += _h24_CollectionChanged;

				OnPropertyChanged(nameof(H24));
			}
		}

		public WorkersAverageHashrate()
		{
			_h1 = new ObservableCollection<WorkerHashrateValue>();
			_h1.CollectionChanged += _h1_CollectionChanged;
			_h3 = new ObservableCollection<WorkerHashrateValue>();
			_h3.CollectionChanged += _h3_CollectionChanged;
			_h6 = new ObservableCollection<WorkerHashrateValue>();
			_h6.CollectionChanged += _h6_CollectionChanged;
			_h12 = new ObservableCollection<WorkerHashrateValue>();
			_h12.CollectionChanged += _h12_CollectionChanged;
			_h24 = new ObservableCollection<WorkerHashrateValue>();
			_h24.CollectionChanged += _h24_CollectionChanged;
		}

		private void _h1_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Notify(nameof(H1));
		}

		private void _h3_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Notify(nameof(H3));
		}

		private void _h6_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Notify(nameof(H6));
		}

		private void _h12_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Notify(nameof(H12));
		}

		private void _h24_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Notify(nameof(H24));
		}

		protected void Notify(string propName)
		{
			OnPropertyChanged(propName);
		}
	}
}