using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BadSquid34.Wpf.UI.Controls;

/// <summary>
/// Error alert card control with icon, message, and close button.
/// 아이콘, 메시지, 닫기 버튼이 있는 에러 알림 카드 컨트롤.
/// </summary>
public sealed class BadSquid34 : ContentControl
{
    /// <summary>
    /// Identifies the <see cref="Message"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(BadSquid34),
            new PropertyMetadata("Error message"));

    /// <summary>
    /// Identifies the <see cref="CloseCommand"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty CloseCommandProperty =
        DependencyProperty.Register(
            nameof(CloseCommand),
            typeof(ICommand),
            typeof(BadSquid34),
            new PropertyMetadata(null));

    /// <summary>
    /// Identifies the <see cref="CloseCommandParameter"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty CloseCommandParameterProperty =
        DependencyProperty.Register(
            nameof(CloseCommandParameter),
            typeof(object),
            typeof(BadSquid34),
            new PropertyMetadata(null));

    static BadSquid34()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BadSquid34),
            new FrameworkPropertyMetadata(typeof(BadSquid34)));
    }

    /// <summary>
    /// Gets or sets the error message text.
    /// 에러 메시지 텍스트를 가져오거나 설정합니다.
    /// </summary>
    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// Gets or sets the command executed when close button is clicked.
    /// 닫기 버튼 클릭 시 실행되는 커맨드를 가져오거나 설정합니다.
    /// </summary>
    public ICommand? CloseCommand
    {
        get => (ICommand?)GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }

    /// <summary>
    /// Gets or sets the parameter for the close command.
    /// 닫기 커맨드의 파라미터를 가져오거나 설정합니다.
    /// </summary>
    public object? CloseCommandParameter
    {
        get => GetValue(CloseCommandParameterProperty);
        set => SetValue(CloseCommandParameterProperty, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_CloseButton") is UIElement closeButton)
        {
            closeButton.MouseLeftButtonUp += OnCloseButtonClick;
        }
    }

    private void OnCloseButtonClick(object sender, MouseButtonEventArgs e)
    {
        if (CloseCommand?.CanExecute(CloseCommandParameter) == true)
        {
            CloseCommand.Execute(CloseCommandParameter);
        }
    }
}
