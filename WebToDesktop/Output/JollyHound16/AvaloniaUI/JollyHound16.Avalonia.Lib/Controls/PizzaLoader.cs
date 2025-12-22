using Avalonia;
using Avalonia.Controls.Primitives;

namespace JollyHound16.Avalonia.Lib.Controls;

/// <summary>
/// 회전하는 피자 애니메이션 로더 컨트롤
/// Rotating pizza animation loader control
/// </summary>
public sealed class PizzaLoader : TemplatedControl
{
    /// <summary>
    /// 스케일 속성 정의
    /// Scale property definition
    /// </summary>
    public static readonly StyledProperty<double> ScaleProperty =
        AvaloniaProperty.Register<PizzaLoader, double>(nameof(Scale), 1.6);

    /// <summary>
    /// 컨트롤의 스케일 값
    /// Scale value of the control
    /// </summary>
    public double Scale
    {
        get => GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }

    /// <summary>
    /// 피자 회전 시간(초) 속성 정의
    /// Pizza rotation duration (seconds) property definition
    /// </summary>
    public static readonly StyledProperty<double> RotationDurationProperty =
        AvaloniaProperty.Register<PizzaLoader, double>(nameof(RotationDuration), 45.0);

    /// <summary>
    /// 피자 전체 회전에 걸리는 시간(초)
    /// Duration for full pizza rotation (seconds)
    /// </summary>
    public double RotationDuration
    {
        get => GetValue(RotationDurationProperty);
        set => SetValue(RotationDurationProperty, value);
    }

    /// <summary>
    /// 슬라이스 애니메이션 시간(초) 속성 정의
    /// Slice animation duration (seconds) property definition
    /// </summary>
    public static readonly StyledProperty<double> SliceDurationProperty =
        AvaloniaProperty.Register<PizzaLoader, double>(nameof(SliceDuration), 4.0);

    /// <summary>
    /// 각 슬라이스 애니메이션 시간(초)
    /// Duration for each slice animation (seconds)
    /// </summary>
    public double SliceDuration
    {
        get => GetValue(SliceDurationProperty);
        set => SetValue(SliceDurationProperty, value);
    }
}
