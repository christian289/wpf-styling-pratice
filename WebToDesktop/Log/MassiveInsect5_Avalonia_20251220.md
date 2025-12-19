# MassiveInsect5 - AvaloniaUI 변환 로그

## 변환 정보

- **변환 일시**: 2025-12-20
- **소스**: MassiveInsect5.html / MassiveInsect5.css
- **대상**: AvaloniaUI Custom Control
- **원본 출처**: Uiverse.io by Smit-Prajapati

## 프로젝트 구조

```
MassiveInsect5/AvaloniaUI/
├── MassiveInsect5.Avalonia.slnx
├── MassiveInsect5.Avalonia.Lib/
│   ├── Controls/
│   │   └── MassiveInsect5Card.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── MassiveInsect5Card.axaml
└── MassiveInsect5.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내용

### 에러 1: Transform 객체에 x:Name 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
```

**원인**: AvaloniaUI에서는 `ScaleTransform`, `TranslateTransform` 등 Transform 객체에 `x:Name` 속성을 사용할 수 없음

**수정 방법**: Transform 객체에서 `x:Name` 속성 제거
```xml
<!-- 수정 전 -->
<ScaleTransform x:Name="RootScaleTransform" ScaleX="1" ScaleY="1"/>
<TranslateTransform x:Name="Box1TranslateTransform" X="-140" Y="140"/>

<!-- 수정 후 -->
<ScaleTransform ScaleX="1" ScaleY="1"/>
<TranslateTransform X="-140" Y="140"/>
```

### 에러 2: STAThread 네임스페이스 누락

**에러 메시지**:
```
error CS0246: 'STAThreadAttribute' 형식 또는 네임스페이스 이름을 찾을 수 없습니다.
```

**원인**: `STAThread` 특성은 `System` 네임스페이스에 있으나 using 문이 없었음

**수정 방법**: `using System;` 추가
```csharp
using System;
using Avalonia;
```

### 에러 3: ResourceDictionary를 Styles에 포함

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type but expected "Avalonia.Styling.IStyle"
```

**원인**: AvaloniaUI에서 `ResourceDictionary`는 `Application.Styles`가 아닌 `Application.Resources`에 포함해야 함

**수정 방법**: App.axaml에서 리소스 포함 방식 변경
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://..."/>
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://..."/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## RadialGradientBrush 변환 주의사항

CSS의 `radial-gradient` 변환 시 AvaloniaUI Issue #19888에 따라 `GradientOrigin`과 `Center` 값을 동일하게 설정함.

```css
/* CSS 원본 */
background: radial-gradient(circle at 100% 107%, #ff89cc 0%, ...);
```

```xml
<!-- AvaloniaUI 변환 -->
<RadialGradientBrush GradientOrigin="100%,107%" Center="100%,107%" RadiusX="1" RadiusY="1">
    <GradientStop Color="#FF89CC" Offset="0"/>
    ...
</RadialGradientBrush>
```

## 잠재적 Runtime Error 가능성

### 1. 애니메이션 동작 차이

CSS의 `transition` 속성과 AvaloniaUI의 `Animation`은 동작 방식이 다름:
- CSS: 상태 변경 시 자동으로 transition 적용
- AvaloniaUI: 명시적으로 Animation을 정의해야 함

**주의**: 호버 상태 해제 시 역방향 애니메이션이 자연스럽게 동작하지 않을 수 있음

### 2. Box Hover Overlay 선택자

중첩된 `:pointerover` 선택자가 예상대로 동작하지 않을 수 있음:
```xml
<Style Selector="^:pointerover /template/ Border#PART_Box1:pointerover /template/ Border#PART_Box1Overlay">
```
- Box 위에 마우스를 올렸을 때 Overlay가 표시되어야 하지만, 복잡한 선택자 구조로 인해 동작하지 않을 수 있음

### 3. Canvas 내부 Path 위치

Logo Canvas 내부의 Path 요소들이 원본 SVG와 동일한 위치에 렌더링되는지 확인 필요

### 4. BoxShadow 렌더링

AvaloniaUI의 `BoxShadow`가 CSS의 `box-shadow`와 완전히 동일하게 렌더링되지 않을 수 있음

## 빌드 결과

- **상태**: 성공 (경고 0개, 오류 0개)
- **빌드 명령어**: `dotnet build MassiveInsect5.Avalonia.slnx`
