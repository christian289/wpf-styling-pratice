# ModernZebra66 AvaloniaUI 변환 로그

## 변환 정보

- **변환 날짜**: 2026-01-04
- **원본 소스**: uiverse.io by csemszepp (Afif13)
- **컨트롤 유형**: 패턴 배경 (Hexagonal Zebra Pattern)

## 원본 CSS 분석

```css
.container {
  --s: 200px; /* control the size */
  --c1: #1d1d1d;
  --c2: #4e4f51;
  --c3: #3c3c3c;

  background: repeating-conic-gradient(
        from 30deg,
        #0000 0 120deg,
        var(--c3) 0 180deg
      )
      calc(0.5 * var(--s)) calc(0.5 * var(--s) * 0.577),
    repeating-conic-gradient(
      from 30deg,
      var(--c1) 0 60deg,
      var(--c2) 0 120deg,
      var(--c3) 0 180deg
    );
  background-size: var(--s) calc(var(--s) * 0.577);
}
```

## 변환 방식

AvaloniaUI는 CSS의 `repeating-conic-gradient`를 직접 지원하지 않으므로,
`Control.Render` 메서드를 오버라이드하여 `DrawingContext`로 육각형 패턴을 직접 렌더링하는 방식으로 구현했습니다.

### 구현 특징

1. **StyledProperty 사용**: `TileSize`, `Color1`, `Color2`, `Color3` 속성으로 패턴 커스터마이징 가능
2. **타일 기반 렌더링**: 육각형 타일을 반복하여 전체 영역 채움
3. **삼각형 조합**: 각 타일은 6개의 삼각형(각 60도)으로 구성
4. **벌집 패턴 오프셋**: 홀수 행에 타일 오프셋 적용하여 자연스러운 패턴 형성

## 컴파일 에러 및 수정

### 컴파일 에러 없음

이번 빌드에서는 컴파일 에러가 발생하지 않았습니다.
기존 2025-12-27 변환에서 발견된 문제들이 이미 수정되어 있었습니다:

1. XML 주석 내 하이픈 문자 (`--`) 이슈 - 이미 수정됨
2. ResourceDictionary vs Styles 루트 요소 - `Styles` 사용으로 해결됨

## 잠재적 런타임 에러

### 1. 대용량 렌더링 시 성능 저하

**상황**: 매우 큰 영역에서 작은 `TileSize`로 렌더링 시

**가능성**: 중간

**이유**: 모든 타일을 매 프레임마다 `DrawingContext`로 직접 그리기 때문에,
타일 수가 많아지면 렌더링 부하 증가

**권장 대응**:
- `TileSize`를 적절한 크기로 유지 (100px 이상 권장)
- 필요시 `VisualBrush` 타일링으로 최적화 고려

### 2. 창 크기 변경 시 깜빡임

**상황**: 창 크기를 빠르게 조절할 때

**가능성**: 낮음

**이유**: `Render` 메서드가 매번 호출되며 전체 패턴 재계산

**권장 대응**:
- 현재 구현으로는 문제없으나, 심한 경우 캐싱 메커니즘 추가 고려

### 3. StreamGeometry 과다 생성

**상황**: 매 렌더 사이클마다 새 StreamGeometry 객체 생성

**가능성**: 낮음

**이유**: GC 압박이 발생할 수 있으나, 일반적인 사용에서는 무시할 수 있는 수준

**권장 대응**:
- 고성능이 필요한 경우 Geometry 캐싱 또는 RenderTargetBitmap 사용 고려

## 생성된 파일 목록

```
ModernZebra66/AvaloniaUI/
├── ModernZebra66.Avalonia.slnx
├── ModernZebra66.Avalonia.Lib/
│   ├── ModernZebra66.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── ZebraPatternControl.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ZebraPatternControl.axaml
└── ModernZebra66.Avalonia.Gallery/
    ├── ModernZebra66.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **오류**: 0개

## 사용 방법

```xml
<!-- App.axaml에서 스타일 포함 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://ModernZebra66.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 기본 사용 -->
<controls:ZebraPatternControl />

<!-- 크기 변형 -->
<controls:ZebraPatternControl Classes="small"/>
<controls:ZebraPatternControl Classes="large"/>

<!-- 테마 변형 -->
<controls:ZebraPatternControl Classes="light"/>
<controls:ZebraPatternControl Classes="blue"/>

<!-- 커스텀 색상 -->
<controls:ZebraPatternControl TileSize="150"
                               Color1="#2d1b4e"
                               Color2="#4a3372"
                               Color3="#3d2760"/>
```

## 변경 이력

| 날짜 | 내용 |
|------|------|
| 2025-12-27 | 최초 변환, XML 주석 및 ResourceDictionary 이슈 수정 |
| 2026-01-04 | 재변환 확인, 에러 없이 빌드 성공 |
