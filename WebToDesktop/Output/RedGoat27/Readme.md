# RedGoat27

Notifications 스타일 컨트롤 - 트로피 아이콘과 축하 메시지를 표시하는 알림 컴포넌트입니다.

## 원본 정보

- **원작자**: devsleonardo
- **원본 링크**: [https://uiverse.io/devsleonardo/red-goat-27](https://uiverse.io/devsleonardo/red-goat-27) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project RedGoat27.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project RedGoat27.Avalonia.Gallery
```

## 기능

- 트로피 아이콘 (SVG → XAML Path 변환)
- 로드 시 바운스 애니메이션
- 마우스 호버 시 360° 스핀 애니메이션
- 커스텀 Title/Message 프로퍼티

## 사용법

```xml
<controls:RedGoat27
    Title="Congratulations!"
    Message="You reached level 10!"/>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 |
|----------|----------|
| `fill: gold` | `SolidColorBrush Color="Gold"` |
| `color: white` | `SolidColorBrush Color="White"` |
| `width/height: 80px` | `sys:Double` 리소스 + Viewbox |
| `animation: bounce 0.5s` | `DoubleAnimationUsingKeyFrames Duration="0:0:0.5"` |
| `animation: spin 1s` | `DoubleAnimation Duration="0:0:1"` |
| `@keyframes bounce (translateY)` | `TranslateTransform.Y` + EasingDoubleKeyFrame |
| `@keyframes spin (rotate)` | `RotateTransform.Angle` + DoubleAnimation |
| `ease-in-out` | `QuadraticEase EasingMode="EaseInOut"` |
| `:hover` | `EventTrigger RoutedEvent="MouseEnter"` |
| `flex-direction: column` | `StackPanel` (기본 Vertical) |
| `text-align: center` | `HorizontalAlignment="Center"` |
| SVG `<path d="...">` | `Geometry` 리소스 + `Path Data="{StaticResource ...}"` |
