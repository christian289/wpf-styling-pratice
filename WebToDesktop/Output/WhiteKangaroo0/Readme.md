# WhiteKangaroo0

loaders 스타일 컨트롤 - 톱니바퀴 회전 애니메이션이 있는 로더

## 원본 정보

- **원작자**: Shoh2008
- **원본 링크**: [https://uiverse.io/Shoh2008/white-kangaroo-0](https://uiverse.io/Shoh2008/white-kangaroo-0) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project WhiteKangaroo0.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project WhiteKangaroo0.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `width: 175px` | `Width="175"` | 컨트롤 너비 |
| `height: 80px` | `Height="80"` | 컨트롤 높이 |
| `radial-gradient` (다중) | `DrawingBrush` + `DrawingGroup` | 여러 원형 그라데이션 |
| `background-color: #FF3D00` | `SolidColorBrush` | 톱니바퀴 주황색 |
| `border-radius: 50%` | `Ellipse` | 원형 요소 |
| `position: absolute` | `Canvas` + `Canvas.Left/Top` | 절대 위치 지정 |
| `::before`, `::after` | 별도 `Ellipse` 요소 | 의사 요소 |
| `animation: rotationBack 3s linear infinite` | `DoubleAnimation` Duration="0:0:3" | 3초 회전 애니메이션 |
| `animation: ... reverse` | To="-360" 또는 To="360" | 역방향 회전 |
| `transform: rotate()` | `RotateTransform` | 회전 변환 |

## 프로젝트 구조

```
WhiteKangaroo0/
├── Wpf/
│   ├── WhiteKangaroo0.Wpf.slnx
│   ├── WhiteKangaroo0.Wpf.Gallery/    # 데모 앱
│   └── WhiteKangaroo0.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── WhiteKangaroo0.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── WhiteKangaroo0.xaml
│           └── WhiteKangaroo0Resources.xaml
└── AvaloniaUI/                        # (예정)
```

## 사용 방법

### XAML에서 사용

```xml
<Window xmlns:controls="clr-namespace:WhiteKangaroo0.Wpf.UI.Controls;assembly=WhiteKangaroo0.Wpf.UI">
    <controls:WhiteKangaroo0 />
</Window>
```

### App.xaml에 리소스 병합

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/WhiteKangaroo0.Wpf.UI;component/Themes/Generic.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
