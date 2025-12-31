# SpicyJellyfish41 변환 로그

## 변환 일시
2026-01-01

## 원본 정보
- 원작자: ahmedyasserdev
- 원본 링크: https://uiverse.io/ahmedyasserdev/spicy-jellyfish-41
- 카테고리: Checkboxes (Hamburger menu toggle)

## 컴파일 에러 및 수정

### 에러 1: StackPanel.Spacing 속성 미지원

**에러 내용:**
```
MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
WPF의 StackPanel은 Spacing 속성을 지원하지 않음. (AvaloniaUI나 UWP/WinUI에서는 지원)

**수정 방법:**
각 자식 요소에 개별적으로 Margin 속성을 적용하여 간격 구현.

```xml
<!-- 수정 전 -->
<StackPanel Spacing="30">
    <TextBlock ... />
</StackPanel>

<!-- 수정 후 -->
<StackPanel>
    <TextBlock Margin="0,0,0,30" ... />
</StackPanel>
```

## 잠재적 Runtime 에러

### 1. cubic-bezier 변환 정확도
**설명:**
CSS의 `cubic-bezier(0.68, -0.55, 0.265, 1.55)`를 WPF의 `KeySpline="0.68,-0.55,0.265,1.55"`로 변환함.
WPF KeySpline은 0~1 범위를 권장하지만 CSS cubic-bezier는 범위 제한이 없음.
음수 및 1 초과 값이 포함되어 있어 약간 다른 애니메이션 결과가 발생할 수 있음.

**확인 필요:**
실제 실행 시 애니메이션 효과가 원본 CSS와 동일하게 보이는지 확인 필요.

### 2. TranslateY 값 계산
**설명:**
CSS의 `translateY(8px)`를 WPF에서 `Y="9"`로 변환함.
이는 StackPanel 내 Border의 Height(3px) + Margin(6px)을 고려한 값임.
레이아웃에 따라 미세 조정이 필요할 수 있음.

**확인 필요:**
X 형태로 변환될 때 세 줄이 정확히 교차하는지 확인 필요.

## 생성된 파일
- `SpicyJellyfish41.Wpf.UI/Controls/SpicyJellyfish41.cs`
- `SpicyJellyfish41.Wpf.UI/Themes/SpicyJellyfish41Resources.xaml`
- `SpicyJellyfish41.Wpf.UI/Themes/SpicyJellyfish41.xaml`
- `SpicyJellyfish41.Wpf.UI/Themes/Generic.xaml` (수정)
- `SpicyJellyfish41.Wpf.Gallery/App.xaml` (수정)
- `SpicyJellyfish41.Wpf.Gallery/MainWindow.xaml` (수정)
