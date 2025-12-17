# QuietHorse20

Buttons 스타일 컨트롤 - 아이콘과 텍스트가 포함된 모던 버튼

## 원본 정보

- **원작자:** aurellsoleil
- **원본 링크:** [https://uiverse.io/aurellsoleil/quiet-horse-20](https://uiverse.io/aurellsoleil/quiet-horse-20) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그:** icon, white, button, hover, active, rounded, modern, hover effect

## 미리보기

그라데이션 배경과 그림자 효과가 적용된 둥근 버튼으로, hover/pressed 상태에서 그림자가 줄어드는 효과가 있습니다.

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project QuietHorse20.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project QuietHorse20.Avalonia.Gallery
```

## 사용법

```xml
<Window xmlns:controls="clr-namespace:QuietHorse20.Wpf.UI.Controls;assembly=QuietHorse20.Wpf.UI">
    <!-- 기본 버튼 -->
    <controls:QuietHorse20 />

    <!-- 커스텀 텍스트 -->
    <controls:QuietHorse20 Text="Submit" />
</Window>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `linear-gradient(to bottom, ...)` | `#ffffff → #eeeeee → #dadada` | `LinearGradientBrush` (StartPoint="0,0" EndPoint="0,1") |
| `border-radius` | `30px` (button), `7px` (container) | `Border.CornerRadius` |
| `box-shadow` | `4px 2px 10px -1px rgba(...)` | `DropShadowEffect` |
| `cursor: pointer` | - | `Cursor="Hand"` |
| `font-weight: 600` | SemiBold | `FontWeight="SemiBold"` |
| `display: flex` | - | `StackPanel Orientation="Horizontal"` |
| `:hover` | shadow 감소 | `Trigger IsMouseOver` |
| `:active` | shadow 최소화 | `Trigger IsPressed` |
| SVG `<path>` | stroke-based | `Path` with `Stroke`, `StrokeThickness` |

## 프로젝트 구조

```
QuietHorse20/
├── Wpf/
│   ├── QuietHorse20.Wpf.slnx
│   ├── QuietHorse20.Wpf.Gallery/          # 데모 애플리케이션
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── QuietHorse20.Wpf.UI/               # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── QuietHorse20.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── QuietHorse20.xaml
│           └── QuietHorse20Resources.xaml
└── AvaloniaUI/                            # (추후 생성)
```

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Text` | `string` | "Send Message" | 버튼에 표시될 텍스트 |
