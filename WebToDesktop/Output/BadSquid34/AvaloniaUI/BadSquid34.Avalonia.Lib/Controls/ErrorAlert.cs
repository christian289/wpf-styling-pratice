using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace BadSquid34.Avalonia.Lib.Controls;

/// <summary>
/// 에러 메시지를 표시하는 알림 카드 컨트롤
/// Error alert card control for displaying error messages
/// </summary>
public sealed class ErrorAlert : TemplatedControl
{
    /// <summary>
    /// 메시지 텍스트를 정의하는 속성
    /// Defines the message text property
    /// </summary>
    public static readonly StyledProperty<string> MessageProperty =
        AvaloniaProperty.Register<ErrorAlert, string>(nameof(Message), "Error message");

    /// <summary>
    /// 닫기 버튼 클릭 이벤트
    /// Close button click event
    /// </summary>
    public static readonly RoutedEvent<RoutedEventArgs> CloseClickedEvent =
        RoutedEvent.Register<ErrorAlert, RoutedEventArgs>(nameof(CloseClicked), RoutingStrategies.Bubble);

    /// <summary>
    /// 메시지 텍스트
    /// Message text
    /// </summary>
    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// 닫기 버튼 클릭 이벤트
    /// Close button click event
    /// </summary>
    public event EventHandler<RoutedEventArgs>? CloseClicked
    {
        add => AddHandler(CloseClickedEvent, value);
        remove => RemoveHandler(CloseClickedEvent, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var closeButton = e.NameScope.Find<Button>("PART_CloseButton");
        if (closeButton is not null)
        {
            closeButton.Click += OnCloseButtonClick;
        }
    }

    private void OnCloseButtonClick(object? sender, RoutedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(CloseClickedEvent, this));
    }
}
