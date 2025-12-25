# TenderFly40 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by alexmaracinaru
- **컨트롤 타입**: Quote Card (명언 카드)
- **변환 일시**: 2025-12-26
- **빌드 결과**: 성공

## 프로젝트 구조

```
TenderFly40/AvaloniaUI/
├── TenderFly40.Avalonia.slnx
├── TenderFly40.Avalonia.Lib/
│   ├── Controls/
│   │   └── TenderFly40Card.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TenderFly40Card.axaml
└── TenderFly40.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내용

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://TenderFly40.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "TenderFly40.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에 `StyleInclude`로 ResourceDictionary를 포함시키려 함
- AvaloniaUI에서 `StyleInclude`는 IStyle 타입만 허용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://TenderFly40.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://TenderFly40.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**교훈**:
- AvaloniaUI에서 ControlTheme이 포함된 ResourceDictionary는 `Application.Resources`에 병합해야 함
- `Application.Styles`는 순수 Style 정의만 허용

## Runtime Error 가능성

### 1. 호버 애니메이션 미작동 가능성

**잠재적 문제**:
- `:pointerover` pseudo-class selector가 ControlTheme 내부의 named element에 정상 적용되지 않을 수 있음

**영향 받는 코드**:
```xml
<Style Selector="^:pointerover /template/ StackPanel#PART_Author">
    <Setter Property="Opacity" Value="1" />
</Style>
```

**확인 방법**:
- 앱 실행 후 카드에 마우스 호버 시 작성자 정보 표시 여부 확인

### 2. SVG Path 렌더링 차이

**잠재적 문제**:
- HTML SVG의 viewBox와 AvaloniaUI Path의 Stretch 동작이 다를 수 있음
- Quote 아이콘과 Heart 아이콘의 크기/위치가 원본과 다를 수 있음

**확인 방법**:
- 원본 HTML과 비교하여 아이콘 크기 및 위치 확인

### 3. TextBlock 대문자 변환 미적용

**잠재적 문제**:
- CSS `text-transform: uppercase`에 해당하는 기능이 AvaloniaUI에 없음
- CardTitle이 소문자로 표시될 수 있음

**해결 방안**:
- ViewModel 또는 Converter에서 `ToUpperInvariant()` 적용 필요

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 | 비고 |
|---------|-----------|------|
| `background: rgb(183, 226, 25)` | `Background="#B7E219"` | - |
| `border-radius: 8px` | `CornerRadius="8"` | - |
| `font-weight: 700` | `FontWeight="Bold"` | - |
| `font-weight: 900` | `FontWeight="Black"` | - |
| `opacity: 0` → `opacity: 1` | `Opacity` + `DoubleTransition` | 호버 애니메이션 |
| `transition: 0.5s` | `Duration="0:0:0.5"` | - |
| `text-transform: uppercase` | 미지원 | 수동 변환 필요 |

## RadialGradientBrush 관련

- 이 프로젝트에서는 RadialGradientBrush를 사용하지 않음
- AvaloniaUI Issue #19888 관련 문제 없음
