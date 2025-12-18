# WPF 제한사항 관련 케이스

WPF에 존재하지 않는 CSS/AvaloniaUI 속성이나 멤버 사용 시 발생하는 컴파일 에러.

---

## C009: StackPanel.Spacing 속성 없음 {#c009}

### 오류 빈도

**매우 높음** - 거의 모든 변환에서 발생

### 에러 메시지

```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

### 원인

- WPF의 `StackPanel`에는 `Spacing` 속성이 없음
- `Spacing`은 AvaloniaUI, WinUI/UWP, .NET MAUI에만 존재
- CSS `gap` 속성과 유사한 기능

### 실수 내용

```xml
<!-- ❌ WPF에서 컴파일 에러 -->
<StackPanel Spacing="20">
    <Button Content="Button 1"/>
    <Button Content="Button 2"/>
    <Button Content="Button 3"/>
</StackPanel>
```

### 해결

각 자식 요소에 `Margin` 속성 적용:

```xml
<!-- ✅ Margin으로 간격 지정 -->
<StackPanel>
    <Button Content="Button 1" Margin="0,0,0,20"/>
    <Button Content="Button 2" Margin="0,0,0,20"/>
    <Button Content="Button 3"/>  <!-- 마지막 요소는 Margin 불필요 -->
</StackPanel>
```

### 가로 StackPanel의 경우

```xml
<StackPanel Orientation="Horizontal">
    <Button Content="Button 1" Margin="0,0,20,0"/>
    <Button Content="Button 2" Margin="0,0,20,0"/>
    <Button Content="Button 3"/>
</StackPanel>
```

### CSS → WPF 매핑

| CSS / AvaloniaUI | WPF |
|------------------|-----|
| `gap: 20px` | 각 요소 `Margin="0,0,0,20"` (세로) 또는 `Margin="0,0,20,0"` (가로) |
| `StackPanel Spacing="20"` | 각 요소 `Margin` |

### 태그

`#layout` `#stackpanel` `#spacing` `#margin` `#avalonia-only`

---

## C010: BooleanToVisibilityConverter.Default 없음 {#c010}

### 오류 빈도

**중간**

### 에러 메시지

```
error MC3011: 'BooleanToVisibilityConverter' 형식에서 정적 멤버 'Default'을(를) 찾을 수 없습니다.
```

### 원인

- WPF의 기본 `BooleanToVisibilityConverter`에는 `Default` 정적 멤버가 없음
- 일부 MVVM 프레임워크(예: CommunityToolkit.Mvvm)에서는 싱글톤 패턴 사용

### 실수 내용

```xml
<!-- ❌ WPF 기본 Converter에는 Default 없음 -->
<TextBlock Visibility="{Binding IsVisible,
    Converter={x:Static BooleanToVisibilityConverter.Default}}"/>
```

### 해결

#### 방법 1: ResourceDictionary에 인스턴스 등록 (권장)

```xml
<ResourceDictionary>
    <BooleanToVisibilityConverter x:Key="BoolToVisibilityConverter"/>
</ResourceDictionary>

<TextBlock Visibility="{Binding IsVisible,
    Converter={StaticResource BoolToVisibilityConverter}}"/>
```

#### 방법 2: 커스텀 Converter에 싱글톤 추가

```csharp
namespace MyApp.Converters;

/// <summary>
/// bool 값을 Visibility로 변환합니다.
/// Converts bool value to Visibility.
/// </summary>
public sealed class BoolToVisibilityConverter : IValueConverter
{
    public static readonly BoolToVisibilityConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Visibility.Visible;
    }
}
```

```xml
<TextBlock Visibility="{Binding IsVisible,
    Converter={x:Static local:BoolToVisibilityConverter.Instance}}"/>
```

### 태그

`#converter` `#visibility` `#singleton` `#staticresource`

---

## C011: Trigger TargetName으로 Transform/Effect 참조 불가 {#c011}

### 오류 빈도

**중간**

### 에러 메시지

```
error MC4111: Trigger 대상 'TransformName'을(를) 찾을 수 없습니다.
대상은 모든 Setters, Triggers 또는 대상을 사용하는 Conditions 앞에 표시되어야 합니다.
```

### 원인

- WPF에서 `Setter`의 `TargetName`은 Visual Tree의 요소(UIElement)에만 적용 가능
- `TranslateTransform`, `ScaleTransform`, `RotateTransform` 등은 Visual Tree의 일부가 아님
- `DropShadowEffect`, `BlurEffect` 등도 마찬가지

### 실수 내용

```xml
<!-- ❌ Transform에 x:Name을 지정하고 Trigger에서 참조 시도 -->
<Border>
    <Border.RenderTransform>
        <TranslateTransform x:Name="TextTranslate" Y="0"/>
    </Border.RenderTransform>
</Border>

<ControlTemplate.Triggers>
    <Trigger Property="IsMouseOver" Value="True">
        <!-- 에러 발생! TextTranslate를 찾을 수 없음 -->
        <Setter TargetName="TextTranslate" Property="Y" Value="10"/>
    </Trigger>
</ControlTemplate.Triggers>
```

### 해결

#### 방법 1: Property Path로 접근

UIElement의 RenderTransform을 통해 간접 참조:

