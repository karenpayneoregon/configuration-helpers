using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationHelperConventional
{
    public class ApplicationSettingError
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Exception Exception { get; set; }
    }

}
