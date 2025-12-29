using System.Windows;
using System.Windows.Controls;

namespace TerribleHound31.Wpf.UI.Controls;

/// <summary>
/// 과일(오렌지) 모양의 장식 컨트롤 - 빨강→주황 그라데이션 배경에 잎 장식과 이모지 애니메이션
/// Fruit (orange) shaped decorative control - red→orange gradient background with leaf decoration and emoji animation
/// </summary>
public sealed class TerribleHound31 : Control
{
    static TerribleHound31()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TerribleHound31),
            new FrameworkPropertyMetadata(typeof(TerribleHound31)));
    }
}
