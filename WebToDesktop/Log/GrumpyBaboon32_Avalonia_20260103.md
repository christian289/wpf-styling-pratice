# GrumpyBaboon32 - AvaloniaUI 변환 로그

**날짜**: 2026-01-03
**원본**: Uiverse.io by mobinkakei (Tags: simple, blue, pattern)

## 변환 개요

CSS 타일 패턴 배경을 AvaloniaUI 커스텀 컨트롤로 변환

### CSS 원본 분석

```css
--s: 25px; /* 타일 크기 */
--c1: #1eaaee; /* 기본 색상 (cyan) */
--c2: #171717; /* 배경 색상 (dark) */

background:
  linear-gradient(45deg, ...) calc(var(--s) / -2) var(--_s),
  linear-gradient(135deg, ...) calc(var(--s) / 2) var(--_s),
  radial-gradient(var(--c1) 35%, var(--c2) 37%) 0 0 / var(--s) var(--s);
```

- `radial-gradient`: 중앙에 원형 (35% 반지름)
- `linear-gradient 45deg/135deg`: 대각선 라인 (71%~79% 범위)
- 타일 크기: 25px

## 컴파일 에러 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://GrumpyBaboon32.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "GrumpyBaboon32.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `ResourceDictionary`를 `Application.Styles`에 `StyleInclude`로 포함시키려 함
- AvaloniaUI에서 `Application.Styles`는 `IStyle` 타입만 허용

**수정 전** (App.axaml):
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://GrumpyBaboon32.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후** (App.axaml):
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GrumpyBaboon32.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**설명**:
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 병합해야 함
- `StyleInclude`는 `Styles` 타입 파일에만 사용 가능

## 잠재적 런타임 에러 (직접 확인 필요)

### 1. 패턴 렌더링 성능 이슈

**위치**: `GrumpyBaboon32PatternBackground.cs:Render()`

**가능성**: 중간

**설명**:
- 현재 구현은 매 프레임마다 모든 타일을 다시 그림
- 큰 윈도우에서 수천 개의 도형을 그려야 할 수 있음
- `RenderOptions.BitmapInterpolationMode` 또는 캐싱 전략 고려 필요

**개선 방안**:
- `DrawingGroup` 캐싱
- `VisualBrush`와 `TileBrush`로 타일링 구현
- `WriteableBitmap`으로 한 번만 렌더링 후 재사용

### 2. 대각선 라인 근사값 정확도

**위치**: `GrumpyBaboon32PatternBackground.cs:DrawDiagonalLine()`

**가능성**: 낮음

**설명**:
- CSS `linear-gradient`의 정확한 렌더링과 약간 다를 수 있음
- 얇은 평행사변형으로 근사하여 구현
- 특정 각도나 크기에서 시각적 차이 발생 가능

### 3. RadialGradientBrush 미사용

**위치**: N/A

**가능성**: 낮음 (현재 미사용)

**설명**:
- 현재 구현은 `SolidColorBrush`와 `EllipseGeometry`로 원을 그림
- `RadialGradientBrush`를 사용하면 AvaloniaUI Issue #19888에 주의 필요
- GradientOrigin과 Center 값이 다르면 정상 동작하지 않음

## 생성된 파일 목록

### Library (GrumpyBaboon32.Avalonia.Lib)

- `GrumpyBaboon32.Avalonia.Lib.csproj`
- `Controls/GrumpyBaboon32PatternBackground.cs`
- `Themes/Generic.axaml`
- `Themes/GrumpyBaboon32PatternBackground.axaml`

### Gallery (GrumpyBaboon32.Avalonia.Gallery)

- `GrumpyBaboon32.Avalonia.Gallery.csproj`
- `Program.cs`
- `App.axaml` / `App.axaml.cs`
- `MainWindow.axaml` / `MainWindow.axaml.cs`

### Solution

- `GrumpyBaboon32.Avalonia.slnx`

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
