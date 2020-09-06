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
            SaveCommand = new RelayCommand(OnEdit, CanEdit);
            AddCommand = new RelayCommand(OnEdit, CanEdit);
        }

        #endregion // RgisterCommands

        #region Handlers

        private bool CanSave(object parameter)
        {
            throw new NotImplementedException();
        }

        private void OnSave(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanOpen(object parameter)
        {
            throw new NotImplementedException();
        }

        private void OnOpen(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanEdit(object parameter)
        {
            throw new NotImplementedException();
        }

        private void OnEdit(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanAdd(object parameter)
        {
            throw new NotImplementedException();
        }

        private void OnAdd(object parameter)
        {
            throw new NotImplementedException();
        }

        #endregion // Handlers

        #endregion // Commands
    }
}
