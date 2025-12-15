# QuietCougar91

Tooltips 스타일 컨트롤 - 호버 시 위로 올라오는 애니메이션 툴팁 버튼

## 원본 정보 / Source Information

- **원작자 / Author**: kyle1dev
- **원본 링크 / Source Link**: [https://uiverse.io/kyle1dev/quiet-cougar-91](https://uiverse.io/kyle1dev/quiet-cougar-91) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그 / Tags**: Tooltips

## 빌드 및 실행 / Build and Run

### WPF

```bash
cd Wpf && dotnet run --project QuietCougar91.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project QuietCougar91.Avalonia.Gallery
```

## 컨트롤 사용법 / Control Usage

```xml
<controls:QuietCougar91 />

<!-- 커스텀 텍스트 / Custom text -->
<controls:QuietCougar91 ButtonText="Click me!" TooltipContent="Hello World"/>
```

### 속성 / Properties

| 속성 / Property | 타입 / Type | 기본값 / Default | 설명 / Description |
|----------------|-------------|------------------|---------------------|
| `ButtonText` | `string` | "Hover me" | 버튼에 표시될 텍스트 / Text displayed on button |
| `TooltipContent` | `object` | "Uiverse.io" | 툴팁에 표시될 내용 / Content displayed in tooltip |

## CSS → WPF 변환 매핑 / CSS to WPF Conversion Mapping

| CSS | WPF |
|-----|-----|
| `linear-gradient(to right, #333, #000)` | `LinearGradientBrush` (StartPoint="0,0.5" EndPoint="1,0.5") |
| `box-shadow: 0 4px 8px rgba(0,0,0,0.5)` | `DropShadowEffect` (ShadowDepth, BlurRadius, Opacity) |
| `border-radius: 6px` | `CornerRadius="6"` |
| `padding: 15px 30px` | `Padding="30,15"` |
| `transition: 0.4s ease` | `DoubleAnimation Duration="0:0:0.4"` + `CubicEase` |
| `transform: translateY(-10px)` | `TranslateTransform Y="-10"` |
| `transform: scale(0.95)` | `ScaleTransform ScaleX="0.95" ScaleY="0.95"` |
| `:hover` | `VisualState x:Name="MouseOver"` + `Trigger IsMouseOver="True"` |
| `:active` | `VisualState x:Name="Pressed"` |
| `opacity: 0/1` | `DoubleAnimation Storyboard.TargetProperty="Opacity"` |
| `gap: 8px` | `Margin="0,0,8,0"` on icon |

## 프로젝트 구조 / Project Structure

```
QuietCougar91/
├── Readme.md
├── Wpf/
│   ├── QuietCougar91.Wpf.slnx
│   ├── QuietCougar91.Wpf.Gallery/    # 데모 앱 / Demo app
│   └── QuietCougar91.Wpf.UI/         # 커스텀 컨트롤 라이브러리 / Custom control library
│       ├── Controls/
│       │   └── QuietCougar91.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── QuietCougar91.xaml
│           └── QuietCougar91Resources.xaml
└── AvaloniaUI/                        # (미구현 / Not implemented yet)
```
