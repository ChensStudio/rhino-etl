using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Etl.Core;

namespace TestETL.Joins
{
    class InnerJoin : BaseJoin
    {
        protected override bool MatchJoinCondition(Row leftRow, Row rightRow)
        {
            foreach (var condition in JoinConditions)
            {
                if (!Equals(leftRow[condition.LeftKey], rightRow[condition.RightKey]))
                    return false;
            }

            return true;
        }
    }
}
