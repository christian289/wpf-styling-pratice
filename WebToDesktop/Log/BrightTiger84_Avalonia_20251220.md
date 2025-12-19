# BrightTiger84 - AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by andrew-demchenk0
- **컴포넌트 유형**: ThumbLikeCheckBox (좋아요/엄지척 스타일 체크박스)
- **변환일**: 2025-12-20
- **AvaloniaUI 버전**: 11.2.2
- **.NET 버전**: 9.0

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - StyleInclude와 ResourceDictionary 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://BrightTiger84.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "BrightTiger84.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 로드하려고 함
- `StyleInclude`는 `IStyle` 인터페이스를 구현한 타입(예: `Styles` 루트 요소)만 로드 가능
- `ResourceDictionary`는 `IStyle`이 아니므로 `StyleInclude`로 로드 불가

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BrightTiger84.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://BrightTiger84.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**수정 방법**:
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 로드
- `Application.Styles`에는 `FluentTheme`만 유지

## 잠재적 런타임 에러

### 1. 애니메이션 RenderTransform 관련

**가능성**: 중간

**설명**:
- `:pointerover`와 `:not(:pointerover)` 상태에서 각각 애니메이션을 정의함
- 두 애니메이션이 동시에 트리거되거나 상태 전환 시 충돌할 수 있음
- `FillMode="Forward"` 사용으로 애니메이션 종료 후 상태가 유지되지만, 빠른 마우스 이동 시 예상치 못한 시각적 결과 발생 가능

**확인 필요**:
- 마우스를 빠르게 올렸다 내릴 때 스케일/회전 값이 올바르게 리셋되는지 확인

### 2. ControlTheme 적용

**가능성**: 낮음

**설명**:
- `ControlTheme`이 `ResourceDictionary`에 정의되어 있음
- `Application.Resources`로 병합 시 `ControlTheme`이 올바르게 적용되어야 함
- 일부 AvaloniaUI 버전에서 `ControlTheme`이 `ResourceDictionary`에서 로드될 때 문제 발생 가능성 있음

**확인 필요**:
- 컨트롤이 올바른 템플릿과 스타일을 적용받는지 확인

## 프로젝트 구조

```
BrightTiger84/AvaloniaUI/
├── BrightTiger84.Avalonia.slnx
├── BrightTiger84.Avalonia.Lib/
│   ├── BrightTiger84.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── ThumbLikeCheckBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ThumbLikeCheckBox.axaml
└── BrightTiger84.Avalonia.Gallery/
    ├── BrightTiger84.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## CSS → AXAML 변환 매핑

| CSS | AXAML |
|-----|-------|
| `fill: #666` | `Fill="{StaticResource ThumbLike.Default.Brush}"` |
| `fill: #2196F3` (checked) | `Fill="{StaticResource ThumbLike.Checked.Brush}"` |
| `transition: all 0.3s` | `Animation Duration="0:0:0.3"` |
| `transform: scale(1.1) rotate(-10deg)` | `ScaleTransform ScaleX="1.1" ScaleY="1.1"` + `RotateTransform Angle="-10"` |
| `:hover` | `:pointerover` |
| `input:checked ~ svg` | `:checked /template/ Path#ThumbIcon` |
| `cursor: pointer` | `Cursor="Hand"` |

## 빌드 결과

- **최종 상태**: 성공
- **경고**: 0개
- **오류**: 0개
