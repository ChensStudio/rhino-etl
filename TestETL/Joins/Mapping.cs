using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestETL.Joins
{
    public class Mapping
    {
        public string LeftKey { get; set; }
        public string RightKey { get; set; }
        public string Formula { get; set; }
        public string Display { get; set; }

        public Mapping(string leftKey, string rightKey, string formula, string display)
        {
            LeftKey = leftKey;
            RightKey = rightKey;
            Formula = formula;
            Display = display;
        }
    }
}
