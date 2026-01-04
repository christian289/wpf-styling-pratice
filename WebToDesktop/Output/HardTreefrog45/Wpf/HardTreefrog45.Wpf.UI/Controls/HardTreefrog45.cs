using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HardTreefrog45.Wpf.UI.Controls;

/// <summary>
/// Facebook 스타일 회원가입 폼 컨트롤
/// Facebook-style sign up form control
/// </summary>
public sealed class HardTreefrog45 : Control
{
    static HardTreefrog45()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(typeof(HardTreefrog45)));
    }

    #region Dependency Properties

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(HardTreefrog45),
            new PropertyMetadata("Sign Up"));

    public static readonly DependencyProperty SubtitleProperty =
        DependencyProperty.Register(nameof(Subtitle), typeof(string), typeof(HardTreefrog45),
            new PropertyMetadata("It's quick and easy."));

    public static readonly DependencyProperty FirstNameProperty =
        DependencyProperty.Register(nameof(FirstName), typeof(string), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SurnameProperty =
        DependencyProperty.Register(nameof(Surname), typeof(string), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty EmailOrPhoneProperty =
        DependencyProperty.Register(nameof(EmailOrPhone), typeof(string), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(nameof(Password), typeof(string), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SelectedDayProperty =
        DependencyProperty.Register(nameof(SelectedDay), typeof(int), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SelectedMonthProperty =
        DependencyProperty.Register(nameof(SelectedMonth), typeof(int), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SelectedYearProperty =
        DependencyProperty.Register(nameof(SelectedYear), typeof(int), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(1990, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SelectedGenderProperty =
        DependencyProperty.Register(nameof(SelectedGender), typeof(string), typeof(HardTreefrog45),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SignUpCommandProperty =
        DependencyProperty.Register(nameof(SignUpCommand), typeof(ICommand), typeof(HardTreefrog45),
            new PropertyMetadata(null));

    public static readonly DependencyProperty CloseCommandProperty =
        DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(HardTreefrog45),
            new PropertyMetadata(null));

    #endregion

    #region Properties

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public string FirstName
    {
        get => (string)GetValue(FirstNameProperty);
        set => SetValue(FirstNameProperty, value);
    }

    public string Surname
    {
        get => (string)GetValue(SurnameProperty);
        set => SetValue(SurnameProperty, value);
    }

    public string EmailOrPhone
    {
        get => (string)GetValue(EmailOrPhoneProperty);
        set => SetValue(EmailOrPhoneProperty, value);
    }

    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    public int SelectedDay
    {
        get => (int)GetValue(SelectedDayProperty);
        set => SetValue(SelectedDayProperty, value);
    }

    public int SelectedMonth
    {
        get => (int)GetValue(SelectedMonthProperty);
        set => SetValue(SelectedMonthProperty, value);
    }

    public int SelectedYear
    {
        get => (int)GetValue(SelectedYearProperty);
        set => SetValue(SelectedYearProperty, value);
    }

    public string SelectedGender
    {
        get => (string)GetValue(SelectedGenderProperty);
        set => SetValue(SelectedGenderProperty, value);
    }

    public ICommand? SignUpCommand
    {
        get => (ICommand?)GetValue(SignUpCommandProperty);
        set => SetValue(SignUpCommandProperty, value);
    }

    public ICommand? CloseCommand
    {
        get => (ICommand?)GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }

    #endregion
}
