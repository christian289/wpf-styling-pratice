# SillyGrasshopper43

loaders 스타일 컨트롤 - 두 개의 원이 좌우로 이동하면서 크기가 변하는 로더 애니메이션

## 원본 정보

- **원작자**: JulioCodesSM
- **원본 링크**: [https://uiverse.io/JulioCodesSM/silly-grasshopper-43](https://uiverse.io/JulioCodesSM/silly-grasshopper-43) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project SillyGrasshopper43.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SillyGrasshopper43.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|---------|
| `width`, `height` | `50px` | `Width="50"`, `Height="50"` |
| `border-radius` | `50%` | `Ellipse` 요소 사용 |
| `position: absolute` | - | `Canvas` + `Canvas.Left/Top` |
| `background-color` | `#fc3f9e`, `#50e8f3` | `SolidColorBrush` |
| `animation-duration` | `1s` | `Duration="0:0:1"` |
| `animation-delay` | `.5s` | `BeginTime="0:0:0.5"` |
| `animation-iteration-count` | `infinite` | `RepeatBehavior="Forever"` |
| `animation-timing-function` | `cubic-bezier(0.77, 0, 0.175, 1)` | `KeySpline="0.77,0,0.175,1"` |
| `transform: scale()` | `.3` ~ `1` | `ScaleTransform` + `DoubleAnimationUsingKeyFrames` |
| `left` | `0` ~ `50px` | `Canvas.Left` + `DoubleAnimationUsingKeyFrames` |
| `mix-blend-mode` | `multiply` | 미구현 (WPF 미지원) |

## 프로젝트 구조

```
SillyGrasshopper43/
├── Readme.md
├── Wpf/
│   ├── SillyGrasshopper43.Wpf.slnx
│   ├── SillyGrasshopper43.Wpf.Gallery/    # 데모 애플리케이션
│   └── SillyGrasshopper43.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SillyGrasshopper43.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SillyGrasshopper43.xaml
│           └── SillyGrasshopper43Resources.xaml
└── AvaloniaUI/                            # (미구현)
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:SillyGrasshopper43.Wpf.UI.Controls;assembly=SillyGrasshopper43.Wpf.UI">
    <controls:SillyGrasshopper43 />
</Window>
```

## 알려진 제한사항

- **mix-blend-mode 미지원**: CSS의 `mix-blend-mode: multiply`는 WPF에서 직접 지원되지 않아 구현되지 않음. 원본에서는 두 원이 겹칠 때 색상이 혼합되지만, WPF에서는 단순 겹침으로 표시됨.
