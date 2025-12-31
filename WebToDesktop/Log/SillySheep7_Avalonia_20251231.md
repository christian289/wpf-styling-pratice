# SillySheep7 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by Subaashbala
- **태그**: skeuomorphism, realistic, radio, rotate, click effect
- **변환일**: 2025-12-31
- **AvaloniaUI 버전**: 11.2.3
- **.NET 버전**: 9.0

## 컨트롤 설명

스큐어모피즘(Skeuomorphism) 스타일의 회전 노브 라디오 버튼 컨트롤입니다.
5개의 라디오 버튼 값(1-5)에 따라 중앙의 노브가 회전하며, CSS의 cubic-bezier 이징을 적용한 부드러운 애니메이션 효과를 제공합니다.

## 컴파일 에러 및 수정

### 에러 1: RotateTransform에 x:Name 속성 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
```

**원인**:
AvaloniaUI에서 `RotateTransform`은 `AvaloniaObject`가 아니므로 `x:Name` 속성을 사용할 수 없고, XAML 바인딩도 직접 지원되지 않습니다.

**수정 방법**:
AXAML에서 `x:Name`과 바인딩을 제거하고, 코드 비하인드(`OnApplyTemplate`)에서 `RotateTransform`을 직접 생성하여 `Border.RenderTransform`에 할당합니다.

```csharp
// 수정 전 (AXAML)
<Border.RenderTransform>
    <RotateTransform x:Name="PART_KnobRotation" Angle="{Binding KnobRotationAngle, ...}" />
</Border.RenderTransform>

// 수정 후 (C# 코드)
_knobBorder = e.NameScope.Find<Border>("PART_Knob");
if (_knobBorder != null)
{
    _knobRotateTransform = new RotateTransform(KnobRotationAngle);
    _knobBorder.RenderTransform = _knobRotateTransform;
}
```

### 에러 2: StyleInclude vs ResourceInclude

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://..." is defined as "Avalonia.Controls.ResourceDictionary" type ... but expected "Avalonia.Styling.IStyle"
```

**원인**:
`Application.Styles`에서 `StyleInclude`는 `IStyle` 타입을 기대하지만, `Generic.axaml`은 `ResourceDictionary` 타입입니다.

**수정 방법**:
`Application.Resources`에서 `ResourceDictionary.MergedDictionaries`를 사용하여 `ResourceInclude`로 병합합니다.

```xml
<!-- 수정 전 -->
<Application.Styles>
    <StyleInclude Source="avares://..." />
</Application.Styles>

<!-- 수정 후 -->
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://..." />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. 노브 회전 애니메이션
- **가능성**: `TransformOperationsTransition`이 `RotateTransform`에 직접 적용될 때 애니메이션이 작동하지 않을 수 있음
- **확인 방법**: 앱 실행 후 라디오 버튼 클릭 시 노브가 부드럽게 회전하는지 확인
- **대안**: 애니메이션이 작동하지 않으면 `Animation`/`KeyFrame`을 사용한 명시적 애니메이션으로 전환

### 2. 라디오 버튼 위치
- **가능성**: CSS의 `%` 기반 위치 지정을 `px` 고정값으로 변환했으므로, 컨트롤 크기 변경 시 라디오 버튼 위치가 맞지 않을 수 있음
- **확인 방법**: 컨트롤의 Width/Height를 변경해보고 레이아웃 확인
- **대안**: Canvas + 바인딩을 사용한 상대 위치 계산으로 변경

### 3. BoxShadow 렌더링
- **가능성**: CSS의 복잡한 box-shadow (multiple shadows, inset)가 AvaloniaUI에서 완전히 동일하게 렌더링되지 않을 수 있음
- **확인 방법**: 앱 실행 후 노브 중앙 핸들의 그림자 효과 확인

### 4. RadioButton GroupName
- **가능성**: ControlTemplate 내에서 `GroupName`이 제대로 작동하지 않을 수 있음
- **확인 방법**: 라디오 버튼들이 상호 배타적으로 선택되는지 확인

## 프로젝트 구조

```
SillySheep7.Avalonia.slnx
├── SillySheep7.Avalonia.Lib/
│   ├── Controls/
│   │   └── SillySheep7KnobRadio.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SillySheep7KnobRadio.axaml
└── SillySheep7.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 및 실행

```bash
cd WebToDesktop/Output/SillySheep7/AvaloniaUI
dotnet build SillySheep7.Avalonia.slnx
dotnet run --project SillySheep7.Avalonia.Gallery
```
