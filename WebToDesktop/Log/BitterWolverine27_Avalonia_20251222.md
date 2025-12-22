# BitterWolverine27 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by Quezaquo
- **태그**: simple, tooltip, transition
- **변환일**: 2025-12-22
- **컨트롤명**: HoverTooltip

## 원본 분석

호버 시 팝업 애니메이션과 함께 툴팁이 나타나는 인터랙티브 컴포넌트.

### 주요 CSS 특성

- `cubic-bezier(0.68, -0.55, 0.27, 1.55)` - 탄성 효과가 있는 커스텀 이징
- `goPopup` 애니메이션 - translateY + scaleY 변환
- `bounce` 애니메이션 - 텍스트 바운스 효과
- `::before` pseudo-element - 삼각형 화살표

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary vs IStyle 타입 불일치

**에러 메시지:**
```
AVLN2000: Resource "avares://BitterWolverine27.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the
"BitterWolverine27.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인:**
- `Application.Styles`에 `StyleInclude`로 `ResourceDictionary`를 참조
- AvaloniaUI에서 `Application.Styles`는 `IStyle` 타입만 허용
- `ControlTheme`이 포함된 `ResourceDictionary`는 `Application.Resources`에 병합해야 함

**수정 전:**
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BitterWolverine27.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후:**
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BitterWolverine27.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 런타임 에러 가능성

### 1. 애니메이션 동작 차이

**위험도**: 중간

CSS의 `cubic-bezier(0.68, -0.55, 0.27, 1.55)`를 AvaloniaUI의 `Easing="0.68,-0.55,0.27,1.55"`로 변환했으나,
음수 값이 포함된 베지어 곡선은 AvaloniaUI에서 다르게 렌더링될 수 있음.

**확인 필요:**
- 애니메이션 탄성 효과가 원본과 동일한지 시각적 확인

### 2. TransformGroup 애니메이션

**위험도**: 낮음

CSS에서는 `transform: translateY(-50%) scaleY(1.2)`를 단일 속성으로 애니메이션하지만,
AvaloniaUI에서는 `TransformGroup` 내의 개별 Transform을 애니메이션해야 함.

**확인 필요:**
- ScaleTransform과 TranslateTransform이 동시에 올바르게 적용되는지 확인

### 3. 삼각형 화살표 위치

**위험도**: 낮음

CSS `::before` pseudo-element로 구현된 삼각형을 `Path`로 변환.
원본에서는 `left: 80%`로 위치했으나, AvaloniaUI에서는 `HorizontalAlignment="Right"`와 `Margin`으로 근사.

**확인 필요:**
- 툴팁 너비에 따른 화살표 위치가 적절한지 확인

### 4. Height 애니메이션

**위험도**: 중간

CSS에서 `height: 10px` → `height: 40px` 애니메이션을 AvaloniaUI에서는
Setter로 `Height="40"` 설정만 하고 있어 부드러운 높이 변화가 아닐 수 있음.

**확인 필요:**
- 툴팁 높이가 부드럽게 변하는지 확인
- 필요시 Height에 대한 별도 Animation 추가

## 프로젝트 구조

```
BitterWolverine27/AvaloniaUI/
├── BitterWolverine27.Avalonia.slnx
├── BitterWolverine27.Avalonia.Lib/
│   ├── BitterWolverine27.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── HoverTooltip.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── HoverTooltip.axaml
└── BitterWolverine27.Avalonia.Gallery/
    ├── BitterWolverine27.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **에러**: 0개 (수정 후)
