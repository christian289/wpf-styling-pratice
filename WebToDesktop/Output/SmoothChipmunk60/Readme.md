# SmoothChipmunk60

Toggle-switches 스타일 컨트롤 - 햄버거 메뉴 아이콘이 X 아이콘으로 변환되는 애니메이션 토글 스위치

## 원본 정보

- **원작자**: omar-alghaish
- **원본 링크**: [https://uiverse.io/omar-alghaish/smooth-chipmunk-60](https://uiverse.io/omar-alghaish/smooth-chipmunk-60)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project SmoothChipmunk60.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SmoothChipmunk60.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 설명 |
|---------|---------|------|
| `linear-gradient(45deg, rgb(183,0,255) 20%, rgb(255,0,170) 100%)` | `LinearGradientBrush StartPoint="0,1" EndPoint="1,0"` | 45도 그라데이션 |
| `box-shadow: 0 5px 25px rgba(0,0,0,0.363)` | `DropShadowEffect BlurRadius="25" ShadowDepth="5"` | 그림자 효과 |
| `border-radius: 5px` | `CornerRadius="5"` | 둥근 모서리 |
| `transition: transform 0.5s` | `DoubleAnimation Duration="0:0:0.5"` | 변환 애니메이션 |
| `transform: translate(-50%, -50%)` | `TranslateTransform X="..." Y="..."` | 이동 변환 |
| `transform: rotate(-45deg)` | `RotateTransform Angle="-45"` | 회전 변환 |
| `input:checked + div span` | `Trigger Property="IsChecked" Value="True"` | 체크 상태 트리거 |
| `opacity: 0` (숨김 input) | `ToggleButton` 상속 | 체크박스 기능 |
| `cursor: pointer` | `Cursor="Hand"` | 클릭 커서 |

## 프로젝트 구조

```
SmoothChipmunk60/
├── Readme.md
├── Wpf/
│   ├── SmoothChipmunk60.Wpf.slnx
│   ├── SmoothChipmunk60.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── SmoothChipmunk60.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── SmoothChipmunk60.xaml
│   │       └── SmoothChipmunk60Resources.xaml
│   └── SmoothChipmunk60.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (예정)
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:SmoothChipmunk60.Wpf.UI.Controls;assembly=SmoothChipmunk60.Wpf.UI">
    <controls:SmoothChipmunk60 />
</Window>
```

## 기능

- 클릭 시 햄버거 메뉴(≡) → X 아이콘으로 부드럽게 변환
- 보라색-핑크색 그라데이션 배경
- 0.5초 애니메이션
- `IsChecked` 속성으로 상태 바인딩 가능
