using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FreshFrog39.Wpf.UI.Controls;

/// <summary>
/// double 값을 왼쪽 Margin으로 변환하는 Converter
/// Converter that converts a double value to a left Margin
/// </summary>
public sealed class DoubleToLeftMarginConverter : IValueConverter
{
    public static readonly DoubleToLeftMarginConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double gap)
        {
            return new Thickness(gap, 0, 0, 0);
        }
        return new Thickness(0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
