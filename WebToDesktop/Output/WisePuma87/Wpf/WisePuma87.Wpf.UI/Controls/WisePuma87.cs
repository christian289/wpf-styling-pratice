using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WisePuma87.Wpf.UI.Controls;

/// <summary>
/// 애니메이션 체크박스 컨트롤 - uiverse.io의 LeonKohli 디자인 기반
/// Animated checkbox control - based on LeonKohli's design from uiverse.io
/// </summary>
public sealed class WisePuma87 : ToggleButton
{
    static WisePuma87()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WisePuma87),
            new FrameworkPropertyMetadata(typeof(WisePuma87)));
    }

    /// <summary>
    /// 체크박스 텍스트
    /// Checkbox text
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(WisePuma87),
            new PropertyMetadata("Check me!"));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
