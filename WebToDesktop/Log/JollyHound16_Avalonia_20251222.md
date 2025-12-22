# JollyHound16 AvaloniaUI 변환 로그

## 변환 정보

- **변환 일시**: 2025-12-22
- **원본**: HTML/CSS (Uiverse.io by AkshatDaxini)
- **대상**: AvaloniaUI CustomControl
- **컨트롤 이름**: PizzaLoader

## 원본 설명

회전하는 피자 애니메이션 로더입니다. 6개의 피자 조각이 각각 다른 방향으로 움직이며, 전체 피자가 천천히 회전합니다. 각 조각에는 페퍼로니, 버섯, 양파, 피망 등의 토핑이 포함되어 있습니다.

## 변환 내용

### CSS 애니메이션 → AvaloniaUI Animation

| CSS | AvaloniaUI |
|-----|-----------|
| `animation: rotate 45s linear infinite` | `Animation Duration="0:0:45" IterationCount="Infinite"` |
| `animation: slice1 4s ease-in-out infinite` | `Animation Duration="0:0:4" Easing="QuadraticEaseInOut"` |
| `animation-delay: 1s` | `Delay="0:0:1"` |
| `transform: translate(5%, 5%)` | `TranslateTransform X="8.4" Y="7.9"` (168*5%=8.4, 158*5%=7.9) |

### SVG → AvaloniaUI Path

- SVG `<path>` → `<Path Data="...">`
- SVG `<circle>` → `<Ellipse>`
- SVG fill/stroke 색상 → SolidColorBrush 리소스

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary를 StyleInclude로 참조

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://JollyHound16.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "JollyHound16.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**: `ResourceDictionary`를 `<StyleInclude>`로 참조하려고 함

**수정 방법**: `Application.Styles` 대신 `Application.Resources`에서 `ResourceInclude`로 참조

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://JollyHound16.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://JollyHound16.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 가능성

1. **애니메이션 타이밍**: CSS의 `ease-in-out`을 `QuadraticEaseInOut`으로 변환했으나, 정확히 동일한 easing curve가 아닐 수 있음

2. **퍼센트 기반 이동**: CSS에서 `translate(5%, 5%)`는 부모 요소 기준이지만, AvaloniaUI에서는 픽셀값으로 직접 계산하여 적용 (168*5%=8.4, 158*7%=11.06 등)

3. **scale 변환**: CSS의 `scale: 1.6`을 `ScaleTransform`으로 구현했으나, 부모 컨테이너 크기에 따라 다르게 보일 수 있음

## 프로젝트 구조

```
JollyHound16/AvaloniaUI/
├── JollyHound16.Avalonia.slnx
├── JollyHound16.Avalonia.Lib/
│   ├── JollyHound16.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── PizzaLoader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── PizzaLoader.axaml
└── JollyHound16.Avalonia.Gallery/
    ├── JollyHound16.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── Program.cs
    └── app.manifest
```

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
