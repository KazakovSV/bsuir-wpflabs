using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab08.Model
{
    /// <summary>
    ///     Главная модель
    /// </summary>
    /// <remarks>Реализует INotifyPropertyChanged для обновления во View</remarks>
    public class Product : INotifyPropertyChanged
    {
        #region Fields

        private string name;
        private string description;
        private int quantity;
        private decimal cost;

        #endregion // Fields

        #region Properties

        /// <summary>
        ///     Идентификатор продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Название продукта
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Описание продукта
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                description = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Количество на складе
        /// </summary>
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Стоимость единицы товара
        /// </summary>
        public decimal Cost
        {
            get => cost;
            set
            {
                cost = value;

                OnPropertyChanged();
            }
        }

        #endregion // Properties

        #region Implementing INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // Implementing INotifyPropertyChanged
    }
}
