using System.Windows;
using System.Windows.Controls;

namespace SourOtter25.Wpf.UI.Controls;

/// <summary>
/// CSS Clip-Path 폴리곤 애니메이션 효과가 있는 카드 컨트롤.
/// 호버 시 클립 경로가 변경되고 텍스트가 회전하며 나타나는 효과.
/// Card control with CSS Clip-Path polygon animation effect.
/// On hover, the clip path changes and text rotates into view.
/// </summary>
public sealed class SourOtter25 : Control
{
    static SourOtter25()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SourOtter25),
            new FrameworkPropertyMetadata(typeof(SourOtter25)));
    }

    /// <summary>
    /// 카드 제목 / Card title
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(SourOtter25),
            new PropertyMetadata("CSS Clip-Path"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 작성자 이름 / Author name
    /// </summary>
    public static readonly DependencyProperty AuthorProperty =
        DependencyProperty.Register(
            nameof(Author),
            typeof(string),
            typeof(SourOtter25),
            new PropertyMetadata("ELEKTRO RAKS"));

    public string Author
    {
        get => (string)GetValue(AuthorProperty);
        set => SetValue(AuthorProperty, value);
    }

    /// <summary>
    /// 설명 텍스트 / Description text
    /// </summary>
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(SourOtter25),
            new PropertyMetadata("Custom card"));

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }
}
