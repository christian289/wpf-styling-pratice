using System.Globalization;
using System.Windows.Data;

namespace SillySheep7.Wpf.UI.Controls;

/// <summary>
/// 인덱스와 파라미터 비교를 통해 Boolean을 반환하는 컨버터입니다.
/// Converter that returns Boolean by comparing index with parameter.
/// </summary>
public sealed class IndexToBoolConverter : IValueConverter
{
    public static readonly IndexToBoolConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int selectedIndex && parameter is string paramStr && int.TryParse(paramStr, out int targetIndex))
        {
            return selectedIndex == targetIndex;
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is true && parameter is string paramStr && int.TryParse(paramStr, out int targetIndex))
        {
            return targetIndex;
        }
        return Binding.DoNothing;
    }
}
