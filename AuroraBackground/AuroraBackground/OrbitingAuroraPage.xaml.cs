using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AuroraBackground;

public partial class OrbitingAuroraPage : Page
{
    public OrbitingAuroraPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        Focus();

        // Start all 6 orbit animations
        for (int i = 1; i <= 6; i++)
        {
            var storyboard = (Storyboard)FindResource($"OrbitAnimation{i}");
            storyboard.Begin();
        }
    }

    private void Page_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            NavigationService?.GoBack();
        }
    }
}
