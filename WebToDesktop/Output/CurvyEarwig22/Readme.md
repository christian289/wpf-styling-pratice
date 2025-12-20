# CurvyEarwig22

Inputs 스타일 컨트롤 - 네온 그라데이션 테두리가 있는 검색 입력 컨트롤

## 원본 정보

- **원작자**: Lakshay-art
- **원본 링크**: [https://uiverse.io/Lakshay-art/curvy-earwig-22](https://uiverse.io/Lakshay-art/curvy-earwig-22) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project CurvyEarwig22.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project CurvyEarwig22.Avalonia.Gallery
```

## 주요 기능

- 네온 그라데이션 테두리 효과
- 호버/포커스 시 테두리 회전 애니메이션
- 검색 아이콘 및 필터 아이콘
- 플레이스홀더 텍스트 지원
- 텍스트 바인딩 지원 (Text 속성)

## 사용 예시

```xml
<controls:CurvyEarwig22 Placeholder="Search..." />
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 비고 |
|----------|----------|------|
| `conic-gradient` | `LinearGradientBrush` + `RotateTransform` | WPF는 conic-gradient 미지원, 근사 구현 |
| `filter: blur(30px)` | `BlurEffect Radius="30"` | |
| `filter: blur(3px)` | `BlurEffect Radius="3"` | |
| `border-radius: 12px` | `CornerRadius="12"` | |
| `overflow: hidden` + `border-radius` | `Border.Clip` + `RectangleGeometry` | MultiBinding으로 동적 크기 계산 |
| `::before` pseudo-element | Canvas 내 Rectangle | z-order는 선언 순서로 결정 |
| `transition: all 2s` | `DoubleAnimation Duration="0:0:2"` | Storyboard 사용 |
| `transition: all 4s` | `DoubleAnimation Duration="0:0:4"` | 포커스 시 더 긴 애니메이션 |
| `transform: rotate(82deg)` | `RotateTransform Angle="82"` | |
| `:hover` | `Trigger Property="IsMouseOver"` | |
| `:focus-within` | `Trigger Property="IsKeyboardFocusWithin"` | |
| `position: absolute` | `Canvas.Left/Top` 또는 `Margin` | |
| `z-index` | 선언 순서 | 나중에 선언된 요소가 위 |
| `linear-gradient(180deg, ...)` | `LinearGradientBrush StartPoint="0,0" EndPoint="0,1"` | |
| `linear-gradient(90deg, ...)` | `LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5"` | |
| `background-color: #010201` | `SolidColorBrush Color="#010201"` | |
| `color: white` | `Foreground="#FFFFFF"` | |
| `::placeholder` | TextBlock (Visibility 제어) | WPF TextBox는 placeholder 미지원 |
| `stroke: url(#gradient)` | Path.Stroke + LinearGradientBrush | |
| `opacity: 0.4` | `Opacity="0.4"` | |
| `opacity: 0` | `Opacity="0"` (Trigger Setter) | 호버 시 투명 처리 |

## 프로젝트 구조

```
CurvyEarwig22/
├── Wpf/
│   ├── CurvyEarwig22.Wpf.slnx
│   ├── CurvyEarwig22.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── CurvyEarwig22.cs
│   │   ├── Converters/
│   │   │   ├── SizeToRectConverter.cs
│   │   │   └── StringToBoolConverter.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── CurvyEarwig22.xaml
│   │       └── CurvyEarwig22Resources.xaml
│   └── CurvyEarwig22.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (TBD)
```
