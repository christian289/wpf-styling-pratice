using System.Windows;
using System.Windows.Controls;

namespace AuroraBackground;

public partial class HomePage : Page
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void NavigateToOriginalAurora(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OriginalAuroraPage());
    }

    private void NavigateToFullScreenAurora(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new FullScreenAuroraPage());
    }

    private void NavigateToVibrantAurora(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new VibrantAuroraPage());
    }

    private void NavigateToDeepAurora(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new DeepAuroraPage());
    }
}
