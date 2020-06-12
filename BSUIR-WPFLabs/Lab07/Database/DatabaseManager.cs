using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using Lab07.Models;

namespace Lab07.Database
{
    /// <summary>
    ///     Управляет базой данных
    /// </summary>
    public static class DatabaseManager
    {
        #region Fields

        // Объект подключения к БД
        private static SqlConnection connection;

        #endregion

        #region Constructor

        static DatabaseManager()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["PharmacyDbConnection"]
                .ConnectionString;

            connection = new SqlConnection(connectionString);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Получает все записи из таблицы Product
        /// </summary>
        /// <returns>Перечислитель продуктов</returns>
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

        /// <summary>
        ///     Получает конкретный продукт по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор продукта</param>
        /// <returns>Объект типа Product</returns>
        public static Product GetProductById(int id)
        {
            var product = GetProducts().ToList()
                .Where(item => item.ProductID == id)
                .FirstOrDefault();

            return product;
        }

        /// <summary>
        ///     Добавляет продукт в БД
        /// </summary>
        /// <param name="name">Название продукта</param>
        /// <param name="quantity">Количество на складе</param>
        /// <param name="cost">Стоимость единицы товара</param>
        /// <param name="description">Описание продукта</param>
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

        /// <summary>
        ///     Обновляет сведения о товаре
        /// </summary>
        /// <param name="id">Идентификатор продукта</param>
        /// <param name="name">Название продукта</param>
        /// <param name="quantity">Количество на складе</param>
        /// <param name="cost">Стоимость единицы товара</param>
        /// <param name="description">Описание продукта</param>
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

        /// <summary>
        ///     Удаляет товар из БД
        /// </summary>
        /// <param name="id">Идентификатор продукта</param>
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

        #endregion
    }
}
