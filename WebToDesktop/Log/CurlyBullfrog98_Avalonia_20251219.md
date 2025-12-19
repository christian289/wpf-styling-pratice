# CurlyBullfrog98 - AvaloniaUI Conversion Log

## 변환 정보

- **원본**: Uiverse.io by Bodyhc
- **태그**: loading, loader, cube, loading animation, 3d loader
- **변환일**: 2025-12-19
- **대상**: AvaloniaUI 11.2.2 / .NET 9.0

## 원본 CSS 분석

원본은 CSS 3D 변환을 사용한 회전 큐브 로딩 애니메이션입니다:
- `perspective: 1000px` - 3D 원근감
- `transform-style: preserve-3d` - 3D 변환 유지
- `translateZ(100px)` - Z축 이동으로 큐브 면 배치
- `rotateX(360deg) rotateY(360deg)` - X, Y축 동시 회전

## 컴파일 에러 및 수정

### 에러 1: CS0234 - 네임스페이스 참조 오류

**에러 내용**:
```
error CS0234: 'CurlyBullfrog98.Avalonia' 네임스페이스에 'Media' 형식 또는 네임스페이스 이름이 없습니다.
```

**원인**:
프로젝트 네임스페이스가 `CurlyBullfrog98.Avalonia.Lib`이므로 컴파일러가 `Avalonia.Media.IBrush`를 `CurlyBullfrog98.Avalonia.Media.IBrush`로 잘못 해석

**수정 방법**:
```csharp
// Before
public static readonly StyledProperty<Avalonia.Media.IBrush?> CubeBackgroundProperty = ...

// After
using Avalonia.Media;
public static readonly StyledProperty<IBrush?> CubeBackgroundProperty = ...
```

### 에러 2: AVLN2000 - Transform에 x:Name 사용 불가

**에러 내용**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**:
AvaloniaUI에서 `RotateTransform`, `ScaleTransform`, `TranslateTransform` 등 Transform 객체에는 `x:Name` 속성을 사용할 수 없음

**수정 방법**:
Transform에서 x:Name 제거하고, 애니메이션에서 CSS-like transform 문자열 사용:
```xml
<!-- Before -->
<RotateTransform x:Name="PART_RotateTransform" Angle="0"/>

<!-- After -->
<RotateTransform Angle="0"/>

<!-- Animation에서 -->
<Setter Property="RenderTransform" Value="rotate(360deg)"/>
```

### 에러 3: AVLN2000 - StyleInclude vs ResourceInclude

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type, but expected "Avalonia.Styling.IStyle"
```

**원인**:
`StyleInclude`는 `IStyle` 타입만 로드 가능. `ResourceDictionary`는 `ResourceInclude`로 로드해야 함

**수정 방법**:
```xml
<!-- Before -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://.../Generic.axaml"/>
</Application.Styles>

<!-- After -->
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

## Runtime Error 가능성

### 1. 3D 효과 제한 (확인 필요)

**문제**: CSS 3D 변환(perspective, preserve-3d, translateZ)은 AvaloniaUI에서 지원되지 않음

**현재 구현**: 2D 변환(scale, rotate, translate)을 조합하여 유사 효과 시뮬레이션
- 3개의 Border를 다른 스케일과 위치로 배치하여 깊이감 표현
- 회전 애니메이션으로 움직임 효과

**잠재적 문제**:
- 원본 CSS의 진정한 3D 큐브 회전과 시각적 차이 있음
- 실제 실행 시 애니메이션 품질/성능 확인 필요

### 2. RenderTransform 애니메이션 (확인 필요)

**현재 구현**: CSS-like transform 문자열 사용
```xml
<Setter Property="RenderTransform" Value="rotate(360deg)"/>
<Setter Property="RenderTransform" Value="scale(0.85,0.85)"/>
```

**잠재적 문제**:
- 특정 AvaloniaUI 버전에서 transform 문자열 파싱 문제 가능성
- 복합 변환(rotate + scale + translate) 동시 애니메이션 시 성능 이슈 가능성

### 3. Panel.Styles 내부 애니메이션 (확인 필요)

**현재 구현**: ControlTemplate 내부 Panel.Styles에서 애니메이션 정의

**잠재적 문제**:
- 템플릿 내부 스타일 셀렉터가 예상대로 동작하지 않을 가능성
- 컨트롤 로드 시점에 따른 애니메이션 시작 타이밍 문제

## 생성된 파일 구조

```
CurlyBullfrog98/AvaloniaUI/
├── CurlyBullfrog98.Avalonia.slnx
├── CurlyBullfrog98.Avalonia.Lib/
│   ├── CurlyBullfrog98.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── CurlyBullfrog98Control.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── CurlyBullfrog98Control.axaml
└── CurlyBullfrog98.Avalonia.Gallery/
    ├── CurlyBullfrog98.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── Program.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
