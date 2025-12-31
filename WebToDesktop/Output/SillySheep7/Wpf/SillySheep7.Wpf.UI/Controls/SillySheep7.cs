using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SillySheep7.Wpf.UI.Controls;

/// <summary>
/// 스큐어모피즘 스타일의 회전 노브 라디오 버튼 컨트롤입니다.
/// A skeuomorphic style rotating knob radio button control.
/// </summary>
public sealed class SillySheep7 : Selector
{
    static SillySheep7()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SillySheep7),
            new FrameworkPropertyMetadata(typeof(SillySheep7)));
    }

    /// <summary>
    /// 노브의 회전 각도를 가져옵니다 (읽기 전용).
    /// Gets the rotation angle of the knob (read-only).
    /// </summary>
    public double KnobAngle
    {
        get => (double)GetValue(KnobAngleProperty);
        private set => SetValue(KnobAnglePropertyKey, value);
    }

    private static readonly DependencyPropertyKey KnobAnglePropertyKey =
        DependencyProperty.RegisterReadOnly(
            nameof(KnobAngle),
            typeof(double),
            typeof(SillySheep7),
            new FrameworkPropertyMetadata(0.0));

    public static readonly DependencyProperty KnobAngleProperty = KnobAnglePropertyKey.DependencyProperty;

    /// <summary>
    /// 선택된 인덱스가 변경될 때 호출됩니다.
    /// Called when the selected index changes.
    /// </summary>
    protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    {
        base.OnSelectionChanged(e);
        UpdateKnobAngle();
    }

    private void UpdateKnobAngle()
    {
        // 인덱스 0~4에 대해 -60, -35, 0, 35, 60도 회전
        // Rotation of -60, -35, 0, 35, 60 degrees for index 0~4
        KnobAngle = SelectedIndex switch
        {
            0 => -60.0,
            1 => -35.0,
            2 => 0.0,
            3 => 35.0,
            4 => 60.0,
            _ => 0.0
        };
    }
}
