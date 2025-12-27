# BitterMoth36 AvaloniaUI 변환 로그

## 변환 일시
2025-12-28

## 원본 소스
- **출처**: uiverse.io by Shoh2008
- **유형**: Loader (회전하는 두 개의 원이 스케일 애니메이션)
- **파일**: BitterMoth36.html, BitterMoth36.css

## 변환 결과

### 프로젝트 구조
```
BitterMoth36/AvaloniaUI/
├── BitterMoth36.Avalonia.slnx
├── BitterMoth36.Avalonia.Lib/
│   ├── Controls/
│   │   └── BitterMoth36Loader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BitterMoth36Loader.axaml
└── BitterMoth36.Avalonia.Gallery/
    ├── App.axaml(.cs)
    ├── MainWindow.axaml(.cs)
    └── Program.cs
```

### CSS → AXAML 변환 매핑
| CSS | AvaloniaUI |
|-----|-----------|
| `animation: rotation_19 1s linear infinite` | `Animation Duration="0:0:1" IterationCount="Infinite"` |
| `animation: scale50 1s infinite ease-in-out` | `Animation Easing="QuadraticEaseInOut"` |
| `animation-delay: 0.5s` | `Animation Delay="0:0:0.5"` |
| `transform: rotate(360deg)` | `RenderTransform Value="rotate(360deg)"` |
| `transform: scale(0)` / `scale(1)` | `RenderTransform Value="scale(0,0)"` / `scale(1,1)` |
| `::before`, `::after` | 개별 `Ellipse` 요소 |
| `border-radius: 50%` | `Ellipse` 요소 사용 |
| `position: absolute; top: 0` | `VerticalAlignment="Top"` |
| `position: absolute; bottom: 0` | `VerticalAlignment="Bottom"` |

## 컴파일 에러 및 수정

### 에러 1: CS0246 - IBrush 형식을 찾을 수 없음
**에러 메시지**:
```
error CS0246: 'IBrush' 형식 또는 네임스페이스 이름을 찾을 수 없습니다.
```

**원인**: `Avalonia.Media` 네임스페이스 누락

**수정 방법**:
```csharp
// 수정 전
using Avalonia;
using Avalonia.Controls.Primitives;

// 수정 후
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;  // 추가
```

### 에러 2: AVLN2000 - ResourceDictionary를 IStyle로 사용할 수 없음
**에러 메시지**:
```
error AVLN2000: Resource "avares://...Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type in the assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**: AvaloniaUI에서 `ControlTheme`은 `Application.Styles`가 아닌 `Application.Resources`에 병합해야 함

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://.../Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://.../Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 동기화
- **가능성**: 낮음
- **설명**: 원본 CSS에서 두 원의 스케일 애니메이션은 `animation-delay: 0.5s`로 동기화됨. AvaloniaUI에서 `Animation Delay` 속성을 사용했으나, 첫 실행 시 지연 동작이 예상과 다를 수 있음
- **확인 필요**: 앱 실행 후 두 원의 애니메이션이 교대로 나타나는지 확인

### 2. `:loaded` 의사 클래스
- **가능성**: 중간
- **설명**: AvaloniaUI의 `:loaded` 의사 클래스는 컨트롤이 시각적 트리에 추가된 후 트리거됨. 일부 상황에서 애니메이션이 시작되지 않을 수 있음
- **확인 필요**: 컨트롤이 다이나믹하게 추가/제거될 때 애니메이션 상태 확인

### 3. RenderTransformOrigin
- **가능성**: 낮음
- **설명**: CSS의 `transform-origin: center`와 AvaloniaUI의 `RenderTransformOrigin="50%,50%"`는 동일해야 하지만, 특정 레이아웃 상황에서 차이가 발생할 수 있음
- **확인 필요**: 다양한 크기에서 회전 중심점이 올바른지 확인

## 빌드 결과
- **최종 상태**: 성공
- **경고**: 0개
- **에러**: 0개

## 특이사항
- RadialGradientBrush 사용 없음 (Issue #19888 해당 없음)
- CSS 애니메이션을 AvaloniaUI Style Animation으로 완전 변환
- 커스텀 속성으로 `TopCircleColor`, `BottomCircleColor` 추가하여 색상 커스터마이징 가능
