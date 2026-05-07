using System;
using System.Collections.Generic;
using System.Data;

namespace WpfApp1.Data
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string CountryName { get; set; }

        public static List<Manufacturer> GetAll()
        {
            List<Manufacturer> list = new List<Manufacturer>();
            DataTable dt = Database.Query(@"
                SELECT m.*, c.Name as CountryName 
                FROM Manufacturer m
                LEFT JOIN Country c ON m.CountryCode = c.Id");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Manufacturer
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    CountryCode = row["CountryCode"] == DBNull.Value ? 0 : Convert.ToInt32(row["CountryCode"]),
                    Phone = row["Phone"].ToString(),
                    Mail = row["Mail"].ToString(),
                    CountryName = row["CountryName"].ToString()
                });
            }
            return list;
        }

        public void Save()
        {
            string sql = $"INSERT INTO Manufacturer (Name, CountryCode, Phone, Mail) VALUES (N'{Name.Replace("'", "''")}', {CountryCode}, N'{Phone.Replace("'", "''")}', N'{Mail.Replace("'", "''")}')";
            Database.Execute(sql);
        }

        public void Update()
        {
            string sql = $"UPDATE Manufacturer SET Name=N'{Name.Replace("'", "''")}', CountryCode={CountryCode}, Phone=N'{Phone.Replace("'", "''")}', Mail=N'{Mail.Replace("'", "''")}' WHERE Id={Id}";
            Database.Execute(sql);
        }

        public void Delete()
        {
            Database.Execute($"DELETE FROM Manufacturer WHERE Id={Id}");
        }
    }
}