using System.Collections.ObjectModel;

using Lab08.DAL;

namespace Lab08.Model
{
    /// <summary>
    ///     Главная модель приложения
    /// </summary>
    public class PharmacyModel
    {
        #region Fields

        private PharmacyContext db;

        #endregion // Fields

        #region Constructor

        public PharmacyModel()
        {
            db = new PharmacyContext();
        }

        #endregion // Constructor

        #region Methods

        public ObservableCollection<Product> GetAllProducts()
        {
            return new ObservableCollection<Product>(db.Products);
        }

        public void AddProduct(string name, string description, int quantity, decimal cost)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Quantity = quantity,
                Cost = cost
            };

            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = db.Products.Find(id);

            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public void EditProduct(int id, string name, string description, int quantity, decimal cost)
        {
            var product = db.Products.Find(id);

            if (product != null)
            {
                product.Name = name;
                product.Description = description;
                product.Quantity = quantity;
                product.Cost = cost;

                db.SaveChanges();
            }        
        }

        #endregion // Methods
    }
}
