using System.Windows;
using System.Windows.Controls;

namespace WisePanda94.Wpf.UI.Controls;

public sealed class WisePanda94 : Button
{
    static WisePanda94()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WisePanda94),
            new FrameworkPropertyMetadata(typeof(WisePanda94)));
    }
}
