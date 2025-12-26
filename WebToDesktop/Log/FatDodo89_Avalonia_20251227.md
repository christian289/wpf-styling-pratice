# FatDodo89 AvaloniaUI 변환 로그

**날짜**: 2025-12-27
**원본 소스**: uiverse.io by fanishah
**컨트롤**: 눈과 입이 있는 이모티콘 스타일 로딩 스피너

---

## 변환 개요

HTML/CSS의 SVG 기반 로딩 애니메이션을 AvaloniaUI CustomControl로 변환했습니다.

### 원본 특징
- SVG clipPath와 mask를 사용한 두 레이어 색상 분리 (청록색/파란색)
- 복잡한 stroke-dasharray 애니메이션
- CSS @keyframes 기반 눈과 입 애니메이션
- transform-origin을 사용한 회전 애니메이션

### AvaloniaUI 변환
- Canvas와 Ellipse/Path를 사용한 레이아웃
- LinearGradientBrush의 OpacityMask로 레이어 분리 구현
- Style.Animations를 사용한 KeyFrame 애니메이션

---

## 컴파일 에러 및 수정

### 에러 1: RotateTransform에 x:Name 속성 불가
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name
on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**: AvaloniaUI에서 `RotateTransform`에 `x:Name` 속성을 직접 지정할 수 없음

**수정 방법**: `x:Name` 속성 제거
```xml
<!-- 변경 전 -->
<RotateTransform x:Name="TopEye1Rotate" />

<!-- 변경 후 -->
<RotateTransform />
```

---

### 에러 2: StrokeDashArray 형식 오류
```
Avalonia error AVLN1000: The input string '2.98 5.96' was not in a correct format.
```

**원인**: AvaloniaUI의 StrokeDashArray는 공백이 아닌 쉼표로 값을 구분해야 함

**수정 방법**: 공백을 쉼표로 변경
```xml
<!-- 변경 전 -->
StrokeDashArray="2.98 5.96"

<!-- 변경 후 -->
StrokeDashArray="2.98,5.96"
```

---

### 에러 3: StyleInclude로 ResourceDictionary 로드 불가
```
Avalonia error AVLN2000: Resource "avares://..." is defined as
"Avalonia.Controls.ResourceDictionary" type but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에서 `StyleInclude`는 `IStyle`을 기대하지만, `Generic.axaml`은 `ResourceDictionary`임

**수정 방법**: `Application.Resources`에 `ResourceInclude`로 변경
```xml
<!-- 변경 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://...Generic.axaml" />
</Application.Styles>

<!-- 변경 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://...Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## 잠재적 런타임 오류 (확인 필요)

### 1. 애니메이션 타이밍 차이
- **설명**: CSS의 `cubic-bezier(0.17, 0, 0.58, 1)`와 AvaloniaUI의 `CubicEaseInOut`은 동작이 다를 수 있음
- **영향**: 애니메이션 곡선이 원본과 약간 다를 수 있음
- **권장**: 런타임에서 애니메이션 확인 후 Easing 조정

### 2. OpacityMask 렌더링
- **설명**: CSS mask와 AvaloniaUI OpacityMask의 동작 차이
- **영향**: 두 레이어 색상 블렌딩이 원본과 다를 수 있음
- **권장**: 런타임에서 시각적 확인 필요

### 3. StrokeDashOffset 애니메이션
- **설명**: CSS stroke-dashoffset 값(-175.93, -351.86)을 단순화된 값(-3, -6)으로 변환
- **영향**: 입 애니메이션의 열리고 닫히는 효과가 원본과 다를 수 있음
- **권장**: 런타임에서 확인 후 값 조정

### 4. RenderTransformOrigin
- **설명**: CSS `transform-origin: 64px 64px`를 AvaloniaUI `RenderTransformOrigin="0.5,0.5"`로 변환
- **영향**: 요소 크기에 따라 회전 중심이 다를 수 있음
- **권장**: Canvas 좌표계와 함께 확인 필요

---

## 생성된 파일

```
FatDodo89.Avalonia.slnx
FatDodo89.Avalonia.Lib/
├── Controls/
│   └── FatDodo89Loader.cs
├── Themes/
│   ├── Generic.axaml
│   └── FatDodo89Loader.axaml
└── FatDodo89.Avalonia.Lib.csproj

FatDodo89.Avalonia.Gallery/
├── App.axaml
├── App.axaml.cs
├── MainWindow.axaml
├── MainWindow.axaml.cs
├── Program.cs
└── FatDodo89.Avalonia.Gallery.csproj
```

---

## 빌드 결과

**상태**: 성공
**경고**: 0개
**에러**: 0개
