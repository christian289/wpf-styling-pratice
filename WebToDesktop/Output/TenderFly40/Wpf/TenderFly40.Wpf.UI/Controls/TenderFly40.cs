using System.Windows;
using System.Windows.Controls;

namespace TenderFly40.Wpf.UI.Controls;

/// <summary>
/// Quote 카드 컨트롤 - 명언을 표시하는 카드 스타일 컨트롤
/// Quote card control - Card style control displaying quotes
/// </summary>
public sealed class TenderFly40 : Control
{
    static TenderFly40()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TenderFly40),
            new FrameworkPropertyMetadata(typeof(TenderFly40)));
    }

    #region CardTitle DependencyProperty
    /// <summary>
    /// 카드 상단 타이틀 (예: "Quote of the month")
    /// Card top title (e.g., "Quote of the month")
    /// </summary>
    public static readonly DependencyProperty CardTitleProperty =
        DependencyProperty.Register(
            nameof(CardTitle),
            typeof(string),
            typeof(TenderFly40),
            new PropertyMetadata("Quote of the month"));

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }
    #endregion

    #region QuoteText DependencyProperty
    /// <summary>
    /// 명언 텍스트
    /// Quote text
    /// </summary>
    public static readonly DependencyProperty QuoteTextProperty =
        DependencyProperty.Register(
            nameof(QuoteText),
            typeof(string),
            typeof(TenderFly40),
            new PropertyMetadata("Fortune favors the bold."));

    public string QuoteText
    {
        get => (string)GetValue(QuoteTextProperty);
        set => SetValue(QuoteTextProperty, value);
    }
    #endregion

    #region Author DependencyProperty
    /// <summary>
    /// 작가 이름
    /// Author name
    /// </summary>
    public static readonly DependencyProperty AuthorProperty =
        DependencyProperty.Register(
            nameof(Author),
            typeof(string),
            typeof(TenderFly40),
            new PropertyMetadata("Virgil"));

    public string Author
    {
        get => (string)GetValue(AuthorProperty);
        set => SetValue(AuthorProperty, value);
    }
    #endregion

    #region AuthorDescription DependencyProperty
    /// <summary>
    /// 작가 설명 (예: "Latin poet")
    /// Author description (e.g., "Latin poet")
    /// </summary>
    public static readonly DependencyProperty AuthorDescriptionProperty =
        DependencyProperty.Register(
            nameof(AuthorDescription),
            typeof(string),
            typeof(TenderFly40),
            new PropertyMetadata("(Latin poet)"));

    public string AuthorDescription
    {
        get => (string)GetValue(AuthorDescriptionProperty);
        set => SetValue(AuthorDescriptionProperty, value);
    }
    #endregion
}
