using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterControl
{
    class SampleData
    {
        public string Name { get; set; }
        public int Val { get; set; }
        public SampleEnum Selection { get; set; }
    }

    enum SampleEnum
    {
        Item1,
        Item2,
        Item3,
    }
}
