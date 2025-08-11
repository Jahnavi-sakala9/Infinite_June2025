using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
        public sealed class Db
        {
            private static Db _i;
            public static Db I
            {
                get
                {
                    if (_i == null) throw new InvalidOperationException("DB not initialized");
                    return _i;
                }
            }

            public SqlConnection Conn { get; private set; }

            private Db(string cs)
            {
                Conn = new SqlConnection(cs);
                Conn.Open();
            }

            public static void Init(string cs)
            {
                if (_i == null) _i = new Db(cs);
            }


            public SqlCommand Cmd(string sql)
            {
                var cmd = new SqlCommand(sql, Conn);
                cmd.CommandType = CommandType.Text;
                return cmd;
            }
        }
}


