using System.Windows;
using System.Windows.Controls;

namespace MightyElephant52.Wpf.UI.Controls;

/// <summary>
/// Tooltip Follow 버튼 컨트롤
/// 호버 시 팔로워 수를 보여주는 Tooltip이 나타나는 소셜 미디어 스타일 버튼
/// </summary>
public sealed class MightyElephant52 : ContentControl
{
    /// <summary>
    /// Tooltip에 표시될 텍스트 (예: "45k")
    /// </summary>
    public static readonly DependencyProperty TooltipTextProperty =
        DependencyProperty.Register(
            nameof(TooltipText),
            typeof(string),
            typeof(MightyElephant52),
            new PropertyMetadata("45k"));

    public string TooltipText
    {
        get => (string)GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    static MightyElephant52()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(MightyElephant52),
            new FrameworkPropertyMetadata(typeof(MightyElephant52)));
    }
}
