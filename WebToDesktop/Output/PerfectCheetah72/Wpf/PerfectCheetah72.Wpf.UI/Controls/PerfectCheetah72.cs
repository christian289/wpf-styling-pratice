using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PerfectCheetah72.Wpf.UI.Controls;

/// <summary>
/// 테마 선택 드롭다운 팝업 컨트롤
/// Theme selection dropdown popup control
/// </summary>
public sealed class PerfectCheetah72 : Control
{
    static PerfectCheetah72()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(PerfectCheetah72),
            new FrameworkPropertyMetadata(typeof(PerfectCheetah72)));
    }

    #region Dependency Properties

    /// <summary>
    /// 선택된 테마 옵션
    /// Selected theme option
    /// </summary>
    public static readonly DependencyProperty SelectedThemeProperty =
        DependencyProperty.Register(
            nameof(SelectedTheme),
            typeof(ThemeOption),
            typeof(PerfectCheetah72),
            new FrameworkPropertyMetadata(
                ThemeOption.Default,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedThemeChanged));

    public ThemeOption SelectedTheme
    {
        get => (ThemeOption)GetValue(SelectedThemeProperty);
        set => SetValue(SelectedThemeProperty, value);
    }

    private static void OnSelectedThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is PerfectCheetah72 control)
        {
            control.RaiseEvent(new RoutedEventArgs(ThemeChangedEvent, control));
        }
    }

    /// <summary>
    /// 드롭다운 팝업 열림 상태
    /// Dropdown popup open state
    /// </summary>
    public static readonly DependencyProperty IsDropDownOpenProperty =
        DependencyProperty.Register(
            nameof(IsDropDownOpen),
            typeof(bool),
            typeof(PerfectCheetah72),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool IsDropDownOpen
    {
        get => (bool)GetValue(IsDropDownOpenProperty);
        set => SetValue(IsDropDownOpenProperty, value);
    }

    /// <summary>
    /// 버튼에 표시될 텍스트
    /// Text displayed on the button
    /// </summary>
    public static readonly DependencyProperty ButtonTextProperty =
        DependencyProperty.Register(
            nameof(ButtonText),
            typeof(string),
            typeof(PerfectCheetah72),
            new PropertyMetadata("Theme"));

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    #endregion

    #region Routed Events

    /// <summary>
    /// 테마 변경 이벤트
    /// Theme changed event
    /// </summary>
    public static readonly RoutedEvent ThemeChangedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(ThemeChanged),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(PerfectCheetah72));

    public event RoutedEventHandler ThemeChanged
    {
        add => AddHandler(ThemeChangedEvent, value);
        remove => RemoveHandler(ThemeChangedEvent, value);
    }

    #endregion

    #region Template Parts

    private ToggleButton? _toggleButton;
    private Popup? _popup;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (_toggleButton is not null)
        {
            _toggleButton.Click -= OnToggleButtonClick;
        }

        _toggleButton = GetTemplateChild("PART_ToggleButton") as ToggleButton;
        _popup = GetTemplateChild("PART_Popup") as Popup;

        if (_toggleButton is not null)
        {
            _toggleButton.Click += OnToggleButtonClick;
        }
    }

    private void OnToggleButtonClick(object sender, RoutedEventArgs e)
    {
        IsDropDownOpen = _toggleButton?.IsChecked ?? false;
    }

    #endregion

    #region Commands

    public static readonly RoutedCommand SelectThemeCommand = new(nameof(SelectThemeCommand), typeof(PerfectCheetah72));

    static PerfectCheetah72 Instance => new();

    public PerfectCheetah72()
    {
        CommandBindings.Add(new CommandBinding(SelectThemeCommand, OnSelectThemeExecuted));
    }

    private void OnSelectThemeExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        if (e.Parameter is ThemeOption theme)
        {
            SelectedTheme = theme;
            IsDropDownOpen = false;
        }
    }

    #endregion
}
