using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace RottenCatfish64.Avalonia.Lib.Controls;

/// <summary>
/// CSS repeating-linear-gradient 패턴을 구현한 커스텀 컨트롤
/// A custom control implementing CSS repeating-linear-gradient pattern
/// </summary>
public sealed class RottenCatfish64 : Control
{
    private static readonly Color PrimaryColor = Color.Parse("#ff7e5f");
    private static readonly Color SecondaryColor = Color.Parse("#3f51b5");
    private const double StripeWidth = 10.0;

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var bounds = new Rect(0, 0, Bounds.Width, Bounds.Height);

        if (bounds.Width <= 0 || bounds.Height <= 0)
            return;

        // CSS repeating-linear-gradient를 DrawingContext로 구현
        // 4개의 repeating-linear-gradient가 겹쳐진 패턴
        // Implementing 4 overlapping repeating-linear-gradient patterns

        // 배경색 (두 색상의 블렌드 효과를 위해)
        // Background color for blending effect
        using (context.PushOpacity(1.0))
        {
            // 패턴 1: -45deg gradient
            DrawRepeatingGradient(context, bounds, -45, PrimaryColor, SecondaryColor, 0.4);

            // 패턴 2: 45deg gradient
            DrawRepeatingGradient(context, bounds, 45, SecondaryColor, PrimaryColor, 0.3);

            // 패턴 3: -30deg gradient
            DrawRepeatingGradient(context, bounds, -30, SecondaryColor, PrimaryColor, 0.2);

            // 패턴 4: 30deg gradient
            DrawRepeatingGradient(context, bounds, 30, PrimaryColor, SecondaryColor, 0.3);
        }
    }

    private static void DrawRepeatingGradient(DrawingContext context, Rect bounds, double angle, Color color1, Color color2, double opacity)
    {
        // 각도를 라디안으로 변환
        // Convert angle to radians
        var radians = angle * Math.PI / 180.0;

        // 대각선 길이 계산 (충분히 긴 패턴 생성을 위해)
        // Calculate diagonal length for sufficient pattern coverage
        var diagonal = Math.Sqrt(bounds.Width * bounds.Width + bounds.Height * bounds.Height);

        // 패턴 반복 횟수
        // Number of pattern repetitions
        var repeatCount = (int)Math.Ceiling(diagonal / (StripeWidth * 2)) + 10;

        // 중심점 기준 회전
        // Rotate around center point
        var centerX = bounds.Width / 2;
        var centerY = bounds.Height / 2;

        using (context.PushOpacity(opacity))
        {
            var transform = Matrix.CreateTranslation(-centerX, -centerY) *
                           Matrix.CreateRotation(radians) *
                           Matrix.CreateTranslation(centerX, centerY);

            using (context.PushTransform(transform))
            {
                var startX = centerX - diagonal;

                for (var i = -repeatCount; i <= repeatCount; i++)
                {
                    var x = startX + i * StripeWidth * 2;

                    // Color1 stripe
                    var rect1 = new Rect(x, -diagonal, StripeWidth, diagonal * 3);
                    context.FillRectangle(new SolidColorBrush(color1), rect1);

                    // Color2 stripe
                    var rect2 = new Rect(x + StripeWidth, -diagonal, StripeWidth, diagonal * 3);
                    context.FillRectangle(new SolidColorBrush(color2), rect2);
                }
            }
        }
    }
}
