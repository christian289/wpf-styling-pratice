# PopularCrab99

loaders 스타일 컨트롤 - 4개의 색상 박스가 시계 방향으로 회전하는 로더 애니메이션

## 원본 정보

- **원작자**: NlghtM4re
- **원본 링크**: [https://uiverse.io/NlghtM4re/popular-crab-99](https://uiverse.io/NlghtM4re/popular-crab-99)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project PopularCrab99.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project PopularCrab99.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성/요소 | WPF 값 |
|---------|--------|--------------|--------|
| `width`, `height` (container) | `120px` | `Width`, `Height` | `120` |
| `width`, `height` (box) | `30px` | `Width`, `Height` | `30` |
| `background-color` | `rgb(158, 136, 246)` 등 | `Background` | `SolidColorBrush` (#9E88F6 등) |
| `box-shadow` | `0px 7px 29px 0px` | `DropShadowEffect` | `BlurRadius=29, ShadowDepth=7, Direction=270` |
| `transform: translate()` | `translate(-30px, -30px)` | `TranslateTransform` | `X="-30" Y="-30"` |
| `animation` | `move 4s infinite` | `Storyboard` | `RepeatBehavior="Forever"` + 4초 Duration |
| `animation-delay` | `-1s, -2s, -3s, -4s` | 키프레임 오프셋 | 초기 위치와 애니메이션 순서로 구현 |
| `@keyframes` | `0%`, `25%`, `50%`, `75%`, `100%` | `DoubleAnimationUsingKeyFrames` | `LinearDoubleKeyFrame` (0s, 1s, 2s, 3s, 4s) |
| `display: flex` + 정렬 | `justify-content: center` | `HorizontalAlignment` | `Center` |
| `position: absolute` | - | `Grid` 레이아웃 | 모든 박스가 동일한 Grid 셀에 겹침 |
