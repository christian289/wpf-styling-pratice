# SpottyElephant13 변환 로그

## 변환 일시
2026-01-04

## 원본 정보
- 원작자: bociKond
- 원본 링크: https://uiverse.io/bociKond/spotty-elephant-13
- 카테고리: Checkboxes

## 컴파일 에러 및 수정

### 에러 1: MC3044 - Margin 속성에 StaticResource 조합 불가

**에러 메시지:**
```
MC3044: MarkupExtension 식의 닫는 '}' 뒤에 텍스트 ',{StaticResource SpottyElephant13.Checkmark.Top},0,0'을(를) 사용할 수 없습니다.
```

**원인:**
WPF에서 `Margin` 속성에 여러 개의 `StaticResource`를 직접 조합하여 사용할 수 없음.

**잘못된 코드:**
```xml
Margin="{StaticResource SpottyElephant13.Checkmark.Left},
        {StaticResource SpottyElephant13.Checkmark.Top},0,0"
```

**수정 방법:**
리소스 파일에 `Thickness` 타입의 리소스를 직접 정의하고 사용.

**SpottyElephant13Resources.xaml에 추가:**
```xml
<Thickness x:Key="SpottyElephant13.Checkmark.Margin">10.8,6,0,0</Thickness>
```

**수정된 코드:**
```xml
Margin="{StaticResource SpottyElephant13.Checkmark.Margin}"
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. DropShadowEffect 애니메이션 성능
- `DropShadowEffect`는 GPU 가속이 되지 않아 다수의 컨트롤에서 동시에 애니메이션을 실행하면 성능 저하가 발생할 수 있음
- 해결 방안: `BitmapCache`를 사용하거나, 컨트롤 수를 제한

### 2. 펄스 애니메이션 반복 트리거
- `Trigger.EnterActions`는 상태 진입 시에만 실행됨
- 이미 체크된 상태에서 창을 로드하면 애니메이션이 실행되지 않음 (정상 동작)
- 사용자가 클릭하여 상태를 변경할 때만 애니메이션 실행

### 3. CornerRadius 트랜지션 부재
- CSS에서는 `transition: 300ms`로 부드러운 CornerRadius 변경이 가능하지만
- WPF에서는 `CornerRadius`에 대한 애니메이션이 기본 지원되지 않음
- 현재 구현에서는 즉각적인 CornerRadius 변경만 적용됨

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `border-radius: 50%` | `CornerRadius="15.6"` (반지름) |
| `border-radius: .5rem` | `CornerRadius="8"` |
| `background-color` | `Background` (SolidColorBrush) |
| `box-shadow` | `DropShadowEffect` |
| `transition: 300ms` | 지원 불가 (CornerRadius 애니메이션) |
| `@keyframes pulse` | `Storyboard` + `DoubleAnimationUsingKeyFrames` |
| `rotate` | `RotateTransform.Angle` |
| `::after` pseudo-element | `Grid` + `Border` 조합 |
| `border-right` + `border-bottom` | 두 개의 `Border` 요소로 분리 |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` |

## 생성된 파일 목록

```
SpottyElephant13.Wpf.slnx
SpottyElephant13.Wpf.Gallery/
├── SpottyElephant13.Wpf.Gallery.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs
SpottyElephant13.Wpf.UI/
├── SpottyElephant13.Wpf.UI.csproj
├── Controls/
│   └── SpottyElephant13.cs
├── Themes/
│   ├── Generic.xaml
│   ├── SpottyElephant13.xaml
│   └── SpottyElephant13Resources.xaml
└── Properties/
    └── AssemblyInfo.cs
```
