using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace CurlyBullfrog98.Avalonia.Lib.Controls;

/// <summary>
/// 3D 회전 큐브 로딩 애니메이션 컨트롤
/// 3D rotating cube loading animation control
/// </summary>
/// <remarks>
/// CSS 3D 변환(perspective, preserve-3d, translateZ)은 AvaloniaUI에서 지원되지 않으므로
/// 2D 변환을 사용하여 유사한 시각 효과를 구현합니다.
/// CSS 3D transforms are not supported in AvaloniaUI,
/// so we use 2D transforms to achieve a similar visual effect.
/// </remarks>
public sealed class CurlyBullfrog98Control : TemplatedControl
{
    /// <summary>
    /// 큐브 크기 속성
    /// Cube size property
    /// </summary>
    public static readonly StyledProperty<double> CubeSizeProperty =
        AvaloniaProperty.Register<CurlyBullfrog98Control, double>(nameof(CubeSize), 200.0);

    /// <summary>
    /// 애니메이션 지속 시간(초) 속성
    /// Animation duration (seconds) property
    /// </summary>
    public static readonly StyledProperty<double> AnimationDurationProperty =
        AvaloniaProperty.Register<CurlyBullfrog98Control, double>(nameof(AnimationDuration), 4.0);

    /// <summary>
    /// 큐브 배경색 속성
    /// Cube background color property
    /// </summary>
    public static readonly StyledProperty<IBrush?> CubeBackgroundProperty =
        AvaloniaProperty.Register<CurlyBullfrog98Control, IBrush?>(nameof(CubeBackground));

    /// <summary>
    /// 큐브 테두리색 속성
    /// Cube border color property
    /// </summary>
    public static readonly StyledProperty<IBrush?> CubeBorderBrushProperty =
        AvaloniaProperty.Register<CurlyBullfrog98Control, IBrush?>(nameof(CubeBorderBrush));

    /// <summary>
    /// 큐브 크기 (기본값: 200)
    /// Cube size (default: 200)
    /// </summary>
    public double CubeSize
    {
        get => GetValue(CubeSizeProperty);
        set => SetValue(CubeSizeProperty, value);
    }

    /// <summary>
    /// 애니메이션 지속 시간 (초, 기본값: 4)
    /// Animation duration in seconds (default: 4)
    /// </summary>
    public double AnimationDuration
    {
        get => GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }

    /// <summary>
    /// 큐브 배경색
    /// Cube background color
    /// </summary>
    public IBrush? CubeBackground
    {
        get => GetValue(CubeBackgroundProperty);
        set => SetValue(CubeBackgroundProperty, value);
    }

    /// <summary>
    /// 큐브 테두리색
    /// Cube border color
    /// </summary>
    public IBrush? CubeBorderBrush
    {
        get => GetValue(CubeBorderBrushProperty);
        set => SetValue(CubeBorderBrushProperty, value);
    }
}
