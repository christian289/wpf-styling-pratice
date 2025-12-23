# BlackMouse53 AvaloniaUI 변환 로그

**날짜**: 2025-12-23
**원본**: uiverse.io by vladaxinte
**설명**: CSS 아트로 구현된 트위터 새 로고 (Twitter Bird CSS Art)

## 변환 요약

### 소스 파일
- HTML: `WebToDesktop/source/20251223_BlackMouse53/BlackMouse53.html`
- CSS: `WebToDesktop/source/20251223_BlackMouse53/BlackMouse53.css`

### 출력 파일
- 솔루션: `WebToDesktop/Output/BlackMouse53/AvaloniaUI/BlackMouse53.Avalonia.slnx`
- 라이브러리: `BlackMouse53.Avalonia.Lib/`
- 갤러리: `BlackMouse53.Avalonia.Gallery/`

## CSS → AvaloniaUI 변환 내용

### 주요 변환

| CSS 속성 | AvaloniaUI 속성 |
|----------|-----------------|
| `border-radius: 100%` | `Ellipse` 요소 사용 |
| `position: absolute` + `left/top` | `Canvas` + `Canvas.Left/Canvas.Top` |
| `transform: rotate(Xdeg)` | `RotateTransform` |
| `transform: translate(X%, Y%)` | `Canvas.Left/Canvas.Top` 계산 |
| `radial-gradient(circle at X% Y%, ...)` | `RadialGradientBrush` |
| `z-index` | Canvas 내 요소 순서로 처리 |

### RadialGradientBrush 변환 (AvaloniaUI Issue #19888)

CSS의 `radial-gradient(circle at X% Y%, ...)`를 AvaloniaUI의 `RadialGradientBrush`로 변환 시, **GradientOrigin과 Center를 동일하게 설정**해야 합니다.

| 요소 | CSS center 위치 | AvaloniaUI GradientOrigin/Center |
|------|-----------------|----------------------------------|
| wing-bottom | `-100% 90%` | `-100%,90%` |
| wing-top | `-100% 90%` | `-100%,90%` |
| wing-middle | `50% -80%` | `50%,-80%` |
| beak | `10% -30%` | `10%,-30%` |
| tummy | `0% -38%` | `0%,-38%` |
| torso | `0% -40%` | `0%,-40%` |
| tail | `10% -42%` | `10%,-42%` |

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary를 StyleInclude로 로드 시도

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://BlackMouse53.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "BlackMouse53.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에 `StyleInclude`를 사용하여 ResourceDictionary를 로드하려고 함
- AvaloniaUI에서 `StyleInclude`는 `IStyle`을 구현한 타입만 로드 가능

**수정 방법**:
- `Application.Resources`에 `ResourceInclude`를 사용하여 ResourceDictionary 병합

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://BlackMouse53.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BlackMouse53.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (확인 필요)

### 1. RadialGradientBrush 렌더링 이슈

**가능성**: 높음
**내용**: CSS의 `radial-gradient`와 AvaloniaUI의 `RadialGradientBrush`는 좌표 시스템과 동작 방식이 다릅니다.

- CSS에서 `-100%`, `90%` 같은 범위 외 값 사용
- AvaloniaUI에서는 이런 범위 외 값이 예상과 다르게 렌더링될 수 있음
- GradientOrigin ≠ Center인 경우 첫 번째 GradientStop이 Transparent일 때 렌더링 이상 가능 (Issue #19888)

**조치**: 런타임에서 실제 렌더링 확인 필요

### 2. 레이어 순서 (z-index)

**가능성**: 중간
**내용**: CSS z-index를 Canvas 내 요소 순서로 변환했으나, 복잡한 중첩 구조에서 원본과 다르게 보일 수 있음

**조치**: 런타임에서 시각적 확인 필요

### 3. Transform Origin

**가능성**: 낮음
**내용**: CSS의 기본 transform-origin은 요소 중심이며, AvaloniaUI도 `RenderTransformOrigin="0.5,0.5"`로 설정했으나 미세한 차이가 있을 수 있음

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 실행 방법

```bash
cd WebToDesktop/Output/BlackMouse53/AvaloniaUI
dotnet run --project BlackMouse53.Avalonia.Gallery
```
