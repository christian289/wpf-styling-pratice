using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace RottenBullfrog69.Avalonia.Lib.Controls;

/// <summary>
/// ChatGPT 스타일의 채팅 UI 컨트롤
/// ChatGPT-style chat UI control
/// </summary>
public sealed class ChatControl : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<ChatControl, string>(nameof(Title), "Chat");

    public static readonly StyledProperty<string> PlaceholderTextProperty =
        AvaloniaProperty.Register<ChatControl, string>(nameof(PlaceholderText), "Send a message.");

    public static readonly StyledProperty<string> MessageTextProperty =
        AvaloniaProperty.Register<ChatControl, string>(nameof(MessageText), string.Empty);

    public static readonly StyledProperty<ICommand?> SendCommandProperty =
        AvaloniaProperty.Register<ChatControl, ICommand?>(nameof(SendCommand));

    public static readonly StyledProperty<ICommand?> CloseCommandProperty =
        AvaloniaProperty.Register<ChatControl, ICommand?>(nameof(CloseCommand));

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string PlaceholderText
    {
        get => GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    public string MessageText
    {
        get => GetValue(MessageTextProperty);
        set => SetValue(MessageTextProperty, value);
    }

    public ICommand? SendCommand
    {
        get => GetValue(SendCommandProperty);
        set => SetValue(SendCommandProperty, value);
    }

    public ICommand? CloseCommand
    {
        get => GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }
}
