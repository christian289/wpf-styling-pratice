# QuietCougar91 변환 로그 / Conversion Log

## 변환 일시 / Conversion Date
2025-12-15

## 원본 정보 / Source Information
- **원작자 / Author**: kyle1dev
- **원본 링크 / Source Link**: https://uiverse.io/kyle1dev/quiet-cougar-91
- **태그 / Tags**: Tooltips

---

## 컴파일 에러 및 수정 / Compile Errors and Fixes

### 에러 1: StackPanel.Spacing 속성 오류
### Error 1: StackPanel.Spacing property error

**에러 내용 / Error Message:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
error MC3072: Property 'Spacing' does not exist in XML namespace 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'.
```

**원인 / Cause:**
- WPF의 StackPanel에는 `Spacing` 속성이 없음
- WPF StackPanel does not have a `Spacing` property
- `Spacing`은 UWP/WinUI 및 AvaloniaUI에서만 지원됨
- `Spacing` is only supported in UWP/WinUI and AvaloniaUI

**수정 방법 / Fix:**
- 각 컨트롤에 `Margin` 속성을 개별적으로 적용
- Applied `Margin` property individually to each control

**수정 전 / Before:**
```xml
<StackPanel Spacing="40">
    <controls:QuietCougar91 />
</StackPanel>
```

**수정 후 / After:**
```xml
<StackPanel>
    <controls:QuietCougar91 Margin="0,20"/>
</StackPanel>
```

---

## 잠재적 런타임 오류 / Potential Runtime Errors

### 1. VisualStateManager 트리거 충돌 가능성
### 1. VisualStateManager trigger conflict possibility

**설명 / Description:**
- ControlTemplate에 VisualStateManager와 Triggers가 동시에 사용됨
- Both VisualStateManager and Triggers are used in ControlTemplate
- MouseOver 상태에서 애니메이션과 Trigger가 동시에 Background를 변경할 수 있음
- Animation and Trigger may change Background simultaneously in MouseOver state

**예상 증상 / Expected Symptoms:**
- 호버 시 배경색 깜빡임 또는 의도치 않은 색상 표시 가능
- Background may flicker or show unintended color on hover

**확인 필요 / Verification Required:**
- 실제 실행하여 호버 애니메이션 동작 확인 필요
- Need to verify hover animation behavior by running the application

### 2. Effect (DropShadowEffect) 클리핑 가능성
### 2. Effect (DropShadowEffect) clipping possibility

**설명 / Description:**
- DropShadowEffect가 부모 컨테이너에 의해 잘릴 수 있음
- DropShadowEffect may be clipped by parent container
- 특히 StackPanel 내에서 Margin이 충분하지 않으면 그림자가 잘림
- Shadow may be clipped if Margin is not sufficient in StackPanel

**예상 증상 / Expected Symptoms:**
- 버튼 그림자가 완전히 표시되지 않을 수 있음
- Button shadow may not be fully visible

**확인 필요 / Verification Required:**
- Gallery 실행 후 그림자 표시 상태 확인
- Verify shadow display after running Gallery

---

## 생성된 파일 목록 / Generated Files

```
QuietCougar91.Wpf.slnx
QuietCougar91.Wpf.Gallery/
├── QuietCougar91.Wpf.Gallery.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs
QuietCougar91.Wpf.UI/
├── QuietCougar91.Wpf.UI.csproj
├── Controls/
│   └── QuietCougar91.cs
├── Themes/
│   ├── Generic.xaml
│   ├── QuietCougar91.xaml
│   └── QuietCougar91Resources.xaml
└── Properties/
    └── AssemblyInfo.cs
```

---

## CSS → WPF 변환 매핑 / CSS to WPF Conversion Mapping

| CSS | WPF |
|-----|-----|
| `linear-gradient(to right, #333, #000)` | `LinearGradientBrush` (StartPoint="0,0.5" EndPoint="1,0.5") |
| `box-shadow: 0 4px 8px rgba(0,0,0,0.5)` | `DropShadowEffect` (ShadowDepth, BlurRadius, Opacity) |
| `border-radius: 6px` | `CornerRadius="6"` |
| `padding: 15px 30px` | `Padding="30,15"` |
| `transition: 0.4s ease` | `DoubleAnimation Duration="0:0:0.4"` + `CubicEase` |
| `transform: translateY(-10px)` | `TranslateTransform Y="-10"` |
| `transform: scale(0.95)` | `ScaleTransform ScaleX="0.95" ScaleY="0.95"` |
| `:hover` | `VisualState x:Name="MouseOver"` + `Trigger IsMouseOver="True"` |
| `:active` | `VisualState x:Name="Pressed"` |
| `opacity: 0/1` | `DoubleAnimation Storyboard.TargetProperty="Opacity"` |
| `visibility: hidden/visible` | `Opacity` 애니메이션으로 대체 |
| `gap: 8px` | `Margin="0,0,8,0"` on icon |
