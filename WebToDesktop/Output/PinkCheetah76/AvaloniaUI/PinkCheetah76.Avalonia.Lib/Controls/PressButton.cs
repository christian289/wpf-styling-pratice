using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace PinkCheetah76.Avalonia.Lib.Controls;

/// <summary>
/// 3D 눌림 효과가 있는 버튼 컨트롤
/// 3D press effect button control
/// </summary>
public sealed class PressButton : Button
{
    /// <summary>
    /// 버튼 강조 색상
    /// Button accent color
    /// </summary>
    public static readonly StyledProperty<IBrush?> AccentBrushProperty =
        AvaloniaProperty.Register<PressButton, IBrush?>(
            nameof(AccentBrush),
            defaultValue: new SolidColorBrush(Color.FromRgb(255, 0, 0)));

    public IBrush? AccentBrush
    {
        get => GetValue(AccentBrushProperty);
        set => SetValue(AccentBrushProperty, value);
    }

    /// <summary>
    /// 버튼 그림자 색상 (AccentBrush의 80% + black)
    /// Button shadow color (80% of AccentBrush + black)
    /// </summary>
    public static readonly StyledProperty<IBrush?> ShadowBrushProperty =
        AvaloniaProperty.Register<PressButton, IBrush?>(
            nameof(ShadowBrush),
            defaultValue: new SolidColorBrush(Color.FromRgb(204, 0, 0)));

    public IBrush? ShadowBrush
    {
        get => GetValue(ShadowBrushProperty);
        set => SetValue(ShadowBrushProperty, value);
    }

    protected override Type StyleKeyOverride => typeof(PressButton);
}
