using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationHelperConventional
{
    public class MyApplication
    {
        public string MainWindowTitle { get; set; }
        public string IncomingFolder { get; set; }
        public int ImportMinutesToPause { get; set; }
        public bool TestMode { get; set; }
        public DateTime LastRan { get; set; }
        public string DatabaseServer { get; set; }
        public string Catalog { get; set; }
        public string ConnectionString => $"Data Source= {DatabaseServer};Initial Catalog={Catalog};Integrated Security=True";
    }

}