```xml
<Border x:Name="PART_Border">
    <Border.RenderTransform>
        <TranslateTransform Y="0"/>  <!-- x:Name 제거 -->
    </Border.RenderTransform>
</Border>

<ControlTemplate.Triggers>
    <Trigger Property="IsMouseOver" Value="True">
        <!-- ✅ UIElement를 TargetName으로, Property Path로 Transform 속성 접근 -->
        <Setter TargetName="PART_Border"
                Property="RenderTransform.(TranslateTransform.Y)"
                Value="10"/>
    </Trigger>
</ControlTemplate.Triggers>
```

#### 방법 2: Storyboard 사용

애니메이션이 필요한 경우 Storyboard 사용:

```xml
<Trigger Property="IsMouseOver" Value="True">
    <Trigger.EnterActions>
        <BeginStoryboard>
            <Storyboard>
                <DoubleAnimation Storyboard.TargetName="PART_Border"
                                 Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.Y)"
                                 To="10" Duration="0:0:0.2"/>
            </Storyboard>
        </BeginStoryboard>
    </Trigger.EnterActions>
</Trigger>
```

#### Effect 참조 시

```xml
<!-- ❌ Effect에 x:Name 지정 불가 -->
<Setter TargetName="ButtonShadow" Property="BlurRadius" Value="15"/>

<!-- ✅ Effect 전체를 새 객체로 교체 -->
<Setter TargetName="ButtonBorder" Property="Effect">
    <Setter.Value>
        <DropShadowEffect Color="#888888" BlurRadius="15" ShadowDepth="0"/>
    </Setter.Value>
</Setter>
```

### Property Path 패턴

| Transform 타입 | Property Path |
|---------------|---------------|
| TranslateTransform | `(UIElement.RenderTransform).(TranslateTransform.X)` |
| ScaleTransform | `(UIElement.RenderTransform).(ScaleTransform.ScaleX)` |
| RotateTransform | `(UIElement.RenderTransform).(RotateTransform.Angle)` |

### 태그

`#trigger` `#targetname` `#transform` `#effect` `#visual-tree` `#property-path`

---

## C012: CornerRadius.Empty 정적 멤버 없음 {#c012}

### 오류 빈도

**낮음**

### 에러 메시지

```
error MC3011: 'CornerRadius' 형식에서 정적 멤버 'Empty'을(를) 찾을 수 없습니다.
```

### 원인

- WPF의 `CornerRadius` 구조체에는 `Empty` 정적 멤버가 없음
- `Thickness.Empty`나 `Size.Empty`와 달리 `CornerRadius`는 해당 속성 미제공

### 실수 내용

```xml
<!-- ❌ CornerRadius.Empty 없음 -->
<DiscreteObjectKeyFrame KeyTime="0:0:0.375"
                        Value="{x:Static CornerRadius.Empty}"/>
```

### 해결

명시적으로 `CornerRadius` 값 0 지정:

```xml
<!-- ✅ 직접 값 지정 -->
<DiscreteObjectKeyFrame KeyTime="0:0:0.375">
    <DiscreteObjectKeyFrame.Value>
        <CornerRadius>0</CornerRadius>
    </DiscreteObjectKeyFrame.Value>
</DiscreteObjectKeyFrame>
```

### WPF Empty 멤버 존재 여부

| 타입 | Empty 멤버 | 대안 |
|------|-----------|------|
| `Thickness` | ✅ 있음 | `{x:Static Thickness.Empty}` |
| `Size` | ✅ 있음 | `{x:Static Size.Empty}` |
| `Rect` | ✅ 있음 | `{x:Static Rect.Empty}` |
| `CornerRadius` | ❌ 없음 | `<CornerRadius>0</CornerRadius>` |

### 태그

`#cornerradius` `#empty` `#struct` `#animation`

---

## C013: XML 주석에서 '--' 사용 불가 {#c013}

### 오류 빈도

**낮음**

### 에러 메시지

```
error MC3000: An XML comment cannot contain '--', and '-' cannot be the last character.
```

### 원인

- XML 표준에서 주석(`<!-- -->`) 내에 `--` 시퀀스 사용 금지
- CSS 변수명(`--primary-color`, `--sz` 등)을 주석에 그대로 사용할 때 발생

### 실수 내용

```xml
<!-- ❌ CSS 변수명 그대로 사용 -->
<!-- CSS 변수: --primary-color, --secondary-color -->
<!-- 원본: background: var(--bg); -->
```

### 해결

CSS 변수명에서 `--` 접두사 제거 또는 다른 형식으로 표기:

```xml
<!-- ✅ 접두사 제거 -->
<!-- CSS 변수: primary-color, secondary-color -->

<!-- ✅ 다른 형식으로 표기 -->
<!-- CSS 변수: [primary-color], [secondary-color] -->

<!-- ✅ 대시 대신 언더스코어 -->
<!-- CSS 변수: __primary_color, __secondary_color -->
```

### CSS 변수 → WPF 매핑 주석 예시

```xml
<!--
    CSS 변수 매핑:
    [sz] = 240px → StaticResource CardSize
    [c0] = #30304a → StaticResource BackgroundColor
    [c1] = #42426a → StaticResource AccentColor
-->
<Grid>
    <Grid.Resources>
        <sys:Double x:Key="CardSize">240</sys:Double>
        <Color x:Key="BackgroundColor">#30304a</Color>
        <Color x:Key="AccentColor">#42426a</Color>
    </Grid.Resources>
</Grid>
```

### 태그

`#xml` `#comment` `#css-variable` `#syntax`

---
