using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Lab07.Commands;
using Lab07.Database;
using Lab07.Models;
using Lab07.Views;

namespace Lab07.ViewModels
{
    /// <summary>
    ///     Главная ViewModel приложения
    /// </summary>
    public class PharmacyViewModel : ViewModelBase
    {
        #region Properties

        // Коллекция товаров
        public ObservableCollection<Product> Products => GetAllProducts();
        // Команды
        public Dictionary<string, ICommand> Commands { get; set; }

        #endregion

        #region Constructor

        // Конструктор
        public PharmacyViewModel()
        {
            Commands = new Dictionary<string, ICommand>();

            RegisterCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Получить список товаров
        /// </summary>
        /// <returns>Обозреваемая коллекция всех товров в БД</returns>
        private ObservableCollection<Product> GetAllProducts()
        {
            return new ObservableCollection<Product>(DatabaseManager.GetProducts());
        }

        /// <summary>
        ///     Регистрация команд
        /// </summary>
        private void RegisterCommands()
        {
            Commands["AddProductCommand"] = new RelayCommand(OnAddProduct, CanAddProduct);
            Commands["UpdateProductCommand"] = new RelayCommand(OnUpdateProduct, CanUpdateProduct);
            Commands["DeleteProductCommand"] = new RelayCommand(OnDeleteProduct, CanDeleteProduct);
        }

        /// <summary>
        ///     Проверяет доступность выполнения команды "AddProductCommand"
        /// </summary>
        /// <param name="parameter">Параметр, переданный из View</param>
        /// <returns>true - если команда доступна для выполнения</returns>
        private bool CanAddProduct(object parameter)
        {
            // Команда доступна всегда
            return true;
        }

        /// <summary>
        ///     Обработчик команды "AddProductCommand"
        /// </summary>
        /// <param name="parameter">Параметр, переданный из View</param>
        private void OnAddProduct(object parameter)
        {
            // Создать окно добавления продукта
            var window = new AddProductView();
            window.ShowDialog();

            // Далее управление передается в ProductViewModel,
            // а по возвращении мы проверяем успешность выполнения
            if (window.DialogResult.Value)
            {
                // Если выполнение прошло гладко, обновляем Products
                OnPropertyChanged(nameof(Products));
            }
        }

        /// <summary>
        ///     Проверяет доступность выполнения команды "UpdateProductCommand"
        /// </summary>
        /// <param name="parameter">Параметр, переданный из View</param>
        /// <returns>true - если команда доступна для выполнения</returns>
        private bool CanUpdateProduct(object parameter)
        {
            // Команда доступна, если выделен конкретный продукт
            var product = parameter as Product;

            return !(product is null);
        }

        /// <summary>
        ///     Обработчик команды "UpdateProductCommand"
        /// </summary>
        /// <param name="parameter">Параметр, переданный из View</param>
        private void OnUpdateProduct(object parameter)
        {
            // Создаем окно обновления продукта
            var product = parameter as Product;
            var window = new UpdateProductView();

            // Инициализируем DataContext окна выделенным продуктом,
            // чтобы автоматически заполнились поля ввода
            window.DataContext = new ProductViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Cost = product.Cost
            };

            window.ShowDialog();

            // Далее управление передается в ProductViewModel,
            // а по возвращении мы проверяем успешность выполнения
            if (window.DialogResult.Value)
            {
                // Если выполнение прошло гладко, обновляем Products
                OnPropertyChanged(nameof(Products));
            }
        }

        /// <summary>
        ///     Проверяет доступность выполнения команды "DeleteProductCommand"
        /// </summary>
        /// <param name="parameter">Параметр, переданный из View</param>
        /// <returns>true - если команда доступна для выполнения</returns>
        private bool CanDeleteProduct(object parameter)
        {
            // Команда доступна, если выделен конкретный продукт
            var product = parameter as Product;

            return !(product is null);
        }

        /// <summary>
        ///     Обработчик команды "DeleteProductCommand"
        /// </summary>
        /// <param name="parameter">Параметр, переданный из View</param>
        private void OnDeleteProduct(object parameter)
        {
            // Если продукт существует, удаляем его из БД
            var product = parameter as Product;

            if (product != null)
            {
                DatabaseManager.DeleteProductById(product.ProductID);
            }

            // Обновляем Products
            OnPropertyChanged(nameof(Products));
        }

        #endregion
    }
}
