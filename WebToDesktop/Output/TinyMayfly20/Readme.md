# TinyMayfly20

Notifications 스타일 컨트롤 - 게임 스타일의 픽셀 아트 알림 UI

## 원본 정보

- **원작자**: M4NT
- **원본 링크**: [https://uiverse.io/M4NT/tiny-mayfly-20](https://uiverse.io/M4NT/tiny-mayfly-20) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project TinyMayfly20.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project TinyMayfly20.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:TinyMayfly20 />

<!-- 커스텀 텍스트 -->
<controls:TinyMayfly20
    Title="Victory!"
    Subtitle="Experience gained:"
    PowerValue="+1500 XP" />
```

## DependencyProperty

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Title` | `string` | "Level up!" | 타이틀 텍스트 |
| `Subtitle` | `string` | "Your power:" | 서브타이틀 텍스트 |
| `PowerValue` | `string` | "+8000!" | 파워 값 텍스트 |

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 비고 |
|-----|-----|------|
| `.notification` (background) | `Border.Background` | SolidColorBrush #18532C |
| `border-radius: 14px` | `CornerRadius="14"` | Border 속성 |
| `transform: translateY(-8px)` | `TranslateTransform.Y` | EventTrigger 애니메이션 |
| `transition: 0.5s` | `DoubleAnimation Duration="0:0:0.3"` | 호버 트랜지션 |
| `.parchment` (background) | `Border.Background` | SolidColorBrush #FFFCD3 |
| `border: 1px dashed` | `Border.BorderBrush` + `BorderThickness` | 점선 효과는 WPF에서 별도 처리 필요 |
| `@keyframes head` | `DoubleAnimationUsingKeyFrames` | 바운스 애니메이션 |
| `box-shadow` (pixel art) | `Ellipse`, `Rectangle`, `Polygon` | 단순화된 벡터 캐릭터 |
| `:hover` 색상 변경 | `ColorAnimation` | 텍스트 호버 효과 |
| `font-family: 'VT323'` | `FontFamily="Consolas"` | 시스템 폰트로 대체 |
| `z-index` | 선언 순서 또는 `Panel.ZIndex` | XAML 선언 순서로 처리 |
| `display: flex; flex-direction: column` | `StackPanel` | 세로 정렬 |
| `transform: scale(0.5)` | `ScaleTransform` | 캐릭터 크기 조절 |

## 주요 특징

- 게임 스타일의 레트로 알림 UI
- 호버 시 상승 애니메이션
- 캐릭터 바운스 애니메이션
- 텍스트 색상 변경 효과
- 커스터마이징 가능한 텍스트 속성
