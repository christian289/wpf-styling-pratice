using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace WhiteKangaroo0.Avalonia.Lib.Controls;

/// <summary>
/// 기어 형태의 로딩 애니메이션 컨트롤입니다.
/// A gear-shaped loading animation control.
/// </summary>
public sealed class GearLoader : TemplatedControl
{
    /// <summary>
    /// 큰 기어의 배경색을 정의합니다.
    /// Defines the background color of the large gear.
    /// </summary>
    public static readonly StyledProperty<IBrush?> LargeGearBrushProperty =
        AvaloniaProperty.Register<GearLoader, IBrush?>(nameof(LargeGearBrush));

    /// <summary>
    /// 작은 기어의 배경색을 정의합니다.
    /// Defines the background color of the small gear.
    /// </summary>
    public static readonly StyledProperty<IBrush?> SmallGearBrushProperty =
        AvaloniaProperty.Register<GearLoader, IBrush?>(nameof(SmallGearBrush));

    /// <summary>
    /// 기어 톱니의 색상을 정의합니다.
    /// Defines the color of gear teeth.
    /// </summary>
    public static readonly StyledProperty<IBrush?> TeethBrushProperty =
        AvaloniaProperty.Register<GearLoader, IBrush?>(nameof(TeethBrush));

    public IBrush? LargeGearBrush
    {
        get => GetValue(LargeGearBrushProperty);
        set => SetValue(LargeGearBrushProperty, value);
    }

    public IBrush? SmallGearBrush
    {
        get => GetValue(SmallGearBrushProperty);
        set => SetValue(SmallGearBrushProperty, value);
    }

    public IBrush? TeethBrush
    {
        get => GetValue(TeethBrushProperty);
        set => SetValue(TeethBrushProperty, value);
    }
}
