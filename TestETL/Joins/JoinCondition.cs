using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestETL.Joins
{
    public class JoinCondition
    {
        public string LeftKey { get; set; }
        public string RightKey { get; set; }

        public JoinCondition(string leftKey, string rightKey)
        {
            LeftKey = leftKey;
            RightKey = rightKey;
        }
    }
}
