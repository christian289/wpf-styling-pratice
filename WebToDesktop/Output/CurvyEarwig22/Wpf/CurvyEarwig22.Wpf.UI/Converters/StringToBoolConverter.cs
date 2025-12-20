using System.Globalization;
using System.Windows.Data;

namespace CurvyEarwig22.Wpf.UI.Converters;

/// <summary>
/// 문자열이 비어있지 않으면 true를 반환하는 컨버터.
/// Converter that returns true if string is not empty.
/// </summary>
public sealed class StringToBoolConverter : IValueConverter
{
    public static readonly StringToBoolConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !string.IsNullOrEmpty(value as string);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
