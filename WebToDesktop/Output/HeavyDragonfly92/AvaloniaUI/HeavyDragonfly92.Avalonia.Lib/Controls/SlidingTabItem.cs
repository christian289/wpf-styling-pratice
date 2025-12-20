using Avalonia;
using Avalonia.Controls.Primitives;

namespace HeavyDragonfly92.Avalonia.Lib.Controls;

/// <summary>
/// 슬라이딩 탭 컨트롤의 개별 탭 아이템
/// Individual tab item for the sliding tab control
/// </summary>
public sealed class SlidingTabItem : TemplatedControl
{
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<SlidingTabItem, string?>(nameof(Text));

    public static readonly StyledProperty<int> NotificationCountProperty =
        AvaloniaProperty.Register<SlidingTabItem, int>(nameof(NotificationCount));

    public static readonly StyledProperty<bool> IsSelectedProperty =
        AvaloniaProperty.Register<SlidingTabItem, bool>(nameof(IsSelected));

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public int NotificationCount
    {
        get => GetValue(NotificationCountProperty);
        set => SetValue(NotificationCountProperty, value);
    }

    public bool IsSelected
    {
        get => GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsSelectedProperty)
        {
            UpdatePseudoClasses(change.GetNewValue<bool>());
        }
    }

    private void UpdatePseudoClasses(bool isSelected)
    {
        if (isSelected)
        {
            Classes.Add(":selected");
        }
        else
        {
            Classes.Remove(":selected");
        }
    }
}
