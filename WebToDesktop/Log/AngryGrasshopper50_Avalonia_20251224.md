# AngryGrasshopper50 - AvaloniaUI 변환 로그

## 변환 정보

- **변환일**: 2024-12-24
- **원본**: HTML/CSS (Uiverse.io by 3bdel3ziz-T)
- **대상**: AvaloniaUI 11.2.2 / .NET 9.0
- **컨트롤 유형**: 햄버거 메뉴 아이콘 (BurgerIcon)

## 컨트롤 설명

클릭 시 햄버거 메뉴 아이콘(≡)이 X 표시로 애니메이션되는 토글 버튼입니다.

### 기능
- 3개의 수평선으로 구성된 햄버거 아이콘
- 클릭 시 상단/하단 라인이 45도 회전하여 X 형태로 변환
- 중앙 라인은 축소되어 사라짐
- Hover 시 배경색 변경 및 원형으로 변환
- Pressed 상태에서 0.95배 축소

## 컴파일 에러 및 수정 내용

### 에러 1: Transform 객체에 x:Name 사용 불가

**에러 메시지:**
```
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.TranslateTransform
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
```

**원인:**
Avalonia에서 Transform 객체(TranslateTransform, RotateTransform, ScaleTransform)에는 x:Name 속성을 사용할 수 없습니다. WPF와 달리 Avalonia의 Transform 클래스는 AvaloniaObject를 상속하지 않아 Name 속성을 지원하지 않습니다.

**수정 방법:**
Transform 객체에서 x:Name 속성을 제거하고, 애니메이션에서 RenderTransform 속성 전체를 설정하는 방식으로 변경했습니다.

```xml
<!-- 수정 전 (에러 발생) -->
<Border.RenderTransform>
    <TransformGroup>
        <TranslateTransform x:Name="TopLineTranslate" Y="-8"/>
        <RotateTransform x:Name="TopLineRotate" Angle="0"/>
    </TransformGroup>
</Border.RenderTransform>

<!-- 수정 후 -->
<Border.RenderTransform>
    <TransformGroup>
        <TranslateTransform Y="-8"/>
        <RotateTransform Angle="0"/>
    </TransformGroup>
</Border.RenderTransform>
```

### 에러 2: ResourceDictionary를 Application.Styles에 직접 포함 불가

**에러 메시지:**
```
AVLN2000: Resource "avares://AngryGrasshopper50.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "AngryGrasshopper50.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인:**
Avalonia의 Application.Styles는 IStyle을 구현하는 객체만 포함할 수 있습니다. ResourceDictionary는 IStyle이 아니므로 StyleInclude로 직접 포함할 수 없습니다.

**수정 방법:**
ResourceDictionary는 Application.Resources에 병합하고, Styles에는 FluentTheme만 유지합니다.

```xml
<!-- 수정 전 (에러 발생) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://AngryGrasshopper50.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://AngryGrasshopper50.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 에러 가능성

### 1. 애니메이션 상태 전환 문제

**가능성**: 중간
**설명**:
- `^:unchecked` 애니메이션이 초기 로드 시에도 실행될 수 있습니다.
- 애플리케이션 시작 시 컨트롤이 unchecked 상태로 초기화되면서 unchecked 애니메이션이 한 번 실행될 수 있습니다.

**확인 필요**:
- 애플리케이션 시작 시 라인 위치가 올바르게 표시되는지 확인
- checked → unchecked 전환 시 애니메이션이 정상 동작하는지 확인

### 2. TransformGroup 애니메이션 보간 문제

**가능성**: 낮음
**설명**:
- Avalonia에서 TransformGroup 내의 여러 Transform을 동시에 애니메이션할 때 보간이 원활하지 않을 수 있습니다.
- 특히 TranslateTransform과 RotateTransform이 함께 변경되는 경우 중간 프레임에서 시각적 이상이 발생할 수 있습니다.

**확인 필요**:
- 햄버거 → X 전환 시 라인이 부드럽게 이동하고 회전하는지 확인
- 50% 지점에서 Y=0으로 이동 후 회전이 시작되는지 확인

### 3. FillMode="Forward" 동작

**가능성**: 낮음
**설명**:
- FillMode="Forward"가 설정되어 애니메이션 종료 후 최종 값이 유지되어야 합니다.
- 하지만 상태 전환 시 이전 애니메이션 값과 충돌할 수 있습니다.

**확인 필요**:
- 빠르게 토글을 반복할 때 애니메이션이 올바르게 시작점을 잡는지 확인

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 프로젝트 구조

```
WebToDesktop/Output/AngryGrasshopper50/AvaloniaUI/
├── AngryGrasshopper50.Avalonia.slnx
├── AngryGrasshopper50.Avalonia.Lib/
│   ├── AngryGrasshopper50.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── BurgerIcon.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BurgerIcon.axaml
└── AngryGrasshopper50.Avalonia.Gallery/
    ├── AngryGrasshopper50.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── Program.cs
    └── app.manifest
```

## 실행 방법

```bash
cd WebToDesktop/Output/AngryGrasshopper50/AvaloniaUI
dotnet run --project AngryGrasshopper50.Avalonia.Gallery
```
