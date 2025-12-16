# LovelyMonkey46

Patterns 스타일 컨트롤 - 여러 개의 radial-gradient와 linear-gradient를 조합한 패턴 배경

## 원본 정보
- 원작자: csemszepp
- 원본 링크: [https://uiverse.io/csemszepp/lovely-monkey-46](https://uiverse.io/csemszepp/lovely-monkey-46) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project LovelyMonkey46.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project LovelyMonkey46.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `radial-gradient(...)` | `RadialGradientBrush` + `DrawingBrush` | 원형 그라데이션을 TileBrush로 반복 |
| `linear-gradient(45deg, ...)` | `LinearGradientBrush` (StartPoint="0,1" EndPoint="1,0") | 45도 대각선 그라데이션 |
| `background-size: 470px 470px` | `Viewport="0,0,470,470" ViewportUnits="Absolute"` | 타일 크기 지정 |
| `background-position: 0 110px` | `Viewport="0,110,410,410"` | 타일 시작 위치 오프셋 |
| `rgba(255,255,255,0.15)` | `#26FFFFFF` | ARGB 형식 색상 변환 |
| 여러 background 레이어 | Grid 내 여러 Rectangle | Z-order로 레이어 표현 |

## 프로젝트 구조

```
LovelyMonkey46/
├── Readme.md
├── Wpf/
│   ├── LovelyMonkey46.Wpf.slnx
│   ├── LovelyMonkey46.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── LovelyMonkey46.Wpf.UI/          # 컨트롤 라이브러리
│       ├── Controls/
│       │   └── LovelyMonkey46.cs
│       ├── Themes/
│       │   ├── Generic.xaml
│       │   ├── LovelyMonkey46.xaml
│       │   └── LovelyMonkey46Resources.xaml
│       └── Properties/
│           └── AssemblyInfo.cs
└── AvaloniaUI/                         # (미구현)
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:LovelyMonkey46.Wpf.UI.Controls;assembly=LovelyMonkey46.Wpf.UI">
    <controls:LovelyMonkey46>
        <!-- 자식 콘텐츠 -->
    </controls:LovelyMonkey46>
</Window>
```
