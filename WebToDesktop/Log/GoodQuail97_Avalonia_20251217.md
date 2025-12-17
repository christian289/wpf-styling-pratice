# GoodQuail97 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by radwakhalil22
- **변환 날짜**: 2025-12-17
- **컨트롤 이름**: NeonRadioButton
- **설명**: Neon Glow 효과가 있는 RadioButton 커스텀 컨트롤

## 프로젝트 구조

```
WebToDesktop/Output/GoodQuail97/AvaloniaUI/
├── GoodQuail97.Avalonia.slnx
├── GoodQuail97.Avalonia.Lib/
│   ├── Controls/
│   │   └── NeonRadioButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── NeonRadioButton.axaml
└── GoodQuail97.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내역

### 에러 1: GetLogicalChildren 메서드 찾을 수 없음

**에러 메시지**:
```
error CS1061: 'StyledElement'에는 'GetLogicalChildren'에 대한 정의가 포함되어 있지 않고...
```

**원인**: `GetLogicalChildren`은 `ILogical` 인터페이스의 확장 메서드로, 별도의 네임스페이스 참조 필요

**수정 방법**:
```csharp
// NeonRadioButton.cs 상단에 추가
using Avalonia.LogicalTree;
```

---

### 에러 2: ScaleTransform에 x:Name 속성 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
```

**원인**: AvaloniaUI에서 `ScaleTransform`은 `x:Name` 속성을 직접 지원하지 않음

**수정 방법**:
- 템플릿 내부 `ScaleTransform`에서 `x:Name` 제거
- 컨트롤 자체에 `RenderTransform` 속성 설정
- 애니메이션은 컨트롤 레벨에서 적용

```xml
<!-- 수정 전 -->
<Border.RenderTransform>
    <ScaleTransform x:Name="MainScaleTransform" ScaleX="1" ScaleY="1"/>
</Border.RenderTransform>

<!-- 수정 후 -->
<Setter Property="RenderTransform">
    <ScaleTransform ScaleX="1" ScaleY="1"/>
</Setter>
```

---

### 에러 3: STAThread 어트리뷰트 찾을 수 없음

**에러 메시지**:
```
error CS0246: 'STAThreadAttribute' 형식 또는 네임스페이스 이름을 찾을 수 없습니다.
```

**원인**: `STAThread`는 `System` 네임스페이스에 정의되어 있음

**수정 방법**:
```csharp
// Program.cs 상단에 추가
using System;
```

---

### 에러 4: ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://GoodQuail97.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type... but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles`에는 `IStyle` 구현체만 추가 가능. `ResourceDictionary`는 `IStyle`이 아님

**수정 방법**:
```xml
<!-- 수정 전 (Generic.axaml) -->
<ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..."/>
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>

<!-- 수정 후 -->
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="avares://GoodQuail97.Avalonia.Lib/Themes/NeonRadioButton.axaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## 잠재적 런타임 에러 가능성

### 1. BoxShadow 애니메이션

**위험도**: 중간

**설명**: CSS의 `box-shadow` 애니메이션을 AvaloniaUI `BoxShadow` 속성 애니메이션으로 변환함. 복합 그림자(여러 개의 shadow)가 애니메이션될 때 성능 이슈 또는 시각적 깜빡임이 발생할 수 있음.

**확인 필요**: 실제 실행 시 glow 애니메이션이 부드럽게 작동하는지 확인

---

### 2. RenderTransform 애니메이션 복원

**위험도**: 낮음

**설명**: 호버 상태에서 스케일 애니메이션 후 원래 크기로 복원되는 애니메이션이 FillMode="Forward"로만 설정됨. 마우스가 컨트롤을 벗어날 때 자동으로 원래 크기로 돌아가지 않을 수 있음.

**확인 필요**: 호버 해제 시 스케일이 1.0으로 복원되는지 확인

---

### 3. RadioButton 그룹 동작

**위험도**: 낮음

**설명**: 커스텀으로 구현한 `GroupName` 기반 상호 배제 로직이 복잡한 레이아웃에서 예상대로 동작하지 않을 수 있음 (Parent가 직접적인 컨테이너가 아닌 경우).

**확인 필요**: 여러 NeonRadioButton이 같은 그룹 내에서 하나만 선택되는지 확인

## CSS to AXAML 변환 매핑

| CSS | AXAML |
|-----|-------|
| `border-radius: 50px` | `CornerRadius="15"` |
| `background-color: rgba(5,19,16,0.3)` | `Background="#4D051310"` |
| `box-shadow: 5px 5px 20px rgb(...)` | `BoxShadow="5 5 20 #5D34A8, -5 -5 20 #5D34A8"` |
| `transform: scale(0.9)` | `RenderTransform` + `ScaleTransform` |
| `animation: glow 1s infinite` | `Style.Animations` + `Animation` |
| `:hover` pseudo-class | `:pointerover` selector |
| `:checked` pseudo-class | `[IsChecked=True]` selector |

## 빌드 결과

**최종 빌드**: 성공 (경고 0, 오류 0)

```
dotnet build GoodQuail97.Avalonia.slnx
빌드했습니다.
    경고 0개
    오류 0개
```
