using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab01
{
    /// <summary>
    ///     Базовая ViewModel для реализации интерфейса INotifyPropertyChanged
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        ///     Событие, возникающее при изменении свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Обработчик события PropertyChanged
        /// </summary>
        /// <param name="propertyName">Имя свойства, значение которого изменилось</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}