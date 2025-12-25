using System.Windows;
using System.Windows.Controls;

namespace RareCobra61.Wpf.UI.Controls;

/// <summary>
/// PasswordBox에 대한 첨부 속성 헬퍼
/// Attached property helper for PasswordBox
/// </summary>
public static class PasswordBoxHelper
{
    public static readonly DependencyProperty AttachProperty =
        DependencyProperty.RegisterAttached(
            "Attach",
            typeof(bool),
            typeof(PasswordBoxHelper),
            new PropertyMetadata(false, OnAttachChanged));

    public static readonly DependencyProperty HasPasswordProperty =
        DependencyProperty.RegisterAttached(
            "HasPassword",
            typeof(bool),
            typeof(PasswordBoxHelper),
            new PropertyMetadata(false));

    public static bool GetAttach(DependencyObject obj) =>
        (bool)obj.GetValue(AttachProperty);

    public static void SetAttach(DependencyObject obj, bool value) =>
        obj.SetValue(AttachProperty, value);

    public static bool GetHasPassword(DependencyObject obj) =>
        (bool)obj.GetValue(HasPasswordProperty);

    public static void SetHasPassword(DependencyObject obj, bool value) =>
        obj.SetValue(HasPasswordProperty, value);

    private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not PasswordBox passwordBox)
            return;

        if ((bool)e.NewValue)
        {
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            SetHasPassword(passwordBox, passwordBox.Password.Length > 0);
        }
        else
        {
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
        }
    }

    private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            SetHasPassword(passwordBox, passwordBox.Password.Length > 0);
        }
    }
}
