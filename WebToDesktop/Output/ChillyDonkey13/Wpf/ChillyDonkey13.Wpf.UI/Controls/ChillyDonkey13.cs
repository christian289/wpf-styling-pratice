using System.Windows;
using System.Windows.Controls;

namespace ChillyDonkey13.Wpf.UI.Controls;

public sealed class ChillyDonkey13 : Button
{
    static ChillyDonkey13()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ChillyDonkey13),
            new FrameworkPropertyMetadata(typeof(ChillyDonkey13)));
    }
}
