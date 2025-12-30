# FatPanther54 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: FatPanther54.html, FatPanther54.css
- **출처**: Uiverse.io by csemszepp
- **태그**: simple, minimalist, pattern
- **변환 일시**: 2025-12-31
- **변환 대상**: AvaloniaUI 11.2.3 / .NET 9.0

## 원본 CSS 분석

```css
.container {
  --s: 37px;
  --c: #0000, #2fb8ac 0.5deg 119.5deg, #0000 120deg;
  --g1: conic-gradient(from 60deg at 56.25% calc(425% / 6), var(--c));
  --g2: conic-gradient(from 180deg at 43.75% calc(425% / 6), var(--c));
  --g3: conic-gradient(from -60deg at 50% calc(175% / 12), var(--c));
  background: var(--g1), var(--g1) var(--s) calc(1.73 * var(--s)), var(--g2),
    var(--g2) var(--s) calc(1.73 * var(--s)), var(--g3) var(--s) 0,
    var(--g3) 0 calc(1.73 * var(--s)) #ecbe13;
  background-size: calc(2 * var(--s)) calc(3.46 * var(--s));
}
```

**특징**: conic-gradient를 사용한 기하학적 삼각형 타일 패턴

## 변환 전략

AvaloniaUI에서는 CSS conic-gradient를 직접 지원하지 않으므로:
- `DrawingContext`의 `Render` 메서드 오버라이드를 사용
- `StreamGeometry`로 삼각형을 직접 그리는 방식으로 구현
- 타일 패턴을 코드로 생성하여 유사한 기하학적 효과 재현

## 컴파일 에러 및 수정

### 에러 1: XML 주석 내 double-hyphen 금지

**에러 메시지**:
```
Avalonia error AVLN1001: An XML comment cannot contain '--', and '-' cannot be the last character.
```

**원인**: AXAML 파일의 XML 주석에 `--c`, `--s` 등 CSS 변수명이 포함됨

**수정 전**:
```xml
<!--
    Color Resources
    CSS --c: #0000, #2fb8ac 0.5deg 119.5deg, #0000 120deg
    CSS background fallback: #ecbe13
-->
<!-- Size Resources (CSS --s: 37px) -->
```

**수정 후**:
```xml
<!-- Color Resources -->
<!-- Size Resources (CSS s variable: 37px) -->
```

### 에러 2: ResourceDictionary를 Styles에 포함 시 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type, but expected "Avalonia.Styling.IStyle"
```

**원인**: `StyleInclude`는 `IStyle` 타입만 허용하므로 `ResourceDictionary`를 직접 포함할 수 없음

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://FatPanther54.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://FatPanther54.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성 (직접 확인 필요)

1. **패턴 렌더링 성능**: 큰 화면에서 많은 삼각형을 그릴 때 성능 저하 가능
   - 해결 방안: `VisualBrush`로 타일 패턴을 캐싱하거나, `WriteableBitmap` 사용 고려

2. **리사이즈 시 깜빡임**: 창 크기 변경 시 전체 패턴을 다시 그리므로 깜빡임 발생 가능
   - 해결 방안: `RenderOptions.BitmapInterpolationMode` 설정 또는 더블 버퍼링 고려

3. **CSS 원본과의 시각적 차이**: conic-gradient의 정확한 각도 표현이 삼각형 근사치로 대체됨
   - 원본 CSS는 0.5deg~119.5deg 범위의 그라데이션 사용
   - 변환된 버전은 단색 삼각형으로 단순화됨

## 생성된 파일 구조

```
WebToDesktop/Output/FatPanther54/AvaloniaUI/
├── FatPanther54.Avalonia.slnx
├── FatPanther54.Avalonia.Lib/
│   ├── FatPanther54.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── GeometricPatternPanel.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── GeometricPatternPanel.axaml
└── FatPanther54.Avalonia.Gallery/
    ├── FatPanther54.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 사용 방법

```xml
<controls:GeometricPatternPanel PatternSize="37"
                                 TriangleColor="#2fb8ac"
                                 BackgroundColor="#ecbe13">
    <!-- 콘텐츠 -->
</controls:GeometricPatternPanel>
```

### 속성 설명

| 속성 | 기본값 | 설명 |
|------|--------|------|
| PatternSize | 37 | 패턴 크기 (CSS --s 변수에 해당) |
| TriangleColor | #2fb8ac | 삼각형 색상 |
| BackgroundColor | #ecbe13 | 배경 색상 |
