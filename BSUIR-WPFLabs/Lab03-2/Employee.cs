using System;

namespace Lab03_2
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Position { get; set; }

        private Employee()
        {

        }

        public static Employee GetEmployeeFromString(string data)
        {
            var fields = data.Split(':');

            if (fields.Length != 6)
            {
                throw new ArgumentException($"Bad format");
            }

            var employee = new Employee
            {
                Name = fields[0],
                Surname = fields[1],
                City = fields[2],
                Street = fields[3],
                House = fields[4],
                Position = fields[5]
            };

            return employee;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}: {Position}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Employee employee))
            {
                return false;
            }

            return Name == employee.Name
                && Surname == employee.Surname
                && City == employee.City
                && Street == employee.Street
                && House == employee.House
                && Position == employee.Position;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
