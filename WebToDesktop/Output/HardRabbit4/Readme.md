# HardRabbit4

Patterns 스타일 컨트롤 - 도트 패턴 배경을 가진 컨테이너

## 원본 정보

- **원작자**: escannord
- **원본 링크**: [https://uiverse.io/escannord/hard-rabbit-4](https://uiverse.io/escannord/hard-rabbit-4) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project HardRabbit4.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project HardRabbit4.Avalonia.Gallery
```

## CSS -> WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `background: rgba(29, 31, 32, 0.904)` | `SolidColorBrush Color="#E71D1F20"` | 배경색 (투명도 포함) |
| `radial-gradient(...)` | `DrawingBrush` + `EllipseGeometry` | 도트 패턴 |
| `background-size: 11px 11px` | `Viewport="0,0,11,11" ViewportUnits="Absolute"` | 패턴 타일 크기 |
| 도트 크기 10% | `RadiusX="0.55" RadiusY="0.55"` | 도트 반지름 (11*0.1/2) |
| `rgba(255, 255, 255, 0.712)` | `SolidColorBrush Color="#B5FFFFFF"` | 도트 색상 |

## 프로젝트 구조

```
HardRabbit4/
├── Readme.md
├── Wpf/
│   ├── HardRabbit4.Wpf.slnx
│   ├── HardRabbit4.Wpf.Gallery/     # 데모 애플리케이션
│   └── HardRabbit4.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── HardRabbit4.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── HardRabbit4.xaml
│           └── HardRabbit4Resources.xaml
└── AvaloniaUI/                       # (미구현)
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:HardRabbit4.Wpf.UI.Controls;assembly=HardRabbit4.Wpf.UI">
    <controls:HardRabbit4>
        <!-- 콘텐츠를 여기에 배치 -->
        <TextBlock Text="Hello World" Foreground="White" />
    </controls:HardRabbit4>
</Window>
```
