using System.Windows;
using System.Windows.Controls;

namespace Gallery.OpenSilver.Controls
{
    /// <summary>
    /// Realism 스타일의 네온 글로우 버튼 커스텀 컨트롤
    /// Realism style neon glow button custom control
    /// CSS의 radial-gradient와 box-shadow 효과를 WPF/OpenSilver로 구현
    /// </summary>
    public class NeonGlowButton : Button
    {
        public NeonGlowButton()
        {
            DefaultStyleKey = typeof(NeonGlowButton);
        }
    }
}
