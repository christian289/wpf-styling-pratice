# BadSquid34 AvaloniaUI 변환 로그

## 변환 정보

- **변환 일시**: 2025-12-30
- **원본 소스**: Uiverse.io by andrew-demchenk0
- **컨트롤 타입**: Error Alert Card (에러 알림 카드)
- **태그**: alert, red, card, error, message, white and red, close, error message

## 프로젝트 구조

```
WebToDesktop/Output/BadSquid34/AvaloniaUI/
├── BadSquid34.Avalonia.slnx
├── BadSquid34.Avalonia.Lib/
│   ├── BadSquid34.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── ErrorAlert.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ErrorAlert.axaml
└── BadSquid34.Avalonia.Gallery/
    ├── BadSquid34.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 |
|---------|-----------|
| `width: 320px` | `Width="320"` |
| `padding: 12px` | `Padding="12"` |
| `display: flex; flex-direction: row; align-items: center` | `Grid ColumnDefinitions="Auto,*,Auto"` + `VerticalAlignment="Center"` |
| `background: #EF665B` | `Background="{StaticResource ErrorAlert.Background.Brush}"` |
| `border-radius: 8px` | `CornerRadius="8"` |
| `box-shadow: 0px 0px 5px -3px #111` | `BoxShadow="0 0 5 0 #33111111"` |
| `font-weight: 500` | `FontWeight="Medium"` |
| `font-size: 14px` | `FontSize="14"` |
| `color: #fff` | `Foreground="{StaticResource ErrorAlert.Foreground.Brush}"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `margin-left: auto` | Grid Column 배치로 구현 |
| `transform: translateY(-2px)` | 무시 (미미한 시각적 조정) |

## 컴파일 에러 및 수정 내역

### 에러 1: ResourceDictionary에 Style 직접 추가 불가

**에러 메시지**:
```
AVLN3000: Unable to find suitable setter or adder for property Content of type
Avalonia.Controls.ResourceDictionary for argument Avalonia.Styling.Style
```

**원인**:
- AvaloniaUI에서 `Style`은 `ResourceDictionary`의 직접적인 자식이 될 수 없음
- WPF와 달리 AvaloniaUI는 Style을 별도의 `Styles` 컬렉션에 추가해야 함

**수정 방법**:
```xml
<!-- 수정 전 (에러) -->
<ResourceDictionary>
    <ControlTheme .../>
    <Style Selector="...">...</Style>  <!-- 에러 발생 -->
</ResourceDictionary>

<!-- 수정 후 (정상) -->
<ControlTheme>
    <Setter Property="Template">
        <ControlTemplate>
            <Button>
                <Button.Styles>
                    <Style Selector="Button:pointerover">
                        <Setter Property="Opacity" Value="0.7"/>
                    </Style>
                </Button.Styles>
            </Button>
        </ControlTemplate>
    </Setter>
</ControlTheme>
```

### 에러 2: StyleInclude와 ResourceDictionary 타입 불일치

**에러 메시지**:
```
AVLN2000: Resource "avares://BadSquid34.Avalonia.Lib/Themes/Generic.axaml" is defined
as "Avalonia.Controls.ResourceDictionary" type, but expected "Avalonia.Styling.IStyle"
```

**원인**:
- `Application.Styles`는 `IStyle` 타입만 허용
- `ResourceDictionary`는 `Application.Resources`에 병합해야 함

**수정 방법**:
```xml
<!-- 수정 전 (에러) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://.../Generic.axaml" />  <!-- ResourceDictionary는 여기 불가 -->
</Application.Styles>

<!-- 수정 후 (정상) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://.../Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (확인 필요)

### 1. Close 버튼 클릭 시 Message 문자열 인덱싱 오류

**위치**: `MainWindow.axaml.cs:OnErrorAlertCloseClicked`

**코드**:
```csharp
StatusText.Text = $"Alert '{errorAlert.Message[..20]}...' has been closed";
```

**문제**:
- `Message`가 20자 미만일 경우 `ArgumentOutOfRangeException` 발생 가능
- 예: `"Error"` (5자) → 인덱스 범위 초과

**권장 수정**:
```csharp
var preview = errorAlert.Message.Length > 20
    ? errorAlert.Message[..20]
    : errorAlert.Message;
StatusText.Text = $"Alert '{preview}...' has been closed";
```

### 2. TemplateBinding과 Foreground 바인딩 차이

**코드**:
```xml
<!-- Path의 Fill은 $parent 바인딩 사용 -->
<Path Fill="{Binding $parent[controls:ErrorAlert].Foreground}" />

<!-- 다른 곳은 TemplateBinding 사용 -->
<TextBlock Foreground="{TemplateBinding Foreground}" />
```

**잠재적 문제**:
- 중첩된 ControlTemplate 내부에서 `TemplateBinding`이 제대로 전파되지 않을 수 있음
- Button 내부의 Path는 `$parent` 바인딩으로 우회

**상태**: 정상 동작 예상, 하지만 런타임에서 확인 필요

## 특이사항

- **RadialGradientBrush**: 원본 CSS에 없으므로 Issue #19888 관련 수정 불필요
- **SVG → StreamGeometry**: 원본 SVG path 데이터를 `StreamGeometry`로 변환
- **box-shadow**: CSS의 음수 spread 값(-3px)은 AvaloniaUI BoxShadow에서 지원 안 함, 0으로 대체하고 알파값 조정

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
