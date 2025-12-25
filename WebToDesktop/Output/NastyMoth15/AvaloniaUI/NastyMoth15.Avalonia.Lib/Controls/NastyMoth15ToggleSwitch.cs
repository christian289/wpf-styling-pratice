using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace NastyMoth15.Avalonia.Lib.Controls;

/// <summary>
/// A toggle switch control with sparkle animation effect and flag icon.
/// 스파클 애니메이션 효과와 깃발 아이콘이 있는 토글 스위치 컨트롤.
/// </summary>
public sealed class NastyMoth15ToggleSwitch : ToggleButton
{
    static NastyMoth15ToggleSwitch()
    {
        // ToggleButton의 기본 스타일 키를 NastyMoth15ToggleSwitch로 설정
        // Set the default style key of ToggleButton to NastyMoth15ToggleSwitch
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
    }
}
