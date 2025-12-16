# GentleFly78

Cards 스타일 컨트롤 - 이모지 버튼이 무한 슬라이딩하는 카드

## 원본 정보

- **원작자**: devkatyall
- **원본 링크**: [https://uiverse.io/devkatyall/gentle-fly-78](https://uiverse.io/devkatyall/gentle-fly-78)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project GentleFly78.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project GentleFly78.Avalonia.Gallery
```

## CSS to WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `width: 354px` | `Width="354"` |
| `background: rgba(41, 41, 41, 0.07)` | `SolidColorBrush Color="#12292929"` |
| `border-radius: 50px` | `CornerRadius="50"` |
| `box-shadow` | `DropShadowEffect` |
| `overflow: hidden` | `ClipToBounds="True"` |
| `font-size: 70px` | `FontSize="70"` |
| `margin: 0 5px` | `Margin="5,0"` |
| `cursor: grab` | `Cursor="Hand"` |
| `transform: scale(1.1)` | `ScaleTransform ScaleX="1.1" ScaleY="1.1"` |
| `transition: 0.5s ease` | `DoubleAnimation Duration="0:0:0.5"` |
| `animation: 5s sliding infinite linear` | `Storyboard RepeatBehavior="Forever" Duration="0:0:5"` |
| `@keyframes sliding { translateX }` | `DoubleAnimation Storyboard.TargetProperty="X"` |
| `display: inline-block` | `StackPanel Orientation="Horizontal"` |

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `SlideDuration` | `double` | `5.0` | 슬라이딩 애니메이션 지속 시간 (초) |
| `PauseOnHover` | `bool` | `false` | 호버 시 애니메이션 일시정지 여부 |

## 사용 예시

```xml
<controls:GentleFly78>
    <Button Content="&#x1F604;" Style="{StaticResource GentleFly78.EmojiButtonStyle}"/>
    <Button Content="&#x1F601;" Style="{StaticResource GentleFly78.EmojiButtonStyle}"/>
    <Button Content="&#x1F606;" Style="{StaticResource GentleFly78.EmojiButtonStyle}"/>
    <Button Content="&#x1F602;" Style="{StaticResource GentleFly78.EmojiButtonStyle}"/>
</controls:GentleFly78>
```

## 프로젝트 구조

```
GentleFly78/
├── Wpf/
│   ├── GentleFly78.Wpf.slnx
│   ├── GentleFly78.Wpf.UI/          # CustomControl 라이브러리
│   │   ├── Controls/
│   │   │   └── GentleFly78.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── GentleFly78.xaml
│   │       └── GentleFly78Resources.xaml
│   └── GentleFly78.Wpf.Gallery/     # 데모 앱
└── AvaloniaUI/                       # (미구현)
```
