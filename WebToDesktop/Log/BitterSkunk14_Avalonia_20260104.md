# BitterSkunk14 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: HTML/CSS (uiverse.io by MohamedAboSeada)
- **컨트롤 유형**: Tooltip Button (호버 시 툴팁 애니메이션)
- **변환 일시**: 2026-01-04
- **AvaloniaUI 버전**: 11.2.3

## 컴파일 에러 수정

### 에러 1: StyleInclude vs ResourceInclude 타입 불일치

**에러 내용**:
```
AVLN2000: Resource "avares://BitterSkunk14.Avalonia.Lib/Themes/Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type in the "BitterSkunk14.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 포함하려 했음
- `StyleInclude`는 `IStyle` 타입만 허용하고, `ResourceDictionary`는 `IStyle`이 아님

**수정 방법**:
```xml
<!-- Before (잘못된 방법) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BitterSkunk14.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- After (올바른 방법) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BitterSkunk14.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. 애니메이션 타이밍 문제
- **가능성**: 낮음
- **설명**: CSS `transition: 300ms ease`를 AvaloniaUI `Animation Duration="0:0:0.3"`으로 변환했으나, 실제 동작 시 부드러움이 다를 수 있음
- **확인 필요**: 실행 후 애니메이션 부드러움 확인

### 2. 툴팁 위치 오프셋
- **가능성**: 중간
- **설명**: CSS `top: -110px`를 `Margin="0,-135,0,0"`으로 변환. 라인과 점의 높이를 고려하여 조정했으나 정확한 위치는 실행 후 확인 필요
- **확인 필요**: 툴팁과 컨테이너 버튼 간의 정렬 상태

### 3. 호버 해제 시 애니메이션
- **가능성**: 중간
- **설명**: `:not(:pointerover)` 상태에서 애니메이션 없이 즉시 숨김 처리됨. CSS 원본은 transition으로 부드럽게 사라지나, AvaloniaUI에서는 별도 애니메이션이 필요할 수 있음
- **확인 필요**: 마우스 아웃 시 자연스러운 페이드아웃 여부

### 4. BoxShadow 렌더링
- **가능성**: 낮음
- **설명**: CSS `box-shadow: 0 3px 0 rgb(0 0 0 / 80%)`를 AvaloniaUI `BoxShadow="0 3 0 #CC000000"`으로 변환
- **확인 필요**: 그림자 색상 및 블러 효과가 기대와 일치하는지

## CSS → AvaloniaUI 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `box-shadow: 0 3px 0 rgb(0 0 0 / 80%)` | `BoxShadow="0 3 0 #CC000000"` |
| `border-radius: 5px` | `CornerRadius="5"` |
| `transition: 300ms ease` | `Animation Duration="0:0:0.3" Easing="CubicEaseOut"` |
| `opacity: 0` → `opacity: 1` | `Opacity` 애니메이션 |
| `::before` (pseudo-element) | `Ellipse` 컨트롤로 대체 |
| `:hover` | `:pointerover` |
| `@keyframes HeightUP` | `Animation` with `Height` KeyFrame |

## 파일 구조

```
BitterSkunk14/AvaloniaUI/
├── BitterSkunk14.Avalonia.slnx
├── BitterSkunk14.Avalonia.Lib/
│   ├── BitterSkunk14.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── BitterSkunk14TooltipButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BitterSkunk14TooltipButton.axaml
└── BitterSkunk14.Avalonia.Gallery/
    ├── BitterSkunk14.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **오류**: 0개
