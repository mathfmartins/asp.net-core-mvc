using System.Data.SqlClient;
using ECommerce.Models;
using System.Collections.Generic;
using System;

namespace ECommerce.Data
{
    public class ProductData : Data
    {
        public Product Read(int id)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM view_products
                                WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            Product product = null;
            if (reader.Read())
            {
                product = new Product
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    Price = (decimal)reader["Price"],
                    CategoryId = (int)reader["CategoryId"],
                    Category = (string)reader["Category"],
                };
            }

            return product;
        }

        public List<Product> Read()
        {
            List<Product> list = new List<Product>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM view_products";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    Price = (decimal)reader["Price"],
                    CategoryId = (int)reader["CategoryId"],
                    Category = (string)reader["Category"],
                };

                list.Add(product);
            }

            return list;
        }

        public void Create(Product e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Products
                                VALUES(@name, @desc, @price, @categoryId)";

            cmd.Parameters.AddWithValue("@name", e.Name);
            cmd.Parameters.AddWithValue("@desc", e.Description);
            cmd.Parameters.AddWithValue("@price", Math.Abs(e.Price));
            cmd.Parameters.AddWithValue("@categoryId", e.CategoryId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Products WHERE id=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }


        public void Update(Product e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Products
                                SET Name = @name, Description = @desc, 
                                    Price = @price, CategoryId = @idC
                                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@name", e.Name);
            cmd.Parameters.AddWithValue("@desc", e.Description);
            cmd.Parameters.AddWithValue("@price", Math.Abs(e.Price));
            cmd.Parameters.AddWithValue("@idC", e.CategoryId);

            cmd.ExecuteNonQuery();
        }
    }
}