using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SwiftChipmunk76.Avalonia.Lib.Controls;

/// <summary>
/// 별점 평가 컨트롤. 사용자가 1~5개의 별을 선택하여 평가를 입력할 수 있습니다.
/// Star rating control. Allows users to select 1-5 stars for rating input.
/// </summary>
public sealed class StarRating : TemplatedControl
{
    /// <summary>
    /// 현재 선택된 별점 값 (1~5). 0은 선택 안 됨.
    /// Current selected star rating value (1-5). 0 means not selected.
    /// </summary>
    public static readonly StyledProperty<int> ValueProperty =
        AvaloniaProperty.Register<StarRating, int>(nameof(Value), defaultValue: 0, coerce: CoerceValue);

    /// <summary>
    /// 최대 별 개수. 기본값 5.
    /// Maximum number of stars. Default is 5.
    /// </summary>
    public static readonly StyledProperty<int> MaxStarsProperty =
        AvaloniaProperty.Register<StarRating, int>(nameof(MaxStars), defaultValue: 5);

    /// <summary>
    /// 마우스가 올라간 별의 인덱스 (1-based). 0은 호버 없음.
    /// Index of the star being hovered (1-based). 0 means no hover.
    /// </summary>
    public static readonly StyledProperty<int> HoverValueProperty =
        AvaloniaProperty.Register<StarRating, int>(nameof(HoverValue), defaultValue: 0);

    /// <summary>
    /// 읽기 전용 모드 여부.
    /// Whether the control is in read-only mode.
    /// </summary>
    public static readonly StyledProperty<bool> IsReadOnlyProperty =
        AvaloniaProperty.Register<StarRating, bool>(nameof(IsReadOnly), defaultValue: false);

    public int Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int MaxStars
    {
        get => GetValue(MaxStarsProperty);
        set => SetValue(MaxStarsProperty, value);
    }

    public int HoverValue
    {
        get => GetValue(HoverValueProperty);
        set => SetValue(HoverValueProperty, value);
    }

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    private static int CoerceValue(AvaloniaObject obj, int value)
    {
        if (obj is StarRating starRating)
        {
            return Math.Clamp(value, 0, starRating.MaxStars);
        }
        return Math.Max(0, value);
    }
}
