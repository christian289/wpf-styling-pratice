using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace AverageElephant52.Avalonia.Lib.Controls;

/// <summary>
/// 그라데이션 효과가 적용된 검색바 커스텀 컨트롤
/// A search bar custom control with gradient effects
/// </summary>
public sealed class SearchBar : TemplatedControl
{
    /// <summary>
    /// Placeholder 텍스트 속성
    /// Placeholder text property
    /// </summary>
    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<SearchBar, string?>(nameof(Placeholder), "Search ...");

    /// <summary>
    /// 검색 텍스트 속성
    /// Search text property
    /// </summary>
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<SearchBar, string?>(nameof(Text));

    /// <summary>
    /// Placeholder 텍스트
    /// Placeholder text
    /// </summary>
    public string? Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    /// <summary>
    /// 검색 텍스트
    /// Search text
    /// </summary>
    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
