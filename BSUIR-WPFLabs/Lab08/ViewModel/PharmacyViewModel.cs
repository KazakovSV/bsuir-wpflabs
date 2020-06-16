using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;

using Lab08.Commands;
using Lab08.Model;
using Lab08.View;

namespace Lab08.ViewModel
{
    /// <summary>
    ///     Главная ViewModel приложения
    /// </summary>
    public class PharmacyViewModel : BaseViewModel
    {
        #region Fields

        private PharmacyModel pharmacy;
        private Product selectedProduct;

        #endregion // Fields

        #region Properties

        public ObservableCollection<Product> Products => pharmacy.GetAllProducts();
        public Dictionary<string, ICommand> Commands { get; set; }

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;

                OnPropertyChanged();
            }
        }

        #endregion // Properties

        #region Constructor

        public PharmacyViewModel()
        {
            Initialize();
            RegisterCommands();
        }

        #endregion // Constructor

        #region Methods

        private void Initialize()
        {
            pharmacy = new PharmacyModel();
            Commands = new Dictionary<string, ICommand>();
        }

        private void RegisterCommands()
        {
            Commands["AddProductCommand"] = new RelayCommand(OnAddProduct, CanAddProduct);
            Commands["EditProductCommand"] = new RelayCommand(OnEditProduct, CanEditProduct);
            Commands["DeleteProductCommand"] = new RelayCommand(OnDeleteProduct, CanDeleteProduct);
        }

        private bool CanAddProduct(object parameter)
        {
            return true;
        }

        private void OnAddProduct(object parameter)
        {
            var window = new AddProductView();
            window.DataContext = new ProductViewModel(pharmacy);
            window.ShowDialog();

            if (window.DialogResult.Value)
            {
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool CanEditProduct(object parameter)
        {
            return !(SelectedProduct is null);
        }

        private void OnEditProduct(object parameter)
        {
            var window = new EditProductView();

            window.DataContext = new ProductViewModel(pharmacy)
            {
                Id = SelectedProduct.Id,
                Name = SelectedProduct.Name,
                Description = SelectedProduct.Description,
                Quantity = SelectedProduct.Quantity,
                Cost = SelectedProduct.Cost
            };

            window.ShowDialog();

            if (window.DialogResult.Value)
            {
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool CanDeleteProduct(object parameter)
        {
            return !(SelectedProduct is null);
        }

        private void OnDeleteProduct(object parameter)
        {
            var message = "Вы уверены?";
            var caption = "Удалить продукт";

            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            pharmacy.DeleteProduct(SelectedProduct.Id);
            OnPropertyChanged(nameof(Products));
        }

        #endregion // Methods
    }
}
