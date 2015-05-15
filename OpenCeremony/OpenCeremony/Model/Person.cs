using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCeremony.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Uri ImagePath { get; set; }
        public string Organization { get; set; }
        public int Order { get; set; }
    }
}
