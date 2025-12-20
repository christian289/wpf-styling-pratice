# SilentOtter72

Toggle-switches 스타일 컨트롤 - 체크마크 아이콘이 있는 부드러운 애니메이션 토글 스위치

## 원본 정보

- **원작자**: alexruix
- **원본 링크**: [https://uiverse.io/alexruix/silent-otter-72](https://uiverse.io/alexruix/silent-otter-72)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project SilentOtter72.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SilentOtter72.Avalonia.Gallery
```

## 프로젝트 구조

```
SilentOtter72/
├── Wpf/
│   ├── SilentOtter72.Wpf.slnx
│   ├── SilentOtter72.Wpf.Gallery/     # 데모 앱
│   └── SilentOtter72.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SilentOtter72.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SilentOtter72.xaml
│           └── SilentOtter72Resources.xaml
└── AvaloniaUI/                        # (미구현)
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `width: 3.5em` | `Width="59.5"` |
| `height: 2em` | `Height="34"` |
| `border-radius: 32px` | `CornerRadius="32"` |
| `background-color` | `SolidColorBrush` |
| `transition: .4s` | `ColorAnimation Duration="0:0:0.4"` |
| `transition: transform .25s ease-in-out` | `DoubleAnimation Duration="0:0:0.25" + CubicEase` |
| `transform: translateX(1.5em)` | `Canvas.Left` 애니메이션 |
| `opacity` 트랜지션 | `DoubleAnimation Storyboard.TargetProperty="Opacity"` |
| `::before` pseudo-element | `Ellipse` 요소 |
| SVG `<path>` | `Path` + `StreamGeometry` |
| `:checked` selector | `IsChecked` Trigger |

## 컨트롤 사용 예시

```xml
<controls:SilentOtter72 IsChecked="False"/>
<controls:SilentOtter72 IsChecked="True"/>
```

## 기능

- Unchecked → Checked 상태 전환 시 부드러운 애니메이션
- 체크마크 아이콘 페이드인/페이드아웃
- Thumb(원형 버튼) 슬라이드 애니메이션
- 배경색 전환 애니메이션
