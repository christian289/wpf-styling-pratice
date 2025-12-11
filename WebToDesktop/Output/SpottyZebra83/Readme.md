# SpottyZebra83

Tooltips 스타일 컨트롤

## 원본 정보

- **원작자**: gharsh11032000
- **원본 링크**: [https://uiverse.io/gharsh11032000/spotty-zebra-83](https://uiverse.io/gharsh11032000/spotty-zebra-83)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project SpottyZebra83.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SpottyZebra83.Avalonia.Gallery
```

## 컨트롤 특징

- 호버 시 상단에 툴팁 표시
- 호버 시 내부 텍스트가 새로운 텍스트로 전환 (슬라이드 애니메이션)
- 툴팁 흔들림(shake) 애니메이션
- 부드러운 cubic-bezier 이징 효과

## 사용 예시

```xml
<controls:SpottyZebra83 Content="Tooltip 👆"
                        TooltipText="Uiverse.io"
                        HoverText="Hello! 👋" />
```

## 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `Content` | object | - | 기본 표시 텍스트 |
| `TooltipText` | string | "Uiverse.io" | 호버 시 상단 툴팁에 표시될 텍스트 |
| `HoverText` | string | "Hello! 👋" | 호버 시 컨트롤 내부에 표시될 텍스트 |

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `--background: #333333` | `SolidColorBrush` 리소스 |
| `--color: #e8e8e8` | `SolidColorBrush` 리소스 |
| `transition: all 0.4s cubic-bezier(0.23, 1, 0.32, 1)` | `DoubleAnimation Duration="0:0:0.4"` + `CubicEase EaseOut` |
| `transform: scale(0)` | `ScaleTransform` |
| `transform: translateX(-50%)` | `TranslateTransform` |
| `opacity` 애니메이션 | `DoubleAnimation Storyboard.TargetProperty="Opacity"` |
| `box-shadow: rgba(0,0,0,0.25) 0 8px 15px` | `DropShadowEffect ShadowDepth="8" BlurRadius="15" Opacity="0.25"` |
| `border-radius: 8px` | `CornerRadius="8"` |
| `@keyframes shake` (rotate) | `DoubleAnimationUsingKeyFrames` + `RotateTransform` |
| `::before` (tooltip arrow) | `Polygon Points="0,0 5,8 10,0"` |
| `position: absolute` | `Grid` 내 요소 오버레이 |
| `z-index` | XAML 선언 순서 |
