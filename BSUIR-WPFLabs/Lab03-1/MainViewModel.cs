using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Lab03_1
{
    public class MainViewModel : IDataErrorInfo
    {
        public double XStart { get; set; }

        public double XStop { get; set; }

        public double Step { get; set; }

        public int N { get; set; }

        public ObservableCollection<string> SResults { get; set; }

        public ObservableCollection<string> YResults { get; set; }

        public ICommand CalculateCommand { get; private set; }

        public MainViewModel()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            XStart = 0;
            XStop = 0;
            Step = 1;
            N = 5;
            SResults = new ObservableCollection<string>();
            YResults = new ObservableCollection<string>();
            CalculateCommand = new RelayCommand(Calculate);
        }

        private void Calculate(object parameters)
        {
            ClearResults();

            for (double x = XStart; x <= XStop; x += Step)
            {
                SResults.Add(FunctionS(x, N).ToString());
                YResults.Add(FunctionY(x).ToString());
            }
        }

        private void ClearResults()
        {
            SResults.Clear();
            YResults.Clear();
        }

        private double FunctionS(double x, int n)
        {
            double result = 0;

            for (double k = 0; k <= n; k++)
            {
                result += Math.Pow(-1, k) * Math.Pow(x, 2 * k + 1) / Factorial((int)(2 * k + 1));
            }

            return result;
        }

        private double FunctionY(double x)
        {
            return Math.Sin(x);
        }

        private int Factorial(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        #region IDataErrorInfo Members

        public string Error => null;

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case nameof(Step):

                        if (Step == 0)
                        {
                            result = "The step cannot be zero";
                        }

                        break;
                    case nameof(N):

                        if (N < 5)
                        {
                            result = "The value must be greater than or equal to 5";
                        }

                        break;
                }

                return result;
            }
        }

        #endregion
    }
}
