using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace Configuration.Helpers
{
    public class SharedFolder
    {
        internal bool IsActive { get; set; }

        internal string FolderName { get; set; }

        internal SharedStatusEnum SharedStatus { get; set; }

        public string SharedStatusDescription
        {
            get { return SharedStatus.GetDescription(); }
            set
            {
                foreach (SharedStatusEnum valueEnum in Enum.GetValues(typeof(SharedStatusEnum)))
                {
                    var valueDescription = valueEnum.GetDescription();
                    if (value == valueDescription)
                    {
                        SharedStatus = valueEnum;
                        break;
                    }
                }
            }
        }
    }
}