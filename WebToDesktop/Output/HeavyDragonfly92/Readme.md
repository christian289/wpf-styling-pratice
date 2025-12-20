# HeavyDragonfly92

Radio-buttons 스타일 컨트롤 - 슬라이딩 글라이더 효과가 있는 탭 스타일 라디오 버튼

## 원본 정보

- **원작자**: Pradeepsaranbishnoi
- **원본 링크**: [https://uiverse.io/Pradeepsaranbishnoi/heavy-dragonfly-92](https://uiverse.io/Pradeepsaranbishnoi/heavy-dragonfly-92)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project HeavyDragonfly92.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project HeavyDragonfly92.Avalonia.Gallery
```

## 사용 예시

```xml
<controls:HeavyDragonfly92>
    <controls:HeavyDragonfly92Item Content="Hello" IsSelected="True" ShowNotification="True" NotificationCount="2"/>
    <controls:HeavyDragonfly92Item Content="UI"/>
    <controls:HeavyDragonfly92Item Content="World"/>
</controls:HeavyDragonfly92>
```

## CSS → WPF 변환 매핑

| CSS 속성 | CSS 값 | WPF 구현 |
|----------|--------|----------|
| `background-color` | `#fff` | `SolidColorBrush Color="#FFFFFF"` |
| `box-shadow` | `rgba(24,94,224,0.15)` | `DropShadowEffect BlurRadius="12"` |
| `padding` | `0.75rem` | `Thickness 12` |
| `border-radius` | `99px` | `CornerRadius 99` |
| `transition` | `0.15s / 0.25s` | `Duration` 리소스 |
| `font-weight: 500` | Medium | `FontWeight="Medium"` |
| `color` (selected) | `#185ee0` | `SolidColorBrush Color="#185EE0"` |
| `display: flex` | Flexbox | `StackPanel Orientation="Horizontal"` |
| `position: absolute` (glider) | Overlay | `Panel.ZIndex="0"` + `TranslateTransform` |

## 프로젝트 구조

```
HeavyDragonfly92/
├── Wpf/
│   ├── HeavyDragonfly92.Wpf.slnx
│   ├── HeavyDragonfly92.Wpf.UI/
│   │   ├── Controls/
│   │   │   ├── HeavyDragonfly92.cs
│   │   │   └── HeavyDragonfly92Item.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── HeavyDragonfly92.xaml
│   │       └── HeavyDragonfly92Resources.xaml
│   └── HeavyDragonfly92.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (TBD)
```
