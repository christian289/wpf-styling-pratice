# CurvyEarwig22 - AvaloniaUI 변환 로그

## 변환 정보
- **날짜**: 2025-12-20
- **원본**: uiverse.io by Lakshay-art (input 태그)
- **설명**: 네온 빛나는 검색 박스 (Neon Glowing Search Box)

## 원본 HTML/CSS 분석

### 주요 특징
1. **conic-gradient 배경**: 여러 레이어에서 원형 그라데이션 효과
2. **회전 애니메이션**: hover/focus 시 테두리 회전
3. **Blur 효과**: 여러 레이어에 blur 필터 적용
4. **pseudo-element (::before)**: 대형 요소를 통한 효과 구현

### CSS에서 AvaloniaUI로 변환 어려움
- **conic-gradient**: AvaloniaUI에서 미지원 (Avalonia 12.0+ 예정)
  - 대안: LinearGradientBrush 여러 개와 회전 변환 조합
- **::before/::after pseudo-element**: Panel 내 추가 Border로 대체

## 컴파일 에러 및 수정 사항

### 에러 1: RotateTransform x:Name 속성 사용 불가
- **에러 메시지**: `Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform`
- **원인**: ControlTemplate 내부에서 RotateTransform에 x:Name을 지정할 수 없음
- **수정 방법**: `x:Name="FilterBorderRotation"` 속성 제거

```xml
<!-- 수정 전 -->
<RotateTransform x:Name="FilterBorderRotation" Angle="0" />

<!-- 수정 후 -->
<RotateTransform Angle="0" />
```

### 에러 2: StrokeLineJoin 속성명 오류
- **에러 메시지**: `Unable to resolve suitable regular or attached property StrokeLineJoin on type Avalonia.Controls:Avalonia.Controls.Shapes.Path`
- **원인**: AvaloniaUI에서는 `StrokeLineJoin` 대신 `StrokeJoin` 사용
- **수정 방법**: 속성명 변경

```xml
<!-- 수정 전 -->
<Path StrokeLineJoin="Round" ... />

<!-- 수정 후 -->
<Path StrokeJoin="Round" ... />
```

### 에러 3: ResourceDictionary를 StyleInclude로 로드 시도
- **에러 메시지**: `Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type in the assembly, but expected "Avalonia.Styling.IStyle"`
- **원인**: ResourceDictionary는 Application.Styles가 아닌 Application.Resources에서 MergedDictionaries로 로드해야 함
- **수정 방법**: App.axaml 구조 변경

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://CurvyEarwig22.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://CurvyEarwig22.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 런타임 잠재적 오류

### 1. conic-gradient 효과 부재
- **문제**: 원본 CSS의 `conic-gradient`는 AvaloniaUI에서 지원하지 않음
- **현재 대안**: LinearGradientBrush와 RotateTransform 조합으로 유사 효과 구현
- **영향**: 시각적 효과가 원본과 다를 수 있음
- **권장**: Avalonia 12.0+ 업그레이드 시 ConicGradientBrush로 변경

### 2. Blur 효과 성능
- **문제**: 여러 레이어에 BlurEffect 적용으로 렌더링 성능 저하 가능
- **영향**: 저사양 기기에서 프레임 드롭 발생 가능
- **권장**: 필요시 Blur 효과 간소화 또는 정적 이미지로 대체

### 3. 회전 애니메이션
- **문제**: Border 내부 자식 요소 전체가 아닌 Border 자체가 회전
- **영향**: 원본 CSS의 ::before 요소 회전 효과와 다를 수 있음
- **권장**: 실행 후 시각적 확인 필요

### 4. TextBox 템플릿 호환성
- **문제**: NeonSearchBox 내 TextBox는 기본 FluentTheme 스타일 사용
- **영향**: Watermark, 포커스 상태 등 스타일이 컨트롤과 조화롭지 않을 수 있음
- **권장**: 필요시 TextBox용 커스텀 ControlTheme 적용

## 프로젝트 구조

```
CurvyEarwig22/AvaloniaUI/
├── CurvyEarwig22.Avalonia.slnx
├── CurvyEarwig22.Avalonia.Lib/
│   ├── CurvyEarwig22.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── NeonSearchBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── NeonSearchBox.axaml
└── CurvyEarwig22.Avalonia.Gallery/
    ├── CurvyEarwig22.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과
- **상태**: 성공
- **경고**: 0
- **오류**: 0

## 사용법

```bash
cd WebToDesktop/Output/CurvyEarwig22/AvaloniaUI
dotnet build CurvyEarwig22.Avalonia.slnx
dotnet run --project CurvyEarwig22.Avalonia.Gallery
```
