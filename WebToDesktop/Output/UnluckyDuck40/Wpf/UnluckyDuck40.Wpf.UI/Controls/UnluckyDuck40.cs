using System.Windows;
using System.Windows.Controls;

namespace UnluckyDuck40.Wpf.UI.Controls;

/// <summary>
/// 소셜 공유 버튼 - 호버 시 소셜 미디어 아이콘이 나타나는 Share 버튼
/// Social share button - Share button with social media icons appearing on hover
/// </summary>
public sealed class UnluckyDuck40 : Control
{
    static UnluckyDuck40()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(UnluckyDuck40),
            new FrameworkPropertyMetadata(typeof(UnluckyDuck40)));
    }

    /// <summary>
    /// 버튼 텍스트
    /// Button text
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(UnluckyDuck40),
            new PropertyMetadata("Share"));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
