# SillySheep7

스큐어모피즘(Skeuomorphism) 스타일의 회전 노브 라디오 버튼 컨트롤입니다.

## 원본 정보

- **원작자**: Subaashbala
- **원본 링크**: [https://uiverse.io/Subaashbala/silly-sheep-7](https://uiverse.io/Subaashbala/silly-sheep-7)
- **태그**: skeuomorphism, realistic, radio, rotate, click effect

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project SillySheep7.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SillySheep7.Avalonia.Gallery
```

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `position: absolute` | `Canvas` + `Canvas.Left/Top` |
| `border-radius: 50%` | `CornerRadius` (Border의 절반 크기) |
| `transform: rotateZ(deg)` | `RotateTransform` + `Angle` |
| `transform: translateX(-50%)` | `Canvas.Left` 계산으로 대체 |
| `box-shadow` | `DropShadowEffect` |
| `aspect-ratio: 1` | 동일한 `Width`/`Height` 설정 |
| `::after` pseudo-element | 내부 `Rectangle` 요소 |
| `:has(:checked)` selector | `RoutedCommand` + `SelectedIndex` 바인딩 |
| `transition: transform 350ms` | 미구현 (Storyboard 추가 필요) |
| Multiple `box-shadow` | 단일 `DropShadowEffect`로 단순화 |

## 사용법

```xml
<controls:SillySheep7 SelectedIndex="2"/>
```

- `SelectedIndex`: 0~4 범위의 선택된 인덱스
- `KnobAngle`: 읽기 전용, 노브의 현재 회전 각도 (-60 ~ 60도)

## 주요 파일

### SillySheep7.Wpf.UI (라이브러리)

| 파일 | 설명 |
|-----|------|
| `Controls/SillySheep7.cs` | Selector 기반 커스텀 컨트롤 |
| `Controls/SillySheep7Commands.cs` | SelectIndex RoutedCommand |
| `Controls/IndexToBoolConverter.cs` | 인덱스↔Boolean 변환기 |
| `Themes/SillySheep7Resources.xaml` | 테마 리소스 (색상, 크기) |
| `Themes/SillySheep7.xaml` | ControlTemplate 및 Style |
