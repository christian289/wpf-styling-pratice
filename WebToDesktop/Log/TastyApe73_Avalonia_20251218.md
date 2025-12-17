# TastyApe73 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by JkHuger (notification)
- **변환 대상**: AvaloniaUI 11.2.2
- **변환 일시**: 2025-12-18
- **컨트롤명**: LevelUpNotification

## 원본 HTML/CSS 분석

"Level Up!" 알림과 함께 confetti(색종이) 애니메이션이 표시되는 UI 컴포넌트입니다.

### 주요 CSS 기능

1. **scale-up 애니메이션**: 0에서 1로 확대되는 등장 효과
2. **confetti 애니메이션**: 위에서 아래로 떨어지는 색종이 효과
3. **hover 상태**: 마우스 오버 시 confetti 애니메이션 시작
4. **다양한 도형**: square, rectangle, hexagram, pentagram, dodecagram, wavy-line

## 컴파일 에러 및 수정 사항

### 에러 1: ScaleTransform x:Name 사용 불가

**에러 메시지**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
```

**원인**: AvaloniaUI에서 ScaleTransform과 같은 Transform 객체에는 x:Name을 사용할 수 없습니다.

**수정 방법**: ScaleTransform에서 `x:Name="ScaleTransform"` 속성을 제거했습니다.

```xml
<!-- 수정 전 -->
<ScaleTransform x:Name="ScaleTransform" ScaleX="1" ScaleY="1" />

<!-- 수정 후 -->
<ScaleTransform ScaleX="1" ScaleY="1" />
```

### 에러 2: StyleInclude vs ResourceInclude

**에러 메시지**:
```
AVLN2000: Resource "avares://TastyApe73.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "TastyApe73.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: ResourceDictionary를 `<Application.Styles>`에서 `StyleInclude`로 로드하려 했으나, ResourceDictionary는 Style이 아니므로 호환되지 않습니다.

**수정 방법**: `<Application.Resources>`에서 `ResourceInclude`로 로드하도록 변경했습니다.

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://TastyApe73.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://TastyApe73.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성

### 1. :loaded 의사 클래스 애니메이션

AvaloniaUI에서 `:loaded` 의사 클래스는 지원되나, 컨트롤이 로드될 때 애니메이션이 예상대로 동작하지 않을 수 있습니다. 실제 테스트 시 확인이 필요합니다.

### 2. Confetti 애니메이션 복잡성

원본 CSS는 CSS 변수(`--speed`, `--bg`)를 사용하여 각 confetti 요소마다 다른 애니메이션 속도와 색상을 적용했습니다. AvaloniaUI 변환에서는 이를 단순화하여 두 개의 StackPanel 그룹으로 구현했습니다. 원본처럼 100개 이상의 개별 confetti 요소를 구현하려면 코드 비하인드에서 동적 생성이 필요합니다.

### 3. FillMode="Forward" 동작

`FillMode="Forward"`가 설정된 애니메이션이 종료 후 상태를 유지하지 않을 수 있습니다. 특히 hover 상태에서 벗어날 때 애니메이션 리셋 여부를 확인해야 합니다.

### 4. BoxShadow 렌더링

`BoxShadow="0 0 10 0 #80000000"` 형식이 AvaloniaUI에서 지원되나, 복잡한 그림자 효과가 있을 경우 성능에 영향을 줄 수 있습니다.

## CSS → AvaloniaUI 변환 패턴 사용

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `background-color: #FDD835` | `Background="#FDD835"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `box-shadow: 0 0 10px rgba(0,0,0,0.5)` | `BoxShadow="0 0 10 0 #80000000"` |
| `transform: rotate(-140deg)` | `<RotateTransform Angle="-140" />` |
| `text-shadow: 2px 2px #000` | TextBlock 두 개 겹치기 (Margin="2,2,0,0") |
| `:hover` | `:pointerover` |
| `animation-duration: calc(70s / var(--speed))` | 고정 Duration (단순화) |
| `animation-iteration-count: infinite` | `IterationCount="Infinite"` |

## 프로젝트 구조

```
TastyApe73/AvaloniaUI/
├── TastyApe73.Avalonia.slnx
├── TastyApe73.Avalonia.Lib/
│   ├── TastyApe73.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── LevelUpNotification.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LevelUpNotification.axaml
└── TastyApe73.Avalonia.Gallery/
    ├── TastyApe73.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

**성공** - 경고 0개, 오류 0개
