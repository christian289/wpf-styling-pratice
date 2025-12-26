# SeriousSheep31 AvaloniaUI 변환 로그

## 프로젝트 정보

- **소스**: Uiverse.io by neerajbaniwal
- **컨트롤 유형**: Neumorphism RadioButton Group
- **변환 일자**: 2025-12-26

## 컴파일 에러 및 수정 내역

### 에러 1: Avalonia.Sdk를 찾을 수 없음

**에러 메시지**:
```
error MSB4236: 지정된 'Avalonia.Sdk/11.3.0' SDK를 찾을 수 없습니다.
```

**원인**: `Avalonia.Sdk`는 NuGet 패키지로 자동 복원되지 않음

**수정 방법**:
- `Sdk="Avalonia.Sdk/11.3.0"` 대신 `Sdk="Microsoft.NET.Sdk"` 사용
- Avalonia NuGet 패키지를 PackageReference로 직접 추가

```xml
<!-- 수정 전 -->
<Project Sdk="Avalonia.Sdk/11.3.0">

<!-- 수정 후 -->
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Avalonia" Version="11.2.2" />
    <PackageReference Include="Avalonia.Desktop" Version="11.2.2" />
    <PackageReference Include="Avalonia.Themes.Fluent" Version="11.2.2" />
    <PackageReference Include="Avalonia.Fonts.Inter" Version="11.2.2" />
  </ItemGroup>
</Project>
```

### 에러 2: RadioButton 형식을 찾을 수 없음

**에러 메시지**:
```
error CS0246: 'RadioButton' 형식 또는 네임스페이스 이름을 찾을 수 없습니다.
```

**원인**: 잘못된 using 지시문

**수정 방법**:
```csharp
// 수정 전
using Avalonia;
using Avalonia.Controls.Primitives;

// 수정 후
using Avalonia.Controls;
```

### 에러 3: Transform에 Name 속성 해결 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name
on type Avalonia.Base:Avalonia.Media.ScaleTransform
```

**원인**: AvaloniaUI에서 Transform 요소에 `x:Name`을 설정하고 Style Selector로 접근하는 것은 지원되지 않음

**수정 방법**:
- Transform에 개별 x:Name 대신 부모 요소의 RenderTransform 속성을 직접 애니메이션
- KeyFrame 내에서 전체 TransformGroup을 설정

```xml
<!-- 수정 전: Transform에 개별 이름 지정 -->
<Ellipse.RenderTransform>
    <TransformGroup>
        <ScaleTransform x:Name="CoverScale" ScaleX="1" ScaleY="1" />
        <TranslateTransform x:Name="CoverTranslate" Y="0" />
    </TransformGroup>
</Ellipse.RenderTransform>

<Style Selector="^:checked /template/ ScaleTransform#CoverScale">
    ...
</Style>

<!-- 수정 후: RenderTransform 속성 전체를 애니메이션 -->
<Style Selector="^:checked /template/ Ellipse#PART_Cover">
    <Style.Animations>
        <Animation Duration="0:0:0.25" Easing="QuadraticEaseInOut" FillMode="Forward">
            <KeyFrame Cue="100%">
                <Setter Property="Opacity" Value="0" />
                <Setter Property="RenderTransform">
                    <TransformGroup>
                        <ScaleTransform ScaleX="0.975" ScaleY="0.975" />
                        <TranslateTransform Y="2.4" />
                    </TransformGroup>
                </Setter>
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>
```

### 에러 4: ResourceDictionary를 Styles에 포함할 수 없음

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://...Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type... but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에 `StyleInclude`로 ResourceDictionary를 참조할 수 없음

**수정 방법**:
- `Application.Resources`에서 `ResourceInclude`로 병합

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://...Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://...Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. BoxShadow inset 미지원

**위험도**: 중간

**설명**: CSS의 `box-shadow: inset` 효과는 AvaloniaUI BoxShadow에서 직접 지원되지 않음. 현재 outer shadow만 사용 중이며, MainWindow의 컨테이너 Border에서 inset 효과를 흉내내기 위해 추가 Border나 다른 기법이 필요할 수 있음.

**확인 필요**: 런타임에서 Neumorphism의 오목한(concave) 효과가 제대로 표현되는지 확인 필요

### 2. DropShadowEffect 성능

**위험도**: 낮음

**설명**: Ellipse에 DropShadowEffect가 적용되어 있음. 많은 RadioButton이 있을 경우 렌더링 성능에 영향을 줄 수 있음.

### 3. 애니메이션 FillMode

**위험도**: 낮음

**설명**: `FillMode="Forward"`를 사용하여 애니메이션 종료 후 상태를 유지함. 상태 변경 시(checked -> unchecked) 초기 상태로 돌아가는 애니메이션이 없어 시각적으로 어색할 수 있음.

## CSS -> AXAML 변환 요약

| CSS 속성 | AXAML 변환 |
|----------|-----------|
| `box-shadow: -8px -4px 8px 0px #fff` | `BoxShadow="-8 -4 8 0 #FFFFFF"` |
| `border-radius: 50%` | `CornerRadius="15"` (반지름 절반) |
| `opacity: 0.6` | `Opacity="0.6"` |
| `transition: opacity 0.2s` | `<Animation Duration="0:0:0.2">` |
| `transform: scale3d(0.975, 0.975, 1)` | `<ScaleTransform ScaleX="0.975" ScaleY="0.975" />` |
| `transform: translate3d(0, 10%, 0)` | `<TranslateTransform Y="2.4" />` (24px * 10%) |
| `:hover` | `:pointerover` |
| `cursor: pointer` | `Cursor="Hand"` |

## 빌드 결과

- **최종 상태**: 성공
- **경고**: 0개
- **오류**: 0개
