using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace WpfApp1.Data
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Format { get; set; }
        public int Size { get; set; }
        public int IdManufacturer { get; set; }
        public float Price { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }

        public string ManufacturerName { get; set; }
        public string StateName { get; set; }
        public string FormatName => Format == 0 ? "Моно" : "Стерео";

        public static List<Record> GetAll()
        {
            List<Record> list = new List<Record>();
            DataTable dt = Database.Query(@"
                SELECT r.*, m.Name as ManufacturerName, s.Name as StateName 
                FROM Record r
                LEFT JOIN Manufacturer m ON r.IdManufacturer = m.Id
                LEFT JOIN State s ON r.IdState = s.Id");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Record
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Year = row["Year"] == DBNull.Value ? 0 : Convert.ToInt32(row["Year"]),
                    Format = row["Format"] == DBNull.Value ? 0 : Convert.ToInt32(row["Format"]),
                    Size = row["Size"] == DBNull.Value ? 0 : Convert.ToInt32(row["Size"]),
                    IdManufacturer = row["IdManufacturer"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdManufacturer"]),
                    Price = row["Price"] == DBNull.Value ? 0 : Convert.ToSingle(row["Price"]),
                    IdState = row["IdState"] == DBNull.Value ? 0 : Convert.ToInt32(row["IdState"]),
                    Description = row["Description"].ToString(),
                    ManufacturerName = row["ManufacturerName"].ToString(),
                    StateName = row["StateName"].ToString()
                });
            }
            return list;
        }

        public void Save()
        {
            string price = Price.ToString().Replace(",", ".");
            string sql = $@"INSERT INTO Record (Name, Year, Format, Size, IdManufacturer, Price, IdState, Description) 
                           VALUES (N'{Name.Replace("'", "''")}', {Year}, {Format}, {Size}, {IdManufacturer}, {price}, {IdState}, N'{Description.Replace("'", "''")}')";
            Database.Execute(sql);
        }

        public void Update()
        {
            string price = Price.ToString().Replace(",", ".");
            string sql = $@"UPDATE Record SET 
                           Name=N'{Name.Replace("'", "''")}', Year={Year}, Format={Format}, Size={Size}, 
                           IdManufacturer={IdManufacturer}, Price={price}, IdState={IdState}, Description=N'{Description.Replace("'", "''")}' 
                           WHERE Id={Id}";
            Database.Execute(sql);
        }

        public void Delete()
        {
            Database.Execute($"DELETE FROM Record WHERE Id={Id}");
        }

        public static void ExportToCsv(string path, List<Record> records)
        {
            using (StreamWriter file = new StreamWriter(path, false, Encoding.UTF8))
            {
                file.WriteLine("Id;Name;Year;Format;Size;Manufacturer;Price;State;Description");
                foreach (var r in records)
                {
                    string format = r.Format == 0 ? "Моно" : "Стерео";
                    file.WriteLine($"{r.Id};{r.Name};{r.Year};{format};{r.Size};{r.ManufacturerName};{r.Price};{r.StateName};{r.Description}");
                }
            }
        }
    }
}