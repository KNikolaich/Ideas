using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration.Helpers
{
    internal class CheckComboBoxItem
    {
        public CheckComboBoxItem(bool checkedState, string name)
        {
            Selected = checkedState;
            Name = name;
            Description = name;
        }

        public CheckComboBoxItem(bool checkedState, string name, string description)
        {
            Selected = checkedState;
            Name = name;
            Description = description;
        }

        public string Description { get; set; }

        public string Name { get; set; }
        public bool Selected { get; set; }

        public override string ToString()
        {
            return$"{Name} ({Description})";
        }
    }
}