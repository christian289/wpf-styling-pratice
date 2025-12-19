# BrightTiger84

Checkboxes 스타일 컨트롤 - 좋아요(Thumbs Up) 토글 버튼

## 원본 정보

- **원작자:** andrew-demchenk0
- **원본 링크:** [https://uiverse.io/andrew-demchenk0/bright-tiger-84](https://uiverse.io/andrew-demchenk0/bright-tiger-84)
- **카테고리:** Checkboxes
- **태그:** checkbox, thumb, like

## 미리보기

호버 시 확대 및 회전 애니메이션이 적용되며, 클릭하면 파란색으로 변경되는 좋아요 버튼입니다.

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project BrightTiger84.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BrightTiger84.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 |
|----------|----------|
| `fill: #666` | `<SolidColorBrush Color="#666666" />` |
| `fill: #2196F3` | `<SolidColorBrush Color="#2196F3" />` (Checked 상태) |
| `height: 50px; width: 50px` | `Width="50" Height="50"` |
| `transition: all 0.3s` | `<DoubleAnimation Duration="0:0:0.3" />` |
| `transform: scale(1.1)` | `<ScaleTransform ScaleX="1.1" ScaleY="1.1" />` |
| `transform: rotate(-10deg)` | `<RotateTransform Angle="-10" />` |
| `cursor: pointer` | `Cursor="Hand"` |
| `input:checked ~ svg { fill: blue }` | `<Trigger Property="IsChecked" Value="True">` |
| `svg:hover { transform }` | `<Trigger Property="IsMouseOver" Value="True">` |
| SVG `<path d="...">` | `<Path Data="..." />` |

## 프로젝트 구조

```
BrightTiger84/
├── Readme.md
├── Wpf/
│   ├── BrightTiger84.Wpf.slnx
│   ├── BrightTiger84.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── BrightTiger84.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── BrightTiger84.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── BrightTiger84.xaml
│           └── BrightTiger84Resources.xaml
└── AvaloniaUI/                        # (미구현)
```

## 사용 방법

### 1. 리소스 딕셔너리 병합 (App.xaml)

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/BrightTiger84.Wpf.UI;component/Themes/Generic.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 2. 컨트롤 사용

```xml
<Window xmlns:controls="clr-namespace:BrightTiger84.Wpf.UI.Controls;assembly=BrightTiger84.Wpf.UI">
    <controls:BrightTiger84 />
    <controls:BrightTiger84 IsChecked="True" />
</Window>
```

## 기능

- **기본 상태:** 회색 엄지 아이콘
- **체크 상태:** 파란색 엄지 아이콘
- **호버 효과:** 1.1배 확대 + -10도 회전 (0.3초 애니메이션)
- **토글 동작:** 클릭 시 체크/해제 전환
