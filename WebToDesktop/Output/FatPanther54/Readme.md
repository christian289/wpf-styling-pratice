# FatPanther54

Patterns 스타일 컨트롤 - conic-gradient 기반 기하학적 삼각형 패턴 배경

## 원본 정보 (Original Source)

- **원작자 (Author)**: csemszepp
- **원본 링크 (Source)**: [https://uiverse.io/csemszepp/fat-panther-54](https://uiverse.io/csemszepp/fat-panther-54)
- **태그 (Tags)**: simple, minimalist, pattern

## 빌드 및 실행 (Build and Run)

### WPF

```bash
cd Wpf && dotnet run --project FatPanther54.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project FatPanther54.Avalonia.Gallery
```

## 프로젝트 구조 (Project Structure)

```
FatPanther54/
├── Wpf/
│   ├── FatPanther54.Wpf.slnx
│   ├── FatPanther54.Wpf.Gallery/    # 데모 애플리케이션
│   └── FatPanther54.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── FatPanther54.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── FatPanther54.xaml
│           └── FatPanther54Resources.xaml
└── AvaloniaUI/                       # (미구현)
```

## CSS → WPF 변환 매핑 (CSS to WPF Conversion Mapping)

| CSS | WPF | 설명 |
|-----|-----|------|
| `width: 100%` | Control 기본 동작 | 부모 컨테이너에 맞춤 |
| `height: 100%` | Control 기본 동작 | 부모 컨테이너에 맞춤 |
| `--s: 37px` | `PatternSize` DependencyProperty | 패턴 타일 크기 |
| `conic-gradient` | `DrawingBrush` + `PathGeometry` | WPF에서 conic-gradient 미지원, 삼각형 근사 |
| `background-size` | `Viewport` + `ViewportUnits="Absolute"` | 타일 크기 지정 |
| `#2fb8ac` | `SolidColorBrush` | 패턴 색상 (teal) |
| `#ecbe13` | `SolidColorBrush` | 배경 색상 (gold/yellow) |

## 컨트롤 속성 (Control Properties)

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `PatternSize` | `double` | `37.0` | 패턴 타일 크기 (CSS --s 변수) |

## 사용 예시 (Usage Example)

```xml
<Window xmlns:controls="clr-namespace:FatPanther54.Wpf.UI.Controls;assembly=FatPanther54.Wpf.UI">
    <controls:FatPanther54 />
</Window>
```

## 기술적 참고사항 (Technical Notes)

- **conic-gradient 제한**: WPF는 CSS의 `conic-gradient`를 직접 지원하지 않습니다. 이 변환에서는 `DrawingBrush`와 `PathGeometry`를 사용하여 삼각형 패턴으로 근사했습니다.
- **타일 크기 계산**:
  - 타일 너비 = 2 * PatternSize = 74px
  - 타일 높이 = 3.46 * PatternSize ≈ 128.02px
