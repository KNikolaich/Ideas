using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration.Models
{
    public class TypeConfig
    {
        public string softtype { get; set; }

        public List<Configuration.Models.Attribute> filterAttribs { get; set; }

        public List<string> filterAttribsInObdOther { get; set; }

        public string FilterAttribs
        {
            get
            {
                string result = "";
                for (var index = 0; index < filterAttribs.Count; )
                {
                    var attrib = filterAttribs[index];
                    result += attrib.Name.Replace(Environment.NewLine, "").Trim();
                    if (++index < filterAttribs.Count)
                    {
                        result += Environment.NewLine;
                    }
                }
                return result;
            }
        }
    }
}
