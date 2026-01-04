# BitterSkunk14

Tooltips 스타일 컨트롤 - 애니메이션 연결선과 버튼이 있는 호버 툴팁

## 원본 정보

- **원작자**: MohamedAboSeada
- **원본 링크**: [https://uiverse.io/MohamedAboSeada/bitter-skunk-14](https://uiverse.io/MohamedAboSeada/bitter-skunk-14) (클릭 시 원본 CSS/HTML 확인 가능)
- **카테고리**: Tooltips
- **태그**: simple, tooltip, animation, minimalist, hover, rounded, cube, modern

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project BitterSkunk14.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BitterSkunk14.Avalonia.Gallery
```

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `TooltipText` | `string` | "This is a test" | 툴팁에 표시되는 메시지 텍스트 |
| `ButtonText` | `string` | "Got It" | 툴팁 내 버튼 텍스트 |
| `TriggerText` | `string` | "Tooltip" | 컨테이너에 표시되는 트리거 텍스트 |

## 사용 예시

```xml
<controls:BitterSkunk14
    TooltipText="사용자 정의 툴팁 메시지"
    ButtonText="확인"
    TriggerText="마우스를 올려보세요"/>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|---------|--------|---------|--------|
| `background-color` | `darkgray` | `SolidColorBrush` | `DarkGray` |
| `background-color` | `#000` | `SolidColorBrush` | `#000000` |
| `color` | `#fff` | `Foreground` | `#FFFFFF` |
| `border-radius` | `5px` | `CornerRadius` | `5` |
| `box-shadow` | `0 3px 0 rgb(0 0 0 / 80%)` | `DropShadowEffect` | `BlurRadius=0, ShadowDepth=3, Opacity=0.8, Direction=270` |
| `box-shadow` | `0 0 10px rgb(0 0 0 / 50%)` | `DropShadowEffect` | `BlurRadius=10, ShadowDepth=0, Opacity=0.5` |
| `transition` | `300ms ease` | `DoubleAnimation` | `Duration="0:0:0.3"` |
| `animation: HeightUP` | `400ms ease` | `DoubleAnimation` | `Duration="0:0:0.4"` |
| `opacity` | `0` → `1` (hover) | `DoubleAnimation` | `Opacity` property animation |
| `::before` | pseudo-element | `Ellipse` | 별도 XAML 요소 |
| `font-style` | `oblique` | `FontStyle` | `Oblique` |
| `position: absolute` | 레이아웃 | `Grid` + `Margin` | 상대 위치 지정 |
| `display: flex` | 정렬 | `StackPanel` / `Grid` | 레이아웃 컨테이너 |
| `align-self: flex-end` | 버튼 정렬 | `HorizontalAlignment` | `Right` |
| `cursor: pointer` | 인터랙션 | `Cursor` | `Hand` |

## 프로젝트 구조

```
BitterSkunk14/
├── Readme.md
├── Wpf/
│   ├── BitterSkunk14.Wpf.slnx
│   ├── BitterSkunk14.Wpf.Gallery/          # 데모 앱
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── BitterSkunk14.Wpf.UI/               # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── BitterSkunk14.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── BitterSkunk14.xaml
│           └── BitterSkunk14Resources.xaml
└── AvaloniaUI/                             # (미구현)
```
