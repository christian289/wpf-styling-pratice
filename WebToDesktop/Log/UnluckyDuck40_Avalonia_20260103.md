# UnluckyDuck40 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by boryanakrasteva (Tags: social, button, share)
- **변환일**: 2026-01-03
- **컨트롤명**: SocialShareButton
- **설명**: Share 버튼에 hover 시 소셜 미디어 아이콘(Twitter, Instagram, Facebook)이 위로 슬라이드되어 나타나는 버튼

## 프로젝트 구조

```
UnluckyDuck40/AvaloniaUI/
├── UnluckyDuck40.Avalonia.slnx
├── UnluckyDuck40.Avalonia.Lib/
│   ├── Controls/
│   │   └── SocialShareButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SocialShareButton.axaml
└── UnluckyDuck40.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내용

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://UnluckyDuck40.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "UnluckyDuck40.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 로드하려고 시도
- `StyleInclude`는 `IStyle` 타입만 허용하며, `ResourceDictionary`는 호환되지 않음

**수정 방법**:
`App.axaml`에서 `Application.Resources`를 사용하여 `ResourceDictionary`를 병합:

```xml
<!-- 수정 전 (에러 발생) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://UnluckyDuck40.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 (정상 동작) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://UnluckyDuck40.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AvaloniaUI 변환 특이사항

### 1. RadialGradientBrush 처리 (Avalonia Issue #19888)

Instagram 아이콘의 SVG에 3개의 RadialGradient가 사용됨. AvaloniaUI에서는 `GradientOrigin`과 `Center` 값이 다르면 정상 동작하지 않으므로 두 값을 동일하게 설정함.

```xml
<!-- 예: Instagram 배경 그라데이션 -->
<RadialGradientBrush GradientOrigin="37.5%,71.875%" Center="37.5%,71.875%" RadiusX="0.8" RadiusY="0.8">
    <GradientStop Color="#B13589" Offset="0" />
    <GradientStop Color="#C62F94" Offset="0.79309" />
    <GradientStop Color="#8A3AC8" Offset="1" />
</RadialGradientBrush>
```

### 2. CSS filter → AvaloniaUI BoxShadow

```css
/* CSS */
filter: drop-shadow(1px 1px 3px rgba(122, 122, 122, 0.808));
```

```xml
<!-- AvaloniaUI -->
BoxShadow="1 1 3 0 #CE7A7A7A"
```

### 3. CSS transition → AvaloniaUI Animation

```css
/* CSS */
.socials {
    transition: .2s linear;
    opacity: 0;
    top: 0;
}
.btn:hover > .socials {
    opacity: 1;
    top: -120%;
}
```

```xml
<!-- AvaloniaUI -->
<Style Selector="^:pointerover /template/ Border#PART_SocialsPanel">
    <Style.Animations>
        <Animation Duration="0:0:0.2" Easing="LinearEasing" FillMode="Forward">
            <KeyFrame Cue="0%">
                <Setter Property="Opacity" Value="0" />
                <Setter Property="RenderTransform" Value="translate(0px, 0px)" />
            </KeyFrame>
            <KeyFrame Cue="100%">
                <Setter Property="Opacity" Value="1" />
                <Setter Property="RenderTransform" Value="translate(0px, -48px)" />
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>
```

### 4. SVG → AvaloniaUI Path/PathIcon

SVG의 `<path>` 데이터를 그대로 `PathGeometry` 또는 `Path.Data`로 변환.

## 잠재적 런타임 오류 가능성

### 1. LetterSpacing 속성

- **위치**: `SocialShareButton.axaml` - TextBlock의 `LetterSpacing="2.5"`
- **가능성**: AvaloniaUI에서 `LetterSpacing` 속성이 지원되지 않을 수 있음
- **확인 필요**: 런타임에서 속성이 무시되거나 예외 발생 여부 확인

### 2. PathIcon 내 PathGeometry 스트로크 표현

- **위치**: Share 아이콘 (원본 SVG에서 `stroke` 사용)
- **가능성**: `PathIcon`은 `Foreground`만 지원하여 스트로크 스타일이 제대로 표현되지 않을 수 있음
- **확인 필요**: 아이콘 렌더링 상태 확인

### 3. Canvas 내 SVG 경로 스케일링

- **위치**: Instagram/Facebook 아이콘의 `ScaleTransform`
- **가능성**: 스케일 변환 후 아이콘 위치가 의도와 다르게 표시될 수 있음
- **확인 필요**: 아이콘 정렬 상태 확인

### 4. 애니메이션 타이밍

- **위치**: Hover 애니메이션
- **가능성**: `FillMode="Forward"` 설정에도 불구하고 마우스 아웃 시 깜빡임 발생 가능
- **확인 필요**: 마우스 인/아웃 반복 시 애니메이션 동작 확인

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
