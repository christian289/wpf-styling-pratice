# FatDodo89

Loaders 스타일 컨트롤 - 스마일 얼굴 로딩 애니메이션

## 원본 정보

- **원작자**: fanishah
- **원본 링크**: [https://uiverse.io/fanishah/fat-dodo-89](https://uiverse.io/fanishah/fat-dodo-89) (클릭 시 원본 CSS/HTML 확인 가능)

## 미리보기

두 개의 눈과 입이 있는 스마일 얼굴이 회전하며 로딩 애니메이션을 표시합니다.
시안(Cyan)과 파랑(Blue) 두 가지 색상이 그라데이션으로 블렌딩됩니다.

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project FatDodo89.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project FatDodo89.Avalonia.Gallery
```

## 사용법

```xml
<Window xmlns:controls="clr-namespace:FatDodo89.Wpf.UI.Controls;assembly=FatDodo89.Wpf.UI">
    <controls:FatDodo89 />
</Window>
```

## CSS → WPF 변환 매핑 테이블

| CSS / SVG                           | WPF                                              |
| ----------------------------------- | ------------------------------------------------ |
| `<svg viewBox="0 0 128 128">`       | `Viewbox` + `Canvas Width="128" Height="128"`    |
| `<circle r="8" cx="64" cy="64">`    | `Ellipse Width="16" Height="16"`                 |
| `stroke="hsl(193,90%,50%)"`         | `Stroke="{StaticResource FatDodo89.Brush.Cyan}"` |
| `stroke-width="12"`                 | `StrokeThickness="12"`                           |
| `stroke-linecap="round"`            | `StrokeStartLineCap="Round"`                     |
| `stroke-dasharray="175.93 351.86"`  | `StrokeDashArray="5 10"` (비율 조정)             |
| `transform-origin: 64px 64px`       | `RenderTransformOrigin="0.5,4.5"`                |
| `animation: eye1 3s infinite`       | `Storyboard RepeatBehavior="Forever"`            |
| `visibility: hidden`                | `Visibility="Hidden"`                            |
| `<mask>` + `<linearGradient>`       | `Canvas.OpacityMask` + `LinearGradientBrush`     |
| `hsl(193,90%,50%)` (시안)           | `#0AC2E8`                                        |
| `hsl(223,90%,50%)` (파랑)           | `#0D47F0`                                        |

## 애니메이션 상세

| 요소     | 애니메이션                        | 시간        |
| -------- | --------------------------------- | ----------- |
| Eye 1    | 회전 -260° → -40° → 225°         | 0s → 1.5s → 3s |
| Eye 2    | 회전 -260° → 40° → 150° + 깜빡임 | 0s → 1.5s → 3s |
| Mouth 1  | 나타남 → 회전 → 사라짐           | 0s → 1.5s      |
| Mouth 2  | 사라짐 → 나타남 → 회전           | 1.5s → 3s      |

## 프로젝트 구조

```
FatDodo89/
├── Readme.md
├── Wpf/
│   ├── FatDodo89.Wpf.slnx
│   ├── FatDodo89.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── FatDodo89.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── FatDodo89.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── FatDodo89.xaml
│           └── FatDodo89Resources.xaml
└── AvaloniaUI/                    # (미구현)
```

## 기술 스택

- .NET 9.0+
- WPF (Windows Presentation Foundation)
- XAML Storyboard 애니메이션
