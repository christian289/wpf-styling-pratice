using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace PhotoBoothCarousel;

public partial class MainWindow : Window
{
    private DispatcherTimer _carouselTimer;
    private int _currentIndex = 0;
    private readonly List<CarouselCard> _cards = new();

    public MainWindow()
    {
        InitializeComponent();
        InitializeCarousel();
    }

    private void InitializeCarousel()
    {
        // Initialize card positions and transforms
        _cards.Add(new CarouselCard
        {
            Border = Card1,
            ScaleTransform = Card1Scale,
            RotateTransform = Card1Rotate,
            TranslateTransform = Card1Translate,
            BaseLeft = 100,
            BaseTop = 100
        });

        _cards.Add(new CarouselCard
        {
            Border = Card2,
            ScaleTransform = Card2Scale,
            RotateTransform = Card2Rotate,
            TranslateTransform = Card2Translate,
            BaseLeft = 510,
            BaseTop = 100
        });

        _cards.Add(new CarouselCard
        {
            Border = Card3,
            ScaleTransform = Card3Scale,
            RotateTransform = Card3Rotate,
            TranslateTransform = Card3Translate,
            BaseLeft = 920,
            BaseTop = 100
        });

        // Setup carousel timer
        _carouselTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(4)
        };
        _carouselTimer.Tick += CarouselTimer_Tick;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Start background floating animation
        var floatingStoryboard = (Storyboard)FindResource("FloatingAnimation");
        floatingStoryboard.Begin();

        // Start pulse animation
        var pulseStoryboard = (Storyboard)FindResource("PulseAnimation");
        pulseStoryboard.Begin();

        // Start carousel
        _carouselTimer.Start();

        // Initial card entrance animation
        AnimateCardsEntrance();
    }

    private void AnimateCardsEntrance()
    {
        var duration = TimeSpan.FromSeconds(1.2);

        for (int i = 0; i < _cards.Count; i++)
        {
            var card = _cards[i];
            var delay = TimeSpan.FromMilliseconds(i * 200);

            // Scale animation
            var scaleAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = duration,
                BeginTime = delay,
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.5 }
            };

            // Opacity animation
            var opacityAnim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = duration,
                BeginTime = delay
            };

            // Rotation animation
            var rotateAnim = new DoubleAnimation
            {
                From = -15,
                To = 0,
                Duration = duration,
                BeginTime = delay,
                EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut }
            };

            card.ScaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, scaleAnim);
            card.ScaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, scaleAnim);
            card.Border.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            card.RotateTransform.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, rotateAnim);
        }
    }

    private void CarouselTimer_Tick(object? sender, EventArgs e)
    {
        AnimateCarouselRotation();
    }

    private void AnimateCarouselRotation()
    {
        _currentIndex = (_currentIndex + 1) % _cards.Count;

        var duration = TimeSpan.FromSeconds(1.5);
        var easing = new CubicEase { EasingMode = EasingMode.EaseInOut };

        for (int i = 0; i < _cards.Count; i++)
        {
            var card = _cards[i];
            int position = (i - _currentIndex + _cards.Count) % _cards.Count;

            double targetScale;
            double targetOpacity;
            double targetRotation;
            double targetTranslateY;
            int zIndex;

            // Position 1 (Center/Focus)
            if (position == 1)
            {
                targetScale = 1.15;
                targetOpacity = 1.0;
                targetRotation = 0;
                targetTranslateY = -30;
                zIndex = 3;
            }
            // Position 0 (Left)
            else if (position == 0)
            {
                targetScale = 0.9;
                targetOpacity = 0.7;
                targetRotation = -5;
                targetTranslateY = 20;
                zIndex = 2;
            }
            // Position 2 (Right)
            else
            {
                targetScale = 0.9;
                targetOpacity = 0.7;
                targetRotation = 5;
                targetTranslateY = 20;
                zIndex = 1;
            }

            // Apply Z-Index
            System.Windows.Controls.Panel.SetZIndex(card.Border, zIndex);

            // Animate scale
            var scaleXAnim = new DoubleAnimation
            {
                To = targetScale,
                Duration = duration,
                EasingFunction = easing
            };
            var scaleYAnim = new DoubleAnimation
            {
                To = targetScale,
                Duration = duration,
                EasingFunction = easing
            };

            // Animate opacity
            var opacityAnim = new DoubleAnimation
            {
                To = targetOpacity,
                Duration = duration,
                EasingFunction = easing
            };

            // Animate rotation
            var rotateAnim = new DoubleAnimation
            {
                To = targetRotation,
                Duration = duration,
                EasingFunction = easing
            };

            // Animate vertical translation
            var translateYAnim = new DoubleAnimation
            {
                To = targetTranslateY,
                Duration = duration,
                EasingFunction = easing
            };

            card.ScaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, scaleXAnim);
            card.ScaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, scaleYAnim);
            card.Border.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            card.RotateTransform.BeginAnimation(System.Windows.Media.RotateTransform.AngleProperty, rotateAnim);
            card.TranslateTransform.BeginAnimation(System.Windows.Media.TranslateTransform.YProperty, translateYAnim);

            // Add subtle wobble effect for the focused card
            if (position == 1)
            {
                AddWobbleEffect(card);
            }
        }
    }

    private void AddWobbleEffect(CarouselCard card)
    {
        var wobbleDuration = TimeSpan.FromSeconds(0.5);
        var wobbleStoryboard = new Storyboard();

        var rotateAnim = new DoubleAnimationUsingKeyFrames();
        rotateAnim.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.Zero)));
        rotateAnim.KeyFrames.Add(new EasingDoubleKeyFrame(2, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.15)))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut }
        });
        rotateAnim.KeyFrames.Add(new EasingDoubleKeyFrame(-2, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.30)))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
        });
        rotateAnim.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(wobbleDuration))
        {
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseIn }
        });

        Storyboard.SetTarget(rotateAnim, card.RotateTransform);
        Storyboard.SetTargetProperty(rotateAnim, new PropertyPath(System.Windows.Media.RotateTransform.AngleProperty));
        wobbleStoryboard.Children.Add(rotateAnim);

        wobbleStoryboard.Begin();
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        // Animate button press
        var scaleDown = new DoubleAnimation
        {
            To = 0.95,
            Duration = TimeSpan.FromMilliseconds(100),
            AutoReverse = true
        };

        var transform = (System.Windows.Media.ScaleTransform)StartButton.RenderTransform;
        transform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, scaleDown);
        transform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, scaleDown);

        // Show message (in real app, navigate to photo booth screen)
        MessageBox.Show("사진 촬영을 시작합니다! 🎉\n\n실제 앱에서는 여기서 촬영 화면으로 전환됩니다.",
                       "Welcome to MOODIT",
                       MessageBoxButton.OK,
                       MessageBoxImage.Information);
    }

    protected override void OnClosed(EventArgs e)
    {
        _carouselTimer?.Stop();
        base.OnClosed(e);
    }

    // Helper class to manage card data
    private class CarouselCard
    {
        public System.Windows.Controls.Border Border { get; set; } = null!;
        public System.Windows.Media.ScaleTransform ScaleTransform { get; set; } = null!;
        public System.Windows.Media.RotateTransform RotateTransform { get; set; } = null!;
        public System.Windows.Media.TranslateTransform TranslateTransform { get; set; } = null!;
        public double BaseLeft { get; set; }
        public double BaseTop { get; set; }
    }
}
