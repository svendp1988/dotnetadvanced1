using System;
using System.Globalization;
using System.Windows.Data;
using ShoppingListApp.Domain;

namespace ShoppingListApp.Presentation.Converters;

public class ShopConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Shop shop = value as Shop;
        return string.IsNullOrEmpty(shop?.Name) ? "???" : shop.Name;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var str = value as string;
        return new Shop()
        {
            Name = "???".Equals(str) ? null : str
        };
    }
}