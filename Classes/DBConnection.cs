using System.Data;
using System.Data.SqlClient;

namespace PR_32.Classes
{
    public class DBConnection
    {
        public static DataTable Connection(string SQL)
        {
            DataTable dataTable = new DataTable("Datatable");
            string connectionString = "server=LAPTOP3019;Trusted_Connection=No;DataBase=VinylRecords;User=sa;PWD=1111";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = SQL;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}