# FuzzyFly47 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본**: uiverse.io by ActiveIceDigital (notification)
- **변환 대상**: AvaloniaUI 11.2.3
- **변환 일시**: 2026-01-01

## 컴포넌트 설명

게임 레벨업 알림 컴포넌트입니다. 반투명 어두운 배경에 빨간색 인셋 그림자 효과가 있으며, 위아래로 움직이는 화살표 애니메이션이 포함되어 있습니다.

## 컴파일 에러 수정 내용

### 1. SDK 오류

**에러 내용**:
```
error MSB4236: 지정된 'Sdk' SDK를 찾을 수 없습니다.
```

**원인**: csproj 파일의 SDK 속성이 잘못 지정됨 (`Sdk="Sdk"`)

**수정 방법**:
```xml
<!-- 수정 전 -->
<Project Sdk="Sdk">

<!-- 수정 후 -->
<Project Sdk="Microsoft.NET.Sdk">
```

---

### 2. CharacterSpacing 속성 오류

**에러 내용**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property CharacterSpacing on type Avalonia.Controls:Avalonia.Controls.TextBlock
```

**원인**: AvaloniaUI에서는 `CharacterSpacing` 대신 `LetterSpacing`을 사용

**수정 방법**:
```xml
<!-- 수정 전 -->
<TextBlock CharacterSpacing="50" />

<!-- 수정 후 -->
<TextBlock LetterSpacing="1" />
```

**참고**: CSS의 `letter-spacing: 1px`은 AvaloniaUI의 `LetterSpacing="1"`로 변환. 값은 em 단위가 아닌 픽셀 기반.

---

### 3. ResourceDictionary 내 Style 오류

**에러 내용**:
```
Avalonia error AVLN3000: Unable to find suitable setter or adder for property Content of type Avalonia.Base:Avalonia.Controls.ResourceDictionary for argument Avalonia.Base:Avalonia.Styling.Style
```

**원인**: ResourceDictionary 내에 Style을 직접 배치할 수 없음

**수정 방법**: ControlTheme 내부에 중첩 Style로 이동
```xml
<!-- 수정 전: ResourceDictionary 직속 자식으로 Style 배치 -->
<ResourceDictionary>
    <ControlTheme>...</ControlTheme>
    <Style Selector="...">...</Style>  <!-- 오류 -->
</ResourceDictionary>

<!-- 수정 후: ControlTheme 내부에 중첩 Style로 배치 -->
<ControlTheme x:Key="{x:Type controls:LevelNotification}" TargetType="controls:LevelNotification">
    <Setter Property="Template">...</Setter>
    <Style Selector="^:loaded /template/ TextBlock#PART_LeftArrow">
        <Style.Animations>...</Style.Animations>
    </Style>
</ControlTheme>
```

---

### 4. StyleInclude vs ResourceInclude 오류

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://FuzzyFly47.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "FuzzyFly47.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: ResourceDictionary 파일을 StyleInclude로 참조할 수 없음

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://FuzzyFly47.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://FuzzyFly47.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## 런타임 에러 가능성 (직접 확인 필요)

### 1. 인셋 그림자 효과 시각적 차이

CSS의 `box-shadow: inset`을 Border의 BorderBrush와 BorderThickness로 시뮬레이션했습니다. 원본과 시각적으로 차이가 있을 수 있습니다.

- CSS: `box-shadow: 2px 2px 0px 1px rgba(255, 0, 0, 0.5) inset`
- AXAML: `Border BorderBrush="#80FF0000" BorderThickness="1,1,0,0"`

### 2. 애니메이션 타이밍 차이

CSS의 `animation: ud 1s ease-in-out infinite`를 AvaloniaUI Animation으로 변환했습니다. easing 함수의 정확한 커브가 다를 수 있습니다.

### 3. 폰트 렌더링 차이

`letter-spacing` 값이 CSS와 AvaloniaUI에서 다르게 해석될 수 있습니다. 원본 CSS는 `letter-spacing: 1px`와 `letter-spacing: 2px`를 사용했으며, AvaloniaUI에서는 `LetterSpacing="1"`과 `LetterSpacing="2"`로 변환했습니다.

### 4. 텍스트 대문자 변환 누락

원본 CSS의 `text-transform: uppercase`는 AvaloniaUI에서 직접 지원되지 않습니다. 필요한 경우 바인딩에서 StringConverter를 사용하거나 데이터 자체를 대문자로 제공해야 합니다.

---

## 생성된 파일 구조

```
FuzzyFly47/AvaloniaUI/
├── FuzzyFly47.Avalonia.slnx
├── FuzzyFly47.Avalonia.Lib/
│   ├── FuzzyFly47.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── LevelNotification.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LevelNotification.axaml
└── FuzzyFly47.Avalonia.Gallery/
    ├── FuzzyFly47.Avalonia.Gallery.csproj
    ├── app.manifest
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
