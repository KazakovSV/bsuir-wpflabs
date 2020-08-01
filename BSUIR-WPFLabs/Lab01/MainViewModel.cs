using System.Windows.Input;

namespace Lab01
{
    /// <summary>
    ///     Главная ViewModel приложения, которая содержит свойства для привязки данных во View
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private Calculator calculator;
        private string result;

        public string Result
        {
            get => result;
            set
            {
                result = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Свойство для привязки команды во View
        /// </summary>
        public ICommand ButtonClickCommand { get; private set; }

        public MainViewModel()
        {
            calculator = new Calculator(new ReadOperandA());
            Result = "0";
            ButtonClickCommand = new RelayCommand(ButtonOnClick);
        }

        /// <summary>
        ///     Обработчик команды нажатия на кнопке
        /// </summary>
        /// <param name="param">Параметр, переданный кнопкой при нажатии</param>
        private void ButtonOnClick(object param)
        {
            if (param == null)
            {
                return;
            }

            calculator.Read(param.ToString());
            Result = calculator.Result;
        }
    }
}
