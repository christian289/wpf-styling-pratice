# PinkCheetah76

Buttons 스타일 컨트롤

## 원본 정보

- **원작자**: SiddhantEngineer
- **원본 링크**: [https://uiverse.io/SiddhantEngineer/pink-cheetah-76](https://uiverse.io/SiddhantEngineer/pink-cheetah-76) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project PinkCheetah76.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project PinkCheetah76.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `background` | `rgb(255, 0, 0)` | `SolidColorBrush` (#FF0000) |
| `box-shadow` (3D effect) | `0px 5px 0px 0px #CC0000, 0px 5px 0px 5px black` | 중첩된 `Border` 요소로 레이어 구현 |
| `border-radius` | `10px` | `CornerRadius="10"` |
| `padding` | `5px 20px` | `Padding="20,5,20,5"` |
| `font-size` | `24px` | `FontSize="24"` |
| `font-weight` | `900` | `FontWeight="Black"` |
| `color` | `white` | `Foreground="#FFFFFF"` |
| `text-shadow` | `0px 0px 1px black` (3x) | `DropShadowEffect` (BlurRadius=1) |
| `cursor` | `pointer` | `Cursor="Hand"` |
| `transition` | `all 0.1s ease-in-out` | `DoubleAnimation` (Duration=0.1s, QuadraticEase) |
| `:active` transform | `translateY(5px)` | `TranslateTransform.Y` (IsPressed Trigger) |
| `:active` box-shadow | 그림자 제거 | Border Margin 조정 |

## 컨트롤 구조

```
PinkCheetah76 (Button 상속)
├── Grid (컨테이너)
│   └── Grid (TranslateTransform 적용)
│       ├── Border (검정 외곽선 - box-shadow spread)
│       ├── Border (어두운 빨강 그림자 - 3D 깊이감)
│       └── Border (빨강 버튼 본체)
│           └── ContentPresenter (DropShadowEffect)
```

## 특징

- 3D 깊이감 있는 버튼 스타일
- 클릭 시 눌림 효과 애니메이션
- Button 컨트롤 상속으로 기존 Button 기능 모두 사용 가능
