# RudeSeahorse6 AvaloniaUI 변환 로그

- **변환일**: 2024-12-24
- **원본**: [Uiverse.io by Javierrocadev](https://uiverse.io)
- **태그**: tooltip, gradient, dark, hover effect, hover button

## 원본 HTML/CSS 분석

hover 시 tooltip이 나타나는 그라데이션 버튼 컴포넌트:
- `linear-gradient(144deg, #af40ff, #5b42f3 50%, #00ddeb)` 그라데이션 배경
- hover 시 tooltip scale 2배 + 위로 이동 애니메이션
- `::before` 회전하는 작은 사각형 (4초 주기)
- `::after` 스케일 애니메이션되는 블러된 원형 (5초 주기)

## 컴파일 에러 및 수정

### 에러 1: Transform에 x:Name 사용 불가

**에러 내용**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**: AvaloniaUI에서는 `TranslateTransform`, `ScaleTransform`, `RotateTransform` 등 Transform 객체에 `x:Name`을 부여하고 Style Selector로 접근하는 방식을 지원하지 않음.

**수정 방법**: Transform에 x:Name 부여 대신, 부모 요소의 `RenderTransform` 속성을 KeyFrame에서 직접 설정.

```xml
<!-- 수정 전 (오류) -->
<Border.RenderTransform>
    <TranslateTransform x:Name="TooltipTranslate" Y="0"/>
</Border.RenderTransform>
<Style Selector="^:pointerover /template/ TranslateTransform#TooltipTranslate">
    <Style.Animations>
        <Animation>
            <KeyFrame Cue="100%">
                <Setter Property="Y" Value="-130"/>
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>

<!-- 수정 후 (정상) -->
<Style Selector="^:pointerover /template/ Border#PART_Tooltip">
    <Style.Animations>
        <Animation Duration="0:0:0.3" FillMode="Forward">
            <KeyFrame Cue="100%">
                <Setter Property="RenderTransform">
                    <TransformGroup>
                        <TranslateTransform Y="-130"/>
                        <ScaleTransform ScaleX="2" ScaleY="2"/>
                    </TransformGroup>
                </Setter>
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>
```

### 에러 2: StyleInclude로 ResourceDictionary 로드 오류

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://RudeSeahorse6.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "RudeSeahorse6.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles` 내에서 `StyleInclude`는 `IStyle` 타입만 로드 가능. `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 로드해야 함.

**수정 방법**:
```xml
<!-- 수정 전 (오류) -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://RudeSeahorse6.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 (정상) -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://RudeSeahorse6.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AvaloniaUI 변환 패턴

| CSS | AvaloniaUI |
|-----|-----------|
| `linear-gradient(144deg, ...)` | `<LinearGradientBrush StartPoint="0%,0%" EndPoint="100%,100%">` |
| `box-shadow: 0 2px 4px rgba(0,0,0,0.2)` | `BoxShadow="0 2 4 0 #33000000"` |
| `border-radius: 16px` | `CornerRadius="16"` |
| `:hover` | `:pointerover` |
| `transition: all 0.3s` | `<Animation Duration="0:0:0.3">` |
| `transform: scale(2)` | `<ScaleTransform ScaleX="2" ScaleY="2"/>` |
| `::before`, `::after` | 별도 `<Border>` 또는 `<Ellipse>` 요소 |
| `filter: blur(8px)` | 직접 지원 안함 (단순화하여 Opacity로 대체) |

## 잠재적 런타임 오류 가능성

1. **blur 효과 미지원**: CSS의 `filter: blur(8px)`가 AvaloniaUI에서 직접 지원되지 않아 `Opacity="0.6"`으로 단순화. 시각적 차이 발생 가능.

2. **애니메이션 FillMode**: `FillMode="Forward"` 사용 시 애니메이션 완료 후 상태가 유지되나, 상태 전환 시 일부 깜빡임 발생 가능.

3. **TransformGroup 애니메이션**: `TranslateTransform`과 `ScaleTransform`을 `TransformGroup`으로 묶어 애니메이션할 때, 두 Transform이 동시에 적용되어야 하는데 개별 보간이 제대로 되지 않을 수 있음.

4. **:not(:pointerover) 애니메이션**: 마우스가 벗어날 때 역방향 애니메이션이 초기 상태에서도 실행될 수 있어 앱 시작 시 원치 않는 애니메이션 발생 가능.

## 생성된 파일 구조

```
RudeSeahorse6/AvaloniaUI/
├── RudeSeahorse6.Avalonia.slnx
├── RudeSeahorse6.Avalonia.Lib/
│   ├── RudeSeahorse6.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── TooltipButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TooltipButton.axaml
└── RudeSeahorse6.Avalonia.Gallery/
    ├── RudeSeahorse6.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 명령어

```bash
cd WebToDesktop/Output/RudeSeahorse6/AvaloniaUI
dotnet build RudeSeahorse6.Avalonia.slnx
dotnet run --project RudeSeahorse6.Avalonia.Gallery
```
