using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using Lab08.Commands;
using Lab08.Model;

namespace Lab08.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        #region Fields

        private PharmacyModel pharmacy;

        private string name;
        private string description;
        private int quantity;
        private decimal cost;

        #endregion

        #region Properties

        public Dictionary<string, ICommand> Commands { get; set; }
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set
            {
                name = value;

                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;

                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;

                OnPropertyChanged();
            }
        }

        public decimal Cost
        {
            get => cost;
            set
            {
                cost = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public ProductViewModel(PharmacyModel pharmacy)
        {
            this.pharmacy = pharmacy;

            Initialize();
            RegisterCommands();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            Name = string.Empty;
            Description = string.Empty;
            Quantity = default;
            Cost = default;
            Commands = new Dictionary<string, ICommand>();
        }

        private void RegisterCommands()
        {
            Commands["AddProductCommand"] = new RelayCommand(OnAddProduct, CanAddProduct);
            Commands["EditProductCommand"] = new RelayCommand(OnEditProduct, CanEditProduct);
        }

        private bool CanAddProduct(object parameter)
        {
            return !string.IsNullOrEmpty(Name)
                 && !string.IsNullOrEmpty(Description)
                 && Quantity > 0
                 && Cost > 0;
        }

        private void OnAddProduct(object parameter)
        {
            if (!(parameter is Window window))
            {
                return;
            }

            pharmacy.AddProduct(Name, Description, Quantity, Cost);
            window.DialogResult = true;
            window.Close();
        }

        private bool CanEditProduct(object parameter)
        {
            return true;
        }

        private void OnEditProduct(object parameter)
        {
            if (!(parameter is Window window))
            {
                return;
            }

            pharmacy.EditProduct(Id, Name, Description, Quantity, Cost);
            window.DialogResult = true;
            window.Close();
        }

        #endregion
    }
}
