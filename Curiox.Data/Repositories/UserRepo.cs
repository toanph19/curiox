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
                //add new row to database
               /*using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO \"DeTai\" VALUES (@DT,@tenDT,@Cap,@KinhPhi)";
                    cmd.Parameters.AddWithValue("DT", "DT05");
                    cmd.Parameters.AddWithValue("tenDT", "Test");
                    cmd.Parameters.AddWithValue("Cap", "Truong");
                    cmd.Parameters.AddWithValue("KinhPhi", 20000);
                    cmd.ExecuteNonQuery();
                }*/

                //update database
                /*using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE \"DeTai\" SET \"TenDT\" = @tenDt WHERE \"DT#\" = @DT";
                    cmd.Parameters.AddWithValue("DT", "DT05");
                    cmd.Parameters.AddWithValue("tenDT", "newTenDT");
                    cmd.ExecuteNonQuery();
                }*/
                //delete from table
                /*using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM \"DeTai\" WHERE \"DT#\" = @DT";
                    cmd.Parameters.AddWithValue("DT", "DT05");
                    cmd.ExecuteNonQuery();
                }*/

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
