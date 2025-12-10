using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Gallery.OpenSilver.Controls
{
    /// <summary>
    /// 회전하는 그라데이션 테두리 카드 컨트롤
    /// Rotating gradient border card control
    /// </summary>
    public class DangerousQuail58 : ContentControl
    {
        private Rectangle _gradientBar;
        private Storyboard _rotationStoryboard;

        public DangerousQuail58()
        {
            DefaultStyleKey = typeof(DangerousQuail58);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // GradientBar 찾기
            // Find GradientBar
            _gradientBar = GetTemplateChild("GradientBar") as Rectangle;

            if (_gradientBar != null)
            {
                StartRotationAnimation();
            }
        }

        private void StartRotationAnimation()
        {
            // Storyboard를 사용한 회전 애니메이션
            // Rotation animation using Storyboard
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = new Duration(TimeSpan.FromSeconds(3)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTarget(animation, _gradientBar);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            _rotationStoryboard = new Storyboard();
            _rotationStoryboard.Children.Add(animation);
            _rotationStoryboard.Begin();
        }
    }
}
