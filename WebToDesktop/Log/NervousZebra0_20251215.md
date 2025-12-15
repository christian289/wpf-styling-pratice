# NervousZebra0 변환 로그

## 변환 일시
2025-12-15

## 원본 정보
- 원작자: WittyHydra
- 원본 링크: https://uiverse.io/WittyHydra/nervous-zebra-0
- 카테고리: Notifications

## 컴파일 에러 및 수정 내용

### 에러 1: MC4111 - Trigger 대상 'ButtonShadow'을(를) 찾을 수 없습니다

**에러 내용:**
```
NervousZebra0.Wpf.UI\Themes\NervousZebra0.xaml(106,91): error MC4111:
Trigger 대상 'ButtonShadow'을(를) 찾을 수 없습니다.
대상은 모든 Setters, Triggers 또는 대상을 사용하는 Conditions 앞에 표시되어야 합니다.
```

**원인:**
Button의 내부 ControlTemplate에서 정의된 `x:Name="ButtonShadow"` (DropShadowEffect)를 외부 ControlTemplate.Triggers에서 참조할 수 없음.

**수정 방법:**
DropShadowEffect의 BlurRadius 속성을 개별적으로 수정하는 대신, Effect 전체를 새 DropShadowEffect 객체로 교체하도록 변경:
```xml
<!-- 수정 전 -->
<Setter TargetName="ButtonShadow" Property="BlurRadius" Value="15"/>

<!-- 수정 후 -->
<Setter TargetName="ButtonBorder" Property="Effect">
    <Setter.Value>
        <DropShadowEffect Color="#888888" BlurRadius="15" ShadowDepth="0" Direction="0"/>
    </Setter.Value>
</Setter>
```

---

### 에러 2: MC3072 - 'Spacing' 속성이 없습니다

**에러 내용:**
```
NervousZebra0.Wpf.Gallery\MainWindow.xaml(12,77): error MC3072:
XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
WPF의 StackPanel에는 `Spacing` 속성이 없음 (AvaloniaUI에는 존재).

**수정 방법:**
Spacing 속성 대신 각 요소에 Margin을 적용:
```xml
<!-- 수정 전 -->
<StackPanel Spacing="20">

<!-- 수정 후 -->
<StackPanel>
    <controls:NervousZebra0 Margin="0,0,0,20"/>
```

---

## 잠재적 런타임 에러 가능성

### 1. ColorAnimation 타겟 속성 경로 문제
- **위치:** `NervousZebra0.xaml` - MouseEnter/MouseLeave EventTrigger
- **내용:** `(Border.Background).(SolidColorBrush.Color)` 경로로 애니메이션 적용
- **가능성:** TemplateBinding으로 Background가 바인딩된 상태에서 ColorAnimation이 실행될 때 Frozen 상태의 브러시에 애니메이션 적용 시 예외 발생 가능
- **확인 필요:** 실제 실행하여 Hover 시 색상 전환 애니메이션 동작 확인 필요

### 2. ScaleTransform Y축 스케일 0부터 시작
- **위치:** `NervousZebra0.xaml` - TitleScale
- **내용:** ScaleY="0"으로 시작하여 애니메이션으로 1까지 증가
- **가능성:** 초기 상태에서 텍스트가 완전히 보이지 않음 (의도된 동작이나 확인 필요)

### 3. CSS rotateX(90deg) → WPF ScaleY 변환
- **원본 CSS:** `transform: rotateX(90deg)` (3D 회전)
- **WPF 구현:** ScaleY로 대체 (2D 스케일)
- **차이점:** CSS의 3D 회전 효과와 WPF의 2D 스케일 효과는 시각적으로 다름. WPF에서 3D 효과를 구현하려면 Viewport3D 사용 필요

---

## 변환 완료 파일 목록
- `NervousZebra0.Wpf.UI/Controls/NervousZebra0.cs`
- `NervousZebra0.Wpf.UI/Themes/NervousZebra0Resources.xaml`
- `NervousZebra0.Wpf.UI/Themes/NervousZebra0.xaml`
- `NervousZebra0.Wpf.UI/Themes/Generic.xaml` (수정됨)
- `NervousZebra0.Wpf.Gallery/App.xaml` (수정됨)
- `NervousZebra0.Wpf.Gallery/MainWindow.xaml` (수정됨)
