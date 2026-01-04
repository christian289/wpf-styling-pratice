using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HardTreefrog45.Avalonia.Lib.Controls;

/// <summary>
/// Facebook 스타일의 회원가입 폼 커스텀 컨트롤
/// A Facebook-style sign-up form custom control
/// </summary>
public sealed class SignUpForm : TemplatedControl
{
    public static readonly StyledProperty<string> FirstNameProperty =
        AvaloniaProperty.Register<SignUpForm, string>(nameof(FirstName), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> SurnameProperty =
        AvaloniaProperty.Register<SignUpForm, string>(nameof(Surname), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> EmailOrPhoneProperty =
        AvaloniaProperty.Register<SignUpForm, string>(nameof(EmailOrPhone), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> PasswordProperty =
        AvaloniaProperty.Register<SignUpForm, string>(nameof(Password), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<int> SelectedDayProperty =
        AvaloniaProperty.Register<SignUpForm, int>(nameof(SelectedDay), defaultValue: 1, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<int> SelectedMonthProperty =
        AvaloniaProperty.Register<SignUpForm, int>(nameof(SelectedMonth), defaultValue: 0, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<int> SelectedYearProperty =
        AvaloniaProperty.Register<SignUpForm, int>(nameof(SelectedYear), defaultValue: 1990, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<Gender> SelectedGenderProperty =
        AvaloniaProperty.Register<SignUpForm, Gender>(nameof(SelectedGender), defaultValue: Gender.None, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<ICommand?> SignUpCommandProperty =
        AvaloniaProperty.Register<SignUpForm, ICommand?>(nameof(SignUpCommand));

    public static readonly StyledProperty<ICommand?> CloseCommandProperty =
        AvaloniaProperty.Register<SignUpForm, ICommand?>(nameof(CloseCommand));

    public static readonly StyledProperty<ObservableCollection<int>> DaysProperty =
        AvaloniaProperty.Register<SignUpForm, ObservableCollection<int>>(nameof(Days));

    public static readonly StyledProperty<ObservableCollection<string>> MonthsProperty =
        AvaloniaProperty.Register<SignUpForm, ObservableCollection<string>>(nameof(Months));

    public static readonly StyledProperty<ObservableCollection<int>> YearsProperty =
        AvaloniaProperty.Register<SignUpForm, ObservableCollection<int>>(nameof(Years));

    public SignUpForm()
    {
        Days = new ObservableCollection<int>(Enumerable.Range(1, 31));
        Months =
        [
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];
        Years = new ObservableCollection<int>(Enumerable.Range(1990, 37).Reverse());
    }

    public string FirstName
    {
        get => GetValue(FirstNameProperty);
        set => SetValue(FirstNameProperty, value);
    }

    public string Surname
    {
        get => GetValue(SurnameProperty);
        set => SetValue(SurnameProperty, value);
    }

    public string EmailOrPhone
    {
        get => GetValue(EmailOrPhoneProperty);
        set => SetValue(EmailOrPhoneProperty, value);
    }

    public string Password
    {
        get => GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    public int SelectedDay
    {
        get => GetValue(SelectedDayProperty);
        set => SetValue(SelectedDayProperty, value);
    }

    public int SelectedMonth
    {
        get => GetValue(SelectedMonthProperty);
        set => SetValue(SelectedMonthProperty, value);
    }

    public int SelectedYear
    {
        get => GetValue(SelectedYearProperty);
        set => SetValue(SelectedYearProperty, value);
    }

    public Gender SelectedGender
    {
        get => GetValue(SelectedGenderProperty);
        set => SetValue(SelectedGenderProperty, value);
    }

    public ICommand? SignUpCommand
    {
        get => GetValue(SignUpCommandProperty);
        set => SetValue(SignUpCommandProperty, value);
    }

    public ICommand? CloseCommand
    {
        get => GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }

    public ObservableCollection<int> Days
    {
        get => GetValue(DaysProperty);
        set => SetValue(DaysProperty, value);
    }

    public ObservableCollection<string> Months
    {
        get => GetValue(MonthsProperty);
        set => SetValue(MonthsProperty, value);
    }

    public ObservableCollection<int> Years
    {
        get => GetValue(YearsProperty);
        set => SetValue(YearsProperty, value);
    }

    private Button? _signUpButton;
    private Button? _closeButton;
    private RadioButton? _femaleRadio;
    private RadioButton? _maleRadio;
    private RadioButton? _customRadio;

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _signUpButton = e.NameScope.Find<Button>("PART_SignUpButton");
        _closeButton = e.NameScope.Find<Button>("PART_CloseButton");
        _femaleRadio = e.NameScope.Find<RadioButton>("PART_FemaleRadio");
        _maleRadio = e.NameScope.Find<RadioButton>("PART_MaleRadio");
        _customRadio = e.NameScope.Find<RadioButton>("PART_CustomRadio");

        if (_signUpButton is not null)
        {
            _signUpButton.Click += OnSignUpClick;
        }

        if (_closeButton is not null)
        {
            _closeButton.Click += OnCloseClick;
        }

        if (_femaleRadio is not null)
        {
            _femaleRadio.IsCheckedChanged += (_, _) =>
            {
                if (_femaleRadio.IsChecked == true)
                    SelectedGender = Gender.Female;
            };
        }

        if (_maleRadio is not null)
        {
            _maleRadio.IsCheckedChanged += (_, _) =>
            {
                if (_maleRadio.IsChecked == true)
                    SelectedGender = Gender.Male;
            };
        }

        if (_customRadio is not null)
        {
            _customRadio.IsCheckedChanged += (_, _) =>
            {
                if (_customRadio.IsChecked == true)
                    SelectedGender = Gender.Custom;
            };
        }
    }

    private void OnSignUpClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        SignUpCommand?.Execute(null);
    }

    private void OnCloseClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        CloseCommand?.Execute(null);
    }
}

public enum Gender
{
    None,
    Female,
    Male,
    Custom
}
