# WhiteKangaroo0 AvaloniaUI 변환 로그

## 원본 정보
- **출처**: Uiverse.io by Shoh2008
- **태그**: loader
- **변환일**: 2026-01-02

## 변환 내용

### CSS 구조 분석
원본 CSS는 복잡한 multiple `background-image`와 `radial-gradient`를 사용하여 기어(gear) 형태의 로딩 애니메이션을 구현합니다:
- 메인 구조: 3개의 원과 1개의 막대로 구성된 배경
- `::before` 가상 요소: 큰 기어 (36x36px, 3초 회전)
- `::after` 가상 요소: 작은 기어 (24x24px, 4초 역회전)

### AvaloniaUI 변환 전략
CSS의 multiple `background-image`는 AvaloniaUI에서 직접 지원하지 않으므로:
1. 각 radial-gradient 원을 개별 `Ellipse`로 변환
2. `Panel`을 사용하여 요소 중첩
3. CSS animation을 AvaloniaUI `Animation`으로 변환

## 컴파일 에러 및 수정

### 에러 1: 네임스페이스 충돌 (CS0234)
```
error CS0234: 'WhiteKangaroo0.Avalonia' 네임스페이스에 'Media' 형식 또는 네임스페이스 이름이 없습니다.
```

**원인**: 프로젝트 네임스페이스 `WhiteKangaroo0.Avalonia.Lib`가 `Avalonia` 네임스페이스와 충돌

**수정 방법**:
- `Avalonia.Media.IBrush?` 대신 `using Avalonia.Media;`를 추가하고 `IBrush?`로 사용
- 전역 네임스페이스 참조를 직접 사용하지 않고 using 문으로 해결

**수정 전**:
```csharp
public static readonly StyledProperty<Avalonia.Media.IBrush?> LargeGearBrushProperty = ...
```

**수정 후**:
```csharp
using Avalonia.Media;
...
public static readonly StyledProperty<IBrush?> LargeGearBrushProperty = ...
```

### 에러 2: ResourceDictionary vs IStyle 타입 불일치 (AVLN2000)
```
error AVLN2000: Resource "avares://WhiteKangaroo0.Avalonia.Lib/Themes/Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type in the "WhiteKangaroo0.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**: ControlTheme을 포함한 ResourceDictionary를 `StyleInclude`로 포함하려고 함

**수정 방법**: `Application.Styles`의 `StyleInclude` 대신 `Application.Resources`의 `ResourceInclude` 사용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://WhiteKangaroo0.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://WhiteKangaroo0.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. 애니메이션 RenderTransform 설정
AXAML에서 `RenderTransform="rotate(0deg)"` 형식의 문자열 설정이 런타임에 올바르게 파싱되지 않을 수 있습니다.

**권장 확인사항**:
- 실행 후 기어가 회전하는지 확인
- 회전하지 않을 경우 Animation의 KeyFrame에서 `RotateTransform` 객체를 직접 생성하도록 수정 필요

### 2. 기어 위치 오프셋
CSS의 `bottom` 속성을 AvaloniaUI의 `Margin`으로 변환했으며, 정확한 위치가 원본과 다를 수 있습니다.

**권장 확인사항**:
- 실행 후 기어 위치가 원본 CSS와 동일한지 시각적으로 비교
- 필요시 Margin 값 미세 조정

### 3. 애니메이션 타이밍
CSS `animation: rotationBack 3s linear infinite reverse`의 `reverse` 방향을 AvaloniaUI `PlaybackDirection="Reverse"`로 변환했으나, 동작이 다를 수 있습니다.

**권장 확인사항**:
- 작은 기어가 큰 기어와 반대 방향으로 회전하는지 확인

## 최종 빌드 결과
```
빌드했습니다.
    경고 0개
    오류 0개
```

## 파일 구조
```
WhiteKangaroo0/AvaloniaUI/
├── WhiteKangaroo0.Avalonia.slnx
├── WhiteKangaroo0.Avalonia.Lib/
│   ├── WhiteKangaroo0.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── GearLoader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── GearLoader.axaml
└── WhiteKangaroo0.Avalonia.Gallery/
    ├── WhiteKangaroo0.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```
