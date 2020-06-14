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

        #endregion

        #region Properties

        public int Id
        {
            get;
            set;
        }

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

        #region Implementing INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
