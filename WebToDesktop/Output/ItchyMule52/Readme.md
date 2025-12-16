# ItchyMule52

Toggle-switches 스타일 컨트롤 - 네온 효과가 적용된 토글 스위치

## 원본 정보

- **원작자:** vinodjangid07
- **원본 링크:** [https://uiverse.io/vinodjangid07/itchy-mule-52](https://uiverse.io/vinodjangid07/itchy-mule-52) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그:** switch, neon, toggle switch

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project ItchyMule52.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project ItchyMule52.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|----------|--------|----------|
| `width` | `50px` | `Width="50"` |
| `height` | `17px` (track) | `Height="17"` |
| `background-color` | `rgb(82, 82, 82)` | `SolidColorBrush Color="#525252"` |
| `background-color` (checked) | `rgb(165, 255, 105)` | `SolidColorBrush Color="#A5FF69"` |
| `border-radius` | `20px` | `CornerRadius="20"` |
| `border-radius` | `50%` (thumb) | `Ellipse` 사용 |
| `transition-duration` | `0.2s` | `Duration="0:0:0.2"` |
| `transform: translateX(100%)` | 22px 이동 | `DoubleAnimation To="28"` (Canvas.Left) |
| `::after` (pseudo-element) | thumb 원형 | `Ellipse` 별도 요소 |
| `border` | `2px solid` | `Stroke` + `StrokeThickness="2"` |
| `position: absolute` | 절대 위치 | `Canvas` 레이아웃 |

## 컨트롤 구조

```
ItchyMule52 (ToggleButton 상속)
├── Grid
│   ├── Border (PART_Track) - 배경 트랙
│   └── Canvas - 썸 컨테이너
│       └── Ellipse (PART_Thumb) - 토글 썸
```

## 사용 예시

```xml
<Window xmlns:controls="clr-namespace:ItchyMule52.Wpf.UI.Controls;assembly=ItchyMule52.Wpf.UI">
    <StackPanel>
        <!-- 기본 상태 (꺼짐) -->
        <controls:ItchyMule52/>

        <!-- 켜진 상태 -->
        <controls:ItchyMule52 IsChecked="True"/>
    </StackPanel>
</Window>
```

## 프로젝트 구조

```
ItchyMule52/
├── Wpf/
│   ├── ItchyMule52.Wpf.slnx
│   ├── ItchyMule52.Wpf.Gallery/      # 데모 앱
│   └── ItchyMule52.Wpf.UI/           # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── ItchyMule52.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── ItchyMule52.xaml
│           └── ItchyMule52Resources.xaml
└── AvaloniaUI/                       # (미구현)
```
