# FreshMoth58 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본**: uiverse.io by Ali-Tahmazi99
- **컨트롤 이름**: NeumorphicToggleSwitch
- **변환 일시**: 2025-12-21
- **UI 프레임워크**: AvaloniaUI 11.2.2
- **대상 프레임워크**: .NET 9.0

## 원본 CSS 분석

Neumorphism 스타일의 토글 스위치로, 다음 특징을 가짐:

- 외부 그림자 (Outer Shadow): `box-shadow: 9px 9px 29px #969696, -9px -9px 29px #ffffff`
- 내부 그림자 (Inner Shadow/Inset): `box-shadow: inset 3px 3px 10px #969696, inset -3px -3px 5px #ffffffbd`
- 토글 애니메이션: 0.3초 `ease-in`, 위치 이동 + 220도 회전
- 토글 색상 변화: Off (#ffaa00) → On (#0a100d)

## 컴파일 에러 및 수정

### 에러 1: 잘못된 색상 코드

**에러 내용**:
```
Avalonia error AVLN2005: Unable to parse "#BDFFFFFFU" as a color
```

**원인**:
CSS에서 `#ffffffbd`는 `#ffffff` 색상에 opacity `0xBD` (약 74%)를 의미함.
AXAML에서 ARGB 형식은 `#AARRGGBB` 순서로, opacity(Alpha)가 앞에 와야 함.
잘못 입력: `#BDFFFFFFU` → 올바른 형식: `#BDFFFFFF`

**수정 방법**:
```xml
<!-- Before (잘못된 형식) -->
<Color x:Key="NeumorphicToggle.InnerShadowLight">#BDFFFFFFU</Color>
BoxShadow="inset -3 -3 5 0 #BDFFFFFFU"

<!-- After (올바른 형식) -->
<Color x:Key="NeumorphicToggle.InnerShadowLight">#BDFFFFFF</Color>
BoxShadow="inset -3 -3 5 0 #BDFFFFFF"
```

### 에러 2: STAThread 특성 누락

**에러 내용**:
```
error CS0246: 'STAThreadAttribute' 형식 또는 네임스페이스 이름을 찾을 수 없습니다.
```

**원인**:
`[STAThread]` 특성은 `System` 네임스페이스에 있으며, `using System;` 누락.

**수정 방법**:
```csharp
// Before
using Avalonia;

// After
using System;
using Avalonia;
```

### 에러 3: ResourceDictionary를 IStyle로 사용

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://FreshMoth58.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "FreshMoth58.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
`Application.Styles`에는 `IStyle` 타입만 추가 가능.
`ResourceDictionary`는 `Application.Resources`에 병합해야 함.

**수정 방법**:
```xml
<!-- Before (잘못된 방법) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://FreshMoth58.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- After (올바른 방법) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://FreshMoth58.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 RenderTransform 적용 문제

**위치**: `NeumorphicToggleSwitch.axaml` - Checked/Unchecked 상태 애니메이션

**잠재적 문제**:
AvaloniaUI에서 `RenderTransform` 전체를 애니메이션으로 변경하는 방식은
WPF와 다르게 동작할 수 있음. 특히 `TransformGroup` 내의 개별 Transform에
대한 애니메이션이 예상대로 작동하지 않을 수 있음.

**현재 구현**:
```xml
<Style.Animations>
    <Animation Duration="0:0:0.3" Easing="CubicEaseIn" FillMode="Forward">
        <KeyFrame Cue="100%">
            <Setter Property="RenderTransform">
                <TransformGroup>
                    <RotateTransform Angle="220"/>
                    <TranslateTransform X="29"/>
                </TransformGroup>
            </Setter>
        </KeyFrame>
    </Animation>
</Style.Animations>
```

**확인 필요**:
- 토글 시 회전 + 이동 애니메이션이 부드럽게 동작하는지
- 언체크 시 원래 위치로 복귀하는지

### 2. BoxShadow 렌더링

**잠재적 문제**:
AvaloniaUI의 `BoxShadow`는 CSS `box-shadow`와 완전히 동일하지 않을 수 있음.
특히 `inset` 그림자의 렌더링이 CSS와 다를 수 있음.

**확인 필요**:
- 외부 Neumorphism 그림자가 올바르게 표시되는지
- 내부(inset) 그림자가 올바르게 표시되는지

## 프로젝트 구조

```
FreshMoth58/AvaloniaUI/
├── FreshMoth58.Avalonia.slnx
├── FreshMoth58.Avalonia.Lib/
│   ├── FreshMoth58.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── NeumorphicToggleSwitch.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── NeumorphicToggleSwitch.axaml
└── FreshMoth58.Avalonia.Gallery/
    ├── FreshMoth58.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **에러**: 0개

## CSS → AXAML 변환 요약

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `box-shadow: 9px 9px 29px #969696, -9px -9px 29px #ffffff` | `BoxShadow="9 9 29 0 #969696, -9 -9 29 0 #FFFFFF"` |
| `box-shadow: inset 3px 3px 10px #969696` | `BoxShadow="inset 3 3 10 0 #969696"` |
| `#ffffffbd` (CSS: RRGGBBAA) | `#BDFFFFFF` (AXAML: AARRGGBB) |
| `border-radius: 50px` | `CornerRadius="15"` (Width/2) |
| `transition: all 0.3s ease-in` | `<Animation Duration="0:0:0.3" Easing="CubicEaseIn">` |
| `transform: rotate(220deg)` | `<RotateTransform Angle="220"/>` |
| `:checked` 셀렉터 | `^:checked` 셀렉터 |
