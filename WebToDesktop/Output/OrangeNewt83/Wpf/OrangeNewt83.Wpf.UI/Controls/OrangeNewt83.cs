using System.Windows;
using System.Windows.Controls;

namespace OrangeNewt83.Wpf.UI.Controls;

/// <summary>
/// 회전 효과가 있는 카드 컨트롤.
/// 호버 시 배경 카드와 콘텐츠 카드가 0도로 정렬됩니다.
/// Rotatable card control with hover effect.
/// Background and content cards align to 0 degrees on hover.
/// </summary>
public sealed class OrangeNewt83 : ContentControl
{
    static OrangeNewt83()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(OrangeNewt83),
            new FrameworkPropertyMetadata(typeof(OrangeNewt83)));
    }

    #region Icon Property

    /// <summary>
    /// 아이콘 콘텐츠 (SVG Path 등)
    /// Icon content (SVG Path, etc.)
    /// </summary>
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(
            nameof(Icon),
            typeof(object),
            typeof(OrangeNewt83),
            new PropertyMetadata(null));

    public object? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region Title Property

    /// <summary>
    /// 제목 텍스트
    /// Title text
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(OrangeNewt83),
            new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region Info Property

    /// <summary>
    /// 정보 텍스트 (예: "30 Min | 165 Sell")
    /// Info text (e.g., "30 Min | 165 Sell")
    /// </summary>
    public static readonly DependencyProperty InfoProperty =
        DependencyProperty.Register(
            nameof(Info),
            typeof(string),
            typeof(OrangeNewt83),
            new PropertyMetadata(string.Empty));

    public string Info
    {
        get => (string)GetValue(InfoProperty);
        set => SetValue(InfoProperty, value);
    }

    #endregion

    #region Price Property

    /// <summary>
    /// 가격 텍스트
    /// Price text
    /// </summary>
    public static readonly DependencyProperty PriceProperty =
        DependencyProperty.Register(
            nameof(Price),
            typeof(string),
            typeof(OrangeNewt83),
            new PropertyMetadata(string.Empty));

    public string Price
    {
        get => (string)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }

    #endregion

    #region PricePrefix Property

    /// <summary>
    /// 가격 접두사 (기본값: $)
    /// Price prefix (default: $)
    /// </summary>
    public static readonly DependencyProperty PricePrefixProperty =
        DependencyProperty.Register(
            nameof(PricePrefix),
            typeof(string),
            typeof(OrangeNewt83),
            new PropertyMetadata("$"));

    public string PricePrefix
    {
        get => (string)GetValue(PricePrefixProperty);
        set => SetValue(PricePrefixProperty, value);
    }

    #endregion
}
