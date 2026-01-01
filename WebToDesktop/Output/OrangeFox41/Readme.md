# OrangeFox41

Material Design 3 스타일의 Tooltip 컨트롤입니다.

## 원본 정보

- **원작자**: SteveBloX
- **원본 링크**: [https://uiverse.io/SteveBloX/orange-fox-41](https://uiverse.io/SteveBloX/orange-fox-41)
- **카테고리**: Tooltips

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project OrangeFox41.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project OrangeFox41.Avalonia.Gallery
```

## 사용법

```xml
<controls:OrangeFox41
    Text="Material Design Tooltip"
    TooltipTitle="Title"
    TooltipContent="Tooltip content text here."/>
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Text` | string | "Material Design Tooltip" | 버튼에 표시될 텍스트 |
| `TooltipTitle` | string | "Title" | 툴팁 제목 |
| `TooltipContent` | string | "Lorem ipsum..." | 툴팁 내용 |

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|----------|----------|
| `background: #e8def8` | `SolidColorBrush` 리소스 |
| `border-radius: 50px` | `CornerRadius="50"` |
| `border-radius: 12px` | `CornerRadius="12"` |
| `padding: 0.7em 1.8em` | `Thickness` (17px 기준 계산) |
| `box-shadow` | `DropShadowEffect` |
| `transition: all 0.25s` | `DoubleAnimation Duration="0:0:0.25"` |
| `scale: 0 → 1` (hover) | `ScaleTransform` + `IsMouseOver` Trigger |
| `position: absolute` | `Popup` 컨트롤 사용 |
| `font-family: Montserrat` | `FontFamily="Montserrat, Segoe UI"` |
| `font-weight: bold` | `FontWeight="Bold"` |
| `font-weight: semibold` | `FontWeight="SemiBold"` |

## 프로젝트 구조

```
OrangeFox41/
├── Wpf/
│   ├── OrangeFox41.Wpf.slnx
│   ├── OrangeFox41.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── OrangeFox41.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── OrangeFox41.xaml
│   │       └── OrangeFox41Resources.xaml
│   └── OrangeFox41.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```
