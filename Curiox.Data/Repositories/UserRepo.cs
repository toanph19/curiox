using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curiox.Data.Repositories
{
    public class UserRepo : BaseRepo
    {
        public string GetUser(int userId)
        {
            string result = string.Empty;

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT \"TenDT\" FROM \"DeTai\"", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            result += reader.GetString(0);
                    }
                }
            }

            return result;
        }
    }
}
