using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SmartBobcat50.Avalonia.Lib.Controls;

/// <summary>
/// 하트 모양의 체크박스 컨트롤 (좋아요 버튼)
/// Heart-shaped checkbox control (like button)
/// </summary>
public sealed class HeartCheckBox : ToggleButton
{
    static HeartCheckBox()
    {
        // ToggleButton의 기본 스타일을 사용하지 않고 커스텀 스타일 사용
        // Use custom style instead of default ToggleButton style
    }
}
