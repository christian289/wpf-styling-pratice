# BlackRabbit68

Cards 스타일 컨트롤 - 3D 회전하는 비트코인 코인 애니메이션

## 원본 정보

- **원작자**: JohnnyCSilva
- **원본 링크**: [https://uiverse.io/JohnnyCSilva/black-rabbit-68](https://uiverse.io/JohnnyCSilva/black-rabbit-68)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project BlackRabbit68.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BlackRabbit68.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 구현 |
|----------|-----|----------|
| `animation` | `rotate_4001510 7s infinite linear` | `Storyboard` + `RepeatBehavior="Forever"` + 7초 Duration |
| `transform-style` | `preserve-3d` | N/A (2D 시뮬레이션) |
| `transform: rotateY()` | `-90deg`, `90deg`, `360deg` | `ScaleTransform.ScaleX` (1 → 0 → -1 → 0 → 1) |
| `backface-visibility` | `hidden` | `Visibility` 전환 (KeyFrame 애니메이션) |
| `border-radius` | `50%` | `Ellipse` 컨트롤 사용 |
| `background` | `linear-gradient(#faa504, #141001)` | `LinearGradientBrush` |
| `transform: scaleX(-1)` | 뒷면 반전 | `ScaleTransform ScaleX="-1"` |
| `width: 1em` / `height: 1em` | em 기반 크기 | `CoinSize` DependencyProperty |

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `CoinSize` | `double` | `200` | 코인 크기 (픽셀) |
| `AnimationDuration` | `double` | `7.0` | 애니메이션 지속 시간 (초) - 현재 XAML에 하드코딩됨 |

## 사용 예제

```xml
<Window xmlns:controls="clr-namespace:BlackRabbit68.Wpf.UI.Controls;assembly=BlackRabbit68.Wpf.UI">
    <controls:BlackRabbit68 Width="300" Height="300" CoinSize="300"/>
</Window>
```

## 구현 노트

- WPF는 CSS의 `rotateY()`와 같은 3D 변환을 네이티브로 지원하지 않음
- `ScaleTransform.ScaleX`를 사용하여 3D 회전 효과를 2D로 시뮬레이션
- 코인 앞/뒷면은 `Visibility` 전환으로 구현
- SVG path 데이터를 WPF `Geometry` 리소스로 변환
