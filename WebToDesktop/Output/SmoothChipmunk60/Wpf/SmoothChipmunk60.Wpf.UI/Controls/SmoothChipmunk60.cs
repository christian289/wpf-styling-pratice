using System.Windows;
using System.Windows.Controls.Primitives;

namespace SmoothChipmunk60.Wpf.UI.Controls;

/// <summary>
/// 햄버거 메뉴 아이콘이 X 아이콘으로 변환되는 토글 스위치 컨트롤
/// A toggle switch control that transforms a hamburger menu icon into an X icon
/// </summary>
public sealed class SmoothChipmunk60 : ToggleButton
{
    static SmoothChipmunk60()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SmoothChipmunk60),
            new FrameworkPropertyMetadata(typeof(SmoothChipmunk60)));
    }
}
