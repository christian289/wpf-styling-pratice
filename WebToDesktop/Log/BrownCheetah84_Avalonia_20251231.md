# BrownCheetah84 - AvaloniaUI 변환 로그

## 변환 정보

- **날짜**: 2025-12-31
- **소스**: Uiverse.io by elijahgummer
- **태그**: simple, blue, modern, pattern
- **원본 파일**: `WebToDesktop/source/20251230_BrownCheetah84/BrownCheetah84.html`, `BrownCheetah84.css`

## CSS 분석

### 원본 스타일
```css
.container {
  width: 100%;
  height: 100%;
  position: relative;
  background: #f0f0f0;
}

.container::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(
      45deg,
      #3498db 25%,
      transparent 25%,
      transparent 50%,
      #3498db 50%,
      #3498db 75%,
      transparent 75%,
      transparent
    ),
    linear-gradient(
      -45deg,
      #3498db 25%,
      transparent 25%,
      transparent 50%,
      #3498db 50%,
      #3498db 75%,
      transparent 75%,
      transparent
    );
  background-size: 20px 20px;
  opacity: 0.8;
}
```

### 변환 전략

CSS의 복합 대각선 gradient 패턴은 AvaloniaUI에서 직접 지원되지 않음. `DrawingBrush`와 `GeometryDrawing`을 사용하여 타일 패턴으로 구현.

| CSS 구문 | AvaloniaUI 구현 |
|----------|----------------|
| `linear-gradient(45deg, ...)` | `PathGeometry`로 삼각형 그리기 |
| `linear-gradient(-45deg, ...)` | `PathGeometry`로 삼각형 그리기 |
| `background-size: 20px 20px` | `DrawingBrush.DestinationRect="0,0,20,20"` |
| `opacity: 0.8` | `Border.Opacity="0.8"` |
| `::before` 가상 요소 | `Panel` 내 별도 `Border` 레이어 |

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://BrownCheetah84.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "BrownCheetah84.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인**:
- `Application.Styles` 컬렉션에는 `IStyle` 타입만 추가 가능
- `ResourceDictionary`는 `IStyle`이 아니므로 `StyleInclude`로 포함할 수 없음

**수정 전** (`App.axaml`):
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BrownCheetah84.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후** (`App.axaml`):
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BrownCheetah84.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**해결 방법**:
- `StyleInclude` 대신 `ResourceInclude` 사용
- `Application.Resources` 섹션에서 `ResourceDictionary.MergedDictionaries`로 병합

## Runtime Error 가능성 (직접 확인 필요)

1. **DrawingBrush 렌더링**: AvaloniaUI의 `DrawingBrush` 타일 패턴이 CSS 원본과 시각적으로 완전히 일치하지 않을 수 있음
   - CSS는 45도/-45도 대각선 줄무늬의 반복 패턴
   - AvaloniaUI는 삼각형 기하학으로 근사 구현
   - 패턴 경계에서 미세한 차이 발생 가능

2. **투명도 적용**: `Border.Opacity`로 전체 패턴 레이어에 투명도 적용
   - 일부 GPU/드라이버에서 렌더링 차이 발생 가능

3. **PatternSize 속성 미연결**: `PatternSize` 속성이 정의되어 있으나 Template에서 실제로 바인딩되지 않음
   - `DestinationRect`가 하드코딩된 `20,20` 사용
   - 동적 패턴 크기 변경 불가

## 생성된 프로젝트 구조

```
WebToDesktop/Output/BrownCheetah84/AvaloniaUI/
├── BrownCheetah84.Avalonia.slnx
├── BrownCheetah84.Avalonia.Lib/
│   ├── BrownCheetah84.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── PatternBackground.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── PatternBackground.axaml
└── BrownCheetah84.Avalonia.Gallery/
    ├── BrownCheetah84.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
