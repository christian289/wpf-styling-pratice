using System.Windows;
using System.Windows.Controls;

namespace MassiveInsect5.Wpf.UI.Controls;

/// <summary>
/// 소셜 미디어 아이콘 카드 컨트롤
/// 마우스 호버 시 Instagram, Twitter, Discord 아이콘이 애니메이션과 함께 나타남
/// Social media icon card control
/// Shows Instagram, Twitter, Discord icons with animation on mouse hover
/// </summary>
public sealed class MassiveInsect5 : Control
{
    static MassiveInsect5()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(MassiveInsect5),
            new FrameworkPropertyMetadata(typeof(MassiveInsect5)));
    }
}
