# BreezyGoose71 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io (vinodjangid07)
- **컨트롤명**: BookmarkToggleButton
- **설명**: 북마크 토글 버튼 (애니메이션 포함)
- **변환일**: 2025-12-18

## 프로젝트 구조

```
BreezyGoose71/AvaloniaUI/
├── BreezyGoose71.Avalonia.slnx
├── BreezyGoose71.Avalonia.Lib/
│   ├── Controls/
│   │   └── BookmarkToggleButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BookmarkToggleButton.axaml
└── BreezyGoose71.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: converters 네임스페이스 미해결

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve namespace converters Line 47, position 31.
```

**원인**: `MathConverters.Multiply` 컨버터를 사용했으나 해당 네임스페이스가 정의되지 않음

**수정 방법**: Path의 Height 바인딩에서 컨버터 사용 제거
```xml
<!-- 변경 전 -->
Height="{Binding $self.Width, Converter={x:Static converters:MathConverters.Multiply}, ConverterParameter=1.4}"

<!-- 변경 후 -->
<!-- Height 속성 제거하고 Stretch="Uniform"으로 비율 유지 -->
```

### 에러 2: StyleInclude vs ResourceInclude

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://BreezyGoose71.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "BreezyGoose71.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에서 `StyleInclude`로 ResourceDictionary를 참조하면 타입 불일치 발생

**수정 방법**: `Application.Resources`에서 `ResourceInclude`로 병합
```xml
<!-- 변경 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BreezyGoose71.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 변경 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BreezyGoose71.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성 (직접 확인 필요)

### 1. StrokeDashArray 애니메이션

CSS의 `stroke-dasharray` 애니메이션을 AvaloniaUI의 `StrokeDashArray` 속성으로 변환했습니다.
AvaloniaUI에서 `StrokeDashArray`는 `AvaloniaList<double>` 타입이므로 애니메이션이 예상대로 동작하지 않을 수 있습니다.

**확인 필요**: Checked 상태 전환 시 stroke-dasharray 애니메이션이 올바르게 동작하는지 확인

### 2. Transition과 Animation 충돌

Fill 속성에 `BrushTransition`과 `:checked` 상태의 `Animation`이 동시에 적용되어 있습니다.
두 애니메이션이 충돌할 가능성이 있습니다.

**확인 필요**: Checked/Unchecked 전환 시 Fill 색상 변화가 부드럽게 이루어지는지 확인

### 3. Path 아이콘 비율

원본 CSS에서는 SVG viewBox가 `0 0 50 70`이었고, Width만 15px로 설정되어 있었습니다.
AvaloniaUI에서는 `Stretch="Uniform"`으로 비율을 유지하지만, 정확한 크기가 다를 수 있습니다.

**확인 필요**: 아이콘 크기와 비율이 원본과 동일한지 확인

## CSS → AvaloniaUI 변환 패턴

| CSS | AvaloniaUI |
|-----|------------|
| `background-color: teal` | `Background="#008080"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `display: flex; align-items: center; justify-content: center` | `Panel` with `HorizontalAlignment="Center" VerticalAlignment="Center"` |
| `:hover` | `:pointerover` |
| `:checked ~` | `:checked /template/` |
| `transition-duration: 0.5s` | `<BrushTransition Duration="0:0:0.5" />` |
| `@keyframes` | `<Style.Animations><Animation>` |
| `stroke-dasharray` | `StrokeDashArray` |
| `stroke-dashoffset` | `StrokeDashOffset` |

## 빌드 결과

- **빌드 성공**: O
- **경고**: 0개
- **에러**: 0개 (수정 후)
