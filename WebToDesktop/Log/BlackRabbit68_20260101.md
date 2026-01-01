# BlackRabbit68 변환 로그

## 변환 정보

- **변환 일시**: 2026-01-01
- **원본**: HTML/CSS (uiverse.io)
- **원작자**: JohnnyCSilva
- **컨트롤 유형**: Cards (3D 회전 비트코인 코인)

## 빌드 결과

**성공** - 컴파일 에러 없음

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 변환 과정에서의 주요 결정사항

### 1. CSS 3D 회전 → WPF 2D 시뮬레이션

**원본 CSS:**
```css
animation: rotate_4001510 7s infinite linear;
transform-style: preserve-3d;
transform: rotateY(-90deg);
backface-visibility: hidden;
```

**WPF 구현:**
- WPF는 네이티브 CSS 3D transform을 지원하지 않음
- `ScaleTransform.ScaleX`를 사용하여 3D 회전 효과 시뮬레이션
- ScaleX: 1 → 0 → -1 → 0 → 1 사이클로 앞/뒤면 전환
- `backface-visibility: hidden`은 Visibility 전환으로 구현

### 2. SVG → WPF Path

**원본 SVG:**
- viewBox: 4091.27 x 4091.73
- 비트코인 로고 (원형 배경 + B 심볼)

**WPF 구현:**
- SVG path data를 `Geometry` 리소스로 변환
- `Canvas` + `Viewbox`로 크기 조절 가능하게 구현

### 3. CSS pseudo-elements → WPF 레이어

**원본 CSS:**
```css
.coin:before, .coin:after {
  background: linear-gradient(#faa504, #141001);
}
```

**WPF 구현:**
- `::before`, `::after`는 `CoinEdge` Rectangle으로 구현
- 코인이 옆면을 보일 때만 Visible

## 잠재적 Runtime 오류

1. **애니메이션 타이밍 불일치**: CSS의 `linear` 타이밍과 WPF KeyFrame 보간이 미묘하게 다를 수 있음
2. **ScaleX=-1 시 렌더링**: 일부 GPU에서 음수 스케일 렌더링 시 깜빡임 가능성
3. **CoinSize 바인딩**: `CoinSize` 프로퍼티 변경 시 애니메이션 재시작 필요 (현재 미구현)

## 생성된 파일 목록

```
BlackRabbit68.Wpf.slnx
BlackRabbit68.Wpf.Gallery/
├── BlackRabbit68.Wpf.Gallery.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs
BlackRabbit68.Wpf.UI/
├── BlackRabbit68.Wpf.UI.csproj
├── Controls/
│   └── BlackRabbit68.cs
├── Themes/
│   ├── Generic.xaml
│   ├── BlackRabbit68.xaml
│   └── BlackRabbit68Resources.xaml
└── Properties/
    └── AssemblyInfo.cs
```
