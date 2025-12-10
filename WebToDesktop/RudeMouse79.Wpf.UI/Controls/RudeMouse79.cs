using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RudeMouse79.Wpf.UI.Controls;

/// <summary>
/// Radio 버튼 스타일 탭 선택기 컨트롤
/// Radio button style tab selector control
/// </summary>
public sealed class RudeMouse79 : Selector
{
    static RudeMouse79()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RudeMouse79),
            new FrameworkPropertyMetadata(typeof(RudeMouse79)));
    }
}

/// <summary>
/// RudeMouse79 컨트롤의 개별 아이템
/// Individual item for RudeMouse79 control
/// </summary>
public sealed class RudeMouse79Item : ListBoxItem
{
    static RudeMouse79Item()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RudeMouse79Item),
            new FrameworkPropertyMetadata(typeof(RudeMouse79Item)));
    }
}
