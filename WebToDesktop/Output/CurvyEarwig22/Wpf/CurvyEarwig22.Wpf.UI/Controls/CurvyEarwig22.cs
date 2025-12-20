using System.Windows;
using System.Windows.Controls;

namespace CurvyEarwig22.Wpf.UI.Controls;

/// <summary>
/// 네온 그라데이션 테두리가 있는 검색 입력 컨트롤.
/// Neon gradient border search input control.
/// </summary>
public sealed class CurvyEarwig22 : Control
{
    static CurvyEarwig22()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(CurvyEarwig22),
            new FrameworkPropertyMetadata(typeof(CurvyEarwig22)));
    }

    /// <summary>
    /// 검색 텍스트.
    /// Search text.
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(CurvyEarwig22),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 플레이스홀더 텍스트.
    /// Placeholder text.
    /// </summary>
    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(
            nameof(Placeholder),
            typeof(string),
            typeof(CurvyEarwig22),
            new PropertyMetadata("Search..."));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
}
