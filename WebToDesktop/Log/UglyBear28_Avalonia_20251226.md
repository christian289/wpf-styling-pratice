# UglyBear28 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by csemszepp
- **태그**: simple, material design, pattern
- **변환일**: 2025-12-26
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## CSS 원본 분석

```css
.container {
  width: 100%;
  height: 100%;
  position: relative;
  background: #fff;
  filter: contrast(7);
  --mask: linear-gradient(red, rgba(0, 0, 0, 0.45));
}

.container::before {
  position: absolute;
  top: 0; right: 0; bottom: 0; left: 0;
  background: radial-gradient(#000, transparent) 0 0/1em 1em space;
  -webkit-mask: var(--mask);
  mask: var(--mask);
  content: "";
}
```

## 변환 전략

### CSS 기능 → AvaloniaUI 변환

| CSS 기능 | AvaloniaUI 구현 | 비고 |
|---------|----------------|------|
| `filter: contrast(7)` | RadialGradientBrush GradientStops 조정 | 직접 지원 안함 - 시뮬레이션 |
| `radial-gradient(#000, transparent)` | RadialGradientBrush | Issue #19888 주의 |
| `0 0/1em 1em space` | VisualBrush TileMode="Tile" | 16x16 픽셀 타일 |
| `mask: linear-gradient(...)` | Border.OpacityMask | LinearGradientBrush |
| `::before` pseudo-element | 별도 Border 레이어 | Panel로 겹침 |

### RadialGradientBrush 처리 (Issue #19888)

AvaloniaUI에서는 RadialGradientBrush의 GradientOrigin과 Center 값이 다르면 정상 동작하지 않습니다. 본 변환에서는 두 값을 동일하게 `50%,50%`로 설정했습니다.

```xml
<RadialGradientBrush GradientOrigin="50%,50%"
                     Center="50%,50%"
                     RadiusX="50%" RadiusY="50%">
```

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://UglyBear28.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "UglyBear28.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- App.axaml의 `<StyleInclude>`는 IStyle 타입을 기대함
- Generic.axaml이 ResourceDictionary로 정의되어 있어서 타입 불일치 발생

**수정 방법**:
- Generic.axaml과 DotPatternBackground.axaml을 `<ResourceDictionary>`에서 `<Styles>`로 변경
- ControlTheme 대신 Style Selector 사용

**수정 전**:
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui">
    <ControlTheme x:Key="{x:Type controls:DotPatternBackground}" ...>
```

**수정 후**:
```xml
<Styles xmlns="https://github.com/avaloniaui">
    <Style Selector="controls|DotPatternBackground">
```

## 잠재적 런타임 오류

### 1. VisualBrush 렌더링 성능

- **위험도**: 낮음
- **설명**: VisualBrush로 도트 패턴을 타일링하면 많은 수의 Ellipse가 렌더링됨
- **증상**: 창 크기가 크거나 리사이즈 시 성능 저하 가능
- **권장**: 실제 테스트 후 DrawingBrush나 ImageBrush로 대체 고려

### 2. CSS filter: contrast(7) 시뮬레이션 한계

- **위험도**: 중간
- **설명**: CSS contrast 필터는 AvaloniaUI에서 직접 지원하지 않음
- **증상**: 원본 CSS와 시각적 차이가 있을 수 있음 (도트 엣지가 덜 선명)
- **권장**: 시각적 결과 확인 후 GradientStops 조정 필요할 수 있음

### 3. OpacityMask 렌더링

- **위험도**: 낮음
- **설명**: LinearGradientBrush OpacityMask가 일부 GPU에서 다르게 렌더링될 수 있음
- **증상**: 그라데이션 마스크 효과가 예상과 다를 수 있음
- **권장**: 다양한 환경에서 테스트 필요

## 생성된 파일 구조

```
WebToDesktop/Output/UglyBear28/AvaloniaUI/
├── UglyBear28.Avalonia.slnx
├── UglyBear28.Avalonia.Lib/
│   ├── UglyBear28.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── DotPatternBackground.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── DotPatternBackground.axaml
└── UglyBear28.Avalonia.Gallery/
    ├── UglyBear28.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
