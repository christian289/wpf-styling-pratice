# HardTreefrog45 - AvaloniaUI 변환 로그

## 변환 정보

- **소스**: `WebToDesktop/source/20260104_HardTreefrog45/HardTreefrog45.html`
- **변환 일시**: 2026-01-05
- **대상 플랫폼**: AvaloniaUI 11.2.3
- **원본 설명**: Facebook 스타일 회원가입 폼 (by themrsami from uiverse.io)

## 생성된 파일 구조

```
WebToDesktop/Output/HardTreefrog45/AvaloniaUI/
├── HardTreefrog45.Avalonia.slnx
├── HardTreefrog45.Avalonia.Lib/
│   ├── HardTreefrog45.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── SignUpForm.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SignUpForm.axaml
└── HardTreefrog45.Avalonia.Gallery/
    ├── HardTreefrog45.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 사항

### 에러 1: Days/Months/Years가 AvaloniaProperty가 아님

**에러 메시지**:
```
Avalonia error AVLN3000: Days is not an AvaloniaProperty Line 259, position 47.
```

**원인**:
- `Days`, `Months`, `Years` 속성이 일반 C# 프로퍼티로 정의되어 있어 AXAML에서 `TemplateBinding`으로 바인딩할 수 없음

**수정 방법**:
- `ObservableCollection<int>` / `ObservableCollection<string>` 타입의 `StyledProperty`로 변경
- 생성자에서 기본값 초기화

```csharp
// 수정 전
public ObservableCollection<int> Days { get; } = new(Enumerable.Range(1, 31));

// 수정 후
public static readonly StyledProperty<ObservableCollection<int>> DaysProperty =
    AvaloniaProperty.Register<SignUpForm, ObservableCollection<int>>(nameof(Days));

public ObservableCollection<int> Days
{
    get => GetValue(DaysProperty);
    set => SetValue(DaysProperty, value);
}

public SignUpForm()
{
    Days = new ObservableCollection<int>(Enumerable.Range(1, 31));
    // ...
}
```

### 에러 2: StyleInclude로 ResourceDictionary 로드 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://HardTreefrog45.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "HardTreefrog45.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- AvaloniaUI에서 `ControlTheme`을 포함하는 `ResourceDictionary`는 `Application.Styles`의 `StyleInclude`로 로드할 수 없음
- `StyleInclude`는 `IStyle` 타입만 허용

**수정 방법**:
- `Application.Resources`에서 `ResourceInclude`를 사용하여 `ResourceDictionary` 병합

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://HardTreefrog45.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://HardTreefrog45.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 경고: ToggleButton.Checked 사용 중단

**경고 메시지**:
```
warning CS0618: 'ToggleButton.Checked'은(는) 사용되지 않습니다. 'Use IsCheckedChanged instead.'
```

**수정 방법**:
- `Checked` 이벤트 대신 `IsCheckedChanged` 이벤트 사용

```csharp
// 수정 전
_femaleRadio.Checked += (_, _) => SelectedGender = Gender.Female;

// 수정 후
_femaleRadio.IsCheckedChanged += (_, _) =>
{
    if (_femaleRadio.IsChecked == true)
        SelectedGender = Gender.Female;
};
```

## Runtime Error 가능성 (직접 확인 필요)

1. **ComboBox SelectedItem 바인딩**:
   - `SelectedItem`에 `int` 타입 바인딩 시 타입 불일치로 선택이 동작하지 않을 수 있음
   - `SelectedIndex` 사용 또는 `IValueConverter` 구현 필요할 수 있음

2. **PathIcon Data 속성**:
   - Close 버튼의 `PathIcon Data="M6 18L18 6M6 6l12 12"` 구문이 AvaloniaUI에서 올바르게 파싱되지 않을 수 있음
   - 실행 시 아이콘이 표시되지 않을 경우 SVG Path 데이터 형식 수정 필요

3. **RadioButton 커스텀 템플릿**:
   - 커스텀 `ControlTemplate`에서 `IsChecked` 상태 시각화가 제대로 동작하지 않을 수 있음
   - `:checked` pseudo-class 스타일 적용 확인 필요

4. **TextBox Watermark 표시**:
   - 커스텀 `TextBox` 템플릿의 Watermark 가시성 로직이 올바르게 동작하는지 확인 필요

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 실행 방법

```bash
cd WebToDesktop/Output/HardTreefrog45/AvaloniaUI
dotnet run --project HardTreefrog45.Avalonia.Gallery
```
