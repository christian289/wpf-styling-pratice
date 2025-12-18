using Avalonia;
using Avalonia.Controls.Primitives;

namespace PopularCrab99.Avalonia.Lib.Controls;

/// <summary>
/// 4개의 색상 큐브가 시계 방향으로 회전하는 로더 컨트롤
/// A loader control with 4 colored cubes rotating clockwise
/// </summary>
public sealed class CubeLoader : TemplatedControl
{

    /// <summary>
    /// 애니메이션 실행 여부
    /// Whether the animation is running
    /// </summary>
    public static readonly StyledProperty<bool> IsRunningProperty =
        AvaloniaProperty.Register<CubeLoader, bool>(nameof(IsRunning), true);

    public bool IsRunning
    {
        get => GetValue(IsRunningProperty);
        set => SetValue(IsRunningProperty, value);
    }
}
