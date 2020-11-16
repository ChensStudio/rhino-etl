using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Rhino.Etl.Core;
using Rhino.Etl.Core.Pipelines;
using TestETL.Joins;

namespace TestETL
{
    public class dfd
    {
        private Dictionary<string, DataTable> dictDataTable = new Dictionary<string, DataTable>();

        public dfd()
        {
            init_dt();   
        }

        private void init_dt()
        {
            dictDataTable.Add("User", init_datatables.get_user());
            dictDataTable.Add("User2", init_datatables.get_user2());
            dictDataTable.Add("User3", init_datatables.get_user3());
        }

        public DataTable run_processes()
        {
            string outputName="";

            List<Joins.JoinSetting> processes = helper.Readjson();

            foreach (Joins.JoinSetting process in processes)
            {
                runJoin(process);

                outputName = process.OutputName;
            }

            return dictDataTable[outputName];
        }

        private void runJoin(JoinSetting setting)
        {
            List<Row> left = helper.DataTable2List(dictDataTable[setting.LeftDTName]);
            List<Row> right = helper.DataTable2List(dictDataTable[setting.RightDTName]);

            List<JoinCondition> joinConditions = new List<JoinCondition>();
            foreach(string[] item in setting.JoinConditions)
            {
                joinConditions.Add(new JoinCondition(item[0], item[1]));
            }

            List<Mapping> mappings = new List<Mapping>();
            foreach (string[] item in setting.Mappings)
            {
                mappings.Add(new Mapping(item[0], item[1], item[2], item[3]));
            }

            BaseJoin join;

            switch (setting.Type)
            {
                case "leftjoin":
                    join = new LeftJoin();
                    break;
                case "innerjoin":
                    join = new InnerJoin();
                    break;
                default:
                    throw new NotImplementedException();
            }

            join.Left(new GenericEnumerableOperation(left))
                .Right(new GenericEnumerableOperation(right));

            join.JoinCondition(joinConditions);
            join.Mapping(mappings);

            join.PrepareForExecution(new SingleThreadedPipelineExecuter());
            IEnumerable<Row> result = join.Execute(null);
            List<Row> items = new List<Row>(result);

            DataTable dtResult = helper.List2DataTable(items);

            dictDataTable.Add(setting.OutputName, dtResult);
        }
    }
}
