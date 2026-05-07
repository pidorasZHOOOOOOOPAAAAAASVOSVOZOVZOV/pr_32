using System;
using System.Collections.Generic;
using System.Data;

namespace WpfApp1.Data
{
    public class Supply
    {
        public int Id { get; set; }
        public int IdManufacturer { get; set; }
        public int IdRecord { get; set; }
        public DateTime DateDelivery { get; set; }
        public int Count { get; set; }

        public string ManufacturerName { get; set; }
        public string RecordName { get; set; }

        public static List<Supply> GetAll()
        {
            List<Supply> list = new List<Supply>();
            DataTable dt = Database.Query(@"
                SELECT s.*, m.Name as ManufacturerName, r.Name as RecordName 
                FROM Supple s
                LEFT JOIN Manufacturer m ON s.IdManufacturer = m.Id
                LEFT JOIN Record r ON s.IdRecord = r.Id");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Supply
                {
                    Id = Convert.ToInt32(row["Id"]),
                    IdManufacturer = row["IdManufacturer"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdManufacturer"]),
                    IdRecord = row["IdRecord"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdRecord"]),
                    DateDelivery = row["DateDelivery"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["DateDelivery"]),
                    Count = row["Count"] == DBNull.Value ? 0 : Convert.ToInt32(row["Count"]),
                    ManufacturerName = row["ManufacturerName"].ToString(),
                    RecordName = row["RecordName"].ToString()
                });
            }
            return list;
        }

        public void Save()
        {
            string date = DateDelivery.ToString("yyyy-MM-dd");
            string sql = $"INSERT INTO Supple (IdManufacturer, IdRecord, DateDelivery, Count) VALUES ({IdManufacturer}, {IdRecord}, '{date}', {Count})";
            Database.Execute(sql);
        }

        public void Update()
        {
            string date = DateDelivery.ToString("yyyy-MM-dd");
            string sql = $"UPDATE Supple SET IdManufacturer={IdManufacturer}, IdRecord={IdRecord}, DateDelivery='{date}', Count={Count} WHERE Id={Id}";
            Database.Execute(sql);
        }

        public void Delete()
        {
            Database.Execute($"DELETE FROM Supple WHERE Id={Id}");
        }
    }
}