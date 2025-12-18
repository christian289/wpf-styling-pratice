# FoolishBulldog87 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by elijahgummer (checkbox)
- **변환 일자**: 2025-12-19
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 컨트롤 설명

SVG 체크마크 애니메이션이 있는 커스텀 체크박스 컨트롤입니다.
- 클릭 시 체크마크가 애니메이션과 함께 나타남
- 호버 시 배경색 변경
- crimson (#DC143C) 테마 색상 사용

## 컴파일 에러 및 수정

### 에러 1: StrokeLineJoin 속성 미지원

**에러 내용**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property StrokeLineJoin on type Avalonia.Controls:Avalonia.Controls.Shapes.Path
```

**원인**: AvaloniaUI의 Path 컨트롤에서 `StrokeLineJoin` 속성을 직접 지원하지 않음

**수정 방법**: `StrokeLineJoin="Round"` 속성 제거

**수정 전**:
```xml
<Path x:Name="PART_Checkmark"
      Stroke="{StaticResource FoolishBulldog87.CheckBox.CheckmarkBrush}"
      StrokeThickness="3"
      StrokeLineCap="Round"
      StrokeLineJoin="Round"
      ...
```

**수정 후**:
```xml
<Path x:Name="PART_Checkmark"
      Stroke="{StaticResource FoolishBulldog87.CheckBox.CheckmarkBrush}"
      StrokeThickness="3"
      StrokeLineCap="Round"
      ...
```

---

### 에러 2: StyleInclude로 ResourceDictionary 로드 불가

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://FoolishBulldog87.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "FoolishBulldog87.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: `StyleInclude`는 IStyle 타입만 로드 가능. ResourceDictionary는 `ResourceInclude`를 사용해야 함

**수정 방법**: `Application.Styles`에서 `Application.Resources`로 이동하고 `ResourceInclude` 사용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://FoolishBulldog87.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://FoolishBulldog87.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. StrokeDashArray/StrokeDashOffset 애니메이션

CSS의 `stroke-dasharray: 25; stroke-dashoffset: 25;`를 AvaloniaUI의 `StrokeDashArray="4,4"` 및 `StrokeDashOffset` 애니메이션으로 변환했습니다.

- CSS에서는 dasharray가 25이고 offset을 0으로 변경하여 체크마크가 그려지는 효과
- AvaloniaUI에서는 Path의 Data 길이에 맞게 DashArray 값을 조정해야 할 수 있음
- 실제 실행 시 애니메이션 효과가 원본과 다를 수 있음

### 2. Path Data 좌표계

원본 SVG `points="20 6 9 17 4 12"`를 `M 20,6 L 9,17 L 4,12`로 변환했습니다.
- 28x28 크기의 Border 내에서 Path가 Center 정렬되어 있음
- 체크마크의 위치나 크기가 예상과 다를 수 있음

## 프로젝트 구조

```
FoolishBulldog87/AvaloniaUI/
├── FoolishBulldog87.Avalonia.slnx
├── FoolishBulldog87.Avalonia.Lib/
│   ├── FoolishBulldog87.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── FoolishBulldog87CheckBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── FoolishBulldog87CheckBox.axaml
└── FoolishBulldog87.Avalonia.Gallery/
    ├── FoolishBulldog87.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── Program.cs
    └── app.manifest
```

## 빌드 결과

- **최종 빌드**: 성공
- **경고**: 0개
- **오류**: 0개
