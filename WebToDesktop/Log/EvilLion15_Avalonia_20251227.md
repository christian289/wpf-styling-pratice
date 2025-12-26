# EvilLion15 - AvaloniaUI 변환 로그

## 변환 정보

- **원본**: `source/20251226_EvilLion15/EvilLion15.html`, `EvilLion15.css`
- **출처**: Uiverse.io by vikramsinghnegi
- **태그**: simple, neumorphism, glassmorphism
- **변환 일자**: 2025-12-27
- **대상 플랫폼**: AvaloniaUI 11.2.3 / .NET 9.0

## 컨트롤 설명

Neumorphism/Glassmorphism 스타일의 토글 스위치 컨트롤입니다.

### 주요 특징

- 슬라이딩 핸들이 있는 토글 스위치
- 좌우 인디케이터 (radial gradient)
- 체크 시 핸들이 오른쪽으로 이동하는 애니메이션 (0.2초)
- 내부 그림자 효과 (BoxShadow inset)

## CSS → AvaloniaUI 변환 매핑

| CSS | AvaloniaUI |
|-----|-----------|
| `radial-gradient(45%, circle, ...)` | `RadialGradientBrush GradientOrigin="45%,45%" Center="45%,45%"` |
| `linear-gradient(#4f4f4f, #2b2b2b)` | `LinearGradientBrush StartPoint="0%,0%" EndPoint="0%,100%"` |
| `box-shadow: ... inset` | `BoxShadow="inset ..."` |
| `border-radius: 50px` | `CornerRadius="21"` (Height/2) |
| `transition: all 0.2s linear` | `Animation Duration="0:0:0.2" Easing="LinearEasing"` |
| `::before`, `::after` | 별도 `Border` 요소로 구현 |
| `:checked + .switch-label span` | `Style Selector="^:checked /template/ Border#PART_Handle"` |

## 빌드 에러 및 수정 내용

### 에러 1: ResourceDictionary를 StyleInclude로 참조

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://EvilLion15.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "EvilLion15.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
`Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 참조하려고 함. `StyleInclude`는 `IStyle` 타입(예: `Styles` 또는 `ControlTheme`)을 예상하지만, `Generic.axaml`은 `ResourceDictionary` 타입임.

**수정 방법**:
`Application.Styles` 대신 `Application.Resources`에서 `ResourceInclude`를 사용하여 `ResourceDictionary`를 병합함.

**수정 전 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://EvilLion15.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://EvilLion15.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## RadialGradientBrush 호환성 주의사항

AvaloniaUI Issue #19888로 인해 `RadialGradientBrush`의 `GradientOrigin`과 `Center` 값이 반드시 동일해야 정상 동작합니다.

**CSS 원본**:
```css
background: -webkit-radial-gradient(45%, circle, rgb(116, 78, 78) 0%, rgb(255, 113, 113) 100%);
```

**AvaloniaUI 변환**:
```xml
<RadialGradientBrush GradientOrigin="45%,45%" Center="45%,45%" RadiusX="100%" RadiusY="100%">
    <GradientStop Color="#744E4E" Offset="0" />
    <GradientStop Color="#FF7171" Offset="1" />
</RadialGradientBrush>
```

## 잠재적 Runtime 오류 가능성

### 1. 애니메이션 상태 전환 이슈

`:checked`와 `:not(:checked)` 상태 간 전환 시 애니메이션이 서로 충돌할 수 있음. 처음 로드될 때 불필요한 애니메이션이 실행될 수 있음.

**확인 필요**: 앱 시작 시 Switch2 (IsChecked="True")의 초기 위치가 올바른지 확인

### 2. BoxShadow 렌더링

CSS의 복잡한 다중 box-shadow를 AvaloniaUI BoxShadow로 완벽히 변환하기 어려울 수 있음. 특히 `inset` 그림자와 일반 그림자를 동시에 적용하는 경우.

**확인 필요**: 시각적으로 원본 CSS와 유사한지 비교 검토

### 3. 음수 마진 (Margin="-23,0,0,0")

좌우 인디케이터가 컨트롤 영역 밖에 위치함 (음수 마진 사용). 부모 컨테이너의 `ClipToBounds` 설정에 따라 잘릴 수 있음.

**확인 필요**: 인디케이터가 정상적으로 보이는지 확인

## 프로젝트 구조

```
EvilLion15/AvaloniaUI/
├── EvilLion15.Avalonia.slnx
├── EvilLion15.Avalonia.Lib/
│   ├── EvilLion15.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── EvilLion15ToggleSwitch.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── EvilLion15ToggleSwitch.axaml
└── EvilLion15.Avalonia.Gallery/
    ├── EvilLion15.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **빌드 성공**: ✅
- **경고**: 0개
- **오류**: 0개

## 실행 방법

```bash
cd WebToDesktop/Output/EvilLion15/AvaloniaUI
dotnet run --project EvilLion15.Avalonia.Gallery
```
