using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace NeonGlow.Avalonia.Lib.Controls;

/// <summary>
/// Realism 스타일의 네온 글로우 버튼 커스텀 컨트롤
/// CSS의 radial-gradient와 box-shadow 효과를 Avalonia로 구현
/// </summary>
public class NeonGlowButton : Button
{
    static NeonGlowButton()
    {
        // Avalonia에서는 StyleKey를 통해 스타일을 연결
    }

    protected override Type StyleKeyOverride => typeof(NeonGlowButton);
}
