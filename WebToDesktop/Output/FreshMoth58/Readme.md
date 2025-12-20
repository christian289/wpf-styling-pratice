# FreshMoth58

Toggle-switches 스타일 컨트롤 - Neumorphism 디자인의 토글 스위치

## 원본 정보

- **원작자**: Ali-Tahmazi99
- **원본 링크**: [https://uiverse.io/Ali-Tahmazi99/fresh-moth-58](https://uiverse.io/Ali-Tahmazi99/fresh-moth-58)
- **카테고리**: Toggle-switches

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project FreshMoth58.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project FreshMoth58.Avalonia.Gallery
```

## 특징

- Neumorphism (뉴모피즘) 스타일의 3D 입체감 표현
- 부드러운 토글 애니메이션 (0.3초)
- 토글 시 220도 회전 효과
- 주황색 ↔ 검정색 색상 전환

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 |
|----------|----------|
| `width: 60px; height: 30px` | `Width="60" Height="30"` |
| `background: #d3d3d3` | `Background="#D3D3D3"` |
| `border-radius: 50px` | `CornerRadius="15"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `box-shadow: 9px 9px 29px #969696` | `DropShadowEffect BlurRadius="29" ShadowDepth="9" Direction="315" Color="#969696"` |
| `box-shadow: -9px -9px 29px #ffffff` | `DropShadowEffect BlurRadius="29" ShadowDepth="9" Direction="135" Color="#FFFFFF"` |
| `box-shadow: inset 3px 3px 10px` | `LinearGradientBrush` (내부 그림자 시뮬레이션) |
| `transition: all 0.3s ease-in` | `DoubleAnimation Duration="0:0:0.3"` + `QuadraticEase EaseMode="EaseIn"` |
| `transform: rotate(220deg)` | `RotateTransform Angle="220"` |
| `left: 29px` (이동) | `TranslateTransform X="30"` |
| `input:checked ~ span` | `<Trigger Property="IsChecked" Value="True">` |
| `background-color: #ffaa00` → `#0a100d` | `ColorAnimation` |

## 프로젝트 구조

```
FreshMoth58/
├── Readme.md
├── Wpf/
│   ├── FreshMoth58.Wpf.slnx
│   ├── FreshMoth58.Wpf.Gallery/        # 데모 애플리케이션
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── FreshMoth58.Wpf.UI/             # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── FreshMoth58.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── FreshMoth58.xaml
│           └── FreshMoth58Resources.xaml
└── AvaloniaUI/                          # (추후 추가)
```

## 사용 방법

### 1. 프로젝트 참조 추가

```bash
dotnet add reference path/to/FreshMoth58.Wpf.UI.csproj
```

### 2. ResourceDictionary 병합 (App.xaml)

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/FreshMoth58.Wpf.UI;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 3. 컨트롤 사용

```xml
<Window xmlns:controls="clr-namespace:FreshMoth58.Wpf.UI.Controls;assembly=FreshMoth58.Wpf.UI">
    <controls:FreshMoth58 />
    <controls:FreshMoth58 IsChecked="True" />
</Window>
```

## 라이선스

원본 디자인의 라이선스를 따릅니다.
