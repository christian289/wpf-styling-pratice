# AverageElephant52 - AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by seyed-mohsen-mousavi
- **태그**: input, shadow, gradient
- **변환일**: 2025-12-22
- **컨트롤명**: SearchBar (그라데이션 효과가 있는 검색바)

## 컴파일 에러 및 수정 내용

### 에러 1: Avalonia.Sdk를 찾을 수 없음

**에러 메시지**:
```
error MSB4236: 지정된 'Avalonia.Sdk/11.2.2' SDK를 찾을 수 없습니다.
```

**원인**: `Avalonia.Sdk`가 설치되어 있지 않은 환경에서 `Sdk="Avalonia.Sdk/11.2.2"` 사용

**수정 방법**:
- `Sdk="Microsoft.NET.Sdk"` 사용
- PackageReference로 Avalonia 패키지 직접 참조

```xml
<!-- 수정 전 -->
<Project Sdk="Avalonia.Sdk/11.2.2">

<!-- 수정 후 -->
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Avalonia" Version="11.2.2" />
  </ItemGroup>
</Project>
```

---

### 에러 2: SkewTransform에 x:Name 속성 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.SkewTransform Line 53, position 26.
```

**원인**: AvaloniaUI에서 Transform 객체에 x:Name을 직접 지정할 수 없음

**수정 방법**:
- SkewTransform에서 x:Name 제거
- Style.Animations에서 Border의 RenderTransform 속성을 직접 애니메이션

```xml
<!-- 수정 전 -->
<Border.RenderTransform>
    <SkewTransform x:Name="OuterSkew" AngleX="0" />
</Border.RenderTransform>
...
<Style Selector="^:focus-within /template/ SkewTransform#OuterSkew">
    <Style.Animations>
        <Animation Duration="0:0:0.3">
            <KeyFrame Cue="100%">
                <Setter Property="AngleX" Value="10" />
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>

<!-- 수정 후 -->
<Border.RenderTransform>
    <SkewTransform AngleX="0" />
</Border.RenderTransform>
...
<Style Selector="^:focus-within /template/ Border#PART_OuterBorder">
    <Style.Animations>
        <Animation Duration="0:0:0.3">
            <KeyFrame Cue="100%">
                <Setter Property="RenderTransform">
                    <SkewTransform AngleX="10" />
                </Setter>
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>
```

---

### 에러 3: Width/Height에 퍼센트 값 사용 불가

**에러 메시지**:
```
Avalonia error AVLN1000: The input string '65%' was not in a correct format. Line 78, position 33.
Avalonia error AVLN1000: The input string '60%' was not in a correct format. Line 79, position 33.
```

**원인**: AvaloniaUI Border의 Width/Height 속성에 퍼센트 값 직접 사용 불가

**수정 방법**: Grid의 ColumnDefinitions/RowDefinitions를 사용하여 비율 지정

```xml
<!-- 수정 전 -->
<Border Width="65%" Height="60%" ... />

<!-- 수정 후 (65% ≈ 1.857:1, 60% ≈ 1.5:1) -->
<Grid ColumnDefinitions="*,1.857*" RowDefinitions="1.5*,*">
    <Border Grid.Column="1" Grid.Row="0" ... />
</Grid>
```

---

### 에러 4: StyleInclude로 ResourceDictionary 로드 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://...Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type ... but expected "Avalonia.Styling.IStyle".
```

**원인**: ResourceDictionary는 StyleInclude가 아닌 ResourceInclude로 로드해야 함

**수정 방법**: App.axaml에서 Application.Resources 섹션에 ResourceInclude 사용

```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://.../Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
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

---

## 잠재적 런타임 오류 가능성

### 1. RadialGradientBrush 렌더링 이슈

**상황**: CSS의 `radial-gradient(circle 80px at 80% -10%, ...)` 변환 시

**주의사항**:
- AvaloniaUI Issue #19888로 인해 GradientOrigin과 Center 값이 반드시 동일해야 함
- 현재 코드에서 동일하게 설정함 (예: `GradientOrigin="80%,-10%" Center="80%,-10%"`)
- 하지만 RadiusX, RadiusY 값이 CSS의 circle 80px와 정확히 매칭되지 않을 수 있음

**확인 필요**: 그라데이션 모양이 원본 CSS와 시각적으로 일치하는지 확인 필요

### 2. Focus 상태 애니메이션

**상황**: `:focus-within` 셀렉터로 skew 변환 애니메이션 적용

**잠재적 이슈**:
- CSS에서는 `transition: all 0.3s linear`로 부드러운 전환
- AvaloniaUI에서는 Animation으로 구현했으나, 포커스 해제 시 원래 상태로 돌아가는 애니메이션이 없음
- `FillMode="Forward"` 사용으로 애니메이션 종료 후 상태 유지

**확인 필요**: 포커스 해제 시 원래 상태로 부드럽게 전환되는지 확인 필요

### 3. TextBox 커스텀 템플릿

**상황**: 내부 TextBox에 커스텀 템플릿 적용

**잠재적 이슈**:
- 기본 TextBox 기능(선택, 복사/붙여넣기 등)이 정상 동작하지 않을 수 있음
- TextPresenter 바인딩이 올바르게 작동하는지 확인 필요

---

## 생성된 파일 목록

```
WebToDesktop/Output/AverageElephant52/AvaloniaUI/
├── AverageElephant52.Avalonia.slnx
├── AverageElephant52.Avalonia.Lib/
│   ├── AverageElephant52.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── SearchBar.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SearchBar.axaml
└── AverageElephant52.Avalonia.Gallery/
    ├── AverageElephant52.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **오류**: 0개
