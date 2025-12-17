using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;

namespace GoodQuail97.Avalonia.Lib.Controls;

/// <summary>
/// Neon Glow 효과가 있는 RadioButton 커스텀 컨트롤
/// A custom RadioButton control with neon glow effect
/// </summary>
public sealed class NeonRadioButton : TemplatedControl
{
    /// <summary>
    /// Identifies the IsChecked dependency property.
    /// </summary>
    public static readonly StyledProperty<bool> IsCheckedProperty =
        AvaloniaProperty.Register<NeonRadioButton, bool>(nameof(IsChecked));

    /// <summary>
    /// Identifies the GroupName dependency property.
    /// </summary>
    public static readonly StyledProperty<string?> GroupNameProperty =
        AvaloniaProperty.Register<NeonRadioButton, string?>(nameof(GroupName));

    /// <summary>
    /// 라디오 버튼의 선택 여부를 가져오거나 설정합니다.
    /// Gets or sets whether the radio button is checked.
    /// </summary>
    public bool IsChecked
    {
        get => GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    /// <summary>
    /// 라디오 버튼 그룹 이름을 가져오거나 설정합니다.
    /// Gets or sets the group name for the radio button.
    /// </summary>
    public string? GroupName
    {
        get => GetValue(GroupNameProperty);
        set => SetValue(GroupNameProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsCheckedProperty && change.NewValue is true)
        {
            UncheckOthersInGroup();
        }
    }

    protected override void OnPointerPressed(global::Avalonia.Input.PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        IsChecked = true;
    }

    private void UncheckOthersInGroup()
    {
        if (string.IsNullOrEmpty(GroupName) || Parent is null)
            return;

        foreach (var child in Parent.GetLogicalChildren())
        {
            if (child is NeonRadioButton other && other != this && other.GroupName == GroupName)
            {
                other.IsChecked = false;
            }
        }
    }
}
