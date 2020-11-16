using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace TestETL
{
    static class init_datatables
    {
        static public DataTable get_user()
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("ID");
            dt.Columns.Add("Name");

            DataRow _newrow = dt.NewRow();
            _newrow["ID"] = 1;
            _newrow["Name"] = "aaa";
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 2;
            _newrow["Name"] = "bbb";
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 3;
            _newrow["Name"] = "ccc";
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 4;
            _newrow["Name"] = "ddd";
            dt.Rows.Add(_newrow);

            return dt;
        }

        static public DataTable get_user2()
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("ID");
            dt.Columns.Add("Age");

            DataRow _newrow = dt.NewRow();
            _newrow["ID"] = 1;
            _newrow["Age"] = 30;
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 3;
            _newrow["Age"] = 31;
            dt.Rows.Add(_newrow);

            return dt;
        }

        static public DataTable get_user3()
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("ID");
            dt.Columns.Add("sex");

            DataRow _newrow = dt.NewRow();
            _newrow["ID"] = 1;
            _newrow["sex"] = 1;
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 2;
            _newrow["sex"] = 1;
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 3;
            _newrow["sex"] = 0;
            dt.Rows.Add(_newrow);

            _newrow = dt.NewRow();
            _newrow["ID"] = 4;
            _newrow["sex"] = 1;
            dt.Rows.Add(_newrow);

            return dt;
        }
    }
}
