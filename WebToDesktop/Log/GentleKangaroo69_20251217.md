# GentleKangaroo69 변환 로그

## 변환 일시
2025-12-17

## 원본 정보
- 원작자: tursynbek
- 원본 링크: https://uiverse.io/tursynbek/gentle-kangaroo-69
- 분류: Notifications

---

## 컴파일 에러 및 수정 내용

### 에러 1: MC4111 - Trigger 대상을 찾을 수 없음

**에러 메시지:**
```
Trigger 대상 'TextTranslate'을(를) 찾을 수 없습니다. 대상은 모든 Setters, Triggers 또는 대상을 사용하는 Conditions 앞에 표시되어야 합니다.
```

**원인:**
- WPF에서 `Setter`의 `TargetName`은 Visual Tree의 요소(UIElement)에만 적용 가능
- `TranslateTransform`과 같은 Transform 객체는 Visual Tree의 일부가 아니므로 직접 참조 불가
- `x:Name="TextTranslate"`로 지정된 Transform을 Trigger의 Setter에서 직접 참조하려고 시도함

**수정 방법:**
- Transform의 x:Name 제거
- Setter 대신 `StopStoryboard`와 애니메이션을 사용하여 동작 구현
- `(UIElement.RenderTransform).(TranslateTransform.Y)` 형태의 Property Path 사용

**수정 전:**
```xml
<TranslateTransform x:Name="TextTranslate" Y="0" />
...
<Setter TargetName="TextTranslate" Property="Y" Value="0" />
```

**수정 후:**
```xml
<TranslateTransform Y="0" />
...
<Trigger.EnterActions>
    <StopStoryboard BeginStoryboardName="BounceStoryboard" />
    <BeginStoryboard>
        <Storyboard>
            <DoubleAnimation Storyboard.TargetName="PART_Text"
                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.Y)"
                             To="0" Duration="0:0:0.1" />
        </Storyboard>
    </BeginStoryboard>
</Trigger.EnterActions>
```

---

### 에러 2: MC3072 - Spacing 속성이 없음

**에러 메시지:**
```
XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 `StackPanel`에는 `Spacing` 속성이 없음
- `Spacing` 속성은 .NET MAUI나 UWP/WinUI의 `StackPanel`에서 지원

**수정 방법:**
- `Spacing` 속성 대신 각 자식 요소에 `Margin` 속성 적용

**수정 전:**
```xml
<StackPanel Spacing="30">
```

**수정 후:**
```xml
<StackPanel>
    <controls:GentleKangaroo69 Margin="0,0,0,30" />
    ...
</StackPanel>
```

---

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. Bounce 애니메이션 재시작 문제
- **상황:** Hover 종료 후 텍스트 bounce 애니메이션을 다시 시작할 때 새로운 Storyboard를 생성
- **가능성:** 빠른 hover in/out 반복 시 여러 Storyboard가 동시에 실행될 수 있음
- **확인 방법:** 빠르게 마우스를 올렸다 내렸다 반복하여 애니메이션이 정상적으로 동작하는지 확인

### 2. Scale Transform 애니메이션 충돌
- **상황:** Hover 진입/종료 시 Scale 애니메이션이 실행됨
- **가능성:** 애니메이션 진행 중 hover 상태가 변경되면 애니메이션이 예상치 않게 동작할 수 있음
- **확인 방법:** 애니메이션 진행 중 hover 상태를 변경하여 부드러운 전환이 되는지 확인

### 3. Dot 애니메이션 RepeatBehavior
- **상황:** Hover 시 원형 점의 bounce 애니메이션이 `RepeatBehavior="Forever"`로 설정됨
- **가능성:** Hover 종료 시 `StopStoryboard`로 애니메이션을 중지하지만, 점이 원래 위치로 돌아가지 않을 수 있음
- **확인 방법:** Hover 종료 후 원형 점이 완전히 사라지는지 확인 (Opacity=0이므로 보이지 않아야 함)

---

## 변환된 파일 목록

1. `GentleKangaroo69.Wpf.UI/Controls/GentleKangaroo69.cs` - CustomControl 클래스
2. `GentleKangaroo69.Wpf.UI/Themes/GentleKangaroo69Resources.xaml` - 테마 리소스
3. `GentleKangaroo69.Wpf.UI/Themes/GentleKangaroo69.xaml` - 스타일 및 ControlTemplate
4. `GentleKangaroo69.Wpf.UI/Themes/Generic.xaml` - ResourceDictionary 병합
5. `GentleKangaroo69.Wpf.Gallery/MainWindow.xaml` - 데모 앱
6. `GentleKangaroo69.Wpf.Gallery/App.xaml` - 리소스 참조

---

## 빌드 결과

**최종 빌드 상태:** 성공 (경고 0, 오류 0)
