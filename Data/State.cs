using System;
using System.Collections.Generic;
using System.Data;

namespace WpfApp1.Data
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string Description { get; set; }

        public static List<State> GetAll()
        {
            List<State> list = new List<State>();
            DataTable dt = Database.Query("SELECT * FROM State ORDER BY Id");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new State
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Subname = row["Subname"].ToString(),
                    Description = row["Description"].ToString()
                });
            }
            return list;
        }

        public void Save()
        {
            string sql = $"INSERT INTO State (Name, Subname, Description) VALUES (N'{Name.Replace("'", "''")}', N'{Subname.Replace("'", "''")}', N'{Description.Replace("'", "''")}')";
            Database.Execute(sql);
        }

        public void Update()
        {
            string sql = $"UPDATE State SET Name=N'{Name.Replace("'", "''")}', Subname=N'{Subname.Replace("'", "''")}', Description=N'{Description.Replace("'", "''")}' WHERE Id={Id}";
            Database.Execute(sql);
        }

        public void Delete()
        {
            Database.Execute($"DELETE FROM State WHERE Id={Id}");
        }
    }
}