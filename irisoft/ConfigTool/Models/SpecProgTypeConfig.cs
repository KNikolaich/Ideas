using System;

namespace Configuration.Models
{
    public class SpecProgTypeConfig : IComparable<SpecProgTypeConfig>
    {
        public int SpecProgramType { get; set; }

        public bool SendTMforNewSpec { get; set; }

        public bool SendTMforChangedSpec { get; set; }

        public string SpecProgramTypeComment { get; set; }

        public string SendTMforNewSpecComment { get; set; }

        public string SendTMforChangedSpecComment { get; set; }

        public string InvalidMessage()
        {
            var strRes = "";
            if (SpecProgramType < -1 || SpecProgramType > 100 || SpecProgramType == 0)
                strRes += $"Ошибка в строке {SpecProgramType} - номер не может выходить за границы значений или быть = 0";
            return strRes;
        }

        public int CompareTo(SpecProgTypeConfig other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var specProgramTypeComparison = SpecProgramType.CompareWith(other.SpecProgramType);
            if (specProgramTypeComparison != 0) return specProgramTypeComparison;
            var sendTMforNewSpecComparison = SendTMforNewSpec.CompareTo(other.SendTMforNewSpec);
            if (sendTMforNewSpecComparison != 0) return sendTMforNewSpecComparison;
            return SendTMforChangedSpec.CompareTo(other.SendTMforChangedSpec);
        }
    }
}
