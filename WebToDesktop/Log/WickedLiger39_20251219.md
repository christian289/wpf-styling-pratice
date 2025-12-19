# WickedLiger39 변환 로그

## 변환 일시
2025-12-19

## 원본 정보
- 원작자: ayman-ashine
- 원본 링크: https://uiverse.io/ayman-ashine/wicked-liger-39
- 카테고리: Radio-buttons

## 컴파일 에러 및 수정

### 에러 1: TextTransform 속성 없음

**에러 내용:**
```
MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'TextTransform' 속성이 없습니다.
```

**원인:**
- WPF의 `TextBlock`에는 CSS의 `text-transform: uppercase`에 해당하는 `TextTransform` 속성이 없음
- HTML/CSS에서 `uppercase` 클래스가 적용되어 있었음

**수정 방법:**
- `Typography.Capitals` 속성을 사용하거나 Header 값을 대문자로 직접 전달하도록 변경
- 최종적으로 Header 바인딩 값 자체를 대문자로 설정하는 방식 채택

**수정 파일:** `Themes/GenderSelector.xaml` (Line 250)

---

### 에러 2: GroupName 속성 없음

**에러 내용:**
```
MC3072: XML 네임스페이스 'clr-namespace:WickedLiger39.Wpf.UI.Controls;assembly=WickedLiger39.Wpf.UI'에 'GroupName' 속성이 없습니다.
```

**원인:**
- `GenderOption` 클래스가 `ToggleButton`을 상속받고 있었음
- `GroupName` 속성은 `RadioButton` 클래스에만 존재

**수정 방법:**
- `GenderOption` 클래스의 기본 클래스를 `ToggleButton`에서 `RadioButton`으로 변경
- using 문도 `System.Windows.Controls.Primitives`에서 `System.Windows.Controls`로 변경

**수정 파일:** `Controls/GenderOption.cs` (Line 2, 11)

---

## 잠재적 런타임 오류

### 1. PathGeometry 데이터 형식
- `GenderSelectorResources.xaml`의 PathGeometry가 복잡한 SVG 경로를 사용
- 일부 브라우저 SVG 경로 형식이 WPF PathGeometry와 100% 호환되지 않을 수 있음
- **확인 필요:** 런타임에서 아이콘이 정상적으로 표시되는지 확인

### 2. Non-binary 아이콘 viewBox 변환
- 원본 SVG는 `viewBox="0 0 512 512"`를 사용
- WPF `Path`의 `Stretch="Uniform"`으로 대체했으나 비율이 다를 수 있음
- **확인 필요:** 논바이너리 아이콘의 크기 및 위치 확인

### 3. Typography.Capitals 지원
- 일부 폰트에서 `Typography.Capitals="AllSmallCaps"`가 지원되지 않을 수 있음
- Consolas 폰트의 경우 OpenType 기능 지원 여부 확인 필요
- **확인 필요:** 헤더 텍스트가 대문자로 표시되는지 확인

## 변환 매핑

| CSS (Tailwind) | WPF |
|----------------|-----|
| `rounded-full` | `CornerRadius="25"` (50px 크기의 절반) |
| `shadow-sm shadow-[#00000050]` | `DropShadowEffect` |
| `ring-2 ring-{color}-400` | `Border.BorderThickness="2"` + `BorderBrush` |
| `scale-110` | `ScaleTransform ScaleX/Y="1.1"` |
| `scale-[500%]` | `ScaleTransform ScaleX/Y="5"` (Ripple 효과) |
| `duration-300` | `Duration="0:0:0.3"` |
| `duration-500` | `Duration="0:0:0.5"` |
| `peer-checked:` | `Trigger Property="IsChecked" Value="True"` |
| `bg-{color}-100` | `SolidColorBrush` 리소스 |
| `stroke-{color}-400` | `Path.Stroke` 바인딩 |
| `fill-{color}-400` | `Path.Fill` 바인딩 |
| `opacity-0` | `Opacity="0"` 또는 애니메이션으로 처리 |
| `-z-10` | `Panel.ZIndex` 또는 요소 순서로 처리 |
