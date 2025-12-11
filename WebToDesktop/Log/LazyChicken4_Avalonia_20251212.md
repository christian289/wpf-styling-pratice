# LazyChicken4 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: HTML/CSS (Tailwind CSS 기반 로그인 폼)
- **출처**: Uiverse.io by LeryLey (Tags: simple, login, form)
- **변환일**: 2025-12-12
- **타겟 프레임워크**: .NET 9.0, Avalonia 11.2.2

## 생성된 파일 구조

```
LazyChicken4/AvaloniaUI/
├── LazyChicken4.Avalonia.slnx
├── LazyChicken4.Avalonia.Lib/
│   ├── LazyChicken4.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── LoginCard.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LoginCard.axaml
└── LazyChicken4.Avalonia.Gallery/
    ├── LazyChicken4.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 컴파일 에러 및 수정

### 에러 1: StyleInclude vs ResourceInclude

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://LazyChicken4.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "LazyChicken4.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인**:
- `Generic.axaml`이 `ResourceDictionary`로 정의되어 있는데, `Application.Styles`에서 `StyleInclude`로 참조함
- `StyleInclude`는 `IStyle` 타입(예: `Styles`)을 기대하지만, `ResourceDictionary`는 `IStyle`이 아님

**수정 방법**:
- `Application.Styles`에서 `StyleInclude` 제거
- `Application.Resources`에 `ResourceDictionary.MergedDictionaries`로 `ResourceInclude` 사용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://LazyChicken4.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://LazyChicken4.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. TextBox PasswordChar 동작

- `PasswordChar="*"` 속성을 사용하여 비밀번호 입력을 구현함
- Avalonia에서 `TextBox`의 `PasswordChar`가 `RevealPassword` 속성과 함께 정상 동작하는지 확인 필요
- 대안: `MaskedTextBox` 또는 별도의 Password 컨트롤 사용 고려

### 2. BoxShadow 렌더링

- `BoxShadow="0 4 6 -1 #1A000000, 0 2 4 -2 #1A000000"` 형식 사용
- 복합 그림자가 의도대로 렌더링되는지 확인 필요

### 3. ControlTheme 적용

- `ControlTheme x:Key="{x:Type controls:LoginCard}"` 형식으로 암시적 스타일 정의
- 컨트롤 인스턴스화 시 테마가 자동 적용되는지 확인 필요

### 4. CheckBox 기본 테마와의 충돌

- `LoginCardCheckBoxTheme`이 FluentTheme의 CheckBox와 충돌하지 않는지 확인 필요
- 현재는 명시적으로 `Theme="{StaticResource LoginCardCheckBoxTheme}"` 적용함

## CSS to AXAML 변환 매핑

| Tailwind CSS | AXAML |
|-------------|-------|
| `w-80` (320px) | `Width="320"` |
| `rounded-lg` | `CornerRadius="8"` |
| `shadow` | `BoxShadow="0 4 6 -1 #1A000000"` |
| `p-6` (24px) | `Padding="24"` |
| `bg-white` | `Background="#FFFFFF"` |
| `text-2xl` | `FontSize="24"` |
| `font-medium` | `FontWeight="Medium"` |
| `text-slate-700` | `Foreground="#334155"` |
| `text-slate-500` | `Foreground="#64748B"` |
| `text-blue-500` | `Foreground="#3B82F6"` |
| `bg-blue-500` | `Background="#3B82F6"` |
| `hover:bg-blue-600` | `:pointerover` + `Background="#2563EB"` |
| `active:bg-blue-700` | `:pressed` + `Background="#1D4ED8"` |
| `focus:border-blue-300` | `:focus` + `BorderBrush="#93C5FD"` |
| `hover:underline` | `:pointerover` + `TextDecorations="Underline"` |
| `space-y-3` (12px) | `Spacing="12"` |

## RadialGradientBrush 관련

- 이 변환에서는 RadialGradientBrush를 사용하지 않음
- 따라서 AvaloniaUI Issue #19888 (GradientOrigin/Center 불일치 문제) 해당 없음

## 빌드 결과

- **최종 빌드**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
