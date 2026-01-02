# SpottyShrimp35 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: `WebToDesktop/source/20260102_SpottyShrimp35/`
- **출처**: Uiverse.io by lautyYT
- **태그**: simple, blue, pattern
- **변환 일시**: 2026-01-02

## 원본 CSS 분석

```css
.container {
  width: 100%;
  height: 100%;
  background: repeating-linear-gradient(45deg, #0050fc, #0050fc 20px, #0684fade 20px, #0684fade 40px);
}
```

### CSS 해석
- 45도 각도의 반복 선형 그라데이션
- 첫 번째 색상: `#0050fc` (파란색) - 0~20px
- 두 번째 색상: `#0684fade` (연한 파란색, 투명도 포함) - 20~40px
- 패턴 반복 주기: 40px

## AvaloniaUI 변환 전략

### 주요 변환 방식
CSS의 `repeating-linear-gradient`를 AvaloniaUI에서 직접 지원하지 않으므로 `DrawingBrush`와 `GeometryDrawing`을 사용하여 타일링 패턴으로 구현함.

### 구현 구조
1. **StripedPatternControl**: ContentControl을 상속한 커스텀 컨트롤
2. **DrawingBrush**: TileMode="Tile"로 40x40 타일 반복
3. **PathGeometry**: 45도 대각선 스트라이프를 평행사변형으로 구현

## 컴파일 에러

**없음** - 빌드 성공 (경고 0개, 오류 0개)

## 잠재적 런타임 오류 가능성

### 1. Stripe2Color 투명도 처리
- **위치**: `StripedPatternControl.cs:32`
- **원본 값**: `#0684fade` (알파 채널 `de` = 222/255 ≈ 87% 불투명도)
- **현재 구현**: `#0684fa` (100% 불투명)
- **설명**: 원본 CSS에서 두 번째 색상에 투명도가 포함되어 있으나, 현재 구현에서는 완전 불투명으로 처리됨
- **영향**: 시각적 차이 발생 가능 (원본보다 약간 더 진하게 보임)
- **해결 방안**: `Color.Parse("#de0684fa")` 또는 `Color.FromArgb(222, 6, 132, 250)`으로 수정

### 2. TemplateBinding 사용 시 색상 바인딩
- **위치**: `StripedPatternControl.axaml:39, 53`
- **내용**: `{Binding Stripe1Color, RelativeSource={RelativeSource TemplatedParent}}`
- **설명**: AvaloniaUI에서 GeometryDrawing 내부의 바인딩은 런타임에 정상 작동하지 않을 수 있음
- **영향**: 커스텀 색상이 적용되지 않고 기본값으로 표시될 수 있음
- **테스트 필요**: Gallery에서 다양한 색상으로 테스트하여 확인

### 3. DrawingBrush 렌더링 성능
- **내용**: 복잡한 DrawingBrush 패턴은 대형 영역에서 렌더링 성능에 영향을 줄 수 있음
- **영향**: 큰 화면이나 창 크기 조절 시 버벅임 발생 가능
- **권장**: 성능 문제 발생 시 렌더 비트맵 캐싱 고려

## 프로젝트 구조

```
SpottyShrimp35/AvaloniaUI/
├── SpottyShrimp35.Avalonia.slnx
├── SpottyShrimp35.Avalonia.Lib/
│   ├── SpottyShrimp35.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── StripedPatternControl.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── StripedPatternControl.axaml
└── SpottyShrimp35.Avalonia.Gallery/
    ├── SpottyShrimp35.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개

경과 시간: 00:00:29.59
```

## 참고 사항

- RadialGradientBrush 사용 없음 (Issue #19888 해당 없음)
- CSS `repeating-linear-gradient` → AvaloniaUI `DrawingBrush` + `TileMode.Tile` 변환
