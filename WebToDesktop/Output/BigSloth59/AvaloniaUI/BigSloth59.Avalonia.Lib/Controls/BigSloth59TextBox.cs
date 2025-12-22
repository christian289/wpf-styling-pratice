using Avalonia;
using Avalonia.Controls;

namespace BigSloth59.Avalonia.Lib.Controls;

/// <summary>
/// 하단 테두리 강조 효과가 있는 커스텀 TextBox 컨트롤
/// Custom TextBox control with bottom border highlight effect
/// </summary>
public sealed class BigSloth59TextBox : TextBox
{
    static BigSloth59TextBox()
    {
        // AvaloniaUI에서는 WPF와 달리 DefaultStyleKeyProperty가 없음
        // 대신 Generic.axaml에서 Selector로 스타일 적용
        // In AvaloniaUI, there's no DefaultStyleKeyProperty like WPF
        // Instead, styles are applied via Selector in Generic.axaml
    }
}
