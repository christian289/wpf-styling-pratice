# MightyElephant52

Tooltips 스타일 컨트롤 - 호버 시 팔로워 수를 보여주는 소셜 미디어 스타일 Follow 버튼

## 원본 정보

- **원작자:** vinodjangid07
- **원본 링크:** [https://uiverse.io/vinodjangid07/mighty-elephant-52](https://uiverse.io/vinodjangid07/mighty-elephant-52) (클릭 시 원본 CSS/HTML 확인 가능)
- **카테고리:** Tooltips

## 미리보기

호버 시 팔로워 수가 표시되는 Tooltip이 부드러운 애니메이션과 함께 나타나는 Follow 버튼입니다.

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project MightyElephant52.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project MightyElephant52.Avalonia.Gallery
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:MightyElephant52.Wpf.UI.Controls;assembly=MightyElephant52.Wpf.UI">
    <controls:MightyElephant52 TooltipText="45k" Content="Follow"/>
</Window>
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `TooltipText` | `string` | `"45k"` | Tooltip에 표시될 텍스트 |
| `Content` | `object` | `"Follow"` | 버튼에 표시될 텍스트 |

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `display: flex; align-items: center` | `StackPanel Orientation="Horizontal"` + `VerticalAlignment="Center"` |
| `gap: 10px` | `Margin="0,0,10,0"` (각 요소에 적용) |
| `border-radius: 12px` | `CornerRadius="12"` |
| `border: 1px solid rgb(211,211,211)` | `BorderThickness="1"` + `BorderBrush="#D3D3D3"` |
| `padding: 11px 18px` | `Padding="18,11"` |
| `transition: all 0.3s` | `Storyboard Duration="0:0:0.3"` |
| `opacity: 0` → `opacity: 1` | `DoubleAnimation To="1"` |
| `transform: translateX(-50%)` | `HorizontalAlignment="Center"` |
| `position: absolute` | Grid 레이아웃 + Alignment |
| `::before` (pseudo-element) | 별도 `Border` + `RotateTransform` |
| `:hover` | `Trigger Property="IsMouseOver"` |
| SVG `<rect>` + `<path>` | `Ellipse` + `Path` in `Viewbox` |

## 프로젝트 구조

```
MightyElephant52/
├── Wpf/
│   ├── MightyElephant52.Wpf.slnx
│   ├── MightyElephant52.Wpf.Gallery/     # 데모 앱
│   └── MightyElephant52.Wpf.UI/          # CustomControl 라이브러리
│       ├── Controls/
│       │   └── MightyElephant52.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── MightyElephant52.xaml
│           └── MightyElephant52Resources.xaml
└── AvaloniaUI/                           # (미구현)
```
