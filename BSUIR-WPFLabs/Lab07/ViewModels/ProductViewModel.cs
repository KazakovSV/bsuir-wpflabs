using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using Lab07.Commands;
using Lab07.Database;
using Lab07.Models;

namespace Lab07.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private string name;
        private string description;
        private int quantity;
        private decimal cost;

        public Dictionary<string, ICommand> Commands { get; set; }

        public int ProductID { get; set; }

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

        public ProductViewModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            Quantity = default(int);
            Cost = default(decimal);
            Commands = new Dictionary<string, ICommand>();

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            Commands["AddProductCommand"] = new RelayCommand(OnAddProduct, CanAddProduct);
            Commands["UpdateProductCommand"] = new RelayCommand(OnUpdateProduct, CanUpdateProduct);
        }

        private bool CanAddProduct(object parameter)
        {
            return !string.IsNullOrEmpty(Name)
                 && Quantity > 0
                 && Cost > 0;
        }

        private void OnAddProduct(object parameter)
        {
            var window = parameter as Window;
            DatabaseManager.AddProductToDatabase(Name, Quantity, Cost, Description);
            window.DialogResult = true;
            window.Close();
        }

        private bool CanUpdateProduct(object parameter)
        {
            return true;
        }

        private void OnUpdateProduct(object parameter)
        {
            var window = parameter as Window;
            DatabaseManager.UpdateProduct(ProductID, Name, Quantity, Cost, Description);
            window.DialogResult = true;
            window.Close();
        }
    }
}
