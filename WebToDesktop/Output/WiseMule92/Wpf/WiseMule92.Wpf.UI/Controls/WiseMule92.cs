using System.Windows;
using System.Windows.Controls;

namespace WiseMule92.Wpf.UI.Controls;

public sealed class WiseMule92 : Button
{
    static WiseMule92()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WiseMule92),
            new FrameworkPropertyMetadata(typeof(WiseMule92)));
    }
}
