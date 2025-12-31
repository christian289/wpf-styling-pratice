# SpicyJellyfish41 AvaloniaUI 변환 로그

## 프로젝트 정보

- **소스**: Uiverse.io by ahmedyasserdev
- **컨트롤 타입**: Hamburger Button (햄버거 메뉴 토글 버튼)
- **변환 날짜**: 2026-01-01
- **원본 위치**: `WebToDesktop/source/20251231_SpicyJellyfish41/`

## 컴파일 에러 및 수정 내역

### 에러 1: Transform 요소의 x:Name 속성

**에러 내용**:
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**:
- AvaloniaUI에서 `TranslateTransform`, `RotateTransform` 등 Transform 요소에 `x:Name` 속성을 직접 사용할 수 없음
- WPF에서는 가능하지만 Avalonia에서는 지원하지 않는 패턴

**수정 방법**:
- Transform 요소에서 `x:Name` 속성 제거
- 애니메이션에서 `RenderTransform` 속성 전체를 교체하는 방식으로 변경

**수정 전**:
```xml
<Border.RenderTransform>
    <TransformGroup>
        <TranslateTransform x:Name="Line1Translate" Y="0" />
        <RotateTransform x:Name="Line1Rotate" Angle="0" />
    </TransformGroup>
</Border.RenderTransform>
```

**수정 후**:
```xml
<Border.RenderTransform>
    <TransformGroup>
        <TranslateTransform Y="0" />
        <RotateTransform Angle="0" />
    </TransformGroup>
</Border.RenderTransform>
```

---

### 에러 2: StyleInclude vs ResourceInclude

**에러 내용**:
```
AVLN2000: Resource "avares://SpicyJellyfish41.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "SpicyJellyfish41.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하면 `IStyle` 타입만 로드 가능
- `ControlTheme`이 포함된 `ResourceDictionary`는 `IStyle`이 아님

**수정 방법**:
- `StyleInclude` 대신 `Application.Resources`에서 `ResourceInclude` 사용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SpicyJellyfish41.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://SpicyJellyfish41.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 Easing 함수 호환성

**위험도**: 낮음

**내용**:
- CSS의 `cubic-bezier(0.68, -0.55, 0.265, 1.55)` Easing을 Avalonia의 문자열 형식 `"0.68,-0.55,0.265,1.55"`로 변환
- 음수 값을 포함한 cubic-bezier가 Avalonia에서 정상 동작하는지 런타임 확인 필요

**확인 방법**: 애플리케이션 실행 후 버튼 클릭 시 애니메이션이 부드럽게 동작하는지 확인

---

### 2. FillMode="Forward" 애니메이션 상태 유지

**위험도**: 중간

**내용**:
- `FillMode="Forward"` 설정으로 애니메이션 종료 후 최종 상태 유지
- `:checked`와 `:unchecked` 상태 전환 시 애니메이션이 제대로 초기화되지 않을 가능성

**확인 방법**: 버튼을 여러 번 토글하여 애니메이션이 일관되게 동작하는지 확인

---

### 3. TransformGroup 내 Transform 순서

**위험도**: 낮음

**내용**:
- `TranslateTransform` → `RotateTransform` 순서로 적용
- Transform 순서에 따라 시각적 결과가 달라질 수 있음
- CSS의 `translateY(8px) rotate(45deg)`와 동일한 효과인지 확인 필요

**확인 방법**: 체크 상태에서 선들이 정확히 X 모양을 형성하는지 확인

---

## 빌드 결과

- **최종 상태**: 빌드 성공 (경고 0, 오류 0)
- **출력 경로**:
  - `SpicyJellyfish41.Avalonia.Lib/bin/Debug/net9.0/SpicyJellyfish41.Avalonia.Lib.dll`
  - `SpicyJellyfish41.Avalonia.Gallery/bin/Debug/net9.0/SpicyJellyfish41.Avalonia.Gallery.dll`
