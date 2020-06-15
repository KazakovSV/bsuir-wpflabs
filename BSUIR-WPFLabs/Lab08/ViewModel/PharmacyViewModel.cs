using Lab08.Model;
using System.Collections.ObjectModel;

namespace Lab08.ViewModel
{
    /// <summary>
    ///     Главная ViewModel приложения
    /// </summary>
    public class PharmacyViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public PharmacyViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Name = "Анальгин",
                    Description = "Обезболивающее средство",
                    Quantity = 25,
                    Cost = 10M
                },

                new Product
                {
                    Name = "Парацетамол",
                    Description = "Жаропонижающее средство, очень жаропонижающее, прям огонь",
                    Quantity = 25,
                    Cost = 10M
                },

                new Product
                {
                    Name = "Касторка",
                    Description = "Слабительное средство",
                    Quantity = 25,
                    Cost = 10M
                },
            };
        }
    }
}
