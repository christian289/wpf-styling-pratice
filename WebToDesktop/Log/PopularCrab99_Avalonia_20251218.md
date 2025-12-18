# PopularCrab99 AvaloniaUI 변환 로그

## 변환 정보
- **원본**: uiverse.io by NlghtM4re
- **태그**: loader, cube, shadow, glow, colorful
- **변환일**: 2025-12-18
- **대상 프레임워크**: .NET 9.0, Avalonia 11.2.2

## 컨트롤 설명
4개의 색상 큐브(보라, 파랑, 초록, 주황)가 시계 방향으로 회전하는 로딩 애니메이션.

## CSS → AXAML 변환 매핑

| CSS | AvaloniaUI |
|-----|------------|
| `box-shadow: rgb(...) 0px 7px 29px 0px` | `BoxShadow="0 7 29 0 #RRGGBB"` |
| `transform: translate(x, y)` | `<TranslateTransform X="x" Y="y"/>` |
| `animation: move 4s infinite` | `<Animation Duration="0:0:4" IterationCount="Infinite">` |
| `animation-delay: -1s` | `Delay="0:0:1"` (양수로 변환) |

## 컴파일 에러 수정 내역

### 에러 1: Template 속성을 찾을 수 없음
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Template
on type PopularCrab99.Avalonia.Lib.Controls.CubeLoader
```

**원인**: `Control` 클래스에는 `Template` 속성이 없음

**수정**: `Control` → `TemplatedControl`로 변경
```csharp
// Before
// 변경 전
public sealed class CubeLoader : Control

// After
// 변경 후
public sealed class CubeLoader : TemplatedControl
```

### 에러 2: ResourceDictionary를 IStyle로 사용할 수 없음
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "ResourceDictionary" type
but expected "Avalonia.Styling.IStyle"
```

**원인**: `ControlTheme`이 포함된 ResourceDictionary는 `Application.Styles`가 아닌 `Application.Resources`에 병합해야 함

**수정**: App.axaml에서 `StyleInclude` → `ResourceInclude`로 변경하고 `Application.Resources`에 배치
```xml
<!-- Before -->
<!-- 변경 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://..."/>
</Application.Styles>

<!-- After -->
<!-- 변경 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://..."/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. 애니메이션 Delay 동작 차이
- **CSS**: `animation-delay: -1s` (음수 값으로 애니메이션 시작 시점 조정)
- **AvaloniaUI**: `Delay`는 양수만 지원
- **현재 구현**: 각 큐브에 0, 1, 2, 3초 딜레이 적용
- **확인 필요**: CSS 원본은 음수 딜레이로 초기 위치를 다르게 하지만, AvaloniaUI에서는 애니메이션 시작 전 각 큐브가 초기 위치에 있다가 순차적으로 움직이기 시작함

### 2. BoxShadow 렌더링
- AvaloniaUI의 `BoxShadow`는 CSS `box-shadow`와 렌더링 결과가 다를 수 있음
- 특히 blur radius(29px)가 큰 경우 시각적 차이 발생 가능

### 3. TranslateTransform 중앙 정렬
- CSS에서는 `position: absolute`와 `translate`를 함께 사용하여 중앙 기준 이동
- AvaloniaUI `Panel`에서 자식 요소는 기본적으로 중앙 정렬되지만, `TranslateTransform`과의 조합에서 정확한 위치 확인 필요

## 프로젝트 구조
```
PopularCrab99/AvaloniaUI/
├── PopularCrab99.Avalonia.slnx
├── PopularCrab99.Avalonia.Lib/
│   ├── Controls/
│   │   └── CubeLoader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── CubeLoader.axaml
└── PopularCrab99.Avalonia.Gallery/
    ├── App.axaml(.cs)
    ├── MainWindow.axaml(.cs)
    └── Program.cs
```

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **오류**: 0개
