# AverageShrimp57 AvaloniaUI 변환 로그

- **변환 일자**: 2026-01-05
- **원본**: uiverse.io by JaydipPrajapati1910
- **컨트롤 유형**: Light Switch Toggle (On/Off 토글 스위치)

## 프로젝트 구조

```
AverageShrimp57/AvaloniaUI/
├── AverageShrimp57.Avalonia.slnx
├── AverageShrimp57.Avalonia.Lib/
│   ├── Controls/
│   │   └── LightSwitch.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LightSwitch.axaml
└── AverageShrimp57.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://AverageShrimp57.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "AverageShrimp57.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인**:
- `Application.Styles`에 `StyleInclude`를 사용하면 `IStyle` 인터페이스를 구현한 타입이 필요
- `ResourceDictionary`는 `IStyle`을 구현하지 않으므로 타입 불일치 발생

**수정 방법**:
- `Application.Styles`에서 `StyleInclude` 제거
- `Application.Resources`에 `ResourceDictionary.MergedDictionaries`로 리소스 병합

**수정 전 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://AverageShrimp57.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://AverageShrimp57.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AXAML 변환 내역

| CSS 속성 | AXAML 변환 |
|----------|-----------|
| `border-radius: 50px` | `CornerRadius="37.5"` (Height/2) |
| `linear-gradient(to bottom, ...)` | `LinearGradientBrush StartPoint="0%,0%" EndPoint="0%,100%"` |
| `linear-gradient(to right, ...)` | `LinearGradientBrush StartPoint="0%,0%" EndPoint="100%,0%"` |
| `box-shadow` | `BoxShadow` 속성 |
| `inset` box-shadow | `BoxShadow="inset ..."` |
| `::before`, `::after` | `TextBlock` 요소로 대체 |
| `:checked` pseudo-class | `:checked` selector |
| `position: absolute` | `Panel` 내 `HorizontalAlignment`, `VerticalAlignment`, `Margin` 조합 |

## 잠재적 런타임 에러 (확인 필요)

### 1. BoxShadow 복합 값 렌더링
- **우려**: CSS에서 여러 box-shadow를 쉼표로 구분하여 중첩 적용
- **AvaloniaUI 변환**: 단일 `BoxShadow` 속성에 공백으로 구분된 여러 그림자 정의
- **가능성**: 낮음 (AvaloniaUI 11.x에서 지원됨)

### 2. text-shadow 미구현
- **원본 CSS**: `text-shadow: 0 1px 0 #fff, 0px 0 7px #df0000;` (빛나는 효과)
- **현재 구현**: `Foreground` 색상만 변경, 글로우 효과 미적용
- **영향**: 시각적 차이 발생 (기능에는 영향 없음)
- **해결 방안**: 필요시 `Effect` 속성에 blur 효과 추가 고려

### 3. ControlTheme 적용 확인
- **우려**: `ControlTheme`이 `LightSwitch` 커스텀 컨트롤에 자동 적용되는지 확인 필요
- **가능성**: 낮음 (x:Key가 `{x:Type controls:LightSwitch}`로 올바르게 설정됨)

## 빌드 결과

- **상태**: 성공 ✅
- **경고**: 0개
- **에러**: 0개 (수정 후)
