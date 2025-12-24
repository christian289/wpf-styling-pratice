# ShaggyEarwig15 - AvaloniaUI 변환 로그

**변환일**: 2024-12-24
**원본**: Uiverse.io by Jack17432
**설명**: 뉴모피즘 스타일의 햄버거 메뉴 버튼 (Glassmorphism, Checkbox, Hamburger, Shadow)

## 프로젝트 구조

```
ShaggyEarwig15/AvaloniaUI/
├── ShaggyEarwig15.Avalonia.slnx
├── ShaggyEarwig15.Avalonia.Lib/
│   ├── Controls/
│   │   └── HamburgerMenuButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── HamburgerMenuButton.axaml
└── ShaggyEarwig15.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내역

### 에러 1: DefaultStyleKeyProperty 미존재

**에러 메시지**:
```
CS0103: 'DefaultStyleKeyProperty' 이름이 현재 컨텍스트에 없습니다.
```

**원인**: WPF에서 사용하는 `DefaultStyleKeyProperty`는 AvaloniaUI에 존재하지 않음.

**수정 방법**: AvaloniaUI에서는 CustomControl이 자동으로 ControlTheme을 찾으므로 static 생성자 제거.

```csharp
// Before (WPF 스타일)
static HamburgerMenuButton()
{
    DefaultStyleKeyProperty.OverrideMetadata(
        typeof(HamburgerMenuButton),
        new StyledPropertyMetadata<Type?>(typeof(HamburgerMenuButton)));
}

// After (AvaloniaUI)
// static 생성자 불필요 - 제거
```

---

### 에러 2: TranslateTransform/RotateTransform에 x:Name 사용 불가

**에러 메시지**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**: AvaloniaUI에서 Transform 객체에는 `x:Name` 속성을 사용할 수 없음.

**수정 방법**: Transform에 이름을 붙이는 대신 부모 Border의 RenderTransform 전체를 Setter로 교체.

```xml
<!-- Before -->
<Border.RenderTransform>
    <TransformGroup>
        <TranslateTransform x:Name="TopBarTranslate" Y="-8" />
        <RotateTransform x:Name="TopBarRotate" Angle="0" />
    </TransformGroup>
</Border.RenderTransform>

<Style Selector="^:checked /template/ TranslateTransform#TopBarTranslate">
    <Setter Property="Y" Value="0" />
</Style>

<!-- After -->
<Style Selector="^:checked /template/ Border#PART_TopBar">
    <Setter Property="RenderTransform">
        <TransformGroup>
            <TranslateTransform Y="0" />
            <RotateTransform Angle="45" />
        </TransformGroup>
    </Setter>
</Style>
```

---

### 에러 3: StyleInclude로 ResourceDictionary 참조 불가

**에러 메시지**:
```
AVLN2000: Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles`에서 `StyleInclude`는 `IStyle` 타입만 수용. ControlTheme을 포함한 ResourceDictionary는 직접 참조 불가.

**수정 방법**: Generic.axaml을 `<Styles>` 루트 요소로 변경하고 내부에 `Styles.Resources`로 ResourceDictionary 병합.

```xml
<!-- Before (Generic.axaml) -->
<ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..." />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>

<!-- After (Generic.axaml) -->
<Styles>
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="..." />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## 런타임 에러 가능성

### 1. CSS transition 효과 미적용

**상황**: 원본 CSS의 `transition: all .3s` 애니메이션이 AvaloniaUI에서 자동으로 적용되지 않음.

**현상**: 체크 상태 전환 시 즉각적인 변환이 발생하며, 부드러운 애니메이션 없이 상태가 변경됨.

**해결 방안**: `Style.Animations`를 추가하여 Transition 효과를 구현해야 함. 현재는 미구현 상태.

### 2. Box-Shadow 형식 차이

**상황**: CSS의 inset box-shadow 구문과 AvaloniaUI BoxShadow 구문이 다름.

**현재 구현**: `BoxShadow="inset 4 4 12 0 #c5c5c5, inset -4 -4 12 0 #ffffff"`

**확인 필요**: inset 키워드가 정상 동작하는지 런타임에서 확인 필요.

### 3. gap 속성 미지원

**상황**: CSS flexbox의 `gap: 13%` 속성은 AvaloniaUI에서 직접 지원되지 않음.

**현재 구현**: 수동으로 TranslateTransform Y 오프셋(-8, 0, 8)으로 막대 간격 조정.

**확인 필요**: 원본 CSS의 비율 기반 gap과 고정 픽셀 오프셋 간 시각적 차이 확인 필요.

## CSS to AvaloniaUI 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `display: flex` + `flex-direction: column` | `Panel` + 수동 배치 |
| `gap: 13%` | `TranslateTransform` Y 오프셋 |
| `box-shadow` | `BoxShadow` |
| `border-radius` | `CornerRadius` |
| `:hover` | `:pointerover` |
| `:active` | `:pressed` |
| `:checked` | `:checked` |
| `transform: translateY()` | `TranslateTransform` |
| `transform: rotate()` | `RotateTransform` |
| `transition` | `Style.Animations` (별도 구현 필요) |

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
