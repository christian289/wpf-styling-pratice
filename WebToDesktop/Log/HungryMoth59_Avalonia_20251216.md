# HungryMoth59 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본**: Uiverse.io by elijahgummer (ruijadom)
- **컴포넌트 타입**: Dog Loader (애니메이션 로딩 인디케이터)
- **변환일**: 2025-12-16
- **대상 프레임워크**: .NET 9.0 / Avalonia 11.2.2

## 변환 내용

CSS로 구현된 귀여운 강아지 로딩 애니메이션을 AvaloniaUI CustomControl로 변환

### CSS 단위 변환

- 1vmax = 8px 기준으로 변환
- 주요 크기:
  - Main Container: 23.5vmax → 188px
  - Dog: 22.5vmax × 8.25vmax → 180px × 66px

### 구조

- `DogLoader` CustomControl
- Canvas 기반 레이아웃 (CSS absolute positioning 대응)
- Viewbox로 감싸서 크기 조절 가능

## 컴파일 에러 및 수정

### 에러 1: RotateTransform/TranslateTransform에 x:Name 속성 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**: Avalonia에서는 Transform 요소에 `x:Name` 속성을 지원하지 않음

**수정 방법**:
```xml
<!-- 수정 전 -->
<RotateTransform x:Name="LeftEarRotate" Angle="-50" />
<TranslateTransform x:Name="HeadTranslate" Y="0" />

<!-- 수정 후 -->
<RotateTransform Angle="-50" />
<TranslateTransform Y="0" />
```

**수정 파일**: `HungryMoth59.Avalonia.Lib/Themes/DogLoader.axaml` (Line 212, 250, 287, 288)

### 에러 2: ResourceDictionary를 Application.Styles에 포함 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles`에는 `IStyle` 타입만 허용됨. `ResourceDictionary`는 `Application.Resources`에 병합해야 함

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://HungryMoth59.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://HungryMoth59.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**수정 파일**: `HungryMoth59.Avalonia.Gallery/App.axaml`

## 잠재적 런타임 오류

### 1. 복잡한 애니메이션 타이밍

- **위험도**: 중간
- **설명**: CSS의 `cubic-bezier(0.3, 0.41, 0.18, 1.01)` 이징을 Avalonia의 `CubicEaseInOut`으로 대체함. 원본과 약간 다른 느낌일 수 있음
- **확인 필요**: 실행하여 애니메이션 부드러움 확인

### 2. RenderTransformOrigin 동작 차이

- **위험도**: 낮음
- **설명**: CSS의 `transform-origin: bottom right`를 Avalonia의 `RenderTransformOrigin="1,1"`로 변환. 0~1 정규화 좌표 사용
- **확인 필요**: 귀와 머리 회전 중심점이 올바른지 확인

### 3. Canvas ZIndex 동작

- **위험도**: 낮음
- **설명**: CSS의 `z-index`를 Canvas의 `ZIndex` attached property로 변환
- **확인 필요**: 요소들의 겹침 순서가 올바른지 확인

### 4. LinearGradientBrush 방향

- **위험도**: 낮음
- **설명**: CSS `linear-gradient(70deg, ...)`를 Avalonia `LinearGradientBrush`로 변환. CSS와 Avalonia의 각도 계산 방식이 다를 수 있음
- **확인 필요**: 다리 그라데이션이 올바르게 표시되는지 확인

### 5. 눈 애니메이션 TranslateY

- **위험도**: 중간
- **설명**: CSS의 눈 Y축 이동 애니메이션(`transform: translateY`)을 구현하지 않음. Width/Height 애니메이션만 적용됨
- **확인 필요**: 눈 깜빡임 효과가 자연스러운지 확인

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 파일 구조

```
HungryMoth59/AvaloniaUI/
├── HungryMoth59.Avalonia.slnx
├── HungryMoth59.Avalonia.Lib/
│   ├── HungryMoth59.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── DogLoader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── DogLoader.axaml
└── HungryMoth59.Avalonia.Gallery/
    ├── HungryMoth59.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
