using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class Calculator : Data
	{
		private CalculatorEarnings _minute { get; set; }
		private CalculatorEarnings _hour { get; set; }
		private CalculatorEarnings _day { get; set; }
		private CalculatorEarnings _week { get; set; }
		private CalculatorEarnings _wonth { get; set; }

		[JsonProperty("minute")]
		public CalculatorEarnings Minute
		{
			get
			{
				return _minute;
			}

			set
			{
				if (_minute == value) return;

				_minute = value;
				OnPropertyChanged(nameof(Minute));
			}
		}

		[JsonProperty("hour")]
		public CalculatorEarnings Hour
		{
			get
			{
				return _hour;
			}

			set
			{
				if (_hour == value) return;

				_hour = value;
				OnPropertyChanged(nameof(Hour));
			}
		}

		[JsonProperty("day")]
		public CalculatorEarnings Day
		{
			get
			{
				return _day;
			}

			set
			{
				if (_day == value) return;

				_day = value;
				OnPropertyChanged(nameof(Day));
			}
		}

		[JsonProperty("week")]
		public CalculatorEarnings Week
		{
			get
			{
				return _week;
			}

			set
			{
				if (_week == value) return;

				_week = value;
				OnPropertyChanged(nameof(Week));
			}
		}

		[JsonProperty("month")]
		public CalculatorEarnings Month
		{
			get
			{
				return _wonth;
			}

			set
			{
				if (_wonth == value) return;

				_wonth = value;
				OnPropertyChanged(nameof(Month));
			}
		}
	}
}