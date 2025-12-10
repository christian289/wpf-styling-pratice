using System.Windows;
using System.Windows.Controls;

namespace Gallery.OpenSilver.Controls
{
    /// <summary>
    /// Radio 버튼 스타일 탭 선택기 컨트롤
    /// Radio button style tab selector control
    /// </summary>
    public class RudeMouse79 : ListBox
    {
        public RudeMouse79()
        {
            DefaultStyleKey = typeof(RudeMouse79);
        }
    }

    /// <summary>
    /// RudeMouse79 컨트롤의 개별 아이템
    /// Individual item for RudeMouse79 control
    /// </summary>
    public class RudeMouse79Item : ListBoxItem
    {
        public RudeMouse79Item()
        {
            DefaultStyleKey = typeof(RudeMouse79Item);
        }
    }
}
