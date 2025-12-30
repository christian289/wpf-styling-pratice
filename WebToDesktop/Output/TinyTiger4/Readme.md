# TinyTiger4

Radio-buttons 스타일 컨트롤 - 버블 효과가 있는 플래시 라디오 버튼

## 원본 정보

- **원작자**: Pradeepsaranbishnoi
- **원본 링크**: [https://uiverse.io/Pradeepsaranbishnoi/tiny-tiger-4](https://uiverse.io/Pradeepsaranbishnoi/tiny-tiger-4)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project TinyTiger4.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project TinyTiger4.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 구현 |
|---------|-----|---------|
| `color` | `#61cea5` | `SolidColorBrush` (TinyTiger4.Accent.Brush) |
| `cursor` | `pointer` | `Cursor="Hand"` |
| `line-height` | `3rem (48px)` | `MinHeight="48"` |
| `padding-left` | `3rem (48px)` | `Grid.ColumnDefinition Width="48"` |
| `border-radius` | `50%` | `Ellipse` 요소 사용 |
| `width (::before)` | `2rem (32px)` | `Ellipse Width/Height="32"` |
| `width (::after)` | `1.4rem (22.4px)` | `Ellipse Width/Height="22.4"` |
| `border` | `0.1rem solid #fff` | `StrokeThickness="1.6" Stroke="#FFFFFF"` |
| `transform: scale()` | `scale(0)` → `scale(1)` | `ScaleTransform` + `DoubleAnimation` |
| `transition` | `0.5s` | `Duration="0:0:0.5"` |
| `radial-gradient` (다중) | 4개 레이어 | `DrawingBrush` + `DrawingGroup` |
| `::before` | 배경 원형 | `Ellipse` (BackgroundCircle) |
| `::after` | 버블 효과 | `Ellipse` (BubbleCircle) + `ScaleTransform` |
| `@keyframes radio` | `scale(1)` → `scale(1.7)` | `DoubleAnimationUsingKeyFrames` |

## 프로젝트 구조

```
TinyTiger4/
├── Wpf/
│   ├── TinyTiger4.Wpf.slnx
│   ├── TinyTiger4.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── TinyTiger4.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── TinyTiger4.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── TinyTiger4.xaml
│           └── TinyTiger4Resources.xaml
└── AvaloniaUI/                     # (미구현)
```

## 사용 예시

```xml
<Window xmlns:controls="clr-namespace:TinyTiger4.Wpf.UI.Controls;assembly=TinyTiger4.Wpf.UI">
    <StackPanel>
        <controls:TinyTiger4 Content="Option 1" IsChecked="True" GroupName="Group1" />
        <controls:TinyTiger4 Content="Option 2" GroupName="Group1" />
        <controls:TinyTiger4 Content="Option 3" GroupName="Group1" />
    </StackPanel>
</Window>
```
