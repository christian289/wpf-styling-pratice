# SpottyZebra83 AvaloniaUI Conversion Log

## 변환 정보

- **날짜**: 2025-12-11
- **소스**: Uiverse.io by gharsh11032000
- **컨트롤 유형**: TooltipButton (hover 시 툴팁 표시 및 텍스트 전환 애니메이션)

## 컴파일 에러 및 수정

### 에러 1: Transform에 x:Name 사용 불가

**에러 메시지**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
```

**원인**:
AvaloniaUI에서는 `ScaleTransform`, `TranslateTransform` 등 Transform 객체에 `x:Name` 속성을 사용할 수 없습니다. WPF에서는 가능하지만 AvaloniaUI에서는 지원되지 않습니다.

**수정 방법**:
- `TransformGroup` 대신 단일 `ScaleTransform`만 사용
- Transform 객체에 직접 이름을 부여하는 대신, 부모 요소의 `RenderTransform` 속성 전체를 애니메이션 대상으로 지정
- `ScaleTransform.ScaleX`, `ScaleTransform.ScaleY` 형태로 KeyFrame에서 직접 속성 지정

**수정 전**:
```xml
<TextBlock.RenderTransform>
    <TransformGroup>
        <ScaleTransform x:Name="TextScale" ScaleX="1" ScaleY="1" />
        <TranslateTransform x:Name="TextTranslate" X="0" Y="0" />
    </TransformGroup>
</TextBlock.RenderTransform>
```

**수정 후**:
```xml
<TextBlock.RenderTransform>
    <ScaleTransform ScaleX="1" ScaleY="1" />
</TextBlock.RenderTransform>
```

### 에러 2: StyleInclude vs ResourceInclude

**에러 메시지**:
```
AVLN2000: Resource "avares://SpottyZebra83.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "SpottyZebra83.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**:
`Application.Styles`에서 `StyleInclude`는 `IStyle` 타입을 기대하지만, `Generic.axaml`은 `ResourceDictionary` 타입입니다.

**수정 방법**:
`Application.Resources`에서 `ResourceInclude`를 사용하여 `ResourceDictionary`를 병합해야 합니다.

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SpottyZebra83.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://SpottyZebra83.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성 (직접 확인 필요)

1. **애니메이션 동작 차이**: CSS의 `cubic-bezier(0.23, 1, 0.32, 1)`를 AvaloniaUI의 `CubicEaseOut`으로 대체했습니다. 정확한 easing 곡선이 다를 수 있어 애니메이션 느낌이 원본과 다를 수 있습니다.

2. **TranslateTransform 제거로 인한 애니메이션 차이**: 원본 CSS에서는 hover 시 텍스트가 오른쪽으로 이동하면서 사라지고, 배경이 왼쪽에서 슬라이드인되는 효과가 있었습니다. 현재 구현에서는 Scale 애니메이션만 적용되어 시각적 효과가 다를 수 있습니다.

3. **Shake 애니메이션 미구현**: 원본 CSS의 툴팁 shake(흔들림) 애니메이션은 AvaloniaUI에서 단일 Animation 블록 내에서 `RenderTransform`을 Scale과 Rotate로 동시에 변경하기 어려워 제외되었습니다.

4. **RenderTransformOrigin 차이**: CSS의 `transform-origin`과 AvaloniaUI의 `RenderTransformOrigin` 좌표 시스템이 다를 수 있어 애니메이션 피벗 포인트가 다르게 동작할 수 있습니다.

## 생성된 파일

```
SpottyZebra83/AvaloniaUI/
├── SpottyZebra83.Avalonia.slnx
├── SpottyZebra83.Avalonia.Lib/
│   ├── SpottyZebra83.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── TooltipButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TooltipButton.axaml
└── SpottyZebra83.Avalonia.Gallery/
    ├── SpottyZebra83.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
