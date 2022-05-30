using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace op_function.Models.Options
{
    public class AppSettings
    {
        public string Setting1 { get; set; }
        public string Setting2 { get; set; }
        public string Setting3 { get; set; }
        public ArraySetting[] ArraySettings { get; set; }
    }

    public class ArraySetting
    {
        public string Setting4 { get; set; }
        public string Setting5 { get; set; }
    }
}
