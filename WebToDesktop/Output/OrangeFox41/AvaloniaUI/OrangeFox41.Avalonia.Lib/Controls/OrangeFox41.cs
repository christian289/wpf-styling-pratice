using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace OrangeFox41.Avalonia.Lib.Controls;

/// <summary>
/// Material Design 3 스타일 툴팁 컨테이너 컨트롤
/// Material Design 3 style tooltip container control
/// </summary>
public sealed class OrangeFox41 : TemplatedControl
{
    /// <summary>
    /// 툴팁 제목
    /// Tooltip title
    /// </summary>
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<OrangeFox41, string>(nameof(Title), "Title");

    /// <summary>
    /// 툴팁 내용
    /// Tooltip content
    /// </summary>
    public static readonly StyledProperty<string> ContentTextProperty =
        AvaloniaProperty.Register<OrangeFox41, string>(nameof(ContentText), string.Empty);

    /// <summary>
    /// 버튼 텍스트
    /// Button text
    /// </summary>
    public static readonly StyledProperty<string> ButtonTextProperty =
        AvaloniaProperty.Register<OrangeFox41, string>(nameof(ButtonText), "Material Design Tooltip");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string ContentText
    {
        get => GetValue(ContentTextProperty);
        set => SetValue(ContentTextProperty, value);
    }

    public string ButtonText
    {
        get => GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }
}
