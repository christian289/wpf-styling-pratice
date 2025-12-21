using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AverageElephant52.Wpf.UI.Converters;

/// <summary>
/// ActualWidth, ActualHeight를 Rect(0, 0, width, height)로 변환합니다.
/// Converts ActualWidth, ActualHeight to Rect(0, 0, width, height).
/// </summary>
public sealed class SizeToRectConverter : IMultiValueConverter
{
    public static readonly SizeToRectConverter Instance = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 2 ||
            values[0] is not double width ||
            values[1] is not double height)
        {
            return Rect.Empty;
        }

        return new Rect(0, 0, width, height);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
