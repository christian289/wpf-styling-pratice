# PinkCheetah76 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by SiddhantEngineer (button)
- **변환일**: 2025-12-21
- **대상 프레임워크**: AvaloniaUI 11.2.2, .NET 9.0

## 원본 CSS 분석

```css
.button {
  --button-accent: rgb(255, 0, 0);
  background: var(--button-accent);
  box-shadow: 0px 5px 0px 0px color-mix(in oklab, var(--button-accent) 80%, black),
    0px 5px 0px 5px black;
  border-radius: 10px;
  font-size: 24px;
  font-weight: 900;
  color: white;
  transition: all 0.1s ease-in-out;
}
.button:active {
  box-shadow: 0px 0px 0px 0px ...;
  transform: translateY(5px);
}
```

## 변환 전략

### 3D 버튼 효과 구현

CSS의 `box-shadow`를 중첩된 `Border` 요소로 구현:
1. **외부 Border**: 검정색 배경으로 5px spread 효과
2. **중간 Border**: 어두운 빨간색 그림자 역할 (Padding으로 5px offset 효과)
3. **내부 Border**: 실제 버튼 배경

### Pressed 상태

- 중간 Border의 Padding을 0으로 설정하여 그림자 제거 효과
- `RenderTransform="translateY(5px)"`로 아래로 이동

## 컴파일 에러 및 수정

### 에러 1: CS0234 - 네임스페이스 충돌

**에러 내용**:
```
'PinkCheetah76.Avalonia' 네임스페이스에 'Media' 형식 또는 네임스페이스 이름이 없습니다.
```

**원인**:
프로젝트 네임스페이스 `PinkCheetah76.Avalonia.Lib`가 `Avalonia`로 시작하여 `Avalonia.Media`와 충돌

**수정 방법**:
```csharp
// 변경 전: 정규화된 타입명 사용 시도
public static readonly StyledProperty<Avalonia.Media.IBrush?> AccentBrushProperty = ...

// 변경 후: using 문 추가 및 단순 타입명 사용
using Avalonia.Media;
public static readonly StyledProperty<IBrush?> AccentBrushProperty = ...
```

### 에러 2: AVLN3000 - TemplateBinding 범위 오류

**에러 내용**:
```
Unable to find the ControlTemplate scope for AvaloniaProperty lookup Line 33, position 39.
```

**원인**:
ControlTheme의 Setter에서 `TemplateBinding`을 사용했으나, TemplateBinding은 ControlTemplate 내부에서만 유효함

**수정 방법**:
```xml
<!-- 변경 전: Setter에서 TemplateBinding 사용 (불가) -->
<Setter Property="Background" Value="{TemplateBinding AccentBrush}"/>

<!-- 변경 후: Setter 제거하고 ControlTemplate 내부에서 직접 바인딩 -->
<ControlTemplate TargetType="controls:PressButton">
    <Border Background="{TemplateBinding AccentBrush}">
        ...
    </Border>
</ControlTemplate>
```

### 에러 3: AVLN2000 - 리소스 타입 불일치

**에러 내용**:
```
Resource "avares://...Generic.axaml" is defined as "ResourceDictionary" type, but expected "IStyle".
```

**원인**:
`Application.Styles`에서 `StyleInclude`는 `IStyle`을 기대하는데, ControlTheme을 포함한 ResourceDictionary가 제공됨

**수정 방법**:
```xml
<!-- 변경 전: Styles에 직접 포함 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://.../Generic.axaml"/>
</Application.Styles>

<!-- 변경 후: Resources에서 병합 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://.../Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. CSS `color-mix` 미지원

**설명**: CSS의 `color-mix(in oklab, var(--button-accent) 80%, black)` 함수는 AvaloniaUI에서 직접 지원하지 않음

**현재 구현**: `ShadowBrush` 속성으로 하드코딩된 어두운 색상 (#CC0000) 사용

**확인 필요**: 사용자가 AccentBrush를 변경할 때 ShadowBrush도 수동으로 설정해야 함

### 2. text-shadow 미구현

**설명**: CSS의 `text-shadow: 0px 0px 1px black` 효과는 현재 구현되지 않음

**영향**: 텍스트 가독성이 원본보다 낮을 수 있음

### 3. 전환 애니메이션 차이

**설명**: CSS의 `transition: all 0.1s ease-in-out`이 `TransformOperationsTransition`으로만 구현됨

**영향**: Padding 변경 시 애니메이션이 적용되지 않음

## 생성된 파일

```
PinkCheetah76.Avalonia.slnx
├── PinkCheetah76.Avalonia.Lib/
│   ├── Controls/
│   │   └── PressButton.cs
│   ├── Themes/
│   │   ├── Generic.axaml
│   │   └── PressButton.axaml
│   └── PinkCheetah76.Avalonia.Lib.csproj
└── PinkCheetah76.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    ├── Program.cs
    ├── app.manifest
    └── PinkCheetah76.Avalonia.Gallery.csproj
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
