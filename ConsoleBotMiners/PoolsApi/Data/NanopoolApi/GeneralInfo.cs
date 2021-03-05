using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NanopoolApi.Data
{
	public class GeneralInfo : Data
	{
		private string _account { get; set; }
		private string _unconfirmedBalance { get; set; }
		private string _balance { get; set; }
		private string _hashrate { get; set; }
		private AverageHashrate _averageHashrate { get; set; }
		private ObservableCollection<Worker> _workers { get; set; }

		[JsonProperty("account")]
		public string Account
		{
			get
			{
				return _account;
			}

			set
			{
				if (_account == value) return;

				_account = value;
				OnPropertyChanged(nameof(Account));
			}
		}

		[JsonProperty("unconfirmed_balance")]
		public string UnconfirmedBalance
		{
			get
			{
				return _unconfirmedBalance;
			}

			set
			{
				if (_unconfirmedBalance == value) return;

				_unconfirmedBalance = value;
				OnPropertyChanged(nameof(UnconfirmedBalance));
			}
		}

		[JsonProperty("balance")]
		public string Balance
		{
			get
			{
				return _balance;
			}

			set
			{
				if (_balance == value) return;

				_balance = value;
				OnPropertyChanged(nameof(Balance));
			}
		}

		[JsonProperty("hashrate")]
		public string Hashrate
		{
			get
			{
				return _hashrate;
			}

			set
			{
				if (_hashrate == value) return;

				_hashrate = value;
				OnPropertyChanged(nameof(Hashrate));
			}
		}

		[JsonProperty("avgHashrate")]
		public AverageHashrate AverageHashrate
		{
			get
			{
				return _averageHashrate;
			}

			set
			{
				if (_averageHashrate == value) return;

				_averageHashrate = value;
				OnPropertyChanged(nameof(AverageHashrate));
			}
		}

		[JsonProperty("workers")]
		public ObservableCollection<Worker> Workers
		{
			get
			{
				return _workers;
			}

			set
			{
				if (_workers == value) return;

				_workers = value;
				_workers.CollectionChanged += _workers_CollectionChanged;

				OnPropertyChanged(nameof(Workers));
			}
		}

		[JsonIgnore]
		public int WorkerCount
		{
			get
			{
				return _workers.Count;
			}
		}

		public GeneralInfo()
		{
			_workers = new ObservableCollection<Worker>();
			_workers.CollectionChanged += _workers_CollectionChanged;
		}

		private void _workers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Notify(nameof(Workers));
		}

		protected void Notify(string propName)
		{
			OnPropertyChanged(propName);
		}
	}
}