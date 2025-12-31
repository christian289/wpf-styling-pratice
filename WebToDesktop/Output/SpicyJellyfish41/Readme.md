# SpicyJellyfish41

Checkboxes 스타일 컨트롤 - 햄버거 메뉴 토글 버튼

## 원본 정보

- **원작자:** ahmedyasserdev
- **원본 링크:** [https://uiverse.io/ahmedyasserdev/spicy-jellyfish-41](https://uiverse.io/ahmedyasserdev/spicy-jellyfish-41)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project SpicyJellyfish41.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SpicyJellyfish41.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `display: block` | span 요소 | `Border` 요소 |
| `width` | `30px` | `Width="30"` |
| `height` | `3px` | `Height="3"` |
| `background` | `#333` | `SolidColorBrush Color="#333333"` |
| `margin` | `6px 0` | `Margin="0,0,0,6"` |
| `cursor` | `pointer` | `Cursor="Hand"` |
| `transition` | `0.3s cubic-bezier(0.68,-0.55,0.265,1.55)` | `SplineDoubleKeyFrame KeyTime="0:0:0.3" KeySpline="0.68,-0.55,0.265,1.55"` |
| `transform: translateY()` | `8px` / `-8px` | `TranslateTransform Y="9"` / `Y="-9"` |
| `transform: rotate()` | `45deg` / `-45deg` | `RotateTransform Angle="45"` / `Angle="-45"` |
| `transform: translateX()` | `-20px` | `TranslateTransform X="-20"` |
| `opacity` | `0` / `1` | `Opacity="0"` / `Opacity="1"` |
| `:checked + .burger span` | pseudo selector | `Trigger Property="IsChecked" Value="True"` |

## 컨트롤 구조

```
SpicyJellyfish41 (ToggleButton)
└── Grid
    └── StackPanel
        ├── Border (Line1) - 상단 줄, 체크 시 아래로 이동 + 45° 회전
        ├── Border (Line2) - 중간 줄, 체크 시 왼쪽으로 사라짐
        └── Border (Line3) - 하단 줄, 체크 시 위로 이동 + -45° 회전
```

## 애니메이션

- **Duration:** 0.3초
- **Easing:** cubic-bezier(0.68, -0.55, 0.265, 1.55) - Back ease in/out 유사
- **효과:** 햄버거 아이콘(≡) ↔ X 아이콘 토글
