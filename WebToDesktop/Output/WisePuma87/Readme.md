# WisePuma87

애니메이션이 있는 Checkbox 스타일 컨트롤

## 원본 정보

- **출처:** [uiverse.io](https://uiverse.io)
- **원작자:** LeonKohli
- **태그:** icon, animation, minimalist, checkbox, rounded, smooth, light, clean

## 빌드 및 실행

```bash
cd Wpf
dotnet run --project WisePuma87.Wpf.Gallery
```

## 프로젝트 구조

```
WisePuma87/
├── Wpf/
│   ├── WisePuma87.Wpf.slnx
│   ├── WisePuma87.Wpf.Gallery/     # 데모 앱
│   └── WisePuma87.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── WisePuma87.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── WisePuma87.xaml
│           └── WisePuma87Resources.xaml
└── Readme.md
```

## 사용법

```xml
<Window xmlns:controls="clr-namespace:WisePuma87.Wpf.UI.Controls;assembly=WisePuma87.Wpf.UI">
    <controls:WisePuma87 Text="Check me!" />
    <controls:WisePuma87 Text="Already checked" IsChecked="True" />
</Window>
```

## 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Text` | `string` | "Check me!" | 체크박스 옆에 표시되는 텍스트 |
| `IsChecked` | `bool?` | `false` | 체크 상태 (ToggleButton 상속) |

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `transition: border-color 0.3s ease` | `ColorAnimation` + `CubicEase` |
| `transition: stroke-dashoffset 0.5s cubic-bezier(...)` | `DoubleAnimationUsingKeyFrames` + `SplineDoubleKeyFrame` |
| `stroke-dasharray: 24` | `Path.StrokeDashArray="24"` |
| `stroke-dashoffset: 24 → 0` | `Path.StrokeDashOffset` 애니메이션 |
| `border-radius: 30% 70% 70% 30% / 30% 30% 70% 70%` | `Border.CornerRadius="10,6,10,6"` (근사값) |
| `:checked + .label .icon` | `Trigger Property="IsChecked"` |
| `background-color: #6c5ce7` | `SolidColorBrush` + `ColorAnimation` |

## 특징

- **체크마크 드로잉 애니메이션:** `stroke-dashoffset` 조작으로 체크마크가 그려지는 효과
- **Blob 형태 모서리:** 비대칭 border-radius로 유기적인 형태 (WPF에서는 근사값 사용)
- **색상 전환:** 체크 시 보라색(#6C5CE7)으로 부드럽게 전환
- **MVVM 호환:** `IsChecked` 속성으로 바인딩 가능

## 제한 사항

1. CSS의 완전한 비대칭 border-radius (`30% 70% 70% 30% / 30% 30% 70% 70%`)는 WPF에서 지원되지 않아 단일 `CornerRadius` 값으로 근사화
2. `cubic-bezier` 이징 함수는 `SplineDoubleKeyFrame`으로 구현 (전체 애니메이션 동작 방식이 약간 다를 수 있음)
