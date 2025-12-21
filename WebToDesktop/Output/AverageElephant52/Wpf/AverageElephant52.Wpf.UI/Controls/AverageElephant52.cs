using System.Windows;
using System.Windows.Controls;

namespace AverageElephant52.Wpf.UI.Controls;

/// <summary>
/// 그라데이션 배경과 장식 블롭이 있는 모던 검색 입력 컨트롤입니다.
/// Modern search input control with gradient background and decorative blob.
/// </summary>
public sealed class AverageElephant52 : Control
{
    static AverageElephant52()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(AverageElephant52),
            new FrameworkPropertyMetadata(typeof(AverageElephant52)));
    }

    /// <summary>
    /// 검색 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the search text.
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(AverageElephant52),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 플레이스홀더 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the placeholder text.
    /// </summary>
    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(
            nameof(Placeholder),
            typeof(string),
            typeof(AverageElephant52),
            new PropertyMetadata("Search ..."));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
}
