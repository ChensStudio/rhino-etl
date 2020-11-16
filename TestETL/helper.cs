using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Rhino.Etl.Core;

namespace TestETL
{
    class helper
    {
        public static List<Joins.JoinSetting> Readjson()
        {
            string jsonfile = "process_def.json";

            List<Joins.JoinSetting> opers = new List<Joins.JoinSetting>();

            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o["process"];

                    foreach (var item in value)
                    {
                        Joins.JoinSetting oper = new Joins.JoinSetting();
                        oper.Name = item["name"].ToString();
                        oper.Type = item["type"].ToString();
                        oper.LeftDTName = (item["left"])["name"].ToString();
                        oper.RightDTName = (item["right"])["name"].ToString();

                        oper.JoinConditions = new List<string[]>();
                        foreach (var cond in item["join_condition"])
                        {
                            string[] a = { cond[0].ToString(), cond[1].ToString() };
                            oper.JoinConditions.Add(a);
                        }

                        oper.Mappings = new List<string[]>();
                        foreach (var mapping in item["mapping"])
                        {
                            string[] a = { mapping["left"].ToString(), mapping["right"].ToString(),
                                mapping["formula"].ToString(), mapping["output"].ToString() };
                            oper.Mappings.Add(a);
                        }

                        oper.OutputName = (item["output"])["name"].ToString();

                        opers.Add(oper);
                    }
                }
            }

            return opers;
        }

        public static List<Row> DataTable2List(DataTable dt)
        {
            List<Row> list = new List<Row>();

            foreach(DataRow r in dt.Rows)
            {
                Row row = new Row();

                foreach(DataColumn c in dt.Columns)
                {
                    row.Add(c.ColumnName, r[c.ColumnName] == DBNull.Value ? null : r[c.ColumnName]);
                }

                list.Add(row);
            }

            return list;
        }

        public static DataTable List2DataTable(List<Row> rows)
        {
            if(rows.Count == 0)
            {
                return null;
            }

            DataTable dt = new DataTable();

            Row row1 = rows.First();
            foreach(string key in row1.Keys)
            {
                Type type = row1[key].GetType();
                dt.Columns.Add(key, type);
            }

            foreach(Row row in rows)
            {
                DataRow r = dt.NewRow();
                foreach(DataColumn c in dt.Columns)
                {
                    r[c.ColumnName] = row[c.ColumnName] == null ? DBNull.Value : row[c.ColumnName];
                }

                dt.Rows.Add(r);
            }

            return dt;
        }
    }
}
