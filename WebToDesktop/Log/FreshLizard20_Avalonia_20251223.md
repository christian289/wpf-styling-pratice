# FreshLizard20 AvaloniaUI 변환 로그

**날짜**: 2025-12-23
**원본**: Uiverse.io by kennyotsu (Tags: simple)
**설명**: 순환하는 단어 목록을 표시하는 로딩 텍스트 컨트롤

## 변환 내용

### HTML 구조

```html
<div class="card">
  <div class="loader">
    <p>loading</p>
    <div class="words">
      <span class="word">buttons</span>
      <span class="word">forms</span>
      <span class="word">switches</span>
      <span class="word">cards</span>
      <span class="word">buttons</span>
    </div>
  </div>
</div>
```

### CSS 특징

- 다크 배경 (#212121)
- 보라색 악센트 텍스트 (#956AFA)
- 4초 순환 애니메이션 (translateY)
- 상하 페이드 효과 (linear-gradient 오버레이)

## 컴파일 에러 및 수정

### 에러 1: SDK 오류

**에러 내용**:

```
error MSB4236: 지정된 'Sdk.NET.Desktop/9.0.200' SDK를 찾을 수 없습니다.
```

**수정 방법**:

- `Sdk="Sdk.NET.Desktop/9.0.200"` → `Sdk="Microsoft.NET.Sdk"`로 변경
- AvaloniaUI는 표준 .NET SDK를 사용해야 함

### 에러 2: TranslateTransform x:Name 오류

**에러 내용**:

```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform Line 73, position 42.
```

**수정 방법**:

- `<TranslateTransform x:Name="WordsTranslate" />` → `<TranslateTransform />`로 변경
- AvaloniaUI에서 Transform 요소에는 x:Name을 사용할 수 없음
- 애니메이션은 Style Selector를 통해 RenderTransform 속성 전체를 설정하는 방식으로 구현

### 에러 3: ResourceDictionary vs IStyle 타입 오류

**에러 내용**:

```
Avalonia error AVLN2000: Resource "avares://FreshLizard20.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "FreshLizard20.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**수정 방법**:

- `Application.Styles` 내의 `StyleInclude` 대신 `Application.Resources` 섹션에서 `ResourceInclude` 사용

**변경 전**:

```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://FreshLizard20.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**변경 후**:

```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://FreshLizard20.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 Runtime 오류

### 1. 애니메이션 `:loaded` pseudo-class 동작

- **위치**: `FreshLizard20LoadingTextControl.axaml:88`
- **내용**: `:loaded` pseudo-class가 AvaloniaUI에서 예상대로 동작하지 않을 수 있음
- **확인 필요**: 컨트롤 로드 시 애니메이션이 시작되는지 확인

### 2. CSS vs AXAML 애니메이션 타이밍 차이

- **위치**: KeyFrame 애니메이션
- **내용**: CSS의 `transform: translateY(-102%)` 같은 percentage 기반 값을 픽셀로 환산 (40px 기준)
- **확인 필요**: 애니메이션 타이밍이 원본과 동일한지 확인

### 3. LinearGradientBrush 페이드 효과

- **위치**: `FreshLizard20.FadeBrush` 리소스
- **내용**: CSS의 `linear-gradient(var(--bg-color) 10%, transparent 30%, transparent 70%, var(--bg-color) 90%)`를 AXAML로 변환
- **확인 필요**: 오버레이 효과가 시각적으로 동일한지 확인

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
