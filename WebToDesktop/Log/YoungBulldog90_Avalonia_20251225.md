# YoungBulldog90 AvaloniaUI 변환 로그

## 원본 정보

- **출처**: Uiverse.io by Clemix37
- **태그**: loader
- **설명**: 회전하는 스피너 로더 (Rotating spinner loader)

## 변환 개요

CSS `::before` 가상 요소를 사용한 회전 스피너를 AvaloniaUI `Arc` 컨트롤로 변환.

- `border-top: 2px solid #8900FF` + `border-right: 2px solid transparent` → 90도 호(Arc)
- `animation: 0.8s linear infinite` → AvaloniaUI Animation

## 컴파일 에러 및 수정

### 에러 1: CS0234 - 네임스페이스 충돌

**에러 내용**:
```
'YoungBulldog90.Avalonia' 네임스페이스에 'Media' 형식 또는 네임스페이스 이름이 없습니다.
```

**원인**: 프로젝트 네임스페이스가 `YoungBulldog90.Avalonia.Lib`이므로 `Avalonia.Media`가 `YoungBulldog90.Avalonia.Media`로 해석됨.

**수정 방법**:
- `using Avalonia.Media;` 추가
- 전체 경로(`Avalonia.Media.IBrush`)를 단순 타입명(`IBrush`)으로 변경

```csharp
// 수정 전
// Before
public static readonly StyledProperty<Avalonia.Media.IBrush?> SpinnerBrushProperty = ...

// 수정 후
// After
using Avalonia.Media;
public static readonly StyledProperty<IBrush?> SpinnerBrushProperty = ...
```

### 에러 2: AVLN2000 - Template 속성 없음

**에러 내용**:
```
Unable to resolve suitable regular or attached property Template on type SpinnerLoader
```

**원인**: `Control` 클래스는 `Template` 속성을 지원하지 않음.

**수정 방법**:
- 기본 클래스를 `Control`에서 `TemplatedControl`로 변경

```csharp
// 수정 전
// Before
public sealed class SpinnerLoader : Control

// 수정 후
// After
public sealed class SpinnerLoader : TemplatedControl
```

### 에러 3: AVLN2000 - StyleInclude 타입 불일치

**에러 내용**:
```
Resource is defined as "ResourceDictionary" type, but expected "IStyle"
```

**원인**: `App.Styles`에서 `StyleInclude`로 `ResourceDictionary`를 로드하려고 함.

**수정 방법**:
- `Application.Resources`에 `ResourceInclude`로 병합

```xml
<!-- 수정 전 -->
<!-- Before -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://..." />
</Application.Styles>

<!-- 수정 후 -->
<!-- After -->
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

## 런타임 오류 가능성

### 1. 애니메이션 동작 확인 필요

`ControlTheme` 내부의 `Style Selector="^:not(:disabled)"`에서 애니메이션이 정상 동작하는지 확인 필요. 컨트롤 자체가 아닌 내부 Arc에 RenderTransform을 적용하므로 회전 중심이 예상과 다를 수 있음.

### 2. Arc 크기 바인딩

Arc가 부모 Panel을 채우도록 설정되어 있지만, 명시적인 Width/Height 바인딩이 없어 레이아웃에 따라 다르게 보일 수 있음.

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개
