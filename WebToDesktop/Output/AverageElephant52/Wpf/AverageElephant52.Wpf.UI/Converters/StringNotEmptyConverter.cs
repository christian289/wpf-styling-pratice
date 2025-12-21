using System.Globalization;
using System.Windows.Data;

namespace AverageElephant52.Wpf.UI.Converters;

/// <summary>
/// 문자열이 비어있지 않은지 확인합니다.
/// Checks if a string is not empty.
/// </summary>
public sealed class StringNotEmptyConverter : IValueConverter
{
    public static readonly StringNotEmptyConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is string str && !string.IsNullOrEmpty(str);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
