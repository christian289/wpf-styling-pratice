using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AuroraBackground;

public partial class OriginalAuroraPage : Page
{
    public OriginalAuroraPage()
    {
        InitializeComponent();
        Focusable = true;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        // Focus the page so it can receive keyboard input
        Focus();

        // Start all aurora orbital animations
        var orbit1 = (Storyboard)FindResource("AuroraOrbit1");
        orbit1.Begin();

        var orbit2 = (Storyboard)FindResource("AuroraOrbit2");
        orbit2.Begin();

        var orbit3 = (Storyboard)FindResource("AuroraOrbit3");
        orbit3.Begin();

        var orbit4 = (Storyboard)FindResource("AuroraOrbit4");
        orbit4.Begin();

        var orbit5 = (Storyboard)FindResource("AuroraOrbit5");
        orbit5.Begin();

        var orbit6 = (Storyboard)FindResource("AuroraOrbit6");
        orbit6.Begin();

        // Start pulsating animation
        var pulsate = (Storyboard)FindResource("PulsateAnimation");
        pulsate.Begin();
    }

    private void Page_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            NavigationService?.Navigate(new HomePage());
        }
    }
}
