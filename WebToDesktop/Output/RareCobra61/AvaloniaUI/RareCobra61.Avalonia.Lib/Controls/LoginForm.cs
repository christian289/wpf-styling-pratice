using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace RareCobra61.Avalonia.Lib.Controls;

/// <summary>
/// 로그인 폼 커스텀 컨트롤
/// Login form custom control
/// </summary>
public sealed class LoginForm : TemplatedControl
{
    public static readonly StyledProperty<string> TitleTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(TitleText), "Welcome back");

    public static readonly StyledProperty<string> EmailPlaceholderProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(EmailPlaceholder), "Email");

    public static readonly StyledProperty<string> PasswordPlaceholderProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(PasswordPlaceholder), "Password");

    public static readonly StyledProperty<string> LoginButtonTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(LoginButtonText), "Log in");

    public static readonly StyledProperty<string> ForgotPasswordTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(ForgotPasswordText), "Forgot Password?");

    public static readonly StyledProperty<string> SignUpLabelTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(SignUpLabelText), "Don't have an account?");

    public static readonly StyledProperty<string> SignUpLinkTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(SignUpLinkText), "Sign up");

    public static readonly StyledProperty<string> AppleLoginTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(AppleLoginText), "Log in with Apple");

    public static readonly StyledProperty<string> GoogleLoginTextProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(GoogleLoginText), "Log in with Google");

    public static readonly StyledProperty<string> EmailProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(Email), string.Empty);

    public static readonly StyledProperty<string> PasswordProperty =
        AvaloniaProperty.Register<LoginForm, string>(nameof(Password), string.Empty);

    public string TitleText
    {
        get => GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public string EmailPlaceholder
    {
        get => GetValue(EmailPlaceholderProperty);
        set => SetValue(EmailPlaceholderProperty, value);
    }

    public string PasswordPlaceholder
    {
        get => GetValue(PasswordPlaceholderProperty);
        set => SetValue(PasswordPlaceholderProperty, value);
    }

    public string LoginButtonText
    {
        get => GetValue(LoginButtonTextProperty);
        set => SetValue(LoginButtonTextProperty, value);
    }

    public string ForgotPasswordText
    {
        get => GetValue(ForgotPasswordTextProperty);
        set => SetValue(ForgotPasswordTextProperty, value);
    }

    public string SignUpLabelText
    {
        get => GetValue(SignUpLabelTextProperty);
        set => SetValue(SignUpLabelTextProperty, value);
    }

    public string SignUpLinkText
    {
        get => GetValue(SignUpLinkTextProperty);
        set => SetValue(SignUpLinkTextProperty, value);
    }

    public string AppleLoginText
    {
        get => GetValue(AppleLoginTextProperty);
        set => SetValue(AppleLoginTextProperty, value);
    }

    public string GoogleLoginText
    {
        get => GetValue(GoogleLoginTextProperty);
        set => SetValue(GoogleLoginTextProperty, value);
    }

    public string Email
    {
        get => GetValue(EmailProperty);
        set => SetValue(EmailProperty, value);
    }

    public string Password
    {
        get => GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }
}
