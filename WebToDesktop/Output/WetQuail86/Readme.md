# WetQuail86

Inputs 스타일 컨트롤 - Hover 시 Title 툴팁이 나타나는 모던 Input 컨트롤

## 원본 정보

- **원작자:** catraco
- **원본 링크:** [https://uiverse.io/catraco/wet-quail-86](https://uiverse.io/catraco/wet-quail-86)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project WetQuail86.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project WetQuail86.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 비고 |
|---------|---------|------|
| `--light: rgb(255, 255, 255)` | `SolidColorBrush Color="#FFFFFF"` | CSS 변수 → StaticResource |
| `--dark: rgb(50, 50, 50)` | `SolidColorBrush Color="#323232"` | CSS 변수 → StaticResource |
| `--br: 8px` | `CornerRadius="8"` | CSS 변수 → CornerRadius |
| `border: 2px solid white` | `BorderThickness="2" BorderBrush="White"` | 직접 매핑 |
| `border-radius: var(--br)` | `CornerRadius="{StaticResource ...}"` | StaticResource 바인딩 |
| `opacity: .8` | `Opacity="0.8"` | 직접 매핑 |
| `transition: .2s ease-in-out` | `DoubleAnimation Duration="0:0:0.2"` | Storyboard 애니메이션 |
| `transform: translate(-50%, -150%)` | `TranslateTransform Y="-5"` + 레이아웃 조정 | 상대 위치 조정 |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` | 직접 매핑 |
| `position: absolute` | Grid 레이아웃 + Alignment | WPF 레이아웃 시스템 사용 |
| `::before` pseudo-element | 별도 Border 요소 | 추가 XAML 요소로 구현 |
| `letter-spacing: 2px` | - | WPF 미지원 |
| `:hover` pseudo-class | `IsMouseOver` Trigger | Trigger 애니메이션 |
| `:focus` pseudo-class | `IsKeyboardFocusWithin` Trigger | Trigger 애니메이션 |

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|--------|------|
| `Title` | `string` | `"Title"` | 호버 시 표시되는 제목 |
| `Text` | `string` | `""` | 입력 텍스트 (양방향 바인딩) |
| `Placeholder` | `string` | `""` | Placeholder 텍스트 |

## 사용 예시

```xml
<controls:WetQuail86 Title="Username" Width="200" />
<controls:WetQuail86 Title="Email" Placeholder="Enter your email" Width="200" />
```
