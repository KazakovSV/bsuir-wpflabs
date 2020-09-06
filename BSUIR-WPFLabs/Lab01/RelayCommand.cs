using System;
using System.Windows.Input;

namespace Lab01
{
    /// <summary>
    ///     Класс, реализующий интерфейс ICommand для работы с командами
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _onExecute;
        private readonly EventHandler _requerySuggested;

        /// <summary>
        ///     Событие, возникающее при измении состояния команды
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     Конструктор команды
        /// </summary>
        /// <param name="execute">Метод, вызывающийся при выполнении команды</param>
        /// <param name="canExecute">Метод, определяющий возможность выполнения команды</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _onExecute = execute;
            _canExecute = canExecute;

            _requerySuggested = (o, e) => Invalidate();
            CommandManager.RequerySuggested += _requerySuggested;
        }

        /// <summary>
        ///     Обработчик события RequerySuggested, которое происходит,
        ///     когда CommandManager определяет условие способное изменить
        ///     возможность выполнения команды
        /// </summary>
        public void Invalidate() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        ///     Метод, определяющий возможность выполнения команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>true - если команда может быть выполнена</returns>
        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute.Invoke(parameter);

        /// <summary>
        ///     Метод, вызывающийся при выполнении команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter) => _onExecute?.Invoke(parameter);
    }
}
