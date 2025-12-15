# NervousZebra0 AvaloniaUI 변환 로그

## 원본 정보

- **출처**: uiverse.io by WittyHydra
- **태그**: notification
- **HTML/CSS 파일**: `source/20251215_NervousZebra0/NervousZebra0.html`, `NervousZebra0.css`

## 변환 결과

- **솔루션**: `NervousZebra0.Avalonia.slnx`
- **라이브러리**: `NervousZebra0.Avalonia.Lib`
- **갤러리**: `NervousZebra0.Avalonia.Gallery`

## 컨트롤 설명

"Level Up!" 알림 UI 컴포넌트:
- 상단: 오렌지색 하이라이트 영역 (슬라이드 다운 애니메이션)
- 하단: 레벨 텍스트 + "Next Level" 버튼
- Hover 시 색상 반전 효과
- 버튼 Hover 시 스케일 업 애니메이션

## 컴파일 에러 및 수정

### 에러 1: Style in ResourceDictionary

**에러 내용**:
```
AVLN3000: Unable to find suitable setter or adder for property Content of type
Avalonia.Base:Avalonia.Controls.ResourceDictionary for argument
Avalonia.Base:Avalonia.Styling.Style
```

**원인**: AvaloniaUI에서 `Style` 요소는 `ResourceDictionary` 내에 직접 배치할 수 없음

**수정 방법**:
- 독립적인 `Style` 선언을 제거하고, 버튼에 `Theme="{StaticResource NextLevelButtonTheme}"`을 직접 적용
- `NextLevelButtonTheme`를 `ControlTheme`으로 정의하여 ResourceDictionary에 배치

**변경 전**:
```xml
<!-- ResourceDictionary 내부에 직접 Style 배치 (오류) -->
<Style Selector="controls|LevelUpNotification /template/ Button#PART_NextButton">
    <Setter Property="Theme" Value="{StaticResource NextLevelButtonTheme}"/>
</Style>
```

**변경 후**:
```xml
<!-- ControlTemplate 내에서 직접 Theme 적용 -->
<Button x:Name="PART_NextButton"
        Theme="{StaticResource NextLevelButtonTheme}"
        .../>
```

### 에러 2: StyleInclude vs ResourceInclude

**에러 내용**:
```
AVLN2000: Resource "avares://NervousZebra0.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the
"NervousZebra0.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: `App.axaml`에서 `StyleInclude`를 사용하여 `ResourceDictionary` 타입을 로드하려 함

**수정 방법**: `Application.Styles`의 `StyleInclude` 대신 `Application.Resources`의 `ResourceInclude` 사용

**변경 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://NervousZebra0.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**변경 후**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://NervousZebra0.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. `:loaded` 의사 클래스 애니메이션

**문제**: AvaloniaUI에서 `:loaded` 의사 클래스는 컨트롤이 시각적 트리에 부착될 때 트리거됨. 하지만 복잡한 시나리오에서 애니메이션이 예상대로 재생되지 않을 수 있음.

**확인 필요**:
- 컨트롤이 처음 표시될 때 슬라이드 다운 애니메이션이 정상 동작하는지
- 컨트롤이 다시 표시될 때 애니메이션이 재실행되는지

### 2. CSS rotateX 미구현

**문제**: 원본 CSS에서 `rotateX(90deg)` 3D 회전을 사용했으나, AvaloniaUI는 2D 변환만 기본 지원. `RotateTransform`은 Z축 기준 2D 회전만 제공.

**현재 구현**: 텍스트 페이드인 애니메이션으로 대체 (`Opacity` 0 → 1)

**영향**: 원본의 3D 플립 효과 대신 단순 페이드인 효과로 변경됨

### 3. BoxShadow 호환성

**문제**: CSS `box-shadow`와 AvaloniaUI `BoxShadow` 구문 차이

**현재 구현**: `BoxShadow="0 8 24 #33000000"` (X, Y, Blur, Color)

**확인 필요**: 그림자 spread 값이 지원되지 않아 원본과 미세한 차이 발생 가능

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 |
|---------|-----------|
| `background-color` | `Background` |
| `border-radius` | `CornerRadius` |
| `box-shadow` | `BoxShadow` |
| `transform: translateY()` | `TranslateTransform.Y` |
| `transform: scale()` | `ScaleTransform.ScaleX/Y` |
| `transition` | `Style.Animations` with Duration |
| `:hover` | `:pointerover` |
| `animation: slide-down` | `Style.Animations` with KeyFrames |

## 빌드 결과

- **빌드 성공**: ✅
- **경고**: 0개
- **오류**: 0개 (수정 후)
