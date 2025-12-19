using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SlipperyDragonfly42.Wpf.UI.Controls;

/// <summary>
/// 로그인 폼 커스텀 컨트롤
/// Login form custom control
/// </summary>
public sealed class SlipperyDragonfly42 : Control
{
    static SlipperyDragonfly42()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SlipperyDragonfly42),
            new FrameworkPropertyMetadata(typeof(SlipperyDragonfly42)));
    }

    #region Dependency Properties

    // Title 속성
    // Title property
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata("Welcome Back"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    // Subtitle 속성
    // Subtitle property
    public static readonly DependencyProperty SubtitleProperty =
        DependencyProperty.Register(
            nameof(Subtitle),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata("Sign in to continue"));

    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    // Email 속성
    // Email property
    public static readonly DependencyProperty EmailProperty =
        DependencyProperty.Register(
            nameof(Email),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Email
    {
        get => (string)GetValue(EmailProperty);
        set => SetValue(EmailProperty, value);
    }

    // Password 속성
    // Password property
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(
            nameof(Password),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    // RememberMe 속성
    // RememberMe property
    public static readonly DependencyProperty RememberMeProperty =
        DependencyProperty.Register(
            nameof(RememberMe),
            typeof(bool),
            typeof(SlipperyDragonfly42),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool RememberMe
    {
        get => (bool)GetValue(RememberMeProperty);
        set => SetValue(RememberMeProperty, value);
    }

    // SignInCommand 속성
    // SignInCommand property
    public static readonly DependencyProperty SignInCommandProperty =
        DependencyProperty.Register(
            nameof(SignInCommand),
            typeof(ICommand),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata(null));

    public ICommand? SignInCommand
    {
        get => (ICommand?)GetValue(SignInCommandProperty);
        set => SetValue(SignInCommandProperty, value);
    }

    // ForgotPasswordCommand 속성
    // ForgotPasswordCommand property
    public static readonly DependencyProperty ForgotPasswordCommandProperty =
        DependencyProperty.Register(
            nameof(ForgotPasswordCommand),
            typeof(ICommand),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata(null));

    public ICommand? ForgotPasswordCommand
    {
        get => (ICommand?)GetValue(ForgotPasswordCommandProperty);
        set => SetValue(ForgotPasswordCommandProperty, value);
    }

    // SignUpCommand 속성
    // SignUpCommand property
    public static readonly DependencyProperty SignUpCommandProperty =
        DependencyProperty.Register(
            nameof(SignUpCommand),
            typeof(ICommand),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata(null));

    public ICommand? SignUpCommand
    {
        get => (ICommand?)GetValue(SignUpCommandProperty);
        set => SetValue(SignUpCommandProperty, value);
    }

    // EmailPlaceholder 속성
    // EmailPlaceholder property
    public static readonly DependencyProperty EmailPlaceholderProperty =
        DependencyProperty.Register(
            nameof(EmailPlaceholder),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata("Email address"));

    public string EmailPlaceholder
    {
        get => (string)GetValue(EmailPlaceholderProperty);
        set => SetValue(EmailPlaceholderProperty, value);
    }

    // PasswordPlaceholder 속성
    // PasswordPlaceholder property
    public static readonly DependencyProperty PasswordPlaceholderProperty =
        DependencyProperty.Register(
            nameof(PasswordPlaceholder),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata("Password"));

    public string PasswordPlaceholder
    {
        get => (string)GetValue(PasswordPlaceholderProperty);
        set => SetValue(PasswordPlaceholderProperty, value);
    }

    // SignInButtonText 속성
    // SignInButtonText property
    public static readonly DependencyProperty SignInButtonTextProperty =
        DependencyProperty.Register(
            nameof(SignInButtonText),
            typeof(string),
            typeof(SlipperyDragonfly42),
            new PropertyMetadata("Sign In"));

    public string SignInButtonText
    {
        get => (string)GetValue(SignInButtonTextProperty);
        set => SetValue(SignInButtonTextProperty, value);
    }

    #endregion
}
