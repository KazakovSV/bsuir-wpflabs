using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab07.ViewModels
{
    /// <summary>
    ///     Базовая ViewModel для реализации INotifyPropertyChanged
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        ///     Событие, возникающее при изменении свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Обработчик события PropertyChanged
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
