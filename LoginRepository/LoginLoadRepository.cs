﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaoCao.Library;
using System.Data.SqlClient;

namespace LoginRepository
{
    public class LoginLoadRepository:ConnectDatabase
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool Execute()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                using(var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM Login WHERE username=@username and password=@password";
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@username",
                        Value = this.username,
                        SqlDbType = System.Data.SqlDbType.NVarChar
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@password",
                        Value = this.password,
                        SqlDbType = System.Data.SqlDbType.NVarChar
                    });
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
