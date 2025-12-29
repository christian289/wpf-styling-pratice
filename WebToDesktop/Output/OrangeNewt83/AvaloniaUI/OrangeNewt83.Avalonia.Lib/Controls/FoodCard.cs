using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace OrangeNewt83.Avalonia.Lib.Controls;

/// <summary>
/// 기울어진 카드 효과가 있는 음식 카드 컨트롤.
/// A food card control with tilted card effect.
/// </summary>
public sealed class FoodCard : TemplatedControl
{
    /// <summary>
    /// 아이콘 콘텐츠를 정의하는 속성.
    /// Defines the icon content property.
    /// </summary>
    public static readonly StyledProperty<object?> IconProperty =
        AvaloniaProperty.Register<FoodCard, object?>(nameof(Icon));

    /// <summary>
    /// 제목을 정의하는 속성.
    /// Defines the title property.
    /// </summary>
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<FoodCard, string>(nameof(Title), "Title");

    /// <summary>
    /// 정보 텍스트를 정의하는 속성.
    /// Defines the info text property.
    /// </summary>
    public static readonly StyledProperty<string> InfoProperty =
        AvaloniaProperty.Register<FoodCard, string>(nameof(Info), string.Empty);

    /// <summary>
    /// 가격을 정의하는 속성.
    /// Defines the price property.
    /// </summary>
    public static readonly StyledProperty<decimal> PriceProperty =
        AvaloniaProperty.Register<FoodCard, decimal>(nameof(Price), 0m);

    /// <summary>
    /// 가격 접두사 (통화 기호)를 정의하는 속성.
    /// Defines the price prefix (currency symbol) property.
    /// </summary>
    public static readonly StyledProperty<string> PricePrefixProperty =
        AvaloniaProperty.Register<FoodCard, string>(nameof(PricePrefix), "$");

    /// <summary>
    /// 아이콘 콘텐츠를 가져오거나 설정합니다.
    /// Gets or sets the icon content.
    /// </summary>
    public object? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// 제목을 가져오거나 설정합니다.
    /// Gets or sets the title.
    /// </summary>
    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 정보 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the info text.
    /// </summary>
    public string Info
    {
        get => GetValue(InfoProperty);
        set => SetValue(InfoProperty, value);
    }

    /// <summary>
    /// 가격을 가져오거나 설정합니다.
    /// Gets or sets the price.
    /// </summary>
    public decimal Price
    {
        get => GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }

    /// <summary>
    /// 가격 접두사를 가져오거나 설정합니다.
    /// Gets or sets the price prefix.
    /// </summary>
    public string PricePrefix
    {
        get => GetValue(PricePrefixProperty);
        set => SetValue(PricePrefixProperty, value);
    }
}
