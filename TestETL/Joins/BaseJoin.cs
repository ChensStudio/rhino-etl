using NReco.Linq;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestETL.Joins
{
    public abstract class BaseJoin : NestedLoopsJoinOperation
    {
        protected List<JoinCondition> JoinConditions = null;
        protected List<Mapping> Mappings = null;

        public void JoinCondition(List<JoinCondition> joinConditions)
        {
            JoinConditions = joinConditions;
        }

        public void Mapping(List<Mapping> mappings)
        {
            Mappings = mappings;
        }

        protected override Row MergeRows(Row leftRow, Row rightRow)
        {
            Row row = new Row();

            foreach (var mapping in Mappings)
            {
                if (!string.IsNullOrEmpty(mapping.LeftKey))
                    row[mapping.Display] = leftRow[mapping.LeftKey];
                else if (!string.IsNullOrEmpty(mapping.RightKey))
                    row[mapping.Display] = rightRow[mapping.RightKey];
                else if (!string.IsNullOrEmpty(mapping.Formula))
                {
                    var varContext = new Dictionary<string, object>();
                    foreach (System.Collections.DictionaryEntry l in leftRow)
                    {
                        string name = "left_" + l.Key;
                        varContext[name] = l.Value;
                    }
                    foreach (System.Collections.DictionaryEntry r in rightRow)
                    {
                        string name = "right_" + r.Key;
                        varContext[name] = r.Value;
                    }

                    var lambdaParser = new LambdaParser();
                    row[mapping.Display] = lambdaParser.Eval(mapping.Formula, varContext);
                }
            }

            return row;
        }
    }
}
