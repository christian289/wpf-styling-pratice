# AverageElephant52

Inputs 스타일 컨트롤 - 그라데이션 배경과 장식 블롭이 있는 모던 검색 입력 컨트롤

## 원본 정보

- **원작자**: seyed-mohsen-mousavi
- **원본 링크**: [https://uiverse.io/seyed-mohsen-mousavi/average-elephant-52](https://uiverse.io/seyed-mohsen-mousavi/average-elephant-52)

## 미리보기

![Preview](https://uiverse.io/api/v1/elements/seyed-mohsen-mousavi/average-elephant-52/preview)

## 특징

- Radial Gradient 배경 효과
- 핑크색 장식 블롭 (Blob)
- 포커스 시 Skew 변환 애니메이션
- 동적 그림자 효과
- 검색 아이콘 통합

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project AverageElephant52.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project AverageElephant52.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `radial-gradient(circle 80px at 80% -10%, #fff, #181b1b)` | `RadialGradientBrush` | 외부 컨테이너 배경 |
| `radial-gradient(circle 80px at 80% -50%, #777, #0f1111)` | `RadialGradientBrush` | 내부 입력 영역 배경 |
| `radial-gradient(circle 60px at 0% 100%, #ff3fcb, ...)` | `RadialGradientBrush` | 장식 블롭 |
| `box-shadow: 0 0 5px rgba(0,0,0,0.66)` | `DropShadowEffect` | 기본 그림자 |
| `box-shadow: -13px 20px 20px rgba(0,0,0,0.66)` | `DropShadowEffect` (애니메이션) | 포커스 시 그림자 |
| `border-radius: 16px` | `CornerRadius="16"` | 모서리 둥글기 |
| `overflow: hidden` | `Border.Clip` + `RectangleGeometry` | 콘텐츠 클리핑 |
| `transform: skew(10deg, 0deg)` | `SkewTransform` | 포커스 시 기울기 |
| `transition: all 0.3s linear` | `Storyboard` + `DoubleAnimation` | 애니메이션 전환 |
| `:focus-within` | `IsKeyboardFocusWithin` Trigger | 포커스 상태 감지 |
| `.blob` (장식 요소) | 별도 `Border` 요소 | 핑크색 그라데이션 장식 |

## 사용 예시

```xml
<controls:AverageElephant52 Placeholder="Search ..."
                            Width="320"/>
```

## 프로젝트 구조

```
AverageElephant52/
├── Wpf/
│   ├── AverageElephant52.Wpf.slnx
│   ├── AverageElephant52.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── AverageElephant52.cs
│   │   ├── Converters/
│   │   │   ├── SizeToRectConverter.cs
│   │   │   └── StringNotEmptyConverter.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── AverageElephant52.xaml
│   │       └── AverageElephant52Resources.xaml
│   └── AverageElephant52.Wpf.Gallery/
└── AvaloniaUI/
    └── (미구현)
```

## 라이선스

원본 디자인: [UIverse.io](https://uiverse.io) - seyed-mohsen-mousavi
