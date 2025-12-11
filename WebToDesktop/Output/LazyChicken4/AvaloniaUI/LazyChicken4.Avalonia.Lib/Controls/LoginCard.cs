using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace LazyChicken4.Avalonia.Lib.Controls;

/// <summary>
/// 로그인 폼 카드 컨트롤
/// Login form card control
/// </summary>
public sealed class LoginCard : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(Title), "Login");

    public static readonly StyledProperty<string> SubtitleProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(Subtitle), "Enter details below.");

    public static readonly StyledProperty<string> UsernameProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(Username), string.Empty);

    public static readonly StyledProperty<string> PasswordProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(Password), string.Empty);

    public static readonly StyledProperty<bool> RememberMeProperty =
        AvaloniaProperty.Register<LoginCard, bool>(nameof(RememberMe), false);

    public static readonly StyledProperty<string> UsernamePlaceholderProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(UsernamePlaceholder), "Username");

    public static readonly StyledProperty<string> PasswordPlaceholderProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(PasswordPlaceholder), "Password");

    public static readonly StyledProperty<string> LoginButtonTextProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(LoginButtonText), "login");

    public static readonly StyledProperty<string> ForgotPasswordTextProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(ForgotPasswordText), "Forgot Password");

    public static readonly StyledProperty<string> SignUpTextProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(SignUpText), "Sign Up");

    public static readonly StyledProperty<string> AccountQuestionTextProperty =
        AvaloniaProperty.Register<LoginCard, string>(nameof(AccountQuestionText), "Have an account?");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Subtitle
    {
        get => GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public string Username
    {
        get => GetValue(UsernameProperty);
        set => SetValue(UsernameProperty, value);
    }

    public string Password
    {
        get => GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    public bool RememberMe
    {
        get => GetValue(RememberMeProperty);
        set => SetValue(RememberMeProperty, value);
    }

    public string UsernamePlaceholder
    {
        get => GetValue(UsernamePlaceholderProperty);
        set => SetValue(UsernamePlaceholderProperty, value);
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

    public string SignUpText
    {
        get => GetValue(SignUpTextProperty);
        set => SetValue(SignUpTextProperty, value);
    }

    public string AccountQuestionText
    {
        get => GetValue(AccountQuestionTextProperty);
        set => SetValue(AccountQuestionTextProperty, value);
    }
}
