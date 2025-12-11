# SillyGrasshopper43 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by JulioCodesSM (loader)
- **변환 날짜**: 2025-12-12
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 원본 CSS 분석

두 개의 원(::before, ::after)이 좌우로 이동하면서 크기가 변하는 로더 애니메이션:
- `mix-blend-mode: multiply` 사용 (두 원이 겹칠 때 색상 혼합)
- `animation: rotate9 1s infinite cubic-bezier(0.77, 0, 0.175, 1)`
- 두 번째 원은 `animation-delay: .5s`로 위상 차이

## 컴파일 에러 및 수정

### 에러 1: CS0234 - 네임스페이스 충돌

**에러 메시지**:
```
'SillyGrasshopper43.Avalonia' 네임스페이스에 'Media' 형식 또는 네임스페이스 이름이 없습니다.
```

**원인**:
- 프로젝트 네임스페이스가 `SillyGrasshopper43.Avalonia.Lib`이므로 `Avalonia.Media.Color`가 `SillyGrasshopper43.Avalonia.Media.Color`로 잘못 해석됨

**수정**:
```csharp
// Before
public static readonly StyledProperty<Avalonia.Media.Color> ForegroundColorProperty = ...

// After - using 문 추가
using Avalonia.Media;
public static readonly StyledProperty<Color> ForegroundColorProperty = ...
```

### 에러 2: AVLN2000 - ScaleTransform에 x:Name 사용 불가

**에러 메시지**:
```
Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
```

**원인**:
- AvaloniaUI에서 `ScaleTransform`은 `x:Name` 속성을 지원하지 않음

**수정**:
```xml
<!-- Before -->
<Ellipse.RenderTransform>
    <ScaleTransform x:Name="Scale1" ScaleX="1" ScaleY="1" />
</Ellipse.RenderTransform>

<!-- After -->
<Ellipse.RenderTransform>
    <ScaleTransform ScaleX="1" ScaleY="1" />
</Ellipse.RenderTransform>
```

### 에러 3: AVLN2000 - StyleInclude vs ResourceInclude

**에러 메시지**:
```
Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type, but expected "Avalonia.Styling.IStyle"
```

**원인**:
- `Application.Styles`에서 `StyleInclude`는 `IStyle` 타입만 포함 가능
- `ResourceDictionary`는 `IStyle`이 아니므로 `Application.Resources`에서 `ResourceInclude`로 포함해야 함

**수정**:
```xml
<!-- Before -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SillyGrasshopper43.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- After -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SillyGrasshopper43.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 런타임 오류 가능성 (직접 확인 필요)

### 1. mix-blend-mode 미지원

**문제**:
- CSS `mix-blend-mode: multiply`는 AvaloniaUI에서 직접 지원되지 않음
- 현재 구현에서는 두 번째 원에 `Opacity="0.7"`을 적용하여 유사한 효과를 시뮬레이션

**영향**:
- 원본과 정확히 동일한 색상 혼합 효과가 나타나지 않을 수 있음

### 2. cubic-bezier 이징 함수 차이

**문제**:
- CSS: `cubic-bezier(0.77, 0, 0.175, 1)`
- AvaloniaUI: `CubicEaseInOut` (표준 이징 함수 사용)

**영향**:
- 애니메이션 가속/감속 곡선이 원본과 다를 수 있음
- 정확한 cubic-bezier 값이 필요한 경우 커스텀 이징 함수 구현 필요

### 3. Animation Delay와 KeyFrame 동기화

**문제**:
- 두 번째 원의 `Delay="0:0:0.5"` 설정이 첫 번째 애니메이션 사이클에서만 적용됨
- 이후 사이클에서는 두 애니메이션이 동일한 타이밍으로 실행될 수 있음

**영향**:
- 첫 번째 사이클 이후 두 원의 위상 차이가 유지되지 않을 가능성

## 생성된 파일

```
SillyGrasshopper43/AvaloniaUI/
├── SillyGrasshopper43.Avalonia.slnx
├── SillyGrasshopper43.Avalonia.Lib/
│   ├── SillyGrasshopper43.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── Loader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── Loader.axaml
└── SillyGrasshopper43.Avalonia.Gallery/
    ├── SillyGrasshopper43.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
