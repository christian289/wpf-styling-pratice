# OldHound37 - AvaloniaUI 변환 로그

## 변환 정보

- **원본 소스**: Uiverse.io by csemszepp (Tags: simple, minimalist, pattern)
- **변환 대상**: AvaloniaUI 11.2.2 CustomControl
- **변환 일자**: 2025-12-28
- **프레임워크**: .NET 9.0

## 프로젝트 구조

```
WebToDesktop/Output/OldHound37/AvaloniaUI/
├── OldHound37.Avalonia.slnx
├── OldHound37.Avalonia.Lib/
│   ├── Controls/
│   │   └── OldHound37Control.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── OldHound37Control.axaml
└── OldHound37.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## CSS 패턴 분석

원본 CSS는 복잡한 다중 그래디언트 패턴을 사용합니다:

```css
background:
    repeating-linear-gradient(45deg, var(--_l1)),     /* 45도 대각선 흰색 라인 */
    repeating-linear-gradient(-45deg, var(--_l1)),    /* -45도 대각선 흰색 라인 */
    repeating-linear-gradient(0deg, var(--_l2)),      /* 수평 흰색 라인 */
    repeating-linear-gradient(90deg, var(--_l2)),     /* 수직 흰색 라인 */
    conic-gradient(from 135deg at 25% 75%, var(--_g)), /* 좌하단 코너 삼각형 */
    conic-gradient(from 225deg at 25% 25%, var(--_g)), /* 좌상단 코너 삼각형 */
    conic-gradient(from 45deg at 75% 75%, var(--_g)),  /* 우하단 코너 삼각형 */
    conic-gradient(from -45deg at 75% 25%, var(--_g)), /* 우상단 코너 삼각형 */
    repeating-conic-gradient(#125c65 0 45deg, #bc4a33 0 90deg); /* 베이스 체커보드 */
```

## 컴파일 에러 및 수정 내역

### 에러 1: StyleInclude vs ResourceInclude

**에러 메시지**:
```
AVLN2000: Resource "avares://OldHound37.Avalonia.Lib/Themes/Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type in the "OldHound37.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에 `StyleInclude`를 사용했으나, `Generic.axaml`은 `ResourceDictionary` 타입임
- AvaloniaUI에서 `StyleInclude`는 `IStyle`을 기대하지만, `ResourceDictionary`는 `IStyle`이 아님

**수정 방법**:
`Application.Resources`에 `ResourceInclude`를 사용하여 `ResourceDictionary`를 병합

```xml
<!-- 수정 전 (에러 발생) -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://OldHound37.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 (정상 동작) -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://OldHound37.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성 (직접 확인 필요)

### 1. conic-gradient 미지원으로 인한 시각적 차이

**문제점**:
- CSS `conic-gradient`는 AvaloniaUI에서 직접 지원되지 않음
- `DrawingBrush`와 `PathGeometry`를 사용하여 근사치로 구현함
- 원본과 시각적 차이가 발생할 수 있음

**영향 범위**:
- 코너 삼각형 영역의 그래디언트 효과가 단색으로 대체됨
- 베이스 체커보드 패턴이 대각선 분할로 근사 구현됨

**확인 방법**:
```bash
cd WebToDesktop/Output/OldHound37/AvaloniaUI
dotnet run --project OldHound37.Avalonia.Gallery
```

### 2. DrawingBrush 타일링 성능

**문제점**:
- 복잡한 `DrawingGroup`이 포함된 `DrawingBrush`가 큰 영역에서 반복될 때 성능 저하 가능성

**권장 확인 사항**:
- 창 크기를 최대화하여 렌더링 성능 확인
- 여러 컨트롤을 동시에 표시할 때 성능 측정

### 3. PathGeometry 렌더링 품질

**문제점**:
- 대각선 라인(`LineSegment`)이 얇은 선으로 렌더링되므로, 확대/축소 시 안티앨리어싱 품질이 변할 수 있음

## 변환 결과 요약

| 항목 | 상태 | 비고 |
|------|------|------|
| 컴파일 | ✅ 성공 | 경고 0개, 오류 0개 |
| ControlTheme | ✅ 구현됨 | `{x:Type controls:OldHound37Control}` |
| DrawingBrush 패턴 | ✅ 구현됨 | 200x200 타일 기준 |
| 베이스 체커보드 | ⚠️ 근사 구현 | conic-gradient 대체 |
| 코너 삼각형 | ⚠️ 근사 구현 | 단색 삼각형으로 대체 |
| 그리드 라인 | ✅ 구현됨 | 수평/수직/대각선 라인 |
| Runtime 동작 | ❓ 확인 필요 | 직접 실행하여 검증 필요 |
