using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RottenBullfrog69.Wpf.UI.Controls;

/// <summary>
/// ChatGPT 스타일의 채팅 UI 컨트롤
/// ChatGPT-style chat UI control
/// </summary>
public sealed class RottenBullfrog69 : Control
{
    static RottenBullfrog69()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RottenBullfrog69),
            new FrameworkPropertyMetadata(typeof(RottenBullfrog69)));
    }

    /// <summary>
    /// 제목 텍스트
    /// Title text
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(RottenBullfrog69),
            new PropertyMetadata("Chat"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 입력 필드 플레이스홀더 텍스트
    /// Input field placeholder text
    /// </summary>
    public static readonly DependencyProperty PlaceholderTextProperty =
        DependencyProperty.Register(
            nameof(PlaceholderText),
            typeof(string),
            typeof(RottenBullfrog69),
            new PropertyMetadata("Send a message."));

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    /// <summary>
    /// 입력 텍스트
    /// Input text
    /// </summary>
    public static readonly DependencyProperty InputTextProperty =
        DependencyProperty.Register(
            nameof(InputText),
            typeof(string),
            typeof(RottenBullfrog69),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string InputText
    {
        get => (string)GetValue(InputTextProperty);
        set => SetValue(InputTextProperty, value);
    }

    /// <summary>
    /// 닫기 버튼 클릭 시 발생하는 이벤트
    /// Event raised when the close button is clicked
    /// </summary>
    public static readonly RoutedEvent CloseClickedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(CloseClicked),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RottenBullfrog69));

    public event RoutedEventHandler CloseClicked
    {
        add => AddHandler(CloseClickedEvent, value);
        remove => RemoveHandler(CloseClickedEvent, value);
    }

    /// <summary>
    /// 전송 버튼 클릭 시 발생하는 이벤트
    /// Event raised when the send button is clicked
    /// </summary>
    public static readonly RoutedEvent SendClickedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(SendClicked),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RottenBullfrog69));

    public event RoutedEventHandler SendClicked
    {
        add => AddHandler(SendClickedEvent, value);
        remove => RemoveHandler(SendClickedEvent, value);
    }

    /// <summary>
    /// 닫기 버튼 Command
    /// Close button Command
    /// </summary>
    public static readonly DependencyProperty CloseCommandProperty =
        DependencyProperty.Register(
            nameof(CloseCommand),
            typeof(ICommand),
            typeof(RottenBullfrog69),
            new PropertyMetadata(null));

    public ICommand? CloseCommand
    {
        get => (ICommand?)GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }

    /// <summary>
    /// 전송 버튼 Command
    /// Send button Command
    /// </summary>
    public static readonly DependencyProperty SendCommandProperty =
        DependencyProperty.Register(
            nameof(SendCommand),
            typeof(ICommand),
            typeof(RottenBullfrog69),
            new PropertyMetadata(null));

    public ICommand? SendCommand
    {
        get => (ICommand?)GetValue(SendCommandProperty);
        set => SetValue(SendCommandProperty, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_CloseButton") is FrameworkElement closeButton)
        {
            closeButton.MouseLeftButtonUp += (_, _) =>
            {
                RaiseEvent(new RoutedEventArgs(CloseClickedEvent));
                CloseCommand?.Execute(null);
            };
        }

        if (GetTemplateChild("PART_SendButton") is FrameworkElement sendButton)
        {
            sendButton.MouseLeftButtonUp += (_, _) =>
            {
                RaiseEvent(new RoutedEventArgs(SendClickedEvent));
                SendCommand?.Execute(InputText);
            };
        }
    }
}
