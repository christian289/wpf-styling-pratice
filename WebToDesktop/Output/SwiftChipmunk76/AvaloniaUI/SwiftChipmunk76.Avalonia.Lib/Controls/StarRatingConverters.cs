using System.Globalization;
using Avalonia.Data.Converters;

namespace SwiftChipmunk76.Avalonia.Lib.Controls;

/// <summary>
/// StarRating 컨트롤에서 사용하는 컨버터들.
/// Converters used by StarRating control.
/// </summary>
public static class StarRatingConverters
{
    /// <summary>
    /// 별이 활성화(선택됨) 상태인지 확인하는 컨버터.
    /// Converter to check if a star is in active (selected) state.
    /// </summary>
    public static readonly IValueConverter IsStarActive = new StarActiveConverter();

    /// <summary>
    /// 별이 호버 상태인지 확인하는 컨버터.
    /// Converter to check if a star is in hovered state.
    /// </summary>
    public static readonly IValueConverter IsStarHovered = new StarHoveredConverter();

    private sealed class StarActiveConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int currentValue && parameter is string paramStr && int.TryParse(paramStr, out int starIndex))
            {
                // 현재 선택된 값(Value) 이하의 별들은 모두 활성화
                // Stars with index <= current Value are all active
                return starIndex <= currentValue;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    private sealed class StarHoveredConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int hoverValue && parameter is string paramStr && int.TryParse(paramStr, out int starIndex))
            {
                // 호버 값이 0보다 크고, 현재 별의 인덱스가 호버 값 이하일 때 호버 상태
                // Star is hovered when HoverValue > 0 and starIndex <= HoverValue
                return hoverValue > 0 && starIndex <= hoverValue;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
