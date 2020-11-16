using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestETL.Joins
{
    public class JoinSetting
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string LeftDTName { get; set; }
        public string RightDTName { get; set; }
        public List<string[]> JoinConditions { get; set; }
        public List<string[]> Mappings { get; set; }
        public string OutputName { get; set; }
    }
}
