using System.Data.SqlClient;
using System.Collections.Generic;
using ECommerce.Models;

namespace ECommerce.Data
{
    public class CategoryData : Data
    {
        public List<Category> Read()
        {
            List<Category> list = new List<Category>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Categories";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Category c = new Category();
                c.Id = (int)reader["id"];
                c.Name = (string)reader["name"];

                list.Add(c);
            }

            return list;
        }
    }
}