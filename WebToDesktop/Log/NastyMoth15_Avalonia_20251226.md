# NastyMoth15 AvaloniaUI 변환 로그

## 변환 정보

- **원본 파일**: `source/20251225_NastyMoth15/NastyMoth15.html`, `NastyMoth15.css`
- **변환 대상**: AvaloniaUI 11.2.2
- **변환 일시**: 2025-12-26
- **원본 출처**: Uiverse.io by MuhammadHasann (animation, minimalist, switch)

## 컴포넌트 설명

스파클(sparkle) 애니메이션 효과와 깃발 아이콘이 있는 세련된 토글 스위치입니다.
- 체크 시 노브가 오른쪽으로 이동하면서 -225도 회전
- 배경 색상이 어두운 그레이에서 투명으로 전환
- RadialGradientBrush를 사용한 조명 효과

## 컴파일 에러 및 수정 내용

### 에러 1: TranslateTransform/RotateTransform에 x:Name 사용 불가

**에러 메시지**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**:
AvaloniaUI에서 TransformGroup 내부의 개별 Transform 객체에 x:Name을 지정하고 스타일 셀렉터로 직접 참조하는 것이 지원되지 않습니다.

**수정 방법**:
TransformGroup 대신 CSS-like transform string을 사용하여 RenderTransform 속성에 직접 적용:

```xml
<!-- 수정 전 -->
<Border.RenderTransform>
    <TransformGroup>
        <TranslateTransform x:Name="KnobTranslate"/>
        <RotateTransform x:Name="KnobRotate"/>
    </TransformGroup>
</Border.RenderTransform>

<!-- 수정 후 -->
<Border ... RenderTransform="translate(0px, 0px) rotate(0deg)">

<!-- 스타일에서 -->
<Style Selector="^:checked /template/ Border#KnobContainer">
    <Setter Property="RenderTransform" Value="translate(36px, 0px) rotate(-225deg)"/>
</Style>
```

---

### 에러 2: StyleInclude와 ResourceDictionary 타입 불일치

**에러 메시지**:
```
AVLN2000: Resource "avares://NastyMoth15.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "NastyMoth15.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**:
`Application.Styles` 내에서 `StyleInclude`를 사용하면 IStyle 타입을 기대하지만, Generic.axaml은 ResourceDictionary 타입입니다.

**수정 방법**:
`Application.Resources`에서 `ResourceDictionary.MergedDictionaries`를 사용:

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://NastyMoth15.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://NastyMoth15.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## RadialGradientBrush 처리

AvaloniaUI Issue #19888에 따라 RadialGradientBrush의 GradientOrigin과 Center 값을 동일하게 설정했습니다.

```xml
<!-- CSS 원본: radial-gradient(circle at 50% 0%, ...) -->
<RadialGradientBrush GradientOrigin="50%,0%" Center="50%,0%" RadiusX="100%" RadiusY="100%">
    <GradientStop Color="#666666" Offset="0"/>
    <GradientStop Color="#414344" Offset="1"/>
</RadialGradientBrush>
```

---

## Runtime Error 가능성 (직접 확인 필요)

1. **스파클 애니메이션 미구현**: 원본 CSS의 sparkle 키프레임 애니메이션은 AvaloniaUI로 직접 변환되지 않았습니다. 현재는 정적인 Ellipse로만 표시됩니다. 실제 애니메이션 효과를 원한다면 Storyboard/Animation을 추가로 구현해야 합니다.

2. **BoxShadow inset 지원 제한**: `inset` BoxShadow가 모든 상황에서 정확히 렌더링되지 않을 수 있습니다.

3. **TransformOperationsTransition 동작**: translate와 rotate를 결합한 RenderTransform 문자열이 트랜지션에서 정확히 보간되는지 확인이 필요합니다.

4. **CornerRadius="9999" 처리**: 매우 큰 CornerRadius 값이 의도대로 완전한 pill 형태를 만드는지 확인이 필요합니다.

---

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 프로젝트 구조

```
WebToDesktop/Output/NastyMoth15/AvaloniaUI/
├── NastyMoth15.Avalonia.slnx
├── NastyMoth15.Avalonia.Lib/
│   ├── NastyMoth15.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── NastyMoth15ToggleSwitch.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── NastyMoth15ToggleSwitch.axaml
└── NastyMoth15.Avalonia.Gallery/
    ├── NastyMoth15.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
