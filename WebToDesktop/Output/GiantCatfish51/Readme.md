# GiantCatfish51

Tooltips 스타일 컨트롤 - Hover 시 상단에 말풍선 형태의 툴팁이 나타나는 버튼

## 원본 정보

- **원작자**: Siyu1017
- **원본 링크**: [https://uiverse.io/Siyu1017/giant-catfish-51](https://uiverse.io/Siyu1017/giant-catfish-51)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project GiantCatfish51.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project GiantCatfish51.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성/값 | WPF 구현 |
|------------|----------|
| `linear-gradient(135deg, #a940fd, #5b46e8)` | `LinearGradientBrush` (StartPoint="0,0" EndPoint="1,1") |
| `box-shadow: 0 4px 16px 4px rgba(0,0,0,0.15)` | `DropShadowEffect` (ShadowDepth=4, BlurRadius=16, Opacity=0.15) |
| `border-radius: 0.75rem` | `CornerRadius="12"` |
| `transition: all 0.2s` | `Storyboard` + `DoubleAnimation` (Duration="0:0:0.2") |
| `transform: scale(0)` → `scale(1)` | `ScaleTransform` (ScaleX/ScaleY 애니메이션) |
| `transform: translateY(-100%)` | `TranslateTransform` (Y 속성 애니메이션) |
| `opacity: 0` → `opacity: 1` | `DoubleAnimation` (Opacity 속성) |
| `::before` (화살표) | 별도 `Border` + `RotateTransform` (Angle=45) |
| CSS Variables (`--bg`, `--color`, etc.) | ResourceDictionary 리소스 (`x:Key`) |
| `:hover` 상태 | `Trigger` (Property="IsMouseOver" Value="True") |
| `padding: 0.7em 1.8em` | `Thickness` (Padding="30,12,30,12") |

## 컨트롤 사용법

```xml
<controls:GiantCatfish51 TooltipText="Uiverse.io" Content="Tooltip"/>
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `TooltipText` | string | "Tooltip" | 툴팁에 표시할 텍스트 |
| `Content` | object | - | 버튼에 표시할 콘텐츠 |
