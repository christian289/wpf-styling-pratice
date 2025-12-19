# CurlyBullfrog98

loaders 스타일 컨트롤 - 3D 회전 큐브 로딩 애니메이션

## 원본 정보

- **원작자**: Bodyhc
- **원본 링크**: [https://uiverse.io/Bodyhc/curly-bullfrog-98](https://uiverse.io/Bodyhc/curly-bullfrog-98)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project CurlyBullfrog98.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project CurlyBullfrog98.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `perspective: 1000px` | `PerspectiveCamera` | 3D 카메라로 원근감 구현 |
| `transform-style: preserve-3d` | `Viewport3D` | WPF 3D 렌더링 컨테이너 |
| `width/height: 200px` | `Width/Height="200"` | 컨트롤 크기 |
| `background-color: #01b4f9` | `DiffuseMaterial` + `SolidColorBrush` | 큐브 면 색상 |
| `border: 3px solid #fff` | Edge `GeometryModel3D` | 흰색 테두리 라인 |
| `border-radius: 10px` | N/A | 3D 메시에서 직접 지원 안 함 |
| `rotateX(360deg)` | `AxisAngleRotation3D Axis="1,0,0"` | X축 회전 |
| `rotateY(360deg)` | `AxisAngleRotation3D Axis="0,1,0"` | Y축 회전 |
| `animation: 4s linear infinite` | `Storyboard RepeatBehavior="Forever"` | 무한 반복 애니메이션 |
| `translateZ(100px)` | 3D 정점 좌표 | 각 면의 위치 계산 |

## 프로젝트 구조

```
CurlyBullfrog98/
├── Readme.md
├── Wpf/
│   ├── CurlyBullfrog98.Wpf.slnx
│   ├── CurlyBullfrog98.Wpf.Gallery/    # 데모 앱
│   └── CurlyBullfrog98.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── CurlyBullfrog98.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── CurlyBullfrog98.xaml
│           └── CurlyBullfrog98Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 사용 방법

```xml
<!-- 1. App.xaml에 리소스 추가 -->
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/CurlyBullfrog98.Wpf.UI;component/Themes/Generic.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>

<!-- 2. XAML에서 사용 -->
<controls:CurlyBullfrog98 />
```

## DependencyProperty

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Duration` | `double` | `4.0` | 애니메이션 지속 시간 (초) |
| `CubeSize` | `double` | `200.0` | 큐브 크기 |

> **참고**: `Duration` 속성은 정의되어 있지만, WPF `Duration` 타입은 `StaticResource` 바인딩을 지원하지 않아 ControlTemplate에서 하드코딩되어 있습니다.
