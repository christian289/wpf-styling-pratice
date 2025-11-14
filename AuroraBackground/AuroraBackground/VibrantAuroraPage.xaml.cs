using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AuroraBackground;

public partial class VibrantAuroraPage : Page
{
    public VibrantAuroraPage()
    {
        InitializeComponent();
        Focusable = true;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        // Focus the page so it can receive keyboard input
        Focus();

        // Start all orbital animations
        for (int i = 1; i <= 12; i++)
        {
            var storyboard = (Storyboard)FindResource($"Orbit{i}");
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
