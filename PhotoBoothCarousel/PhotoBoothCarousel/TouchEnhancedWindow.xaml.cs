using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace PhotoBoothCarousel;

public partial class TouchEnhancedWindow : Window
{
    private DispatcherTimer _autoScrollTimer;
    private int _currentCardIndex = 0;
    private readonly List<TouchCard> _cards = new();
    private Point _touchStartPoint;
    private bool _isDragging = false;
    private double _currentOffset = 0;
    private const double SwipeThreshold = 100;

    public TouchEnhancedWindow()
    {
        InitializeComponent();
        InitializeTouchCards();
    }

    private void InitializeTouchCards()
    {
        _cards.Add(new TouchCard
        {
            Border = TouchCard1,
            ScaleTransform = TouchCard1Scale,
            RotateTransform = TouchCard1Rotate,
            TranslateTransform = TouchCard1Translate,
            BaseLeft = 250,
            BaseTop = 110
        });

        _cards.Add(new TouchCard
        {
            Border = TouchCard2,
            ScaleTransform = TouchCard2Scale,
            RotateTransform = TouchCard2Rotate,
            TranslateTransform = TouchCard2Translate,
            BaseLeft = 750,
            BaseTop = 110
        });

        _cards.Add(new TouchCard
        {
            Border = TouchCard3,
            ScaleTransform = TouchCard3Scale,
            RotateTransform = TouchCard3Rotate,
            TranslateTransform = TouchCard3Translate,
            BaseLeft = 1250,
            BaseTop = 110
        });

        // Auto-scroll timer
        _autoScrollTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(5)
        };
        _autoScrollTimer.Tick += AutoScrollTimer_Tick;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Start background animations
        var shimmerStoryboard = (Storyboard)FindResource("ShimmerAnimation");
        shimmerStoryboard.Begin();

        var particleStoryboard = (Storyboard)FindResource("ParticleAnimation");
        particleStoryboard.Begin();

        var glowStoryboard = (Storyboard)FindResource("GlowPulseAnimation");
        glowStoryboard.Begin();

        // Entrance animation
        AnimateCardsEntrance();

        // Start auto-scroll
        _autoScrollTimer.Start();

        // Start button pulse
        StartButtonPulseAnimation();

