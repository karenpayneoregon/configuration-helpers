using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionsFrontEnd
{
    public static class BoolExtensions
    {
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
    }
}
