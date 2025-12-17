# GentleKangaroo69 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by tursynbek (Tags: notification)
- **날짜**: 2025-12-17
- **컨트롤명**: LevelUpNotification

## 소스 분석

### HTML 구조
```html
<div class="level-up">
  <span class="text">LEVEL UP!</span>
</div>
```

### CSS 특징
- bounce 애니메이션 (무한 반복, translateY 0 → -10px → 0)
- hover 시 색상 반전 (배경: #ff5733 → white, 텍스트: white → #ff5733)
- hover 시 scale(1.1) 확대
- hover 시 ::before pseudo-element로 원형 장식 (10x10px, bounce 애니메이션)
- box-shadow: 0px 5px 10px rgba(0,0,0,0.2)

## 변환 결과

### 생성된 파일
1. `GentleKangaroo69.Avalonia.Lib/Controls/LevelUpNotification.cs` - CustomControl 클래스
2. `GentleKangaroo69.Avalonia.Lib/Themes/LevelUpNotification.axaml` - 컨트롤 스타일
3. `GentleKangaroo69.Avalonia.Lib/Themes/Generic.axaml` - 스타일 병합
4. `GentleKangaroo69.Avalonia.Gallery/` - 데모 앱

### CSS → AXAML 매핑

| CSS | AvaloniaUI |
|-----|------------|
| `font-family: 'Montserrat'` | `FontFamily="Montserrat, Segoe UI, sans-serif"` |
| `font-size: 25px` | `FontSize="25"` |
| `font-weight: bold` | `FontWeight="Bold"` |
| `color: #ffffff` | `Foreground="{StaticResource LevelUp.ForegroundBrush}"` |
| `background-color: #ff5733` | `Background="{StaticResource LevelUp.BackgroundBrush}"` |
| `padding: 20px` | `Padding="20"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `box-shadow: 0px 5px 10px rgba(0,0,0,0.2)` | `BoxShadow="0 5 10 #33000000"` |
| `:hover` | `:pointerover` |
| `transform: scale(1.1)` | `<ScaleTransform ScaleX="1.1" ScaleY="1.1" />` |
| `transform: translateY(-10px)` | `<TranslateTransform Y="-10" />` |
| `transition: all 0.3s ease` | `<Animation Duration="0:0:0.3">` |
| `animation: bounce 1s infinite` | `<Animation Duration="0:0:1" IterationCount="Infinite">` |
| `::before` pseudo-element | `<Ellipse x:Name="PART_Decoration" />` |

## 컴파일 에러 수정

### 에러 1: ResourceDictionary vs IStyle 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://GentleKangaroo69.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "GentleKangaroo69.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `App.axaml`의 `<StyleInclude>`는 `IStyle` 타입을 기대
- `Generic.axaml`과 `LevelUpNotification.axaml`이 `<ResourceDictionary>`로 정의됨

**수정 방법**:
1. `Generic.axaml`: `<ResourceDictionary>` → `<Styles>`, `<ResourceDictionary.MergedDictionaries>` → `<StyleInclude>`
2. `LevelUpNotification.axaml`: `<ResourceDictionary>` → `<Styles>`, `<ControlTheme>` → `<Style Selector="...">`

**수정 전 (Generic.axaml)**:
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui" ...>
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..." />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

**수정 후 (Generic.axaml)**:
```xml
<Styles xmlns="https://github.com/avaloniaui" ...>
    <StyleInclude Source="avares://GentleKangaroo69.Avalonia.Lib/Themes/LevelUpNotification.axaml" />
</Styles>
```

**수정 전 (LevelUpNotification.axaml)**:
```xml
<ResourceDictionary ...>
    <Color x:Key="...">...</Color>
    <ControlTheme x:Key="{x:Type controls:LevelUpNotification}" TargetType="...">
        <!-- nested styles with ^ selector -->
    </ControlTheme>
</ResourceDictionary>
```

**수정 후 (LevelUpNotification.axaml)**:
```xml
<Styles ...>
    <Styles.Resources>
        <Color x:Key="...">...</Color>
        <SolidColorBrush x:Key="..." Color="..." />
    </Styles.Resources>
    <Style Selector="controls|LevelUpNotification">
        <!-- setters -->
    </Style>
    <!-- separate styles for states -->
    <Style Selector="controls|LevelUpNotification:pointerover">...</Style>
</Styles>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. 애니메이션 충돌 가능성
- `:not(:pointerover)` 상태의 bounce 애니메이션과 `:pointerover` 상태 전환 시 애니메이션이 부드럽게 전환되지 않을 수 있음
- 특히 hover 진입/이탈 시 텍스트의 TranslateTransform 값이 즉시 0으로 리셋되는지 확인 필요

### 2. 중복 Style Selector 문제
- `controls|LevelUpNotification:pointerover /template/ TextBlock#PART_Text`가 두 가지 역할 (RenderTransform 리셋 + Foreground 애니메이션)을 담당
- 마지막에 정의된 스타일만 적용되거나, Setter와 Animation이 충돌할 수 있음

### 3. Ellipse 장식 표시 위치
- `Margin="0,-30,0,0"`으로 위치 지정, 부모 Panel에 ClipToBounds가 없어 표시는 되나 레이아웃 영역 밖에 있음
- 컨트롤이 Window 상단에 배치될 경우 잘릴 수 있음

### 4. 폰트 로딩
- `FontFamily="Montserrat, Segoe UI, sans-serif"` 설정
- Montserrat 폰트가 시스템에 설치되어 있지 않으면 Segoe UI로 폴백됨

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
