using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AuroraBackground;

public partial class DeepAuroraPage : Page
{
    public DeepAuroraPage()
    {
        InitializeComponent();
        Focusable = true;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        // Focus the page so it can receive keyboard input
        Focus();

        // Start all gradient rotation animations
        for (int i = 1; i <= 6; i++)
        {
            var storyboard = (Storyboard)FindResource($"RotateGradient{i}");
            storyboard.Begin();
        }
    }

    private void Page_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            NavigationService?.Navigate(new HomePage());
        }
    }
}
