# BadSquid34

Cards 스타일 컨트롤 - Error Alert Card

아이콘, 메시지, 닫기 버튼이 있는 에러 알림 카드 컨트롤입니다.

## 원본 정보

- **원작자:** andrew-demchenk0
- **원본 링크:** [https://uiverse.io/andrew-demchenk0/bad-squid-34](https://uiverse.io/andrew-demchenk0/bad-squid-34)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project BadSquid34.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BadSquid34.Avalonia.Gallery
```

## 사용 방법

```xml
<controls:BadSquid34 Message="Error message here" />
```

### 속성

| 속성 | 타입 | 설명 |
|-----|------|-----|
| `Message` | `string` | 에러 메시지 텍스트 |
| `CloseCommand` | `ICommand` | 닫기 버튼 클릭 시 실행되는 커맨드 |
| `CloseCommandParameter` | `object` | CloseCommand에 전달되는 파라미터 |

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `display: flex; flex-direction: row` | `Grid` with `ColumnDefinitions` |
| `align-items: center` | `VerticalAlignment="Center"` |
| `margin-left: auto` | Grid 마지막 열에 배치 |
| `background: #EF665B` | `SolidColorBrush` |
| `border-radius: 8px` | `CornerRadius="8"` |
| `box-shadow: 0px 0px 5px -3px #111` | `DropShadowEffect` |
| `transform: translateY(-2px)` | `TranslateTransform Y="-2"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `font-weight: 500` | `FontWeight="Medium"` |
| `fill: #fff` (SVG) | `Path.Fill` with `SolidColorBrush` |

## 프로젝트 구조

```
BadSquid34/
├── Readme.md
├── Wpf/
│   ├── BadSquid34.Wpf.slnx
│   ├── BadSquid34.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── BadSquid34.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── BadSquid34.xaml
│   │       └── BadSquid34Resources.xaml
│   └── BadSquid34.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (구현 예정)
```
