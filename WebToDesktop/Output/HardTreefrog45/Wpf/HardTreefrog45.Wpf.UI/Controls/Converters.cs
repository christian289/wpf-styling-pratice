using System.Globalization;
using System.Windows.Data;

namespace HardTreefrog45.Wpf.UI.Controls;

/// <summary>
/// Day (1-31) to ComboBox index (0-30) converter
/// 일(1-31)을 ComboBox 인덱스(0-30)로 변환
/// </summary>
public sealed class DayIndexConverter : IValueConverter
{
    public static readonly DayIndexConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int day)
        {
            return day - 1;
        }
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int index)
        {
            return index + 1;
        }
        return 1;
    }
}

/// <summary>
/// Month (1-12) to ComboBox index (0-11) converter
/// 월(1-12)을 ComboBox 인덱스(0-11)로 변환
/// </summary>
public sealed class MonthIndexConverter : IValueConverter
{
    public static readonly MonthIndexConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int month)
        {
            return month - 1;
        }
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int index)
        {
            return index + 1;
        }
        return 1;
    }
}

/// <summary>
/// Year (1990-2023) to ComboBox index (0-33) converter
/// 연도(1990-2023)를 ComboBox 인덱스(0-33)로 변환
/// </summary>
public sealed class YearIndexConverter : IValueConverter
{
    private const int BaseYear = 1990;

    public static readonly YearIndexConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int year)
        {
            return year - BaseYear;
        }
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int index)
        {
            return index + BaseYear;
        }
        return BaseYear;
    }
}
