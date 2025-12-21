using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SwiftChicken44.Avalonia.Lib.Controls;

/// <summary>
/// 유효성 검사 상태에 따라 시각적 피드백을 제공하는 텍스트 박스
/// A text box that provides visual feedback based on validation state
/// </summary>
public sealed class ValidationTextBox : TemplatedControl
{
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<ValidationTextBox, string?>(nameof(Text));

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<ValidationTextBox, string?>(nameof(Placeholder));

    public static readonly StyledProperty<bool> IsValidProperty =
        AvaloniaProperty.Register<ValidationTextBox, bool>(nameof(IsValid));

    public static readonly StyledProperty<bool> IsRequiredProperty =
        AvaloniaProperty.Register<ValidationTextBox, bool>(nameof(IsRequired));

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string? Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool IsValid
    {
        get => GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public bool IsRequired
    {
        get => GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == TextProperty || change.Property == IsRequiredProperty)
        {
            UpdateValidation();
        }
    }

    private void UpdateValidation()
    {
        if (IsRequired)
        {
            IsValid = !string.IsNullOrEmpty(Text);
        }
        else
        {
            IsValid = true;
        }

        UpdatePseudoClasses();
    }

    private void UpdatePseudoClasses()
    {
        PseudoClasses.Set(":valid", IsValid && !string.IsNullOrEmpty(Text));
        PseudoClasses.Set(":invalid", !IsValid && IsRequired);
        PseudoClasses.Set(":empty", string.IsNullOrEmpty(Text));
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdateValidation();
    }
}
