using System;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1.Data
{
    public class Database
    {
        // Для SQL Server (как в вашем скрипте)
        private static string connectionString = "server=localhost;database=VinylRecords;User Id=sa;Password=1111;";

        public static DataTable Query(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка БД: {ex.Message}\nSQL: {sql}");
            }
            return table;
        }

        public static void Execute(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка выполнения: {ex.Message}\nSQL: {sql}");
            }
        }
    }
}