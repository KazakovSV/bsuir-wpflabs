using System;
using System.Windows.Input;

namespace Lab07.Commands
{
    /// <summary>
    ///     Класс, реализующий интерфейс ICommand для работы с командами
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> onExecute;
        private readonly EventHandler requerySuggested;

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
            onExecute = execute;
            this.canExecute = canExecute;

            requerySuggested = (o, e) => Invalidate();
            CommandManager.RequerySuggested += requerySuggested;
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
        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute.Invoke(parameter);

        /// <summary>
        ///     Метод, вызывающийся при выполнении команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter) => onExecute?.Invoke(parameter);
    }
}
