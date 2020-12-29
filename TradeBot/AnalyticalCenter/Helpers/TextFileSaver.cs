using AnalyticalCenter.Indicators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnalyticalCenter.Helpers
{
    public class TextFileSaver
    {

        public static void SaveData(List<MacD> dataList)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var macD in dataList)
            {
                sb.AppendLine($"{macD.OpenDateTime}\t {macD.Difference}{Environment.NewLine}");
            }
            SaveData("export.txt", sb.ToString());
        }

        public static void SaveData(string fileName, string data)
        {
            File.WriteAllText(fileName, data);
        }
    }
}
