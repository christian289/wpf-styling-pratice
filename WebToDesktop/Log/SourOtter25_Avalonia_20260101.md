# SourOtter25 - AvaloniaUI 변환 로그

## 원본 정보

- **소스**: Uiverse.io by ElektroRaks
- **HTML**: `WebToDesktop/source/20251231_SourOtter25/SourOtter25.html`
- **CSS**: `WebToDesktop/source/20251231_SourOtter25/SourOtter25.css`
- **태그**: card, polygon, blur filter, text animation, rotate, clip-path

## 변환 결과

- **출력 경로**: `WebToDesktop/Output/SourOtter25/AvaloniaUI/`
- **솔루션**: `SourOtter25.Avalonia.slnx`
- **라이브러리**: `SourOtter25.Avalonia.Lib`
- **갤러리**: `SourOtter25.Avalonia.Gallery`

## 컴파일 에러 및 수정

### 에러 1: RotateTransform에 x:Name 사용 불가

**에러 내용**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type
Avalonia.Base:Avalonia.Media.RotateTransform Line 73, position 42.
```

**원인**: AvaloniaUI에서 `RotateTransform`은 `INamedElement`를 구현하지 않아 `x:Name` 속성을 사용할 수 없음.

**수정 방법**:
1. `RotateTransform`을 ResourceDictionary에 리소스로 정의
2. `RenderTransform` 속성에 StaticResource로 바인딩
3. Style Selector에서 `RenderTransform` 속성 값을 직접 변경

```xml
<!-- 리소스 정의 -->
<RotateTransform x:Key="ClipPathCard.Transform.Rotated" Angle="34" />
<RotateTransform x:Key="ClipPathCard.Transform.Normal" Angle="0" />

<!-- 사용 -->
<TextBlock RenderTransform="{StaticResource ClipPathCard.Transform.Rotated}" />

<!-- Hover 시 변경 -->
<Style Selector="^:pointerover /template/ TextBlock#PART_Title">
    <Setter Property="RenderTransform" Value="{StaticResource ClipPathCard.Transform.Normal}" />
</Style>
```

### 에러 2: StyleInclude에서 ResourceDictionary 타입 불일치

**에러 내용**:
```
AVLN2000: Resource "avares://SourOtter25.Avalonia.Lib/Themes/Generic.axaml" is defined
as "Avalonia.Controls.ResourceDictionary" type in the "SourOtter25.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**: `Application.Styles`에 `StyleInclude`로 ResourceDictionary를 포함하려고 함. Styles는 IStyle 인터페이스를 구현한 객체만 받음.

**수정 방법**: `Application.Resources`에 `ResourceDictionary.MergedDictionaries`로 병합

```xml
<!-- 수정 전 (오류) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://..." />
</Application.Styles>

<!-- 수정 후 (정상) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://..." />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성

### 1. Clip 애니메이션 미지원

**설명**: AvaloniaUI의 Style Animation에서 `Clip` 속성의 Geometry 값 변경 애니메이션이 지원되지 않음.

**현재 구현**: Setter로 즉시 변경 (애니메이션 없음)

**확인 필요 사항**:
- Hover 시 clip-path가 즉시 변경되어 CSS의 부드러운 전환 효과가 없음
- 사용자 경험상 문제가 있다면 코드 비하인드에서 직접 애니메이션 구현 필요

### 2. backdrop-filter 미지원

**설명**: CSS `backdrop-filter: blur(20px)`는 AvaloniaUI에서 직접 지원되지 않음.

**현재 구현**: 반투명 배경색 `#13FFFFFF`으로 대체

**확인 필요 사항**:
- 블러 효과 없이 반투명 오버레이만 적용됨
- 실제 블러 효과가 필요하면 별도의 블러 레이어 구현 필요

### 3. RenderTransform 애니메이션 제한

**설명**: Style Animation에서 `RenderTransform` 속성 자체를 애니메이션하면 Transform 객체 전체가 교체됨.

**현재 구현**: Setter로 즉시 변경 (회전 애니메이션 없음)

**확인 필요 사항**:
- CSS의 `transition: 0.5s`로 부드럽게 회전하는 효과가 구현되지 않음
- `Margin` 변경 애니메이션은 정상 동작함

## CSS → AXAML 변환 요약

| CSS 속성 | AXAML 변환 | 비고 |
|---------|-----------|------|
| `linear-gradient(135deg, ...)` | `LinearGradientBrush StartPoint="0%,0%" EndPoint="100%,100%"` | 정상 |
| `clip-path: polygon(...)` | `Clip` + `StreamGeometry` | 애니메이션 미지원 |
| `backdrop-filter: blur(20px)` | 반투명 배경색 | 블러 미지원 |
| `transform: rotate(34deg)` | `RotateTransform Angle="34"` | 애니메이션 미지원 |
| `transition: 0.5s` | `Style.Animations` | 일부 속성만 지원 |
| `:hover` | `:pointerover` | 정상 |
| `opacity` | `Opacity` | 애니메이션 정상 |
| `margin-left: 25%` | `Margin="47.5,..."` | 절대값으로 변환 |

## 빌드 결과

- **빌드 성공**: 2026-01-01
- **경고**: 0개
- **오류**: 0개 (수정 후)
