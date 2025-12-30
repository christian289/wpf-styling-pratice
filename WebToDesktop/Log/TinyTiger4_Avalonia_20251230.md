# TinyTiger4 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: HTML/CSS (uiverse.io by Pradeepsaranbishnoi)
- **원본 이름**: Jordan (flashy, green, bubble, radio, click)
- **변환 일자**: 2025-12-30
- **대상 플랫폼**: AvaloniaUI 11.2.2 / .NET 9.0

## 컴파일 에러 및 수정

### 에러 1: Avalonia.Sdk를 찾을 수 없음

**에러 메시지**:
```
error MSB4236: 지정된 'Avalonia.Sdk/11.2.2' SDK를 찾을 수 없습니다.
```

**원인**: Avalonia.Sdk workload가 설치되지 않은 환경에서 `Sdk="Avalonia.Sdk/11.2.2"` 사용

**수정 방법**:
- `Sdk="Microsoft.NET.Sdk"`로 변경
- NuGet 패키지로 Avalonia 참조 추가

```xml
<!-- 수정 전 -->
<Project Sdk="Avalonia.Sdk/11.2.2">

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

---

### 에러 2: GetLogicalChildren 메서드를 찾을 수 없음

**에러 메시지**:
```
error CS1061: 'StyledElement'에는 'GetLogicalChildren'에 대한 정의가 포함되어 있지 않습니다.
```

**원인**: `GetLogicalChildren()` 확장 메서드 사용 시 namespace 누락

**수정 방법**: `using Avalonia.LogicalTree;` 추가

```csharp
// 수정 전
using Avalonia;
using Avalonia.Controls.Primitives;

// 수정 후
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
```

---

### 에러 3: StyleInclude에 ResourceDictionary 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "ResourceDictionary" type, but expected "IStyle".
```

**원인**: Avalonia 11에서 `StyleInclude`는 `IStyle` 구현체만 참조 가능

**수정 방법**: `ResourceDictionary`를 `Styles` 루트 요소로 변경

```xml
<!-- 수정 전 -->
<ResourceDictionary xmlns="https://github.com/avaloniaui">
    <Color x:Key="...">...</Color>
    <ControlTheme x:Key="..." TargetType="...">
</ResourceDictionary>

<!-- 수정 후 -->
<Styles xmlns="https://github.com/avaloniaui">
    <Styles.Resources>
        <Color x:Key="...">...</Color>
    </Styles.Resources>
    <Style Selector="controls|TinyTiger4RadioButton">
        ...
    </Style>
</Styles>
```

---

## RadialGradientBrush 변환 주의사항

CSS의 `radial-gradient(circle at X% Y%, ...)` 패턴에서 center 위치가 다른 경우가 있습니다.

**AvaloniaUI Issue #19888**: GradientOrigin과 Center 값이 다르면 정상 동작하지 않음

본 변환에서는 모든 RadialGradientBrush에 대해 **GradientOrigin = Center** 규칙을 적용하였습니다.

```xml
<!-- CSS: radial-gradient(circle at 70% 30%, ...) -->
<RadialGradientBrush GradientOrigin="70%,30%" Center="70%,30%" RadiusX="50%" RadiusY="50%">
```

---

## 잠재적 런타임 에러

### 1. 애니메이션 동작 차이

CSS의 `@keyframes radio` 애니메이션이 AvaloniaUI Animation으로 변환되었습니다.
원본 CSS는 체크 해제 시 scale(1) → scale(1.7)로 확대되면서 사라지는 효과입니다.

**확인 필요**:
- 애니메이션 타이밍 및 이징 함수 동작 검증
- `:not(:checked)` 셀렉터 초기 상태에서의 애니메이션 트리거 여부

### 2. RadialGradientBrush 렌더링

CSS의 다중 `radial-gradient` 레이어를 개별 Ellipse로 분리하여 구현했습니다.

**확인 필요**:
- 그라데이션 색상 및 투명도 정확도
- 레이어 순서에 따른 시각적 효과

### 3. IsChecked 상태 pseudo-class (해결됨)

`:checked` pseudo-class가 커스텀 컨트롤에서 동작하려면 `PseudoClasses`를 수동 설정해야 합니다.

**해결 방법**: `UpdatePseudoClasses` 메서드 추가

```csharp
protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
{
    base.OnPropertyChanged(change);

    if (change.Property == IsCheckedProperty)
    {
        var isChecked = change.GetNewValue<bool>();
        UpdatePseudoClasses(isChecked);
        // ...
    }
}

protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
{
    base.OnApplyTemplate(e);
    UpdatePseudoClasses(IsChecked);
}

private void UpdatePseudoClasses(bool isChecked)
{
    PseudoClasses.Set(":checked", isChecked);
}
```

---

## 생성된 파일 목록

```
TinyTiger4/AvaloniaUI/
├── TinyTiger4.Avalonia.slnx
├── TinyTiger4.Avalonia.Lib/
│   ├── TinyTiger4.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── TinyTiger4RadioButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TinyTiger4RadioButton.axaml
└── TinyTiger4.Avalonia.Gallery/
    ├── TinyTiger4.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
