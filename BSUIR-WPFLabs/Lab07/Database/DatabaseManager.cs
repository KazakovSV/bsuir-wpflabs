using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using Lab07.Models;

namespace Lab07.Database
{
    public static class DatabaseManager
    {
        private static SqlConnection connection;

        static DatabaseManager()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["PharmacyDbConnection"]
                .ConnectionString;

            connection = new SqlConnection(connectionString);
        }

        public static IEnumerable<Product> GetProducts()
        {
            var query = "SELECT ProductID, Name, Description, Quantity, Cost FROM Product";
            var getProductsCommand = new SqlCommand(query, connection);

            connection.Open();

            var reader = getProductsCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var description = reader.GetSqlString(2);
                    var quantity = reader.GetInt32(3);
                    var cost = reader.GetDecimal(4);

                    var product = new Product
                    {
                        ProductID = id,
                        Name = name.Trim(),
                        Description = description.IsNull ? string.Empty : description.Value.Trim(),
                        Quantity = quantity,
                        Cost = cost
                    };

                    yield return product;
                }
            }

            connection.Close();
        }

        public static Product GetProductById(int id)
        {
            var product = GetProducts().ToList()
                .Where(item => item.ProductID == id)
                .FirstOrDefault();

            return product;
        }

        public static void AddProductToDatabase(string name, int quantity, decimal cost, string description = null)
        {
            var query = "INSERT INTO Product (Name, Description, Quantity, Cost) "
                      + "VALUES (@name, @description, @quantity, @cost)";
            var addProductCommand = new SqlCommand(query, connection);

            addProductCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("quantity", quantity),
                new SqlParameter("cost", cost)
            });

            connection.Open();
            addProductCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateProduct(int id, string name, int quantity, decimal cost, string description = null)
        {
            var query = "UPDATE Product SET Name=@name, Description=@description, Quantity=@quantity, Cost=@cost "
                      + "WHERE ProductID=@id";
            var updateProductCommand = new SqlCommand(query, connection);

            updateProductCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("quantity", quantity),
                new SqlParameter("cost", cost)
            });

            connection.Open();
            updateProductCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteProductById(int id)
        {
            var query = "DELETE FROM Product "
                      + "WHERE ProductID=@id";
            var deleteProductCommand = new SqlCommand(query, connection);

            deleteProductCommand.Parameters.AddWithValue("id", id);

            connection.Open();
            deleteProductCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
