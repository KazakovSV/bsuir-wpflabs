namespace Lab07.Models
{
    /// <summary>
    ///     Главная модель, представляет собой один конкретный продукт
    /// </summary>
    /// <remarks>
    ///     Никакой логики, просто объект хранящий данные о продукте
    /// </remarks>
    public class Product
    {
        #region Fileds

        // Идентификатор продукта в базе данных
        public int ProductID { get; set; }
        // Имя продукта
        public string Name { get; set; }
        // Описание продукта (может быть null)
        public string Description { get; set; }
        // Количество на складе
        public int Quantity { get; set; }
        // Стоимость продукта
        public decimal Cost { get; set; }

        #endregion
    }
}
