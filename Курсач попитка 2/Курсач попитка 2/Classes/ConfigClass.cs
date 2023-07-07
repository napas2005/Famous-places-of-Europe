using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач_попитка_2
{
    public class ConfigClass
    {
        public ConfigClass()
        {
            Environment.SetEnvironmentVariable("mongoString", "mongodb://localhost:27017");
        }
    }
}
