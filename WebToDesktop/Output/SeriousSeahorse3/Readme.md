# SeriousSeahorse3

Tooltips 스타일 컨트롤

## 원본 정보
- 원작자: eduardojsc18
- 원본 링크: [https://uiverse.io/eduardojsc18/serious-seahorse-3](https://uiverse.io/eduardojsc18/serious-seahorse-3) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project SeriousSeahorse3.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SeriousSeahorse3.Avalonia.Gallery
```

## CSS to WPF 변환 매핑

| CSS / Tailwind | WPF |
|----------------|-----|
| `bg-neutral-200` (#e5e5e5) | `SolidColorBrush` Background |
| `hover:bg-neutral-300` (#d4d4d4) | Trigger + Setter Background |
| `border border-neutral-300` | `BorderBrush`, `BorderThickness="1"` |
| `text-neutral-600` (#525252) | `Foreground` |
| `px-3 py-2` (12px, 8px) | `Padding="12,8"` |
| `rounded-md` | `CornerRadius="6"` |
| `text-sm` (14px) | `FontSize="14"` |
| `font-medium` | `FontWeight="Medium"` |
| `::after` (tooltip box) | `Border` in `StackPanel` |
| `::before` (tooltip arrow) | `Polygon Points="0,0 6,4 12,0"` |
| `data-[tooltip]:after:bg-black` | `Background="Black"` |
| `data-[tooltip]:after:text-white` | `Foreground="White"` |
| `data-[tooltip]:after:text-[10px]` | `FontSize="10"` |
| `data-[tooltip]:after:px-1.5 py-1` | `Padding="6,4"` |
| `hover:data-[tooltip]:after:visible` | `IsMouseOver` Trigger |
| `data-[tooltip]:after:invisible` | `Opacity="0"` (hidden) |
| `data-[tooltip]:after:scale-50` | `ScaleTransform ScaleX="0.5" ScaleY="0.5"` |
| `hover:data-[tooltip]:after:scale-100` | Storyboard `DoubleAnimation To="1"` |
| `data-[tooltip]:after:opacity-0` | `Opacity="0"` |
| `hover:data-[tooltip]:after:opacity-100` | Storyboard `DoubleAnimation To="1"` |
| `data-[tooltip]:after:transition-all` | `Duration="0:0:0.15"` |
| `data-[tooltip]:after:origin-bottom` | `RenderTransformOrigin="0.5,1"` |
| `data-[tooltip]:after:drop-shadow` | `DropShadowEffect` |
| `[clip-path:polygon(100%_0,0_0,50%_100%)]` | `Polygon` 삼각형 |

## 프로젝트 구조

```
SeriousSeahorse3/
├── Readme.md
├── Wpf/
│   ├── SeriousSeahorse3.Wpf.slnx
│   ├── SeriousSeahorse3.Wpf.Gallery/
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── SeriousSeahorse3.Wpf.UI/
│       ├── Controls/
│       │   └── SeriousSeahorse3.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SeriousSeahorse3.xaml
│           └── SeriousSeahorse3Resources.xaml
└── AvaloniaUI/
    └── (TODO)
```

## 사용법

```xml
<controls:SeriousSeahorse3 Content="Hover me"
                           TooltipText="Hello!" />
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Content` | object | - | 버튼에 표시될 텍스트/콘텐츠 |
| `TooltipText` | string | "Hi!" | Tooltip에 표시될 텍스트 |
