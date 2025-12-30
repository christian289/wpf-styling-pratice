using System.Windows;
using System.Windows.Controls;

namespace PlasticMule29.Wpf.UI.Controls;

/// <summary>
/// 3D 입체감을 주는 그린 버튼 컨트롤
/// A green button control with 3D depth effect
/// </summary>
public sealed class PlasticMule29 : Button
{
    static PlasticMule29()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(PlasticMule29),
            new FrameworkPropertyMetadata(typeof(PlasticMule29)));
    }
}
