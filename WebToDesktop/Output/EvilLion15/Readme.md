# EvilLion15

Toggle-switches 스타일 컨트롤 - Neumorphism/Glassmorphism 스타일의 슬라이딩 토글 스위치

## 원본 정보

- **원작자:** vikramsinghnegi
- **원본 링크:** [https://uiverse.io/vikramsinghnegi/evil-lion-15](https://uiverse.io/vikramsinghnegi/evil-lion-15)
- **태그:** simple, neumorphism, glassmorphism

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project EvilLion15.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project EvilLion15.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 변환 | 비고 |
|---------|-----|---------|------|
| `background-color: rgba(0,0,0,0.2)` | 반투명 검정 | `SolidColorBrush Color="#33000000"` | Switch 배경 |
| `border-radius: 50px` | 둥근 모서리 | `CornerRadius="50"` | Switch 트랙 |
| `border: 4px solid rgba(209,92,92,0.1)` | 테두리 | `BorderThickness="4"` + `BorderBrush` | |
| `transition: all 0.2s` | 전환 효과 | `ThicknessAnimation Duration="0:0:0.2"` | Trigger EnterActions |
| `radial-gradient(45%, circle, ...)` | 방사형 그라디언트 | `RadialGradientBrush GradientOrigin="0.45,0.5"` | 인디케이터 |
| `linear-gradient(#4f4f4f, #2b2b2b)` | 선형 그라디언트 | `LinearGradientBrush StartPoint="0,0" EndPoint="0,1"` | Thumb 배경 |
| `position: absolute` + `left/right` | 절대 위치 | `HorizontalAlignment` + `Margin` | |
| `::before`, `::after` | 가상 요소 | 추가 `Border` 요소 | Thumb 내부 파트 |
| `.switch-check:checked + .switch-label span { left: 59px }` | 체크 상태 | `Trigger Property="IsChecked"` + `ThicknessAnimation` | |

## 프로젝트 구조

```
EvilLion15/
├── Readme.md
├── Wpf/
│   ├── EvilLion15.Wpf.slnx
│   ├── EvilLion15.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── EvilLion15.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── EvilLion15.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── EvilLion15.xaml
│           └── EvilLion15Resources.xaml
└── AvaloniaUI/                      # (미구현)
```

## 사용법

### XAML에서 사용

```xml
<Window xmlns:controls="clr-namespace:EvilLion15.Wpf.UI.Controls;assembly=EvilLion15.Wpf.UI">
    <controls:EvilLion15 />
    <controls:EvilLion15 IsChecked="True" />
</Window>
```

### App.xaml에 리소스 추가

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/EvilLion15.Wpf.UI;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
