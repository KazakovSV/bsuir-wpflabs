using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using Lab07.Commands;
using Lab07.Database;

namespace Lab07.ViewModels
{
    /// <summary>
    ///     ViewModel конкретного продукта
    /// </summary>
    /// <remarks>Создана для привязок в окнах UpdateProductView и AddProductView</remarks>
    public class ProductViewModel : ViewModelBase
    {
        #region Fields

        private string name;
        private string description;
        private int quantity;
        private decimal cost;

        #endregion

        #region Properties

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

        #endregion

        #region Constructor

        public ProductViewModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            Quantity = default(int);
            Cost = default(decimal);
            Commands = new Dictionary<string, ICommand>();

            RegisterCommands();
        }

        #endregion

        #region Methods

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
            if (!(parameter is Window window))
            {
                return;
            }

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
            if (!(parameter is Window window))
            {
                return;
            }

            DatabaseManager.UpdateProduct(ProductID, Name, Quantity, Cost, Description);
            window.DialogResult = true;
            window.Close();
        }

        #endregion
    }
}
