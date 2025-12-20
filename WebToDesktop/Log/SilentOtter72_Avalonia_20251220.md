# SilentOtter72 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by alexruix (Tags: switch)
- **변환일**: 2025-12-20
- **컴포넌트**: 체크마크 아이콘이 있는 토글 스위치

## 프로젝트 구조

```
SilentOtter72/AvaloniaUI/
├── SilentOtter72.Avalonia.slnx
├── SilentOtter72.Avalonia.Lib/
│   ├── Controls/
│   │   └── SilentOtter72.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SilentOtter72.axaml
└── SilentOtter72.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: StrokeLineJoin 속성 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property StrokeLineJoin on type Avalonia.Controls:Avalonia.Controls.Shapes.Path
```

**원인**: AvaloniaUI에서는 WPF의 `StrokeLineJoin` 대신 `StrokeJoin`을 사용함

**수정 방법**:
```xml
<!-- 수정 전 -->
<Path StrokeLineJoin="Round" ... />

<!-- 수정 후 -->
<Path StrokeJoin="Round" ... />
```

---

### 에러 2: ResourceDictionary를 StyleInclude로 참조

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://SilentOtter72.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "SilentOtter72.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에서 `StyleInclude`는 `IStyle` 타입을 기대하지만, Generic.axaml은 `ResourceDictionary` 타입임

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SilentOtter72.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SilentOtter72.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. 체크마크 아이콘 위치

CSS에서 체크마크 아이콘은 `right: 60%` → `right: 20%`로 애니메이션되지만, AXAML에서는 `Margin` 값으로 변환했습니다. 실제 위치가 원본과 다를 수 있습니다.

### 2. 트랜지션 타이밍

CSS의 `transition: .4s`와 AvaloniaUI의 `Duration="0:0:0.4"` 간에 미세한 차이가 있을 수 있습니다. 특히 easing 함수가 기본값으로 다를 수 있습니다.

### 3. Thumb 크기와 위치

CSS에서 thumb는 `left: -1px; bottom: -1px`로 설정되어 slider 트랙 바깥으로 약간 돌출됩니다. AXAML에서는 Grid 내 HorizontalAlignment="Left"로 구현하여 정확히 동일하지 않을 수 있습니다.

## CSS → AXAML 변환 주요 매핑

| CSS 속성 | AXAML 속성 |
|---------|-----------|
| `stroke-linejoin` | `StrokeJoin` |
| `transition` | `Transitions` 컬렉션 |
| `transform: translateX()` | `RenderTransform="translate()"` |
| `border-radius` | `CornerRadius` |
| `outline` | `BorderBrush` + `BorderThickness` |

## 빌드 결과

- **최종 빌드**: 성공
- **경고**: 0개
- **오류**: 0개
