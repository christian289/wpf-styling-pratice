using Avalonia;
using Avalonia.Controls;

namespace NewDog56.Avalonia.Lib.Controls;

/// <summary>
/// Primary button with gradient hover effect.
/// hover 시 그라데이션 효과가 나타나는 프라이머리 버튼.
/// </summary>
public sealed class NewDog56Button : Button
{
    static NewDog56Button()
    {
        // AvaloniaUI는 WPF와 달리 DefaultStyleKeyProperty가 없음
        // 스타일은 Generic.axaml에서 Selector로 적용됨
        // AvaloniaUI doesn't have DefaultStyleKeyProperty like WPF
        // Styles are applied via Selector in Generic.axaml
    }
}
