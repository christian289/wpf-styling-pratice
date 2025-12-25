using Avalonia;
using Avalonia.Controls.Primitives;

namespace TenderFly40.Avalonia.Lib.Controls;

/// <summary>
/// Quote 카드 컨트롤 - 명언과 작성자 정보를 표시하며 호버 시 작성자가 나타남
/// Quote card control - displays quote with author info appearing on hover
/// </summary>
public sealed class TenderFly40Card : TemplatedControl
{
    public static readonly StyledProperty<string> CardTitleProperty =
        AvaloniaProperty.Register<TenderFly40Card, string>(nameof(CardTitle), "Quote of the month");

    public static readonly StyledProperty<string> QuoteTextProperty =
        AvaloniaProperty.Register<TenderFly40Card, string>(nameof(QuoteText), "Fortune favors the bold.");

    public static readonly StyledProperty<string> AuthorNameProperty =
        AvaloniaProperty.Register<TenderFly40Card, string>(nameof(AuthorName), "Virgil");

    public static readonly StyledProperty<string> AuthorDescriptionProperty =
        AvaloniaProperty.Register<TenderFly40Card, string>(nameof(AuthorDescription), "(Latin poet)");

    public string CardTitle
    {
        get => GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string QuoteText
    {
        get => GetValue(QuoteTextProperty);
        set => SetValue(QuoteTextProperty, value);
    }

    public string AuthorName
    {
        get => GetValue(AuthorNameProperty);
        set => SetValue(AuthorNameProperty, value);
    }

    public string AuthorDescription
    {
        get => GetValue(AuthorDescriptionProperty);
        set => SetValue(AuthorDescriptionProperty, value);
    }
}
