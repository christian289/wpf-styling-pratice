# UglyPug52 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본**: uiverse.io by SouravBandyopadhyay
- **컨트롤 유형**: Add To Cart 버튼 (호버 시 텍스트/아이콘 전환 + 툴팁)
- **변환일**: 2025-12-25
- **빌드 결과**: 성공

## 컴파일 에러 및 수정

### 에러 1: TranslateTransform에 x:Name 속성 사용 불가

**에러 메시지**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type
Avalonia.Base:Avalonia.Media.TranslateTransform Line 79, position 38.
```

**원인**:
- AvaloniaUI에서 `TranslateTransform`은 WPF와 달리 `x:Name` 속성을 지원하지 않음
- `TranslateTransform`은 `AvaloniaObject`를 상속하지만 `INameScope`에 등록할 수 없음

**수정 방법**:
```xml
<!-- 수정 전 -->
<TranslateTransform x:Name="TextTransform" Y="0" />

<!-- 수정 후 -->
<TranslateTransform Y="0" />
```

**영향 범위**:
- `UglyPug52Button.axaml` 79행, 93행

---

### 에러 2: StyleInclude로 ResourceDictionary 참조 불가

**에러 메시지**:
```
AVLN2000: Resource "avares://UglyPug52.Avalonia.Lib/Themes/Generic.axaml" is
defined as "Avalonia.Controls.ResourceDictionary" type in the "UglyPug52.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`는 `IStyle` 타입만 참조 가능
- `ControlTheme`을 포함한 `ResourceDictionary`는 `IStyle`이 아님

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://UglyPug52.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://UglyPug52.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**영향 범위**:
- `App.axaml`

---

## Runtime Error 가능성

### 1. 애니메이션 초기 상태 플리커링

**가능성**: 낮음

**설명**:
- 컨트롤이 처음 로드될 때 `:not(:pointerover)` 애니메이션이 한 번 실행될 수 있음
- 초기 상태에서 RenderTransform이 애니메이션 없이 설정되어 있어 문제 없을 것으로 예상

**확인 필요**:
- 첫 로드 시 텍스트/아이콘 위치가 올바른지 확인

### 2. 툴팁 클리핑 문제

**가능성**: 중간

**설명**:
- 툴팁이 버튼 위에 표시되며, 부모 컨테이너의 클리핑 설정에 따라 잘릴 수 있음
- `ClipToBounds="False"` 설정으로 방지했으나, 상위 레이아웃에 따라 영향 받을 수 있음

**확인 필요**:
- Gallery 앱에서 툴팁이 정상적으로 버튼 위에 표시되는지 확인

### 3. Path 렌더링 문제

**가능성**: 낮음

**설명**:
- SVG에서 추출한 Path Data가 AvaloniaUI에서 정상 렌더링되지 않을 수 있음
- Bootstrap Icons의 cart2 아이콘 경로 사용

**확인 필요**:
- 카트 아이콘이 올바르게 표시되는지 확인

---

## CSS → AvaloniaUI 변환 요약

| CSS 속성 | AvaloniaUI 변환 |
|----------|----------------|
| `transition: top 0.5s` | `Animation Duration="0:0:0.5"` |
| `position: absolute` | `Panel` + `RenderTransform` |
| `::before`, `::after` | 별도 `Border`, `Panel` 요소 |
| `:hover` | `:pointerover` pseudo-class |
| `top: -100%` | `TranslateTransform Y="-35"` |
| `border-radius: 0.5em` | `CornerRadius="6"` |
| `opacity: 0/1` | `Opacity="0/1"` |

---

## 파일 구조

```
UglyPug52.Avalonia.slnx
├── UglyPug52.Avalonia.Lib/
│   ├── Controls/
│   │   └── UglyPug52Button.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── UglyPug52Button.axaml
└── UglyPug52.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
