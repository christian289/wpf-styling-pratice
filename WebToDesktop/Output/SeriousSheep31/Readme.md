# SeriousSheep31

Radio-buttons 스타일 컨트롤 - Neumorphism 디자인의 라디오 버튼 그룹

## 원본 정보

- **원작자**: neerajbaniwal
- **원본 링크**: [https://uiverse.io/neerajbaniwal/serious-sheep-31](https://uiverse.io/neerajbaniwal/serious-sheep-31) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: radio, submit, switcher, html, css, 3d button

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project SeriousSheep31.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SeriousSheep31.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:NeumorphicRadioButtonGroup>
    <controls:NeumorphicRadioButton Content="a) close" GroupName="Options" IsChecked="True" />
    <controls:NeumorphicRadioButton Content="b) remove" GroupName="Options" />
    <controls:NeumorphicRadioButton Content="c) delete" GroupName="Options" />
    <controls:NeumorphicRadioButton Content="d) all of the above" GroupName="Options" />
</controls:NeumorphicRadioButtonGroup>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 구현 |
|----------|-----|----------|
| `background` | `#ecf0f3` | `SolidColorBrush` |
| `box-shadow` (inset) | `4px 4px 4px 0px #d1d9e6 inset` | `DropShadowEffect` + `LinearGradientBrush` |
| `box-shadow` (outer) | `-8px -4px 8px 0px #ffffff` | `DropShadowEffect` |
| `border-radius` | `16px`, `50%` | `CornerRadius`, `Ellipse` |
| `padding` | `48px 64px` | `Padding="64,48,64,48"` |
| `margin` | `8px 0` | `Margin="0,8,0,8"` |
| `transition` | `opacity 0.2s linear` | `DoubleAnimation Duration="0:0:0.2"` |
| `transition` | `transform 0.25s ease-in-out` | `DoubleAnimation Duration="0:0:0.25"` + `SineEase` |
| `transform: scale3d()` | `scale3d(0.975, 0.975, 1)` | `ScaleTransform ScaleX="0.975" ScaleY="0.975"` |
| `transform: translate3d()` | `translate3d(0, 10%, 0)` | `TranslateTransform Y="2.4"` |
| `::before`, `::after` | pseudo-elements | 추가 `Ellipse` 요소 |
| `opacity` | `0.6` | `Opacity="0.6"` |
| `cursor: pointer` | - | `Cursor="Hand"` |
| `color` | `#394a56` | `Foreground` |

## 주요 특징

- **Neumorphism 스타일**: 부드러운 그림자 효과로 3D 느낌 구현
- **부드러운 애니메이션**: 선택/호버/포커스 상태에 따른 부드러운 전환 효과
- **원형 인디케이터**: 선택 시 내부 원이 페이드아웃되는 애니메이션
- **텍스트 상호작용**: 호버/포커스 시 텍스트 투명도 및 위치 변화

## 프로젝트 구조

```
SeriousSheep31/
├── Wpf/
│   ├── SeriousSheep31.Wpf.slnx
│   ├── SeriousSheep31.Wpf.Gallery/     # 데모 앱
│   └── SeriousSheep31.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   ├── NeumorphicRadioButton.cs
│       │   └── NeumorphicRadioButtonGroup.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── NeumorphicRadioButton.xaml
│           └── NeumorphicRadioButtonResources.xaml
└── AvaloniaUI/                         # (미구현)
```
