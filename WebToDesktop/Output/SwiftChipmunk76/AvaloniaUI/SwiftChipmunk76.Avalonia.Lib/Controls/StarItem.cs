using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.VisualTree;

namespace SwiftChipmunk76.Avalonia.Lib.Controls;

/// <summary>
/// 개별 별 아이템 컨트롤. StarRating 내부에서 사용됩니다.
/// Individual star item control. Used internally by StarRating.
/// </summary>
public sealed class StarItem : TemplatedControl
{
    /// <summary>
    /// 이 별의 인덱스 (1-based).
    /// Index of this star (1-based).
    /// </summary>
    public static readonly StyledProperty<int> StarIndexProperty =
        AvaloniaProperty.Register<StarItem, int>(nameof(StarIndex), defaultValue: 1);

    /// <summary>
    /// 이 별이 활성화(선택/채워짐) 상태인지 여부.
    /// Whether this star is active (selected/filled).
    /// </summary>
    public static readonly StyledProperty<bool> IsActiveProperty =
        AvaloniaProperty.Register<StarItem, bool>(nameof(IsActive), defaultValue: false);

    /// <summary>
    /// 이 별이 호버 상태인지 여부.
    /// Whether this star is being hovered.
    /// </summary>
    public static readonly StyledProperty<bool> IsHoveredProperty =
        AvaloniaProperty.Register<StarItem, bool>(nameof(IsHovered), defaultValue: false);

    public int StarIndex
    {
        get => GetValue(StarIndexProperty);
        set => SetValue(StarIndexProperty, value);
    }

    public bool IsActive
    {
        get => GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    public bool IsHovered
    {
        get => GetValue(IsHoveredProperty);
        set => SetValue(IsHoveredProperty, value);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        if (this.FindAncestorOfType<StarRating>() is { IsReadOnly: false } parent)
        {
            parent.Value = StarIndex;
        }
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);

        if (this.FindAncestorOfType<StarRating>() is { IsReadOnly: false } parent)
        {
            parent.HoverValue = StarIndex;
        }
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);

        if (this.FindAncestorOfType<StarRating>() is { IsReadOnly: false } parent)
        {
            parent.HoverValue = 0;
        }
    }
}
