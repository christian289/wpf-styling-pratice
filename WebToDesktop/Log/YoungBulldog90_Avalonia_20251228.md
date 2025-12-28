# YoungBulldog90 AvaloniaUI 변환 로그

## 변환 정보

- **변환 일자**: 2025-12-28
- **원본 소스**: Uiverse.io by Clemix37 (loader)
- **컨트롤 타입**: SpinnerLoader (회전 스피너)

## 프로젝트 구조

```
YoungBulldog90/AvaloniaUI/
├── YoungBulldog90.Avalonia.slnx
├── YoungBulldog90.Avalonia.Lib/
│   ├── Controls/
│   │   └── SpinnerLoader.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SpinnerLoader.axaml
└── YoungBulldog90.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## CSS → AvaloniaUI 변환 내용

| CSS 속성 | AvaloniaUI 구현 |
|----------|-----------------|
| `width: 60px` | `Width="60"` |
| `height: 60px` | `Height="60"` |
| `border-radius: 50%` | `Arc` 컨트롤 사용 |
| `border-top: 2px solid #8900FF` | `Arc` + `Stroke` + `StartAngle/SweepAngle` |
| `border-right: 2px solid transparent` | 90도 호(Arc)로 표현 |
| `animation: spinner8217 0.8s linear infinite` | `Animation Duration="0:0:0.8" IterationCount="Infinite"` |
| `transform: rotate(360deg)` | `RotateTransform Angle="360"` |
| `::before` pseudo-element | `Arc` 컨트롤로 직접 구현 |

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 컴파일 에러

**없음** - 빌드 성공

## 수정 내용

**없음** - 기존 프로젝트가 정상 동작

## 잠재적 런타임 오류 가능성

1. **Arc 렌더링 이슈**
   - `Arc` 컨트롤의 `StartAngle`, `SweepAngle` 값이 예상과 다르게 렌더링될 수 있음
   - 일부 플랫폼에서 Arc의 시작점/끝점 계산이 다를 수 있음

2. **애니메이션 성능**
   - `IterationCount="Infinite"` 애니메이션이 장시간 실행 시 리소스 사용량 증가 가능
   - 컨트롤이 화면에서 보이지 않을 때도 애니메이션이 계속 실행될 수 있음

3. **RenderTransform 중복**
   - `ControlTemplate` 내부 `Arc`의 `RenderTransform`과 스타일의 `RenderTransform` 애니메이션이 충돌할 수 있음
   - 현재 구현에서는 스타일 애니메이션이 컨트롤 전체에 적용됨

## 컨트롤 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `SpinnerBrush` | `IBrush?` | `#8900FF` | 스피너 색상 |
| `SpinnerThickness` | `double` | `2.0` | 스피너 두께 |

## 사용 예시

```xml
<!-- 기본 사용 -->
<controls:SpinnerLoader Width="60" Height="60" />

<!-- 커스텀 색상 및 크기 -->
<controls:SpinnerLoader
    Width="40"
    Height="40"
    SpinnerBrush="#00D4FF"
    SpinnerThickness="3" />
```
