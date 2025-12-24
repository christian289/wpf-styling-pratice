using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RottenBullfrog69.Wpf.UI.Controls;

/// <summary>
/// ActualWidth와 ActualHeight를 Rect로 변환하는 Converter
/// Converts ActualWidth and ActualHeight to Rect
/// </summary>
public sealed class SizeToRectConverter : IMultiValueConverter
{
    public static readonly SizeToRectConverter Instance = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length >= 2 &&
            values[0] is double width &&
            values[1] is double height)
        {
            return new Rect(0, 0, width, height);
        }

        return new Rect(0, 0, 0, 0);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

/// <summary>
/// null 또는 빈 문자열이면 False, 그 외에는 True를 반환하는 Converter
/// Returns False for null or empty string, True otherwise
/// </summary>
public sealed class NullOrEmptyToFalseConverter : IValueConverter
{
    public static readonly NullOrEmptyToFalseConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !string.IsNullOrEmpty(value as string);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
