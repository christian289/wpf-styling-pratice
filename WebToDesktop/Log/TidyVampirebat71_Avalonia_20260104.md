# TidyVampirebat71 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by Uncannypotato69
- **변환일**: 2026-01-04
- **컨트롤명**: RainbowCheckBox
- **설명**: 체크 시 8개의 바가 무지개색으로 펼쳐지고 전체가 360도 회전하는 애니메이션 체크박스

## 프로젝트 구조

```
TidyVampirebat71/AvaloniaUI/
├── TidyVampirebat71.Avalonia.slnx
├── TidyVampirebat71.Avalonia.Lib/
│   ├── Controls/
│   │   └── RainbowCheckBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── RainbowCheckBox.axaml
└── TidyVampirebat71.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── Program.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary vs IStyle 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://TidyVampirebat71.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "TidyVampirebat71.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Generic.axaml`이 `<ResourceDictionary>` 루트 요소로 정의됨
- `App.axaml`의 `<Application.Styles>` 컬렉션은 `IStyle`을 기대함

**수정 방법**:
`Generic.axaml`을 `<Styles>` 루트 요소로 변경하고, 내부에 `<Styles.Resources>`로 ResourceDictionary를 포함:

```xml
<!-- 수정 전 -->
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="avares://TidyVampirebat71.Avalonia.Lib/Themes/RainbowCheckBox.axaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>

<!-- 수정 후 -->
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="avares://TidyVampirebat71.Avalonia.Lib/Themes/RainbowCheckBox.axaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. 애니메이션 동작 차이
- **문제**: CSS transition과 AvaloniaUI Animation의 동작 방식 차이
- **설명**:
  - CSS는 `transition-delay`로 각 바의 애니메이션 시작 시점을 지연
  - AvaloniaUI는 `Animation.Delay`로 구현했으나, 상태 변경 시 애니메이션 재생 방식이 다를 수 있음
- **확인 필요**: 체크/언체크 시 각 바의 순차적 애니메이션이 정상 동작하는지 확인

### 2. TransformGroup 애니메이션
- **문제**: TransformGroup 내부 Transform 애니메이션
- **설명**:
  - 각 바는 `TranslateTransform`과 `RotateTransform`을 함께 사용
  - AvaloniaUI에서 TransformGroup 내부 속성 애니메이션이 제한될 수 있음
- **확인 필요**: 바가 위로 이동하는 애니메이션이 정상 동작하는지 확인

### 3. 언체크 상태 복귀 애니메이션
- **문제**: 체크 해제 시 원래 상태로 복귀하는 애니메이션 부재
- **설명**:
  - 현재 구현은 체크 시에만 애니메이션 적용
  - 언체크 시 즉시 원래 상태로 돌아감 (CSS 원본도 동일)
- **확인 필요**: 언체크 동작 확인

### 4. RenderTransformOrigin 좌표계
- **문제**: Nut 요소의 `RenderTransformOrigin="0.5,5"` (CSS: transform-origin: 50% 500%)
- **설명**:
  - CSS에서 transform-origin 500%는 요소 높이의 5배 위치
  - AvaloniaUI에서 RenderTransformOrigin은 0~1 범위 외 값 동작이 다를 수 있음
- **확인 필요**: Nut 요소의 회전 중심점이 올바른지 확인

## CSS → AvaloniaUI 변환 매핑

| CSS | AvaloniaUI |
|-----|------------|
| `transform: translateY(-16px)` | `<TranslateTransform Y="-16" />` |
| `rotate: 45deg` | `<RotateTransform Angle="45" />` |
| `transform-origin: bottom` | `RenderTransformOrigin="0.5,1"` |
| `border-radius: 50%` | `<Ellipse />` 또는 `CornerRadius="16"` |
| `transition: all 200ms ease-in` | `<Animation Duration="0:0:0.2" Easing="CubicEaseIn">` |
| `transition-delay: 250ms` | `Delay="0:0:0.25"` |
| `:checked` pseudo-class | `^:checked` selector |
| `/template/` | Template 내부 요소 접근 |

## 빌드 결과

- **최종 빌드**: 성공
- **경고**: 0개
- **오류**: 0개
