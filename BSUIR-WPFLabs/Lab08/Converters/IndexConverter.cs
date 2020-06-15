using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab08.Converters
{
    /// <summary>
    ///     Конвертирует DataGridRow в Index
    /// </summary>
    [ValueConversion(typeof(DataGridRow), typeof(string))]
    public class IndexConverter : IValueConverter
    {
        // Возвращает строковое представление индекса DataGridRow
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DataGridRow row))
            {
                return null;
            }

            if (!(ItemsControl.ItemsControlFromItemContainer(row) is DataGrid grid))
            {
                return null;
            }

            // Добавляем единицу, так как хотим нумеровать с 1
            var index = grid.ItemContainerGenerator.IndexFromContainer(row) + 1;

            return index.ToString();
        }

        // Этот метод не понадобиться
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
