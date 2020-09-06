using System;
using System.Windows.Input;

using Lab01;

namespace Lab05
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            RegisterCommands();
        }

        #region Commands

        #region Properties

        public ICommand SaveCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        #endregion // Properties

        #region RgisterCommands

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
            OpenCommand = new RelayCommand(OnOpen, CanOpen);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            AddCommand = new RelayCommand(OnAdd, CanAdd);
        }

        #endregion // RgisterCommands

        #region Handlers

        private bool CanSave(object parameter)
        {
            return true;
        }

        private void OnSave(object parameter)
        {
        }

        private bool CanOpen(object parameter)
        {
            return true;
        }

        private void OnOpen(object parameter)
        {
        }

        private bool CanEdit(object parameter)
        {
            return true;
        }

        private void OnEdit(object parameter)
        {
        }

        private bool CanAdd(object parameter)
        {
            return true;
        }

        private void OnAdd(object parameter)
        {
        }

        #endregion // Handlers

        #endregion // Commands
    }
}
