using System.Windows;
using System.Windows.Controls;

namespace SpottyShrimp35.Wpf.UI.Controls;

public sealed class SpottyShrimp35 : Control
{
    static SpottyShrimp35()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpottyShrimp35),
            new FrameworkPropertyMetadata(typeof(SpottyShrimp35)));
    }
}
