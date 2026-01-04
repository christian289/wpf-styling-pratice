# AverageShrimp57

Toggle-switches 스타일 컨트롤 - On/Off 텍스트가 있는 3D 효과 토글 스위치

## 원본 정보

- **원작자**: JaydipPrajapati1910
- **원본 링크**: [https://uiverse.io/JaydipPrajapati1910/average-shrimp-57](https://uiverse.io/JaydipPrajapati1910/average-shrimp-57)
- **태그**: switch, toggle switch, light switch

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project AverageShrimp57.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project AverageShrimp57.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:AverageShrimp57 OnText="On" OffText="Off" />
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `OnText` | string | "On" | 토글이 켜졌을 때 표시되는 텍스트 |
| `OffText` | string | "Off" | 토글이 꺼졌을 때 표시되는 텍스트 |
| `IsChecked` | bool? | false | 토글 상태 (ToggleButton 상속) |

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 비고 |
|-----|-----|------|
| `linear-gradient(to bottom, ...)` | `LinearGradientBrush` StartPoint="0,0" EndPoint="0,1" | 수직 그라데이션 |
| `linear-gradient(to right, ...)` | `LinearGradientBrush` StartPoint="0,0.5" EndPoint="1,0.5" | 수평 그라데이션 |
| `border-radius: 50px` | `CornerRadius="50"` | 둥근 모서리 |
| `box-shadow: 0 -1px 1px 0 rgba(...)` | `DropShadowEffect` | 외부 그림자 |
| `box-shadow: inset ...` | 미구현 | WPF 직접 지원 안됨 |
| `text-shadow: 0 1px 0 #fff, 0px 0 7px #color` | `DropShadowEffect` on TextBlock | 글로우 효과 |
| `color: #df0000` | `Foreground="#DF0000"` | 텍스트 색상 |
| `input:checked ~ div` | `Trigger Property="IsChecked"` | 상태 트리거 |
| `::before`, `::after` pseudo-elements | 별도 `TextBlock` 요소 | 가상 요소 |
| `position: absolute` | Grid 내 배치 | 레이아웃 |
| `opacity: 0` (숨김 요소) | 불필요 (ToggleButton 기본 동작) | 클릭 영역 |

## 프로젝트 구조

```
AverageShrimp57/
├── Readme.md
├── Wpf/
│   ├── AverageShrimp57.Wpf.slnx
│   ├── AverageShrimp57.Wpf.Gallery/    # 데모 애플리케이션
│   └── AverageShrimp57.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── AverageShrimp57.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── AverageShrimp57.xaml
│           └── AverageShrimp57Resources.xaml
└── AvaloniaUI/                          # (미구현)
```
