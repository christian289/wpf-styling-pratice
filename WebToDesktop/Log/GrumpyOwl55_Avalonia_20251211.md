# GrumpyOwl55 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by vikas7754
- **태그**: simple, clean, pattern
- **변환일**: 2025-12-11
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 원본 CSS 분석

원본 CSS는 복잡한 기하학적 패턴을 구현하며 다음 기능을 사용합니다:

1. **conic-gradient** - AvaloniaUI에서 지원하지 않음
2. **radial-gradient** - 지원하지만 CSS와 동작 방식이 다름
3. **linear-gradient** - 지원
4. **repeating-linear-gradient** - 지원하지 않음
5. **CSS 변수 (--sz, --c0, --c1)** - XAML에서 StaticResource로 대체
6. **calc() 연산** - XAML에서 직접 지원하지 않음

## 변환 전략

AvaloniaUI의 기본 브러시 시스템으로는 원본 CSS 패턴을 완전히 재현할 수 없으므로,
**DrawingContext를 사용한 커스텀 렌더링** 방식으로 구현했습니다.

### 구현 내용

| CSS 기능 | AvaloniaUI 구현 |
|----------|-----------------|
| conic-gradient | 사각형 블록으로 근사 (RenderConicBlocks) |
| radial-gradient 도트 | DrawEllipse 메서드 사용 |
| linear-gradient -45deg | LinearGradientBrush |
| repeating-linear-gradient | FillRectangle 반복 |
| CSS 변수 | StyledProperty로 정의 |

## 컴파일 에러 수정 내역

### 에러 1: StyleInclude vs ResourceInclude

**에러 메시지:**
```
Avalonia error AVLN2000: Resource "avares://GrumpyOwl55.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "GrumpyOwl55.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인:**
- `Application.Styles`에 `StyleInclude`를 사용하여 ResourceDictionary를 포함하려 함
- ResourceDictionary는 IStyle이 아니므로 StyleInclude로 포함할 수 없음

**수정 방법:**
```xml
<!-- 수정 전 (에러) -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://GrumpyOwl55.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 (정상) -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GrumpyOwl55.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 에러

### 1. 패턴 시각적 차이

- **문제**: 원본 CSS의 conic-gradient를 사각형 블록으로 근사하여 구현했으므로,
  원본과 시각적으로 다를 수 있음
- **확인 필요**: 실제 실행하여 패턴의 시각적 품질 확인

### 2. 대형 윈도우에서 성능

- **문제**: 윈도우 크기가 커질수록 타일 렌더링 횟수가 증가
- **확인 필요**: 대형 해상도에서 렌더링 성능 테스트

### 3. 색상 블렌딩

- **문제**: CSS의 투명도 연산(`#fff0`, `#0002`)이 XAML에서 다르게 렌더링될 수 있음
- **확인 필요**: 투명도가 적용된 영역의 색상 확인

## 생성된 파일 목록

```
WebToDesktop/Output/GrumpyOwl55/AvaloniaUI/
├── GrumpyOwl55.Avalonia.slnx
├── GrumpyOwl55.Avalonia.Lib/
│   ├── GrumpyOwl55.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── GrumpyOwl55Pattern.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── GrumpyOwl55Pattern.axaml
└── GrumpyOwl55.Avalonia.Gallery/
    ├── GrumpyOwl55.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 사용 방법

### 빌드

```bash
cd WebToDesktop/Output/GrumpyOwl55/AvaloniaUI
dotnet build GrumpyOwl55.Avalonia.slnx
```

### 실행

```bash
dotnet run --project GrumpyOwl55.Avalonia.Gallery
```

### 다른 프로젝트에서 사용

```xml
<!-- 리소스 딕셔너리 병합 -->
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GrumpyOwl55.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>

<!-- 컨트롤 사용 -->
<controls:GrumpyOwl55Pattern xmlns:controls="using:GrumpyOwl55.Avalonia.Lib.Controls"/>
```

### 커스터마이징

```xml
<controls:GrumpyOwl55Pattern
    PatternSize="20"
    PrimaryColor="#1a1a2e"
    SecondaryColor="#e94560"/>
```

## 참고 사항

- RadialGradientBrush 사용 시 AvaloniaUI Issue #19888 주의 (GradientOrigin과 Center 동일해야 함)
- 본 컨트롤은 RadialGradientBrush 대신 DrawEllipse를 사용하여 해당 이슈 회피
