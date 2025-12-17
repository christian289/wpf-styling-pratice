using System.Windows;
using System.Windows.Controls;

namespace QuietHorse20.Wpf.UI.Controls;

/// <summary>
/// 아이콘과 텍스트가 포함된 모던 버튼 컨트롤
/// Modern button control with icon and text
/// </summary>
public sealed class QuietHorse20 : Button
{
    static QuietHorse20()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(QuietHorse20),
            new FrameworkPropertyMetadata(typeof(QuietHorse20)));
    }

    #region Text DependencyProperty

    /// <summary>
    /// 버튼에 표시될 텍스트
    /// Text displayed on the button
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(QuietHorse20),
            new PropertyMetadata("Send Message"));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
}
