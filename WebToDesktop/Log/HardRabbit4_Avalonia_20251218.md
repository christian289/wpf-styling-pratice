# HardRabbit4 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by escannord
- **태그**: simple, black, pattern
- **변환일**: 2025-12-18
- **대상 프레임워크**: .NET 9.0, Avalonia 11.2.2

## 프로젝트 구조

```
HardRabbit4/AvaloniaUI/
├── HardRabbit4.Avalonia.slnx
├── HardRabbit4.Avalonia.Lib/
│   ├── Controls/
│   │   └── DotPatternBackground.cs    # 커스텀 컨트롤
│   └── Themes/
│       ├── Generic.axaml              # ResourceDictionary 병합
│       └── DotPatternBackground.axaml # 컨트롤 스타일
└── HardRabbit4.Avalonia.Gallery/
    ├── App.axaml                      # 앱 설정
    ├── App.axaml.cs
    ├── MainWindow.axaml               # 데모 UI
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컨트롤 설명

### DotPatternBackground

점 패턴 배경을 가진 컨테이너 컨트롤입니다. CSS의 `radial-gradient` + `background-size` 조합으로 타일링되는 점 패턴을 렌더링합니다.

#### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| BackgroundColor | Color | #E61D1F20 | 배경색 (rgba(29, 31, 32, 0.904)) |
| DotColor | Color | #B5FFFFFF | 점 색상 (rgba(255, 255, 255, 0.712)) |
| DotSize | double | 11.0 | 점 패턴 셀 크기 (px) |
| DotRadiusRatio | double | 0.10 | 점 반지름 비율 (셀 크기의 10%) |

## 컴파일 에러 및 수정 내용

### 에러 1: AVLN2000 - ResourceDictionary 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://HardRabbit4.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "HardRabbit4.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary` 타입의 리소스를 포함하려 했음
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 허용함
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 포함해야 함

**수정 방법**:
```xml
<!-- 수정 전 (오류) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://HardRabbit4.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 (정상) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://HardRabbit4.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 가능성

### 1. 렌더링 성능 이슈 (확인 필요)

**위치**: `DotPatternBackground.cs` - `Render()` 메서드

**내용**:
- 현재 구현은 `Render()` 메서드에서 매 프레임마다 점 패턴을 직접 그립니다
- 큰 화면이나 작은 `DotSize`의 경우 많은 수의 점을 그려야 하므로 성능 저하 가능

**권장 확인 사항**:
- 1920x1080 이상의 해상도에서 테스트
- 창 크기 변경 시 부드러운 렌더링 확인

### 2. CSS 원본과의 시각적 차이 (확인 필요)

**내용**:
- CSS 원본은 `radial-gradient`를 사용하여 점 가장자리가 부드럽게 페이드
- AvaloniaUI 구현은 `DrawEllipse`로 단색 원을 그림
- 시각적으로 약간 다를 수 있음

**대안 (필요 시)**:
- `RadialGradientBrush`를 사용한 점 그리기로 변경 가능
- 단, 성능이 더 저하될 수 있음

## 빌드 명령

```bash
cd WebToDesktop/Output/HardRabbit4/AvaloniaUI
dotnet build HardRabbit4.Avalonia.slnx
dotnet run --project HardRabbit4.Avalonia.Gallery
```
