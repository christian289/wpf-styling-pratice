# TerribleKangaroo96 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by Cornerstone-04
- **컨트롤 유형**: Circle CheckBox
- **변환 날짜**: 2025-12-21

## 원본 HTML/CSS 분석

원형 체크박스 컨트롤로, 다음 특징을 가짐:
- 30x30px 크기의 원형 보더
- 체크 시 배경색이 `#212fab`로 채워짐
- 체크마크는 L자 모양을 45도 회전하여 표현
- 0.3초 linear 트랜지션 애니메이션

## 컴파일 에러 및 수정

### 에러 1: StyleInclude vs ResourceInclude

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://TerribleKangaroo96.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "TerribleKangaroo96.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Application.Styles` 내에서 `StyleInclude`를 사용하면 `IStyle` 타입이 필요
- `ResourceDictionary`는 `IStyle`이 아니므로 타입 불일치 발생

**수정 방법**:
- `Application.Styles`에서 `StyleInclude` 제거
- `Application.Resources`에 `ResourceDictionary.MergedDictionaries`로 `ResourceInclude` 사용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://TerribleKangaroo96.Avalonia.Lib/Themes/Generic.axaml"/>
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
            <ResourceInclude Source="avares://TerribleKangaroo96.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성

### 1. 체크마크 애니메이션

**상태**: 확인 필요

CSS의 `transform: rotate(45deg) scale(0) translate(-50%, -50%)` 복합 변환을 AvaloniaUI의 `TransformGroup`으로 변환했으나, `translate` 부분은 `RenderTransformOrigin`과 `Margin`으로 대체함. 실제 시각적 결과가 원본과 다를 수 있음.

### 2. 트랜지션 애니메이션

**상태**: 확인 필요

CSS의 `transition: all 0.3s linear`를 AvaloniaUI `Transitions`로 변환했으나, `ScaleTransform`과 `RotateTransform`의 트랜지션은 `Transitions`에서 직접 지원되지 않음. 체크 상태 전환 시 스케일/회전 애니메이션이 즉시 적용될 수 있음.

### 3. ControlTheme 적용

**상태**: 확인 필요

`ControlTheme`이 `CircleCheckBox` 컨트롤에 자동으로 적용되는지 확인 필요. 적용되지 않는 경우 명시적으로 `Theme="{StaticResource ...}"` 설정이 필요할 수 있음.

## 생성된 파일 목록

```
TerribleKangaroo96.Avalonia.slnx
TerribleKangaroo96.Avalonia.Lib/
├── TerribleKangaroo96.Avalonia.Lib.csproj
├── Controls/
│   └── CircleCheckBox.cs
└── Themes/
    ├── Generic.axaml
    └── CircleCheckBox.axaml
TerribleKangaroo96.Avalonia.Gallery/
├── TerribleKangaroo96.Avalonia.Gallery.csproj
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
