# RedGoat27 AvaloniaUI 변환 로그

## 개요

- **원본 소스**: uiverse.io by devsleonardo (notification)
- **변환 일자**: 2025-12-20
- **대상 프레임워크**: .NET 9.0 + Avalonia 11.2.2

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지:**
```
Avalonia error AVLN2000: Resource "avares://RedGoat27.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "RedGoat27.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인:**
- `Application.Styles` 내에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 로드하려고 시도
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 허용하며, `ResourceDictionary`는 별도로 `Application.Resources`에서 로드해야 함

**수정 전 (App.axaml):**
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://RedGoat27.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후 (App.axaml):**
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://RedGoat27.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. `:loaded` 의사 클래스 애니메이션

**위치:** `NotificationControl.axaml` - `:loaded` 선택자 사용

**설명:**
- AvaloniaUI에서 `:loaded` 의사 클래스는 컨트롤이 로드될 때 트리거되어야 하지만, 일부 버전에서는 예상대로 동작하지 않을 수 있음
- Bounce 애니메이션이 처음 로드 시 재생되지 않을 가능성 있음

**대안:**
- 코드 비하인드에서 `OnLoaded` 이벤트를 통해 수동으로 애니메이션 트리거 고려

### 2. 복합 Transform 애니메이션

**위치:** `NotificationControl.axaml` - `TransformGroup` 애니메이션

**설명:**
- `TransformGroup` 내의 `TranslateTransform`과 `RotateTransform`을 함께 애니메이션하는 방식은 복잡함
- 일부 경우 KeyFrame 간 전환이 부드럽지 않을 수 있음

**대안:**
- 각 Transform을 별도의 컨트롤에 적용하거나, `RenderTransformOrigin`을 세심하게 조정

### 3. `:pointerover` 상태의 애니메이션 반복

**위치:** `NotificationControl.axaml` - `:pointerover` 선택자

**설명:**
- 마우스를 올릴 때마다 spin 애니메이션이 재시작됨
- 마우스를 빠르게 오갈 경우 애니메이션이 갑자기 중단되고 다시 시작될 수 있음

## 변환 내용 요약

| 원본 (CSS) | 변환 (AvaloniaUI) |
|------------|-------------------|
| `display: flex; flex-direction: column` | `<StackPanel Orientation="Vertical">` |
| `color: white` | `Foreground="White"` |
| `fill: gold` | `Fill="#FFD700"` (SolidColorBrush) |
| `width: 80px; height: 80px` | `Width="80" Height="80"` |
| `@keyframes bounce` | `<Animation>` with multiple KeyFrames |
| `@keyframes spin` | `<Animation>` with RotateTransform |
| `:hover` | `:pointerover` |
| SVG paths | `<PathGeometry>` resources |

## 프로젝트 구조

```
RedGoat27/AvaloniaUI/
├── RedGoat27.Avalonia.slnx
├── RedGoat27.Avalonia.Lib/
│   ├── RedGoat27.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── NotificationControl.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── NotificationControl.axaml
└── RedGoat27.Avalonia.Gallery/
    ├── RedGoat27.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
