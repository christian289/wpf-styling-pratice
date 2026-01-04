# ModernZebra66 변환 로그

## 변환 일시
2026-01-04

## 원본 정보
- **원작자**: csemszepp (Afif13)
- **원본 링크**: https://uiverse.io/csemszepp/modern-zebra-66
- **카테고리**: Patterns

## 변환 결과

### 컴파일 에러
없음 - 빌드 성공

### 수정 내용
초기 변환 시 에러 없이 성공적으로 빌드됨.

### 잠재적 런타임 오류 가능성

1. **DrawingBrush 타일 정렬 문제**
   - CSS의 `repeating-conic-gradient`는 완벽한 연속 패턴을 생성하지만, WPF의 DrawingBrush 타일링은 경계에서 미세한 간격이 발생할 수 있음
   - 확인 필요: 큰 해상도에서 패턴 경계 확인

2. **색상 정확도**
   - CSS의 conic-gradient는 각도별로 색상이 부드럽게 전환되지만, WPF 구현은 삼각형 섹터로 분할하여 단색으로 채움
   - 원본과 약간 다른 시각적 결과가 나타날 수 있음

3. **성능**
   - DrawingBrush의 복잡한 PathGeometry가 큰 영역에서 렌더링 성능에 영향을 줄 수 있음
   - 확인 필요: 전체 화면 적용 시 성능 테스트

## CSS → WPF 변환 매핑

| CSS | WPF | 비고 |
|-----|-----|------|
| `repeating-conic-gradient` | `DrawingBrush` + `PathGeometry` | WPF는 conic-gradient 미지원 |
| `--c1: #1d1d1d` | `SolidColorBrush` | 가장 어두운 색상 |
| `--c2: #4e4f51` | `SolidColorBrush` | 중간 색상 |
| `--c3: #3c3c3c` | `SolidColorBrush` | 어두운 중간 색상 |
| `from 30deg` | `RotateTransform Angle="30"` | 시작 각도 회전 |
| `background-size` | `Viewport`/`Viewbox` | 타일 크기 설정 |
| `calc()` 오프셋 | `TranslateTransform` | 레이어 오프셋 |

## 파일 구조

```
ModernZebra66/
└── Wpf/
    ├── ModernZebra66.Wpf.slnx
    ├── ModernZebra66.Wpf.UI/
    │   ├── Controls/
    │   │   └── ModernZebra66.cs
    │   └── Themes/
    │       ├── Generic.xaml
    │       ├── ModernZebra66.xaml
    │       └── ModernZebra66Resources.xaml
    └── ModernZebra66.Wpf.Gallery/
        ├── App.xaml
        └── MainWindow.xaml
```
