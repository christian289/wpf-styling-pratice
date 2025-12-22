# SpicyDingo98 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by Yaya12085 - Transport Radio Button
- **변환일**: 2025-12-23
- **결과**: 빌드 성공

## 컴파일 에러 및 수정 사항

### 에러 1: BorderDashArray 속성 미지원

**에러 내용:**
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property BorderDashArray on type Avalonia.Controls.Border
```

**원인:**
- CSS의 `border-bottom: 2px dashed #fff`를 AvaloniaUI의 `BorderDashArray`로 변환하려 했으나, AvaloniaUI의 `Border` 컨트롤은 `BorderDashArray` 속성을 지원하지 않음
- WPF의 `Border`도 마찬가지로 대시 테두리를 직접 지원하지 않음

**수정 방법:**
- 대시 테두리 스타일을 제거하고 일반 실선 테두리로 대체
- 주석으로 원본 CSS와의 차이점 명시

```xml
<!-- 수정 전 -->
<Border.Styles>
    <Style Selector="Border#OuterBorder">
        <Setter Property="BorderDashArray" Value="3,0,0,3" />
    </Style>
</Border.Styles>

<!-- 수정 후 -->
<!-- Note: CSS border-bottom: dashed는 AvaloniaUI Border에서 지원하지 않아 일반 실선으로 대체 -->
<Border x:Name="OuterBorder" ... BorderThickness="2" />
```

---

### 에러 2: ResourceDictionary를 Styles에서 직접 참조

**에러 내용:**
```
Avalonia error AVLN2000: Resource "avares://SpicyDingo98.Avalonia.Lib/Themes/Generic.axaml" is defined as "ResourceDictionary" type, but expected "IStyle"
```

**원인:**
- `Application.Styles`에서 `StyleInclude`로 `ResourceDictionary` 타입의 파일을 참조함
- AvaloniaUI에서 `Styles`는 `IStyle` 타입만 포함 가능하며, `ResourceDictionary`는 `Resources`에서 병합해야 함

**수정 방법:**
- `Application.Styles`에서 `StyleInclude` 제거
- `Application.Resources`에 `ResourceDictionary.MergedDictionaries`로 병합

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SpicyDingo98.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SpicyDingo98.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## Runtime Error 가능성 (직접 확인 필요)

### 1. 대시 테두리 시각적 차이

- **위험도**: 낮음
- **내용**: 원본 CSS의 하단 테두리가 대시선(`dashed`)이었으나, 변환 후에는 실선으로 표시됨
- **영향**: 시각적 차이만 존재하며 기능에는 영향 없음
- **대안**: `DrawingBrush` 또는 커스텀 렌더링으로 대시 효과 구현 가능 (복잡도 증가)

### 2. 애니메이션 TransformGroup 동작

- **위험도**: 중간
- **내용**: Checked 상태에서 `RotateTransform`과 `ScaleTransform`을 `TransformGroup`으로 조합
- **확인 필요**: AvaloniaUI에서 애니메이션 중 `TransformGroup` 내 여러 Transform 동시 적용이 의도대로 동작하는지 확인 필요

### 3. PathIcon과 PathGeometry 렌더링

- **위험도**: 낮음
- **내용**: 원본 SVG를 `PathGeometry`로 변환하여 `PathIcon`에 적용
- **확인 필요**: 복잡한 SVG path가 AvaloniaUI에서 올바르게 렌더링되는지 시각적 확인 필요

---

## 프로젝트 구조

```
SpicyDingo98/AvaloniaUI/
├── SpicyDingo98.Avalonia.slnx
├── SpicyDingo98.Avalonia.Lib/
│   ├── Controls/
│   │   └── TransportRadioButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TransportRadioButton.axaml
└── SpicyDingo98.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## CSS → AXAML 변환 요약

| CSS 속성 | AXAML 변환 | 비고 |
|---------|-----------|------|
| `background-color: #444` | `Background="{StaticResource ...}"` | SolidColorBrush 사용 |
| `linear-gradient(to top left, ...)` | `LinearGradientBrush StartPoint="100%,100%" EndPoint="0%,0%"` | |
| `box-shadow: 0 5px 15px rgba(...)` | `BoxShadow="0 5 15 #4D000000"` | |
| `border-radius: 30px` | `CornerRadius="30"` | |
| `transform: scale(1.2)` | `<ScaleTransform ScaleX="1.2" ScaleY="1.2" />` | |
| `:hover` | `:pointerover` | 의사 클래스 변환 |
| `:checked` | `:checked` | 동일 |
| `border-bottom: dashed` | 실선으로 대체 | AvaloniaUI 미지원 |
