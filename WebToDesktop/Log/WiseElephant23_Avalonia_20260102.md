# WiseElephant23 AvaloniaUI 변환 로그

## 원본 정보

- **출처**: Uiverse.io by martinval9
- **태그**: checkbox, circle
- **컴포넌트**: 원형 체크박스 (Circle CheckBox)

## 변환 요약

HTML/CSS 원형 체크박스를 AvaloniaUI CustomControl로 변환했습니다.

### CSS → AvaloniaUI 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `background-color: #ccc` | `Background="{StaticResource CircleCheckBox.Unchecked.BackgroundBrush}"` |
| `background-color: limegreen` | `Background="{StaticResource CircleCheckBox.Checked.BackgroundBrush}"` |
| `border-radius: 25px` | `CornerRadius="13"` |
| `transition: 0.15s` | `<BrushTransition Duration="0:0:0.15"/>` |
| `transform: rotate(45deg)` | `<RotateTransform Angle="45"/>` |
| `:checked` pseudo-class | `:checked` selector |
| `::after` pseudo-element | 별도 `Border` 요소로 구현 |

## 컴파일 에러 및 수정 내역

### 에러 1: Avalonia.Sdk를 찾을 수 없음

**에러 메시지**:
```
error MSB4236: 지정된 'Avalonia.Sdk/11.2.3' SDK를 찾을 수 없습니다.
```

**원인**: `Avalonia.Sdk`는 NuGet 패키지 형태가 아닌 workload로 설치되어야 함

**수정 방법**:
- `Sdk="Avalonia.Sdk/11.2.3"` → `Sdk="Microsoft.NET.Sdk"` 로 변경
- Avalonia를 PackageReference로 추가

```xml
<!-- Before -->
<Project Sdk="Avalonia.Sdk/11.2.3">

<!-- After -->
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Avalonia" Version="11.2.3" />
    <PackageReference Include="Avalonia.Desktop" Version="11.2.3" />
    <PackageReference Include="Avalonia.Themes.Fluent" Version="11.2.3" />
    <PackageReference Include="Avalonia.Fonts.Inter" Version="11.2.3" />
  </ItemGroup>
</Project>
```

### 에러 2: ResourceDictionary를 IStyle로 사용할 수 없음

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://WiseElephant23.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "WiseElephant23.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에서 `StyleInclude`를 사용할 때, 대상 리소스는 `Styles` 루트 요소를 가져야 함

**수정 방법**:
1. `Generic.axaml`: `<ResourceDictionary>` → `<Styles>` 로 변경
2. `CircleCheckBox.axaml`: `<ResourceDictionary>` → `<Styles>` 로 변경, 리소스는 `<Styles.Resources>` 내부에 배치

```xml
<!-- Before -->
<ResourceDictionary xmlns="https://github.com/avaloniaui">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..." />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>

<!-- After -->
<Styles xmlns="https://github.com/avaloniaui">
    <StyleInclude Source="..." />
</Styles>
```

## 잠재적 Runtime 에러 가능성

### 1. ControlTheme 미적용 가능성

**상황**: `CircleCheckBox`가 렌더링되지 않거나 기본 ToggleButton 스타일이 적용될 수 있음

**원인 가능성**:
- ControlTheme의 `x:Key="{x:Type controls:CircleCheckBox}"`가 정상 동작하지 않을 수 있음

**확인 필요**: 직접 실행하여 컨트롤이 원형 체크박스로 표시되는지 확인 필요

### 2. StaticResource 참조 순서

**상황**: `Styles.Resources` 내에서 Color → SolidColorBrush 순서로 정의했지만, 참조 순서에 따라 null 참조 발생 가능

**확인 필요**: Color 리소스가 SolidColorBrush 리소스보다 먼저 정의되었는지 확인함 (현재 올바르게 정의됨)

### 3. Checkmark 표시 위치

**상황**: 체크마크(✓)가 원의 중앙에서 약간 벗어날 수 있음

**원인**: CSS `left: 0.45em`, `top: 0.25em` 값을 `Margin="0,-3,0,0"`으로 근사 변환했기 때문

**확인 필요**: 직접 실행하여 체크마크 위치가 적절한지 확인 필요

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 생성된 파일 구조

```
WiseElephant23/AvaloniaUI/
├── WiseElephant23.Avalonia.slnx
├── WiseElephant23.Avalonia.Lib/
│   ├── WiseElephant23.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── CircleCheckBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── CircleCheckBox.axaml
└── WiseElephant23.Avalonia.Gallery/
    ├── WiseElephant23.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
