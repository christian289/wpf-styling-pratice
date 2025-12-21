# SmoothChipmunk60 AvaloniaUI 변환 로그

## 변환 일시
2025-12-22

## 소스 정보
- **원본**: Uiverse.io by omar-alghaish
- **태그**: switch
- **설명**: 햄버거 메뉴 토글 버튼 - 체크 시 X 표시로 변환되는 애니메이션 스위치

## 프로젝트 구조
```
SmoothChipmunk60/AvaloniaUI/
├── SmoothChipmunk60.Avalonia.slnx
├── SmoothChipmunk60.Avalonia.Lib/
│   ├── Controls/
│   │   └── SmoothChipmunk60.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SmoothChipmunk60.axaml
└── SmoothChipmunk60.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://SmoothChipmunk60.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "SmoothChipmunk60.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Generic.axaml`이 `ResourceDictionary`로 정의되어 있음
- `App.axaml`에서 `StyleInclude`로 포함하려 했으나, `StyleInclude`는 `IStyle` 타입만 허용

**수정 전** (`App.axaml`):
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SmoothChipmunk60.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후** (`App.axaml`):
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SmoothChipmunk60.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**교훈**:
- AvaloniaUI에서 `ResourceDictionary`와 `Style`은 다른 컨테이너에 포함해야 함
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 포함
- `Styles`는 `Application.Styles`에서 `StyleInclude`로 포함

## 잠재적 런타임 에러

### 1. 애니메이션 Transform 관련
- **위험도**: 낮음
- **설명**: CSS의 `transform-origin` 속성을 AvaloniaUI의 `RenderTransformOrigin`으로 변환함
- **확인 필요**:
  - 애니메이션 시작/종료 시점의 Transform 값이 CSS 원본과 일치하는지
  - `TransformGroup` 내 `TranslateTransform`과 `RotateTransform`의 적용 순서가 올바른지

### 2. BoxShadow 렌더링
- **위험도**: 낮음
- **설명**: CSS `box-shadow: 0 5px 25px rgba(0, 0, 0, 0.363)` → AvaloniaUI `BoxShadow="0 5 25 0 #5C000000"`
- **확인 필요**: 그림자 blur 및 opacity가 원본과 유사하게 렌더링되는지

### 3. 라인 위치 계산
- **위험도**: 중간
- **설명**: CSS에서 `width: 50%`, `transform: translate(-100%, -10px)` 등 퍼센트 기반 계산을 픽셀 값으로 변환함
- **확인 필요**:
  - 40x40px 컨트롤에서 라인 위치가 정확한지
  - 다른 크기로 스케일링할 경우 레이아웃이 깨지지 않는지

## CSS → AXAML 변환 매핑

| CSS | AXAML |
|-----|-------|
| `linear-gradient(45deg, rgb(183, 0, 255) 20%, rgb(255, 0, 170) 100%)` | `LinearGradientBrush StartPoint="0%,0%" EndPoint="100%,100%"` |
| `box-shadow: 0 5px 25px rgba(0, 0, 0, 0.363)` | `BoxShadow="0 5 25 0 #5C000000"` |
| `border-radius: 5px` | `CornerRadius="5"` |
| `transition: transform 0.5s` | `Animation Duration="0:0:0.5"` |
| `:checked` 의사 클래스 | `:checked` 선택자 |
| `cursor: pointer` | `Cursor="Hand"` |

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **에러**: 0개 (수정 후)
