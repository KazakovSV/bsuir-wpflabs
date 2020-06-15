using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab08.ViewModel
{
    /// <summary>
    ///     Базовая ViewModel
    /// </summary>
    /// <remarks>Реализует INotifyPropertyChanged</remarks>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Implementing INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
