# SpottyZebra83 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by gharsh11032000
- **변환 날짜**: 2026-01-03
- **컨트롤명**: TooltipButton
- **설명**: 호버 시 툴팁과 배경 슬라이드 애니메이션이 있는 버튼 컨트롤

## 프로젝트 구조

```
SpottyZebra83/AvaloniaUI/
├── SpottyZebra83.Avalonia.slnx
├── SpottyZebra83.Avalonia.Lib/
│   ├── Controls/
│   │   └── TooltipButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TooltipButton.axaml
└── SpottyZebra83.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary를 StyleInclude로 참조

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://SpottyZebra83.Avalonia.Lib/Themes/Generic.axaml" 
is defined as "Avalonia.Controls.ResourceDictionary" type in the "SpottyZebra83.Avalonia.Lib" 
assembly, but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인**:
- AvaloniaUI에서 `StyleInclude`는 `IStyle`을 구현한 리소스만 참조 가능
- `ResourceDictionary`는 `IStyle`이 아니므로 `StyleInclude`로 참조 불가

**수정 방법**:
App.axaml에서 `StyleInclude`를 `ResourceInclude`로 변경하고 `Application.Resources` 섹션에 배치

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SpottyZebra83.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://SpottyZebra83.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 키프레임 내 복합 Transform 문제

TooltipButton.axaml의 `Style.Animations` 섹션에서 `ScaleTransform.ScaleX` 형태로 속성을 지정하고 있음.
AvaloniaUI 버전에 따라 Animation KeyFrame에서 복합 속성 경로가 작동하지 않을 수 있음.

**영향 범위**: 호버 시 Scale 애니메이션이 동작하지 않을 수 있음

**확인 필요**: 런타임에서 호버 애니메이션 테스트 필요

### 2. TextTransform 속성

TextBlock의 `TextTransform="Uppercase"` 속성이 AvaloniaUI에서 지원되지 않을 수 있음.
AvaloniaUI 11.x에서는 TextBlock에 TextTransform 속성이 없을 수 있음.

**대안**: 대문자 텍스트가 필요한 경우 바인딩 컨버터 또는 코드에서 직접 변환 필요

### 3. BoxShadow 형식 호환성

CSS의 `box-shadow: rgba(0, 0, 0, 0.25) 0 8px 15px` 형식과 
AvaloniaUI의 `BoxShadow="0 8 15 #40000000"` 형식 간 차이

**확인 필요**: 그림자 효과가 의도대로 표시되는지 런타임 확인 필요

## CSS to AXAML 변환 매핑

| CSS | AvaloniaUI |
|-----|------------|
| `transition: all 0.4s cubic-bezier(...)` | `<Transitions>` + `<Animation>` |
| `:hover` | `:pointerover` |
| `transform: scale(0)` | `<ScaleTransform ScaleX="0" ScaleY="0" />` |
| `box-shadow` | `BoxShadow` |
| `border-radius` | `CornerRadius` |
| `place-items: center` | `HorizontalAlignment="Center" VerticalAlignment="Center"` |
| `text-transform: uppercase` | (미지원 - 직접 대문자로 작성 또는 컨버터 사용) |

## 빌드 결과

- **빌드 성공**: Yes
- **경고**: 0개
- **오류**: 0개 (수정 후)
