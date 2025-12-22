# BitterWolverine27

호버 시 팝업되는 Tooltip 스타일 컨트롤

## 원본 정보

- **원작자:** Quezaquo
- **원본 링크:** [https://uiverse.io/Quezaquo/bitter-wolverine-27](https://uiverse.io/Quezaquo/bitter-wolverine-27)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project BitterWolverine27.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BitterWolverine27.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성/기능 | WPF 구현 |
|--------------|----------|
| `position: relative/absolute` | `Grid` + `Margin` + `VerticalAlignment` |
| `cursor: pointer` | `Cursor="Hand"` |
| `display: inline-block` | `HorizontalAlignment="Left"` |
| `text-decoration: underline` | `TextBlock.TextDecorations` |
| `text-underline-offset` | WPF에서 직접 지원 안 함 (기본 밑줄 사용) |
| `opacity: 0/1` | `Opacity` 속성 + `DoubleAnimation` |
| `visibility: hidden/visible` | `Opacity` 애니메이션으로 대체 |
| `transform: scaleY()` | `ScaleTransform.ScaleY` |
| `transform: translateY()` | `TranslateTransform.Y` |
| `transform-origin: center top` | `RenderTransformOrigin="0.5,0"` |
| `box-shadow` | `DropShadowEffect` |
| `border-radius` | `CornerRadius` |
| `::before` (화살표) | `Polygon` 요소 |
| `transition` | WPF `Storyboard` 사용 불가, Trigger 애니메이션으로 대체 |
| `animation` (goPopup) | `DoubleAnimationUsingKeyFrames` + `SplineDoubleKeyFrame` |
| `animation` (bounce) | `DoubleAnimationUsingKeyFrames` + `RepeatBehavior="Forever"` |
| `cubic-bezier(0.68,-0.55,0.27,1.55)` | `KeySpline="0.68,-0.55,0.27,1.55"` (근사값, 오버슈트 제한됨) |
| `:hover` | `Trigger Property="IsMouseOver"` |
| `animation-iteration-count: infinite` | `RepeatBehavior="Forever"` |

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `HoverText` | `string` | "Hover me !" | 메인 텍스트 (호버 영역) |
| `TooltipText` | `string` | "Heyy👋" | Tooltip에 표시될 텍스트 |

## 사용 예시

```xml
<controls:BitterWolverine27
    HoverText="Click here !"
    TooltipText="Hello there!"/>
```

## 프로젝트 구조

```
BitterWolverine27/
├── Wpf/
│   ├── BitterWolverine27.Wpf.slnx
│   ├── BitterWolverine27.Wpf.Gallery/    # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── BitterWolverine27.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── BitterWolverine27.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── BitterWolverine27.xaml
│           └── BitterWolverine27Resources.xaml
└── AvaloniaUI/                           # (미구현)
```
