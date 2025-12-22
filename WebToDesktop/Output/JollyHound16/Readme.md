# JollyHound16

loaders 스타일 컨트롤 - 피자 슬라이스 로더 애니메이션

## 원본 정보

- **원작자**: AkshatDaxini
- **원본 링크**: [https://uiverse.io/AkshatDaxini/jolly-hound-16](https://uiverse.io/AkshatDaxini/jolly-hound-16) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project JollyHound16.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project JollyHound16.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 설명 |
|---------|---------|------|
| `animation: rotate 45s linear infinite` | `DoubleAnimation Duration="0:0:45" RepeatBehavior="Forever"` | 전체 피자 회전 |
| `animation: slice1 4s ease-in-out infinite` | `DoubleAnimationUsingKeyFrames` + `SineEase` | 슬라이스 이동 |
| `animation-delay: 1s` | `BeginTime="0:0:1"` | 순차적 애니메이션 시작 |
| `transform: translate(5%, 5%)` | `TranslateTransform X="8.4" Y="7.9"` | 픽셀 값으로 변환 |
| `transform-origin: center center` | `RenderTransformOrigin="0.5,0.5"` | 중앙 기준 변환 |
| `scale: 1.6` | `Viewbox Stretch="Uniform"` | 크기 조정 |
| SVG `<circle>` | `Ellipse` | 페페로니 |
| SVG `<path>` | `Path Data="..."` | 피자, 토핑 |
| SVG fill color | `SolidColorBrush` (리소스) | 색상 정의 |

## 프로젝트 구조

```
JollyHound16/
├── Wpf/
│   ├── JollyHound16.Wpf.slnx
│   ├── JollyHound16.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│   │   ├── Controls/
│   │   │   └── JollyHound16.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── JollyHound16.xaml
│   │       └── JollyHound16Resources.xaml
│   └── JollyHound16.Wpf.Gallery/     # 데모 앱
└── AvaloniaUI/                        # (미구현)
```

## 컨트롤 사용법

```xml
<Window xmlns:controls="clr-namespace:JollyHound16.Wpf.UI.Controls;assembly=JollyHound16.Wpf.UI">
    <controls:JollyHound16 />
</Window>
```
