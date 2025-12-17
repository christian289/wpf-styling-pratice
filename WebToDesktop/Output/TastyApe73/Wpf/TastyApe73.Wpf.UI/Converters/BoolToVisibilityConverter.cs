using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TastyApe73.Wpf.UI.Converters;

/// <summary>
/// Boolean을 Visibility로 변환하는 컨버터
/// Converter that converts Boolean to Visibility
/// </summary>
public sealed class BoolToVisibilityConverter : IValueConverter
{
    public static readonly BoolToVisibilityConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }
        return false;
    }
}
