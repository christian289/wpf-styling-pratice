# NervousZebra0 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by WittyHydra (notification)
- **변환 일자**: 2025-12-18
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 프로젝트 구조

```
NervousZebra0/AvaloniaUI/
├── NervousZebra0.Avalonia.slnx
├── NervousZebra0.Avalonia.Lib/
│   ├── Controls/
│   │   └── LevelUpNotification.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LevelUpNotification.axaml
└── NervousZebra0.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **오류**: 0개

## CSS → AvaloniaUI 변환 내용

### 색상 리소스

| CSS 변수 | AvaloniaUI 리소스 | 값 |
|---------|------------------|-----|
| `--bg-color` (Light) | `Notification.Background` | `#C3DAF6` |
| `--text-color` | `Notification.Foreground` | `#1E2B3C` |
| `--highlight-color` | `Notification.Highlight` | `#FC9A32` |
| hover background | `Notification.Background.Hover` | `#1E2B3C` |
| hover foreground | `Notification.Foreground.Hover` | `#C3DAF6` |
| button background | `Button.Background` | `#EFEFEF` |
| button hover | `Button.Background.Hover` | `#C3DAF6` |

### 애니메이션 변환

| CSS 애니메이션 | AvaloniaUI 구현 |
|--------------|----------------|
| `slide-down` (translateY -100% → 0) | `TranslateTransform Y` 애니메이션, `:loaded` 의사 클래스 |
| `rotate-text` (rotateX 90deg → 0) | `Opacity` 애니메이션으로 대체 (3D 회전 미지원) |
| `transition: transform scale(1.1)` | `ScaleTransform` 애니메이션, `:pointerover` 의사 클래스 |
| `transition: all 0.3s` | `Animation Duration="0:0:0.3"` |

### 레이아웃 변환

| CSS | AvaloniaUI |
|-----|-----------|
| `position: absolute` + `top/bottom` | `Panel` + `VerticalAlignment="Top/Bottom"` |
| `display: flex; justify-content: space-between` | `Grid ColumnDefinitions="*,Auto"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `box-shadow: 0 8px 24px rgba(0,0,0,0.2)` | `BoxShadow="0 8 24 #33000000"` |
| `overflow: hidden` | `ClipToBounds="True"` |

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `TopText` | `string` | `"Level Up!"` | 상단 하이라이트 영역 텍스트 |
| `LevelText` | `string` | `"Level 5"` | 하단 레벨 표시 텍스트 |
| `ButtonText` | `string` | `"Next Level"` | 버튼 텍스트 |

## 잠재적 런타임 오류

### 1. 3D 회전 애니메이션 미지원

- **원본 CSS**: `transform: rotateX(90deg)` (3D X축 회전)
- **현재 구현**: `Opacity` 페이드 인으로 대체
- **영향**: 텍스트가 3D로 뒤집히며 나타나는 효과 대신 단순 페이드 인
- **해결 방안**: SkiaSharp 커스텀 렌더링 또는 Avalonia 3D 확장 사용

### 2. 애니메이션 Trigger 시점

- **구현**: `:loaded` 의사 클래스 사용
- **잠재적 문제**: 컨트롤이 다시 표시될 때 애니메이션이 재생되지 않을 수 있음
- **해결 방안**: `IsVisible` 속성 변경 시 애니메이션 트리거하는 코드비하인드 추가

### 3. 호버 상태 전환 애니메이션 누락

- **원본 CSS**: `transition: background-color 0.3s ease-out`
- **현재 구현**: 즉시 색상 변경 (애니메이션 없음)
- **영향**: 호버 시 부드러운 색상 전환 대신 즉각적인 변경
- **해결 방안**: Background 속성에 대한 추가 애니메이션 구현

## 사용 예시

```xml
<controls:LevelUpNotification TopText="Level Up!"
                              LevelText="Level 5"
                              ButtonText="Next Level"/>
```

## 참고사항

- RadialGradientBrush 미사용으로 Issue #19888 영향 없음
- Light Mode 스타일만 구현 (원본 CSS의 최종 스타일 기준)
