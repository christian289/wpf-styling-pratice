using System.Windows;
using System.Windows.Controls;

namespace BitterSkunk14.Wpf.UI.Controls;

/// <summary>
/// Tooltip with animated connector line and button.
/// 애니메이션 연결선과 버튼이 있는 툴팁 컨트롤.
/// </summary>
public sealed class BitterSkunk14 : ContentControl
{
    /// <summary>
    /// Tooltip message text.
    /// 툴팁 메시지 텍스트.
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(BitterSkunk14),
            new PropertyMetadata("This is a test"));

    /// <summary>
    /// Button text in tooltip.
    /// 툴팁 내 버튼 텍스트.
    /// </summary>
    public static readonly DependencyProperty ButtonTextProperty =
        DependencyProperty.Register(
            nameof(ButtonText),
            typeof(string),
            typeof(BitterSkunk14),
            new PropertyMetadata("Got It"));

    /// <summary>
    /// Trigger text displayed on the container.
    /// 컨테이너에 표시되는 트리거 텍스트.
    /// </summary>
    public static readonly DependencyProperty TriggerTextProperty =
        DependencyProperty.Register(
            nameof(TriggerText),
            typeof(string),
            typeof(BitterSkunk14),
            new PropertyMetadata("Tooltip"));

    static BitterSkunk14()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BitterSkunk14),
            new FrameworkPropertyMetadata(typeof(BitterSkunk14)));
    }

    public string TooltipText
    {
        get => (string)GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public string TriggerText
    {
        get => (string)GetValue(TriggerTextProperty);
        set => SetValue(TriggerTextProperty, value);
    }
}
