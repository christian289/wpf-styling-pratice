# RudeSeahorse6

그라데이션 배경의 버튼과 호버 시 나타나는 다크 모드 툴팁 컨트롤입니다.

## 원본 정보

- **원작자**: Javierrocadev
- **원본 링크**: [https://uiverse.io/Javierrocadev/rude-seahorse-6](https://uiverse.io/Javierrocadev/rude-seahorse-6)
- **분류**: Tooltips

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project RudeSeahorse6.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project RudeSeahorse6.Avalonia.Gallery
```

## 기능

- 그라데이션 배경 버튼 (보라/파랑/청록 그라데이션)
- 호버 시 스케일 애니메이션과 함께 툴팁 표시
- 다크 모드 툴팁 디자인
- 블러 처리된 장식 요소

## 사용 예시

```xml
<controls:RudeSeahorse6 Content="uiverse"
                        TooltipTitle="LET'S CREATE!"
                        TooltipItem1="1 - Explore"
                        TooltipItem2="2 - Have fun!" />
```

## 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Content` | `object` | - | 버튼에 표시할 텍스트 |
| `TooltipTitle` | `string` | "LET'S CREATE!" | 툴팁 제목 |
| `TooltipItem1` | `string` | "1 - Explore" | 툴팁 아이템 1 |
| `TooltipItem2` | `string` | "2 - Have fun!" | 툴팁 아이템 2 |

## CSS → WPF 변환 매핑

| CSS | 값 | WPF | 값 |
|-----|-----|-----|-----|
| `linear-gradient(144deg, ...)` | `#af40ff → #5b42f3 → #00ddeb` | `LinearGradientBrush` | `StartPoint="0,0" EndPoint="0.83,0.83"` |
| `box-shadow` | `0 2px 4px rgba(0,0,0,0.2)` | `DropShadowEffect` | `BlurRadius=4, ShadowDepth=2` |
| `filter: blur(8px)` | - | `BlurEffect` | `Radius=8` |
| `border-radius` | `16px`, `4px` | `CornerRadius` | `16`, `4` |
| `transition` | `0.3s`, `0.2s` | `DoubleAnimation` | `Duration="0:0:0.3"` |
| `transform: scale(2)` | - | `ScaleTransform` | `ScaleX=2, ScaleY=2` |
| `opacity` | `0` → `1` | `DoubleAnimation` | `To=1` |
| `color: aliceblue` | - | `SolidColorBrush` | `Color="AliceBlue"` |
| `background-color` | `#212121`, `#171717` | `SolidColorBrush` | `Color="#212121"`, `Color="#171717"` |
| `::before`, `::after` | pseudo-elements | `Rectangle`, `Ellipse` | 별도 요소로 구현 |
