using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace OldHound37.Avalonia.Lib.Controls;

/// <summary>
/// 패턴 배경을 표시하는 커스텀 컨트롤입니다.
/// A custom control that displays a pattern background.
/// </summary>
/// <remarks>
/// CSS conic-gradient 기반의 기하학적 패턴을 AvaloniaUI DrawingBrush로 구현합니다.
/// Implements geometric patterns based on CSS conic-gradient using AvaloniaUI DrawingBrush.
/// </remarks>
public sealed class OldHound37Control : TemplatedControl
{
    /// <summary>
    /// 패턴 타일 크기를 정의합니다. 기본값은 200입니다.
    /// Defines the pattern tile size. Default is 200.
    /// </summary>
    public static readonly StyledProperty<double> TileSizeProperty =
        AvaloniaProperty.Register<OldHound37Control, double>(nameof(TileSize), 200.0);

    /// <summary>
    /// 패턴 타일 크기를 가져오거나 설정합니다.
    /// Gets or sets the pattern tile size.
    /// </summary>
    public double TileSize
    {
        get => GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }
}
