using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;

namespace TinyTiger4.Avalonia.Lib.Controls;

/// <summary>
/// 버블 효과가 있는 커스텀 RadioButton 컨트롤
/// Custom RadioButton control with bubble effect
/// </summary>
public sealed class TinyTiger4RadioButton : TemplatedControl
{
    /// <summary>
    /// 라디오 버튼 선택 여부
    /// Whether the radio button is checked
    /// </summary>
    public static readonly StyledProperty<bool> IsCheckedProperty =
        AvaloniaProperty.Register<TinyTiger4RadioButton, bool>(nameof(IsChecked));

    /// <summary>
    /// 라디오 버튼 그룹 이름
    /// Radio button group name
    /// </summary>
    public static readonly StyledProperty<string?> GroupNameProperty =
        AvaloniaProperty.Register<TinyTiger4RadioButton, string?>(nameof(GroupName));

    /// <summary>
    /// 라벨 텍스트
    /// Label text
    /// </summary>
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<TinyTiger4RadioButton, string?>(nameof(Text));

    public bool IsChecked
    {
        get => GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public string? GroupName
    {
        get => GetValue(GroupNameProperty);
        set => SetValue(GroupNameProperty, value);
    }

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsCheckedProperty)
        {
            var isChecked = change.GetNewValue<bool>();
            UpdatePseudoClasses(isChecked);

            if (isChecked)
            {
                UncheckOthersInGroup();
            }
        }
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdatePseudoClasses(IsChecked);
    }

    private void UpdatePseudoClasses(bool isChecked)
    {
        PseudoClasses.Set(":checked", isChecked);
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

        foreach (var sibling in Parent.GetLogicalChildren())
        {
            if (sibling is TinyTiger4RadioButton radio &&
                radio != this &&
                radio.GroupName == GroupName)
            {
                radio.IsChecked = false;
            }
        }
    }
}