        // Update initial indicators
        UpdateIndicators();
    }

    private void AnimateCardsEntrance()
    {
        var duration = TimeSpan.FromSeconds(1.5);

        for (int i = 0; i < _cards.Count; i++)
        {
            var card = _cards[i];
            var delay = TimeSpan.FromMilliseconds(i * 250);

            // Scale animation with bounce
            var scaleAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = duration,
                BeginTime = delay,
                EasingFunction = new ElasticEase
                {
                    EasingMode = EasingMode.EaseOut,
                    Oscillations = 1,
                    Springiness = 5
                }
            };

            // Opacity animation
            var opacityAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = duration,
                BeginTime = delay
            };

            // Y translation from top
            var translateYAnim = new DoubleAnimation
            {
                From = -200,
                To = 0,
                Duration = duration,
                BeginTime = delay,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            card.ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            card.ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
            card.Border.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            card.TranslateTransform.BeginAnimation(TranslateTransform.YProperty, translateYAnim);
        }
    }

    private void StartButtonPulseAnimation()
    {
        var pulseStoryboard = new Storyboard { RepeatBehavior = RepeatBehavior.Forever };

        var scaleXAnim = new DoubleAnimationUsingKeyFrames();
        scaleXAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.0, KeyTime.FromTimeSpan(TimeSpan.Zero)));
        scaleXAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.12, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.5)))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
        });
        scaleXAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3)))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
        });

        var scaleYAnim = scaleXAnim.Clone();

        Storyboard.SetTarget(scaleXAnim, TouchStartButton);
        Storyboard.SetTargetProperty(scaleXAnim, new PropertyPath("RenderTransform.ScaleX"));
        Storyboard.SetTarget(scaleYAnim, TouchStartButton);
        Storyboard.SetTargetProperty(scaleYAnim, new PropertyPath("RenderTransform.ScaleY"));

        pulseStoryboard.Children.Add(scaleXAnim);
        pulseStoryboard.Children.Add(scaleYAnim);
        pulseStoryboard.Begin();
    }

    private void AutoScrollTimer_Tick(object? sender, EventArgs e)
    {
        NavigateToCard((_currentCardIndex + 1) % _cards.Count);
    }

    private void Grid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
    {
        if (!_isDragging)
        {
            _isDragging = true;
            _autoScrollTimer.Stop();
        }

        // Get horizontal drag amount
        double deltaX = e.DeltaManipulation.Translation.X;
        _currentOffset += deltaX;

        // Apply drag with resistance
        ApplyDragOffset(_currentOffset);
    }

    private void Grid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
    {
        if (!_isDragging) return;

        _isDragging = false;
        double totalDeltaX = e.TotalManipulation.Translation.X;

        // Determine if swipe was significant enough
        if (Math.Abs(totalDeltaX) > SwipeThreshold)
        {
            if (totalDeltaX > 0)
            {
                // Swipe right - go to previous
                NavigateToCard((_currentCardIndex - 1 + _cards.Count) % _cards.Count);
            }
            else
            {
                // Swipe left - go to next
                NavigateToCard((_currentCardIndex + 1) % _cards.Count);
            }
        }
        else
        {
            // Return to current position
            NavigateToCard(_currentCardIndex);
        }

        _currentOffset = 0;
        _autoScrollTimer.Start();
    }

    private void ApplyDragOffset(double offset)
    {
        // Apply immediate visual feedback during drag
        for (int i = 0; i < _cards.Count; i++)
        {
            var card = _cards[i];
            double dragOffset = offset * 0.5; // Resistance factor
            card.TranslateTransform.X = dragOffset;
        }
    }

    private void NavigateToCard(int targetIndex)
    {
        _currentCardIndex = targetIndex;
        var duration = TimeSpan.FromSeconds(0.8);
        var easing = new CubicEase { EasingMode = EasingMode.EaseInOut };

        for (int i = 0; i < _cards.Count; i++)
        {
            var card = _cards[i];
            int relativePosition = i - _currentCardIndex;

            // Normalize position
            if (relativePosition > 1) relativePosition -= _cards.Count;
            if (relativePosition < -1) relativePosition += _cards.Count;

            double targetScale;
            double targetOpacity;
            double targetRotation;
            double targetTranslateX;
            double targetTranslateY;
            int zIndex;

            switch (relativePosition)
            {
                case 0: // Center (focused)
                    targetScale = 1.15;
                    targetOpacity = 1.0;
                    targetRotation = 0;
                    targetTranslateX = 0;
                    targetTranslateY = -40;
                    zIndex = 3;
                    break;

                case -1: // Left
                    targetScale = 0.85;
                    targetOpacity = 0.6;
                    targetRotation = -8;
                    targetTranslateX = -50;
                    targetTranslateY = 30;
                    zIndex = 2;
                    break;

                case 1: // Right
                    targetScale = 0.85;
                    targetOpacity = 0.6;
                    targetRotation = 8;
                    targetTranslateX = 50;
                    targetTranslateY = 30;
                    zIndex = 1;
                    break;

                default: // Far away
                    targetScale = 0.7;
                    targetOpacity = 0.3;
                    targetRotation = relativePosition > 0 ? 15 : -15;
                    targetTranslateX = relativePosition > 0 ? 100 : -100;
                    targetTranslateY = 50;
                    zIndex = 0;
                    break;
            }

            // Set Z-Index
            System.Windows.Controls.Panel.SetZIndex(card.Border, zIndex);

            // Animate scale
            var scaleXAnim = new DoubleAnimation(targetScale, duration) { EasingFunction = easing };
            var scaleYAnim = new DoubleAnimation(targetScale, duration) { EasingFunction = easing };

            // Animate opacity
            var opacityAnim = new DoubleAnimation(targetOpacity, duration) { EasingFunction = easing };

            // Animate rotation
            var rotateAnim = new DoubleAnimation(targetRotation, duration) { EasingFunction = easing };

            // Animate translation
            var translateXAnim = new DoubleAnimation(targetTranslateX, duration) { EasingFunction = easing };
            var translateYAnim = new DoubleAnimation(targetTranslateY, duration) { EasingFunction = easing };

            card.ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleXAnim);
            card.ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleYAnim);
            card.Border.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            card.RotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);
            card.TranslateTransform.BeginAnimation(TranslateTransform.XProperty, translateXAnim);
            card.TranslateTransform.BeginAnimation(TranslateTransform.YProperty, translateYAnim);

            // Add special effect for focused card
            if (relativePosition == 0)
            {
                AddFocusEffect(card);
            }
        }

        UpdateIndicators();
    }

    private void AddFocusEffect(TouchCard card)
    {
        // Subtle bounce effect
        var bounceStoryboard = new Storyboard();

        var bounceAnim = new DoubleAnimationUsingKeyFrames();
        bounceAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.15, KeyTime.FromTimeSpan(TimeSpan.Zero)));
        bounceAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.20, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.2)))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut }
        });
        bounceAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.15, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.4)))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseIn }
        });

        Storyboard.SetTarget(bounceAnim, card.ScaleTransform);
        Storyboard.SetTargetProperty(bounceAnim, new PropertyPath(ScaleTransform.ScaleXProperty));

        var bounceAnimY = bounceAnim.Clone();
        Storyboard.SetTarget(bounceAnimY, card.ScaleTransform);
        Storyboard.SetTargetProperty(bounceAnimY, new PropertyPath(ScaleTransform.ScaleYProperty));

        bounceStoryboard.Children.Add(bounceAnim);
        bounceStoryboard.Children.Add(bounceAnimY);
        bounceStoryboard.Begin();
    }

    private void UpdateIndicators()
    {
        var indicators = new[] { Indicator1, Indicator2, Indicator3 };

        for (int i = 0; i < indicators.Length; i++)
        {
            var targetOpacity = i == _currentCardIndex ? 0.9 : 0.3;
            var targetScale = i == _currentCardIndex ? 1.3 : 1.0;

            var opacityAnim = new DoubleAnimation(targetOpacity, TimeSpan.FromSeconds(0.3));
            var scaleAnim = new DoubleAnimation(targetScale, TimeSpan.FromSeconds(0.3))
            {
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut }
            };

            indicators[i].BeginAnimation(UIElement.OpacityProperty, opacityAnim);

            var scaleTransform = new ScaleTransform();
            indicators[i].RenderTransform = scaleTransform;
            indicators[i].RenderTransformOrigin = new Point(0.5, 0.5);

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        // Stop all animations
        _autoScrollTimer.Stop();

        // Button press animation
        var pressStoryboard = new Storyboard();

        var scaleDown = new DoubleAnimation(0.92, TimeSpan.FromMilliseconds(100));
        var scaleUp = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(200))
        {
            BeginTime = TimeSpan.FromMilliseconds(100)
        };

        Storyboard.SetTarget(scaleDown, TouchStartButton);
        Storyboard.SetTargetProperty(scaleDown, new PropertyPath("RenderTransform.ScaleX"));

        var scaleDownY = scaleDown.Clone();
        Storyboard.SetTarget(scaleDownY, TouchStartButton);
        Storyboard.SetTargetProperty(scaleDownY, new PropertyPath("RenderTransform.ScaleY"));

        var scaleUpY = scaleUp.Clone();
        Storyboard.SetTarget(scaleUpY, TouchStartButton);
        Storyboard.SetTargetProperty(scaleUpY, new PropertyPath("RenderTransform.ScaleY"));

        pressStoryboard.Children.Add(scaleDown);
        pressStoryboard.Children.Add(scaleDownY);
        pressStoryboard.Children.Add(scaleUp);
        pressStoryboard.Children.Add(scaleUpY);

        pressStoryboard.Completed += (s, args) =>
        {
            var selectedPackage = _currentCardIndex switch
            {
                0 => "클래식 컷 (₩8,000)",
                1 => "비디오 부스 (₩10,000)",
                2 => "프리미엄 패키지 (₩15,000)",
                _ => "Unknown"
            };

            MessageBox.Show($"선택하신 패키지: {selectedPackage}\n\n사진 촬영을 시작합니다! 📸✨",
                           "MOODIT Photo Booth",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
        };

        pressStoryboard.Begin();
    }

    protected override void OnClosed(EventArgs e)
    {
        _autoScrollTimer?.Stop();
        base.OnClosed(e);
    }

    // Helper class
    private class TouchCard
    {
        public System.Windows.Controls.Border Border { get; set; } = null!;
        public ScaleTransform ScaleTransform { get; set; } = null!;
        public RotateTransform RotateTransform { get; set; } = null!;
        public TranslateTransform TranslateTransform { get; set; } = null!;
        public double BaseLeft { get; set; }
        public double BaseTop { get; set; }
    }
}
