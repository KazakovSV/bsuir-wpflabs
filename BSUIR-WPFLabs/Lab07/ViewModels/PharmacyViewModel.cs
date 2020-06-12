using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

using Lab07.Commands;
using Lab07.Database;
using Lab07.Models;
using Lab07.Views;

namespace Lab07.ViewModels
{
    public class PharmacyViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products => GetAllProducts();
        public Dictionary<string, ICommand> Commands { get; set; }

        public PharmacyViewModel()
        {
            Commands = new Dictionary<string, ICommand>();

            RegisterCommands();
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            return new ObservableCollection<Product>(DatabaseManager.GetProducts());
        }

        private void RegisterCommands()
        {
            Commands["AddProductCommand"] = new RelayCommand(OnAddProduct, CanAddProduct);
            Commands["UpdateProductCommand"] = new RelayCommand(OnUpdateProduct, CanUpdateProduct);
            Commands["DeleteProductCommand"] = new RelayCommand(OnDeleteProduct, CanDeleteProduct);
        }

        private bool CanAddProduct(object parameter)
        {
            return true;
        }

        private void OnAddProduct(object parameter)
        {
            var window = new AddProductView();
            window.ShowDialog();

            if (window.DialogResult.Value)
            {
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool CanUpdateProduct(object parameter)
        {
            var product = parameter as Product;

            return !(product is null);
        }

        private void OnUpdateProduct(object parameter)
        {
            var product = parameter as Product;
            var window = new UpdateProductView();

            window.DataContext = new ProductViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Cost = product.Cost
            };

            window.ShowDialog();

            if (window.DialogResult.Value)
            {
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool CanDeleteProduct(object parameter)
        {
            var product = parameter as Product;

            return !(product is null);
        }

        private void OnDeleteProduct(object parameter)
        {
            var product = parameter as Product;

            if (product != null)
            {
                DatabaseManager.DeleteProductById(product.ProductID);
            }

            OnPropertyChanged(nameof(Products));
        }
    }
}
