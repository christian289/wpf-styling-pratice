using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CurvyEarwig22.Wpf.UI.Converters;

/// <summary>
/// ActualWidth와 ActualHeight를 Rect로 변환하는 컨버터.
/// Converter that converts ActualWidth and ActualHeight to Rect.
/// </summary>
public sealed class SizeToRectConverter : IMultiValueConverter
{
    public static readonly SizeToRectConverter Instance = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length >= 2 && values[0] is double width && values[1] is double height)
        {
            return new Rect(0, 0, width, height);
        }
        return Rect.Empty;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
