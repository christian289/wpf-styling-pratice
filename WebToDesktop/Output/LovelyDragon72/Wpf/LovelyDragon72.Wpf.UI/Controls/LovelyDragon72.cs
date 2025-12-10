using System.Windows;
using System.Windows.Controls;

namespace LovelyDragon72.Wpf.UI.Controls;

/// <summary>
/// 프로필 카드 컨트롤 - 호버 시 애니메이션 효과가 있는 About Me 카드
/// Profile card control - About Me card with hover animation effect
/// </summary>
public sealed class LovelyDragon72 : ContentControl
{
    /// <summary>
    /// 프로필 이름 (첫 번째 줄)
    /// Profile name (first line)
    /// </summary>
    public static readonly DependencyProperty FirstNameProperty =
        DependencyProperty.Register(
            nameof(FirstName),
            typeof(string),
            typeof(LovelyDragon72),
            new PropertyMetadata("John"));

    /// <summary>
    /// 프로필 이름 (두 번째 줄)
    /// Profile name (second line)
    /// </summary>
    public static readonly DependencyProperty LastNameProperty =
        DependencyProperty.Register(
            nameof(LastName),
            typeof(string),
            typeof(LovelyDragon72),
            new PropertyMetadata("Doe"));

    /// <summary>
    /// 프로필 이미지 소스
    /// Profile image source
    /// </summary>
    public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register(
            nameof(ImageSource),
            typeof(object),
            typeof(LovelyDragon72),
            new PropertyMetadata(null));

    static LovelyDragon72()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(LovelyDragon72),
            new FrameworkPropertyMetadata(typeof(LovelyDragon72)));
    }

    public string FirstName
    {
        get => (string)GetValue(FirstNameProperty);
        set => SetValue(FirstNameProperty, value);
    }

    public string LastName
    {
        get => (string)GetValue(LastNameProperty);
        set => SetValue(LastNameProperty, value);
    }

    public object? ImageSource
    {
        get => GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
}
