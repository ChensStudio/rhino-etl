using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestETL.Joins
{
    public class GenericEnumerableOperation : AbstractOperation
    {
        private readonly IEnumerable<Row> rowsToReturn;

        public GenericEnumerableOperation(IEnumerable<Row> rows)
        {
            rowsToReturn = rows;
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            return rowsToReturn;
        }
    }
}
