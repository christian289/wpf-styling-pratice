using System.Windows;
using System.Windows.Controls;

namespace OrangeFox41.Wpf.UI.Controls;

/// <summary>
/// Material Design 3 스타일의 툴팁 컨트롤
/// Material Design 3 style tooltip control
/// </summary>
public sealed class OrangeFox41 : ContentControl
{
    static OrangeFox41()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(OrangeFox41),
            new FrameworkPropertyMetadata(typeof(OrangeFox41)));
    }

    /// <summary>
    /// 버튼에 표시될 텍스트
    /// Text displayed on the button
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(OrangeFox41),
            new PropertyMetadata("Material Design Tooltip"));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 툴팁 제목
    /// Tooltip title
    /// </summary>
    public static readonly DependencyProperty TooltipTitleProperty =
        DependencyProperty.Register(
            nameof(TooltipTitle),
            typeof(string),
            typeof(OrangeFox41),
            new PropertyMetadata("Title"));

    public string TooltipTitle
    {
        get => (string)GetValue(TooltipTitleProperty);
        set => SetValue(TooltipTitleProperty, value);
    }

    /// <summary>
    /// 툴팁 내용
    /// Tooltip content
    /// </summary>
    public static readonly DependencyProperty TooltipContentProperty =
        DependencyProperty.Register(
            nameof(TooltipContent),
            typeof(string),
            typeof(OrangeFox41),
            new PropertyMetadata("Lorem ipsum dolor sit amet consectetur adipisicing elit."));

    public string TooltipContent
    {
        get => (string)GetValue(TooltipContentProperty);
        set => SetValue(TooltipContentProperty, value);
    }
}
