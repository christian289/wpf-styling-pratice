using System.Windows;
using System.Windows.Controls;

namespace RudeSeahorse6.Wpf.UI.Controls;

/// <summary>
/// 그라데이션 배경의 버튼과 호버 시 나타나는 다크 모드 툴팁 컨트롤.
/// Button with gradient background and dark mode tooltip that appears on hover.
/// </summary>
public sealed class RudeSeahorse6 : ContentControl
{
    /// <summary>
    /// 툴팁 제목 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the tooltip title text.
    /// </summary>
    public static readonly DependencyProperty TooltipTitleProperty =
        DependencyProperty.Register(
            nameof(TooltipTitle),
            typeof(string),
            typeof(RudeSeahorse6),
            new PropertyMetadata("LET'S CREATE!"));

    /// <summary>
    /// 툴팁 아이템1 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the tooltip item 1 text.
    /// </summary>
    public static readonly DependencyProperty TooltipItem1Property =
        DependencyProperty.Register(
            nameof(TooltipItem1),
            typeof(string),
            typeof(RudeSeahorse6),
            new PropertyMetadata("1 - Explore"));

    /// <summary>
    /// 툴팁 아이템2 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the tooltip item 2 text.
    /// </summary>
    public static readonly DependencyProperty TooltipItem2Property =
        DependencyProperty.Register(
            nameof(TooltipItem2),
            typeof(string),
            typeof(RudeSeahorse6),
            new PropertyMetadata("2 - Have fun!"));

    static RudeSeahorse6()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RudeSeahorse6),
            new FrameworkPropertyMetadata(typeof(RudeSeahorse6)));
    }

    public string TooltipTitle
    {
        get => (string)GetValue(TooltipTitleProperty);
        set => SetValue(TooltipTitleProperty, value);
    }

    public string TooltipItem1
    {
        get => (string)GetValue(TooltipItem1Property);
        set => SetValue(TooltipItem1Property, value);
    }

    public string TooltipItem2
    {
        get => (string)GetValue(TooltipItem2Property);
        set => SetValue(TooltipItem2Property, value);
    }
}
