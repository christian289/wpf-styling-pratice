using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ThinCrab36.Wpf.UI.Controls;

/// <summary>
/// Brutalist 스타일의 경고 카드 컨트롤
/// Brutalist-style warning card control
/// </summary>
public sealed class ThinCrab36 : Control
{
    static ThinCrab36()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ThinCrab36),
            new FrameworkPropertyMetadata(typeof(ThinCrab36)));
    }

    #region Title Property

    /// <summary>
    /// 카드 헤더 제목 (기본값: "Warning")
    /// Card header title (default: "Warning")
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ThinCrab36),
            new PropertyMetadata("Warning"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region Message Property

    /// <summary>
    /// 카드 본문 메시지
    /// Card body message
    /// </summary>
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(ThinCrab36),
            new PropertyMetadata("This is a brutalist card with a very angry button. Proceed with caution, you've been warned."));

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    #endregion

    #region PrimaryButtonText Property

    /// <summary>
    /// 기본 버튼 텍스트 (검은색 배경)
    /// Primary button text (black background)
    /// </summary>
    public static readonly DependencyProperty PrimaryButtonTextProperty =
        DependencyProperty.Register(
            nameof(PrimaryButtonText),
            typeof(string),
            typeof(ThinCrab36),
            new PropertyMetadata("Okay"));

    public string PrimaryButtonText
    {
        get => (string)GetValue(PrimaryButtonTextProperty);
        set => SetValue(PrimaryButtonTextProperty, value);
    }

    #endregion

    #region SecondaryButtonText Property

    /// <summary>
    /// 보조 버튼 텍스트 (흰색 배경)
    /// Secondary button text (white background)
    /// </summary>
    public static readonly DependencyProperty SecondaryButtonTextProperty =
        DependencyProperty.Register(
            nameof(SecondaryButtonText),
            typeof(string),
            typeof(ThinCrab36),
            new PropertyMetadata("Mark as Read"));

    public string SecondaryButtonText
    {
        get => (string)GetValue(SecondaryButtonTextProperty);
        set => SetValue(SecondaryButtonTextProperty, value);
    }

    #endregion

    #region IconData Property

    /// <summary>
    /// 아이콘 SVG Path 데이터
    /// Icon SVG Path data
    /// </summary>
    public static readonly DependencyProperty IconDataProperty =
        DependencyProperty.Register(
            nameof(IconData),
            typeof(string),
            typeof(ThinCrab36),
            new PropertyMetadata("M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm1 15h-2v-2h2v2zm0-4h-2V7h2v6z"));

    public string IconData
    {
        get => (string)GetValue(IconDataProperty);
        set => SetValue(IconDataProperty, value);
    }

    #endregion

    #region Commands

    /// <summary>
    /// 기본 버튼 클릭 명령
    /// Primary button click command
    /// </summary>
    public static readonly DependencyProperty PrimaryCommandProperty =
        DependencyProperty.Register(
            nameof(PrimaryCommand),
            typeof(ICommand),
            typeof(ThinCrab36),
            new PropertyMetadata(null));

    public ICommand? PrimaryCommand
    {
        get => (ICommand?)GetValue(PrimaryCommandProperty);
        set => SetValue(PrimaryCommandProperty, value);
    }

    /// <summary>
    /// 보조 버튼 클릭 명령
    /// Secondary button click command
    /// </summary>
    public static readonly DependencyProperty SecondaryCommandProperty =
        DependencyProperty.Register(
            nameof(SecondaryCommand),
            typeof(ICommand),
            typeof(ThinCrab36),
            new PropertyMetadata(null));

    public ICommand? SecondaryCommand
    {
        get => (ICommand?)GetValue(SecondaryCommandProperty);
        set => SetValue(SecondaryCommandProperty, value);
    }

    #endregion

    #region Routed Events

    /// <summary>
    /// 기본 버튼 클릭 이벤트
    /// Primary button click event
    /// </summary>
    public static readonly RoutedEvent PrimaryClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(PrimaryClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ThinCrab36));

    public event RoutedEventHandler PrimaryClick
    {
        add => AddHandler(PrimaryClickEvent, value);
        remove => RemoveHandler(PrimaryClickEvent, value);
    }

    /// <summary>
    /// 보조 버튼 클릭 이벤트
    /// Secondary button click event
    /// </summary>
    public static readonly RoutedEvent SecondaryClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(SecondaryClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ThinCrab36));

    public event RoutedEventHandler SecondaryClick
    {
        add => AddHandler(SecondaryClickEvent, value);
        remove => RemoveHandler(SecondaryClickEvent, value);
    }

    #endregion

    #region Template Parts

    private const string PART_PrimaryButton = "PART_PrimaryButton";
    private const string PART_SecondaryButton = "PART_SecondaryButton";

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild(PART_PrimaryButton) is Button primaryButton)
        {
            primaryButton.Click += (s, e) =>
            {
                RaiseEvent(new RoutedEventArgs(PrimaryClickEvent, this));
                PrimaryCommand?.Execute(null);
            };
        }

        if (GetTemplateChild(PART_SecondaryButton) is Button secondaryButton)
        {
            secondaryButton.Click += (s, e) =>
            {
                RaiseEvent(new RoutedEventArgs(SecondaryClickEvent, this));
                SecondaryCommand?.Execute(null);
            };
        }
    }

    #endregion
}
