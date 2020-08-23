using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Lab03_2
{
    public class MainViewModel : BaseViewModel, IDataErrorInfo
    {
        private const string DATA_FILE = "data.txt";

        public ObservableCollection<string> Cities { get; set; }
        public ObservableCollection<string> Streets { get; set; }
        public ObservableCollection<string> Positions { get; set; }
        public ObservableCollection<Employee> Staff { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;

                name = value;
                OnPropertyChanged();
            }
        }

        private string surname;
        public string Surname 
        {
            get => surname;
            set
            {
                if (surname == value) return;

                surname = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get => city;
            set
            {
                if (city == value) return;

                city = value;
                OnPropertyChanged();
            }
        }

        private string street;
        public string Street
        {
            get => street;
            set
            {
                if (street == value) return;

                street = value;
                OnPropertyChanged();
            }
        }

        private string house;
        public string House
        {
            get => house;
            set
            {
                if (house == value) return;

                house = value;
                OnPropertyChanged();
            }
        }

        private string position;
        public string Position
        {
            get => position;
            set
            {
                if (position == value) return;

                position = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveEmployeeDetails { get; private set; }

        public MainViewModel()
        {
            Initialize();
            ReadData();
        }

        private void Initialize()
        {
            Cities = new ObservableCollection<string>()
            {
                "Minsk",
                "Grodno",
                "Gomel",
                "Brest",
                "Vitebsk",
                "Mogilev"
            };

            Streets = new ObservableCollection<string>()
            {
                "Leninskaya",
                "Pervomaiskaya",
                "Oktyabrskaya"
            };

            Positions = new ObservableCollection<string>()
            {
                "Developer",
                "Tester",
                "Manager",
                "Director"
            };

            Staff = new ObservableCollection<Employee>();

            SaveEmployeeDetails = new RelayCommand(OnSaveEmployeeDetails);
        }

        private void ReadData()
        {
            if (!File.Exists(DATA_FILE))
            {
                File.Create(DATA_FILE);

                return;
            }

            try
            {
                using (var reader = new StreamReader(DATA_FILE))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var employee = Employee.GetEmployeeFromString(line);
                        Staff.Add(employee);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void OnSaveEmployeeDetails(object parameter)
        {
            var buildString = $"{Name}:{Surname}:{City}:{Street}:{House}:{Position}";

            try
            {
                using (var writer = new StreamWriter(DATA_FILE, true))
                {
                    writer.WriteLine(buildString);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }

            var employee = Employee.GetEmployeeFromString(buildString);

            if (Staff.Any(item => item.Equals(employee)))
            {
                return;
            }

            Staff.Add(employee);

            if (!Cities.Contains(City))
            {
                Cities.Add(City);
            }

            if (!Streets.Contains(Street))
            {
                Streets.Add(Street);
            }

            if (!Positions.Contains(Position))
            {
                Positions.Add(Position);
            }
        }

        #region IDataErrorInfo Members

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name) || Name.Length < 3)
                        {
                            result = "Name cannot be empty or less than three characters.";
                        }

                        break;
                    case nameof(Surname):
                        if (string.IsNullOrEmpty(Surname) || Surname.Length < 3)
                        {
                            result = "Surname cannot be empty or less than three characters.";
                        }

                        break;
                    case nameof(City):
                        if (string.IsNullOrEmpty(City))
                        {
                            result = "City cannot be empty.";
                        }

                        break;
                    case nameof(Street):
                        if (string.IsNullOrEmpty(Street))
                        {
                            result = "Street cannot be empty.";
                        }

                        break;
                    case nameof(House):
                        if (string.IsNullOrEmpty(House))
                        {
                            result = "House cannot be empty.";
                        }
                        else if (!int.TryParse(House, out int number))
                        {
                            result = "Input integer number.";
                        }

                        break;
                    case nameof(Position):
                        if (string.IsNullOrEmpty(Position))
                        {
                            result = "Position cannot be empty.";
                        }

                        break;
                }

                return result;
            }
        }

        #endregion
    }
}
