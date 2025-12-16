using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SmoothDuck62.Avalonia.Lib.Controls;

/// <summary>
/// 체크 시 45도 회전하여 체크마크 모양을 표시하는 커스텀 체크박스
/// A custom checkbox that displays a checkmark shape by rotating 45 degrees when checked
/// </summary>
public sealed class SmoothDuck62CheckBox : TemplatedControl
{
    public static readonly StyledProperty<bool> IsCheckedProperty =
        AvaloniaProperty.Register<SmoothDuck62CheckBox, bool>(nameof(IsChecked), defaultValue: false);

    public bool IsChecked
    {
        get => GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsCheckedProperty)
        {
            PseudoClasses.Set(":checked", IsChecked);
        }
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        PseudoClasses.Set(":checked", IsChecked);
    }

    protected override void OnPointerPressed(global::Avalonia.Input.PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        IsChecked = !IsChecked;
        e.Handled = true;
    }
}
