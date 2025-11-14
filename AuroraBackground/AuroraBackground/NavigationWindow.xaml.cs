using System.Windows;
using System.Windows.Navigation;

namespace AuroraBackground;

public partial class NavigationWindow : Window
{
    public NavigationWindow()
    {
        InitializeComponent();

        // Navigate to HomePage on startup
        MainFrame.Navigate(new HomePage());
    }

    private void MainFrame_Navigated(object sender, NavigationEventArgs e)
    {
        // Remove navigation history to prevent back button showing
        if (MainFrame.NavigationService.CanGoBack)
        {
            MainFrame.NavigationService.RemoveBackEntry();
        }
    }
}
