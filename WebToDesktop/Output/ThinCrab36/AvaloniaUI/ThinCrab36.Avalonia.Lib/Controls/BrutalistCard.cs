using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ThinCrab36.Avalonia.Lib.Controls;

/// <summary>
/// Brutalist 스타일의 경고/알림 카드 컨트롤
/// A brutalist-style warning/notification card control
/// </summary>
public sealed class BrutalistCard : TemplatedControl
{
    public static readonly StyledProperty<object?> IconProperty =
        AvaloniaProperty.Register<BrutalistCard, object?>(nameof(Icon));

    public static readonly StyledProperty<string> AlertTextProperty =
        AvaloniaProperty.Register<BrutalistCard, string>(nameof(AlertText), "Warning");

    public static readonly StyledProperty<string> MessageProperty =
        AvaloniaProperty.Register<BrutalistCard, string>(nameof(Message), string.Empty);

    public static readonly StyledProperty<string> PrimaryButtonTextProperty =
        AvaloniaProperty.Register<BrutalistCard, string>(nameof(PrimaryButtonText), "Okay");

    public static readonly StyledProperty<string> SecondaryButtonTextProperty =
        AvaloniaProperty.Register<BrutalistCard, string>(nameof(SecondaryButtonText), "Mark as Read");

    public object? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string AlertText
    {
        get => GetValue(AlertTextProperty);
        set => SetValue(AlertTextProperty, value);
    }

    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public string PrimaryButtonText
    {
        get => GetValue(PrimaryButtonTextProperty);
        set => SetValue(PrimaryButtonTextProperty, value);
    }

    public string SecondaryButtonText
    {
        get => GetValue(SecondaryButtonTextProperty);
        set => SetValue(SecondaryButtonTextProperty, value);
    }
}
