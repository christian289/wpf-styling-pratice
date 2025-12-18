using Avalonia;
using Avalonia.Controls.Primitives;

namespace BreezyGoose71.Avalonia.Lib.Controls;

/// <summary>
/// 북마크 토글 버튼 커스텀 컨트롤
/// Bookmark toggle button custom control
/// </summary>
public sealed class BookmarkToggleButton : ToggleButton
{
    /// <summary>
    /// 아이콘 크기
    /// Icon size
    /// </summary>
    public static readonly StyledProperty<double> IconSizeProperty =
        AvaloniaProperty.Register<BookmarkToggleButton, double>(nameof(IconSize), 15.0);

    /// <summary>
    /// 아이콘 크기
    /// Icon size
    /// </summary>
    public double IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }

    static BookmarkToggleButton()
    {
        // 컨트롤에 기본 스타일 적용
        // Apply default style to control
    }
}
