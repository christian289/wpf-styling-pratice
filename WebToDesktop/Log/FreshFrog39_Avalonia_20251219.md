# FreshFrog39 AvaloniaUI 변환 로그

## 개요

- **원본**: Uiverse.io by satyamchaudharydev (Tags: loader)
- **변환 일시**: 2025-12-19
- **변환 대상**: HTML/CSS → AvaloniaUI AXAML

## 원본 분석

3개의 원이 순차적으로 페이드 애니메이션을 실행하는 스피너 로더

### CSS 핵심 속성

```css
--clr: rgb(0, 113, 128);  /* 스피너 색상 */
--gap: 6px;                /* 원 사이 간격 */
width: 20px;               /* 각 원 크기 */
animation: fade 1s ease-in-out infinite;
/* delay: 0s, 0.33s, 0.66s */
```

### 애니메이션 키프레임

```css
@keyframes fade {
  0%, 100% { opacity: 1; }
  60% { opacity: 0; }
}
```

## 변환 결과

### 프로젝트 구조

```
FreshFrog39/AvaloniaUI/
├── FreshFrog39.Avalonia.slnx
├── FreshFrog39.Avalonia.Lib/
│   ├── Controls/
│   │   └── FreshFrog39Spinner.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── FreshFrog39Spinner.axaml
└── FreshFrog39.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

### 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| SpinnerColor | IBrush | rgb(0, 113, 128) | 원의 색상 |
| Gap | double | 6.0 | 원 사이 간격 (px) |
| CircleSize | double | 20.0 | 각 원의 크기 (px) |

## 컴파일 에러 및 수정

### 에러 1: AVLN2000

**에러 내용:**
```
Resource "avares://FreshFrog39.Avalonia.Lib/Themes/Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type in the "FreshFrog39.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인:**
`Application.Styles`에 `ResourceDictionary`를 직접 `StyleInclude`로 참조할 수 없음

**수정 방법:**
`Generic.axaml`을 `ResourceDictionary`에서 `Styles`로 변경하고, `Styles.Resources` 내부에 `ResourceDictionary`를 배치

**수정 전:**
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="avares://FreshFrog39.Avalonia.Lib/Themes/FreshFrog39Spinner.axaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

**수정 후:**
```xml
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="avares://FreshFrog39.Avalonia.Lib/Themes/FreshFrog39Spinner.axaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## 잠재적 런타임 오류

### 1. 애니메이션 타이밍 차이

- **가능성**: 낮음
- **설명**: CSS `ease-in-out`과 AvaloniaUI `SineEaseInOut`은 유사하지만 정확히 동일하지 않음
- **영향**: 애니메이션 느낌이 미세하게 다를 수 있음
- **확인 필요**: 직접 실행하여 시각적 차이 확인

### 2. 애니메이션 Delay 동작

- **가능성**: 중간
- **설명**: AvaloniaUI의 Animation Delay는 첫 반복에만 적용되며, CSS처럼 각 반복마다 지연되지 않음
- **영향**: 각 원이 순차적으로 시작하지만, 이후 반복에서는 동기화될 수 있음
- **확인 필요**: 직접 실행하여 애니메이션 동기화 상태 확인

### 3. ControlTheme 적용

- **가능성**: 낮음
- **설명**: `ControlTheme`이 `TemplatedControl`에 자동 적용되지 않을 수 있음
- **영향**: 컨트롤이 빈 상태로 렌더링될 수 있음
- **확인 필요**: 직접 실행하여 컨트롤 렌더링 확인

## 빌드 결과

✅ **빌드 성공** (경고 0개, 오류 0개)

```
dotnet build FreshFrog39.Avalonia.slnx
빌드했습니다.
    경고 0개
    오류 0개
경과 시간: 00:00:02.04
```

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 |
|----------|-----------|
| `display: flex; gap: var(--gap)` | `StackPanel Spacing="{TemplateBinding Gap}"` |
| `border-radius: 100%` | `Ellipse` |
| `opacity: 0` | `Opacity="0"` |
| `animation: fade 1s ease-in-out infinite` | `Animation Duration="0:0:1" IterationCount="Infinite" Easing="SineEaseInOut"` |
| `animation-delay: 0.33s` | `Animation Delay="0:0:0.33"` |
| `@keyframes` | `KeyFrame Cue="X%"` |

## 참고 사항

- RadialGradientBrush 미사용으로 Issue #19888 해당 없음
- .NET 9.0 + Avalonia 11.2.2 사용
