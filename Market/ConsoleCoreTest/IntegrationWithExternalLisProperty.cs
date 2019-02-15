using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace ConsoleCoreTest
{
    public class IntegrationWithExternalLisProperty
    {
        private static IntegrationWithExternalLisProperty _single;

        public DateTime TimeNextConnectToExternalLis { get; set; }

        public static IntegrationWithExternalLisProperty Load()
        {
            return _single ?? (_single = new IntegrationWithExternalLisProperty{ TimeNextConnectToExternalLis  = DateTime.Now.AddSeconds(15)});
        }

        public void Update()
        {
            // иммитация
            Thread.Sleep(500);
        }
    }
}
