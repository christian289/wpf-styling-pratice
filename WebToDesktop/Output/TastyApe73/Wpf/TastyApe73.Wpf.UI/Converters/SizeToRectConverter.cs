using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TastyApe73.Wpf.UI.Converters;

/// <summary>
/// ActualWidth, ActualHeight를 Rect로 변환하는 컨버터
/// Converter that converts ActualWidth, ActualHeight to Rect
/// </summary>
public sealed class SizeToRectConverter : IMultiValueConverter
{
    public static readonly SizeToRectConverter Instance = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length >= 2 &&
            values[0] is double width &&
            values[1] is double height &&
            !double.IsNaN(width) &&
            !double.IsNaN(height))
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
