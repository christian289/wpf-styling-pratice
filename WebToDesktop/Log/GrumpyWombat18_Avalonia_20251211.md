# GrumpyWombat18 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by milegelu
- **변환 일시**: 2025-12-11
- **컨트롤명**: IconToggleButton
- **설명**: 체크 상태에 따라 다른 아이콘과 텍스트를 표시하는 모던 토글 버튼

## 컴파일 에러 및 수정 내용

### 에러 1: AVLN2000 - ResourceDictionary를 IStyle로 로드 시도

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://GrumpyWombat18.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "GrumpyWombat18.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- App.axaml에서 `<Application.Styles>` 섹션에 `<StyleInclude>`를 사용하여 ResourceDictionary를 로드하려고 시도
- ControlTheme을 포함한 ResourceDictionary는 Styles 섹션이 아닌 Resources 섹션에 병합해야 함

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://GrumpyWombat18.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GrumpyWombat18.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. TemplateBinding과 RelativeSource TemplatedParent 혼용

**위치**: `IconToggleButton.axaml` - Checked 상태의 Icon Width 바인딩

**내용**:
```xml
<Style Selector="^:checked /template/ Path#PART_CheckedIcon">
    <Setter Property="Width" Value="{Binding IconSize, RelativeSource={RelativeSource TemplatedParent}}"/>
</Style>
```

**설명**:
- ControlTheme 내부 Style에서 TemplatedParent에 대한 바인딩 사용
- 대부분의 경우 정상 동작하나, 일부 시나리오에서 바인딩이 실패할 수 있음
- 직접 실행하여 IconSize 동적 변경 시 정상 동작 확인 필요

### 2. StreamGeometry Path 데이터 복잡성

**위치**: `IconToggleButton.axaml` - DribbbleBallIcon, GameControllerIcon

**내용**: SVG에서 변환한 Path 데이터가 복잡하여 렌더링 성능에 영향을 줄 수 있음

**권장 사항**:
- 대량의 IconToggleButton 인스턴스 사용 시 성능 테스트 필요
- 필요 시 DrawingImage로 변환 고려

### 3. UncheckedText/CheckedText 표시 로직

**위치**: `IconToggleButton.axaml` - Checked/Unchecked 상태 전환

**내용**:
- Unchecked 상태에서 CheckedText의 Opacity가 0으로 설정됨
- Checked 상태에서 UncheckedText의 Opacity가 0으로 설정됨
- 두 TextBlock이 모두 레이아웃에 포함되어 있어 불필요한 공간 차지 가능

**권장 사항**:
- 실행 시 레이아웃이 예상대로 동작하는지 확인 필요
- 필요 시 `IsVisible` 바인딩으로 변경 고려

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 |
|---------|-----------|
| `--UnChacked-color: hsl(0, 0%, 10%)` | `#1A1A1A` (SolidColorBrush) |
| `--chacked-color: hsl(216, 100%, 60%)` | `#3385FF` (SolidColorBrush) |
| `border-radius: 0.8em` | `CornerRadius="16"` (20px * 0.8) |
| `padding: 0.5em` | `Padding="10"` (20px * 0.5) |
| `transition: all 0.2s` | `Transitions` (Duration="0:0:0.2") |
| `:hover transform: scale(1.1)` | `:pointerover RenderTransform="scale(1.1)"` |
| `:active transform: scale(0.95)` | `:pressed RenderTransform="scale(0.95)"` |
| `::before pseudo-element` | `Border#PART_HoverOverlay` |

## 프로젝트 구조

```
GrumpyWombat18/AvaloniaUI/
├── GrumpyWombat18.Avalonia.slnx
├── GrumpyWombat18.Avalonia.Lib/
│   ├── Controls/
│   │   └── IconToggleButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── IconToggleButton.axaml
└── GrumpyWombat18.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
