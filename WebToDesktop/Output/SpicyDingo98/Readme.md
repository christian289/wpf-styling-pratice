# SpicyDingo98

Radio-buttons 스타일 컨트롤 - 아이콘이 있는 라디오 버튼 그룹

## 원본 정보

- **원작자**: Yaya12085
- **원본 링크**: [https://uiverse.io/Yaya12085/spicy-dingo-98](https://uiverse.io/Yaya12085/spicy-dingo-98)
- **태그**: button, hover, radio, futuristic

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project SpicyDingo98.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SpicyDingo98.Avalonia.Gallery
```

## 사용법

```xml
<controls:SpicyDingo98 HorizontalAlignment="Center">
    <controls:SpicyDingo98Item IsSelected="True">
        <Path Data="{StaticResource SpicyDingo98.Icon.Bicycle}"
              Fill="White" Stretch="Uniform"/>
    </controls:SpicyDingo98Item>
    <controls:SpicyDingo98Item>
        <Path Data="{StaticResource SpicyDingo98.Icon.Motorcycle}"
              Fill="White" Stretch="Uniform"/>
    </controls:SpicyDingo98Item>
    <controls:SpicyDingo98Item>
        <Path Data="{StaticResource SpicyDingo98.Icon.Car}"
              Fill="White" Stretch="Uniform"/>
    </controls:SpicyDingo98Item>
</controls:SpicyDingo98>
```

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 변환 |
|---------|---------|
| `display: flex` | `StackPanel Orientation="Horizontal"` |
| `border-radius: 30px` | `CornerRadius="30"` |
| `box-shadow: 0 5px 15px rgba(0,0,0,0.3)` | `DropShadowEffect BlurRadius="15" ShadowDepth="5" Opacity="0.3"` |
| `::before` pseudo-element | 별도 `Border` 요소 (Margin="-5") |
| `transform: scale(1.2)` | `ScaleTransform` + `DoubleAnimation` |
| `transform: rotate(90deg)` | `RotateTransform` + `DoubleAnimation` |
| `linear-gradient(to top left, #D4145A, #FBB03B)` | `LinearGradientBrush StartPoint="1,1" EndPoint="0,0"` |
| `animation: pulse-border 1s ease infinite` | `DoubleAnimation Duration="0:0:1" RepeatBehavior="Forever" AutoReverse="True"` |
| `transition: 0.3s ease` | `DoubleAnimation Duration="0:0:0.3"` with `QuadraticEase` |
| `cursor: pointer` | `Cursor="Hand"` |
| `z-index: 1` | `Panel.ZIndex="1"` |
| `background-color: #444` | `SolidColorBrush Color="#444444"` |
| `background-color: #FBB03B` (hover) | Trigger `IsMouseOver` → Background 변경 |
| `border: 2px solid #fff` | `BorderThickness="2" BorderBrush="#FFFFFF"` |
| `border-color: #D4145A` (selected) | Trigger `IsSelected` → BorderBrush 변경 |

## 프로젝트 구조

```
SpicyDingo98/
├── Wpf/
│   ├── SpicyDingo98.Wpf.slnx
│   ├── SpicyDingo98.Wpf.Gallery/    # 데모 앱
│   └── SpicyDingo98.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   ├── SpicyDingo98.cs      # 라디오 그룹 컨테이너
│       │   └── SpicyDingo98Item.cs  # 개별 라디오 아이템
│       └── Themes/
│           ├── Generic.xaml
│           ├── SpicyDingo98.xaml
│           └── SpicyDingo98Resources.xaml
└── AvaloniaUI/                       # (미구현)
```
