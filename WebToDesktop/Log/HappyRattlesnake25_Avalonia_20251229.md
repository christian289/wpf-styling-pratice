# HappyRattlesnake25 AvaloniaUI 변환 로그

## 변환 정보
- **날짜**: 2025-12-29
- **원본**: uiverse.io (csemszepp / Afif13)
- **유형**: Material Design Geometric Pattern (Patterns)
- **프레임워크**: AvaloniaUI 11.2.2

## 원본 CSS 분석

### 핵심 특징
- `conic-gradient`를 사용한 기하학적 패턴 배경
- 3색 컬러 스킴: `--c1` (밝은 회색), `--c2` (청록색), `--c3` (민트색)
- 타일 기반 반복 패턴 (`background-size: calc(2 * var(--s)) var(--s)`)

### CSS 변수
```css
--s: 65px;      /* 패턴 크기 */
--c1: #dadee1;  /* 밝은 회색 */
--c2: #4a99b4;  /* 청록색 */
--c3: #9cceb5;  /* 민트색 */
```

## 변환 전략

### conic-gradient 대체
AvaloniaUI에서는 `conic-gradient`를 직접 지원하지 않습니다. 따라서 커스텀 렌더링 방식으로 구현했습니다:

1. **Control 상속**: `Control` 클래스를 상속하여 `Render` 메서드 오버라이드
2. **StreamGeometry 사용**: 삼각형과 마름모 도형을 직접 그려 패턴 생성
3. **타일 반복**: 화면 크기에 맞게 타일을 반복 배치

## 컴파일 에러 및 수정

### 에러 1: Style을 ResourceDictionary에 직접 배치

**에러 메시지**:
```
AVLN3000: Unable to find suitable setter or adder for property Content of type
Avalonia.Base:Avalonia.Controls.ResourceDictionary for argument Avalonia.Base:Avalonia.Styling.Style
```

**원인**:
AvaloniaUI에서 `Style`은 `ResourceDictionary` 내부에 직접 배치할 수 없습니다. WPF와 달리 AvaloniaUI는 스타일과 리소스를 분리합니다.

**수정 방법**:
- `ResourceDictionary` 대신 `Styles` 루트 요소 사용
- 리소스는 `Styles.Resources` 내부에 정의
- 스타일은 `Styles` 하위에 직접 정의

**수정 전**:
```xml
<ResourceDictionary>
    <Color x:Key="...">...</Color>
    <Style Selector="...">...</Style>
</ResourceDictionary>
```

**수정 후**:
```xml
<Styles>
    <Styles.Resources>
        <Color x:Key="...">...</Color>
    </Styles.Resources>
    <Style Selector="...">...</Style>
</Styles>
```

### Generic.axaml 수정
동일한 이유로 `ResourceDictionary.MergedDictionaries` 대신 `StyleInclude` 사용:

**수정 전**:
```xml
<ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..." />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

**수정 후**:
```xml
<Styles>
    <StyleInclude Source="..." />
</Styles>
```

## 잠재적 런타임 에러 (확인 필요)

### 1. 패턴 렌더링 성능
- **위험도**: 중간
- **설명**: 화면 크기가 큰 경우 많은 수의 도형을 그리므로 렌더링 성능 저하 가능
- **권장 조치**: 필요 시 `DrawingBrush`를 사용한 타일링 방식으로 최적화

### 2. 패턴 시각적 차이
- **위험도**: 낮음
- **설명**: 원본 CSS의 `conic-gradient` 효과와 정확히 일치하지 않을 수 있음
- **권장 조치**: 시각적 확인 후 도형 좌표 미세 조정

### 3. 윈도우 크기 변경 시 깜빡임
- **위험도**: 낮음
- **설명**: `AffectsRender`가 설정되어 있지만 빠른 크기 변경 시 깜빡임 가능
- **권장 조치**: 필요 시 `RenderOptions.BitmapScalingMode` 설정

## 생성된 파일 구조

```
HappyRattlesnake25/AvaloniaUI/
├── HappyRattlesnake25.Avalonia.slnx
├── HappyRattlesnake25.Avalonia.Lib/
│   ├── HappyRattlesnake25.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── HappyRattlesnake25.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── HappyRattlesnake25.axaml
└── HappyRattlesnake25.Avalonia.Gallery/
    ├── HappyRattlesnake25.Avalonia.Gallery.csproj
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

## 사용 방법

```xml
<Window xmlns:controls="using:HappyRattlesnake25.Avalonia.Lib.Controls">
    <controls:HappyRattlesnake25 />
</Window>
```

### 속성 커스터마이징
```xml
<controls:HappyRattlesnake25
    PatternSize="80"
    Color1="#e0e0e0"
    Color2="#3498db"
    Color3="#2ecc71" />
```
