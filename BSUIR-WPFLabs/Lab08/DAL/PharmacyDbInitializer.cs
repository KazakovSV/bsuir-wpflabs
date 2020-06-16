using System.Data.Entity;

using Lab08.Model;

namespace Lab08.DAL
{
    /// <summary>
    ///     Инициализатор базы данных
    /// </summary>
    public class PharmacyDbInitializer : DropCreateDatabaseIfModelChanges<PharmacyContext>
    {
        protected override void Seed(PharmacyContext context)
        {
            context.Products.AddRange(new Product[]
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
                }
            });

            context.SaveChanges();
        }
    }
}
