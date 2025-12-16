# ItchyMule52 AvaloniaUI 변환 로그

## 변환 정보
- **원본**: uiverse.io by vinodjangid07
- **컴포넌트**: Neon Toggle Switch
- **변환 날짜**: 2025-12-17

## 빌드 에러 및 수정

### 에러 1: Avalonia.Sdk를 찾을 수 없음

**에러 내용:**
```
error MSB4236: 지정된 'Avalonia.Sdk/11.2.2' SDK를 찾을 수 없습니다.
```

**원인:**
- Avalonia.Sdk는 NuGet SDK-style로 참조해야 하지만, 기본 NuGet 소스에서 SDK로 확인할 수 없었음

**수정 방법:**
- `Sdk="Avalonia.Sdk/11.2.2"`에서 `Sdk="Microsoft.NET.Sdk"`로 변경
- Avalonia 패키지를 NuGet PackageReference로 추가

```xml
<!-- 수정 전 -->
<Project Sdk="Avalonia.Sdk/11.2.2">

<!-- 수정 후 -->
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Avalonia" Version="11.2.2"/>
  </ItemGroup>
</Project>
```

### 에러 2: ResourceDictionary를 IStyle로 사용 시도

**에러 내용:**
```
Avalonia error AVLN2000: Resource "avares://ItchyMule52.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "ItchyMule52.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인:**
- App.axaml에서 ResourceDictionary를 Application.Styles에 StyleInclude로 포함하려 했음
- StyleInclude는 IStyle 타입만 허용하고, ResourceDictionary는 Resources에 포함해야 함

**수정 방법:**
- Application.Styles에서 분리하여 Application.Resources로 이동

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://ItchyMule52.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://ItchyMule52.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. RenderTransform 애니메이션
- CSS `transform: translateX(100%)`를 `RenderTransform="translateX(28)"`로 고정값 변환
- 100%는 22px (Thumb 크기)이므로 28px ≈ 127%로 계산 (원본보다 약간 더 이동)
- **확인 필요**: 실제 실행 시 Thumb 이동 위치가 트랙 끝에 맞는지 확인

### 2. ControlTheme 적용
- AvaloniaUI 11.x에서 ControlTheme을 사용한 커스텀 컨트롤 스타일 적용
- **확인 필요**: ToggleButton 기반 NeonToggleSwitch에 ControlTheme이 정상 적용되는지

### 3. Transition 동작
- CSS `transition-duration: .2s`를 Avalonia `Duration="0:0:0.2"`로 변환
- **확인 필요**: BrushTransition, TransformOperationsTransition이 정상 동작하는지

## 변환 노트

### RadialGradientBrush 관련
- 이 컴포넌트에서는 RadialGradientBrush를 사용하지 않으므로 관련 이슈(AvaloniaUI#19888)는 해당 없음

### CSS-to-AXAML 변환 요약
| CSS | AXAML |
|-----|-------|
| `display: flex` + `position: relative` | `Grid` with template parts |
| `::after` pseudo-element | `Border#PART_Thumb` |
| `:checked` state | `:checked` selector |
| `transition-duration` | `<Transitions>` with `Duration` |
| `transform: translateX(100%)` | `RenderTransform="translateX(28)"` |
| `cursor: pointer` | `Cursor="Hand"` |
