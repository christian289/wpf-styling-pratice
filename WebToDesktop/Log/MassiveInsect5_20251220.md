# MassiveInsect5 변환 로그

## 변환 일시
2025-12-20

## 원본 정보
- 원작자: Smit-Prajapati
- 원본 링크: https://uiverse.io/Smit-Prajapati/massive-insect-5
- 카테고리: Cards

## 빌드 결과
**성공** - 컴파일 오류 없음, 경고 없음

## 에러 수정 내용
컴파일 에러 없이 빌드 성공

## 잠재적 Runtime Error (직접 확인 필요)

### 1. Canvas.Top 바인딩 문제
- **위치**: `MassiveInsect5.xaml` - Box1~Box4의 Canvas.Top 바인딩
- **내용**: `Canvas.Bottom` 대신 `Canvas.Top`을 사용하고 `ActualHeight`에 바인딩하여 하단 위치를 계산
- **잠재 오류**: Canvas가 크기를 가지지 않으면 바인딩이 0을 반환하여 박스가 상단에 위치할 수 있음
- **권장 확인**: 실행 후 박스 위치가 올바른지 확인

### 2. RadialGradientBrush GradientOrigin 값
- **위치**: `MassiveInsect5Resources.xaml` - 배경 및 박스 그라데이션
- **내용**: CSS `radial-gradient(circle at 100% 107%, ...)` → `GradientOrigin="1,1.07" Center="1,1.07"`
- **잠재 오류**: WPF RadialGradientBrush는 1.0을 초과하는 값에서 예상과 다르게 렌더링될 수 있음
- **권장 확인**: 그라데이션 방향이 원본과 일치하는지 확인

### 3. DropShadowEffect 성능
- **위치**: `MassiveInsect5Resources.xaml` - Card.Shadow, Box.Shadow, Icon.Glow
- **내용**: 다수의 DropShadowEffect 사용
- **잠재 오류**: 여러 Effect가 동시에 활성화되면 렌더링 성능 저하 가능
- **권장 확인**: 애니메이션 부드러움 확인

### 4. 비대칭 CornerRadius 근사값
- **위치**: `MassiveInsect5.xaml` - Box1~Box4
- **내용**: CSS `border-radius: 10% 13% 42% 0%/10% 12% 75% 0%` → WPF `CornerRadius="14,18,105,0"` (픽셀 값 근사)
- **잠재 오류**: 퍼센트 기반 border-radius는 요소 크기에 따라 달라지지만 WPF는 고정 픽셀 사용
- **권장 확인**: 박스 모서리 모양이 원본과 유사한지 확인

### 5. Logo Path 스케일링
- **위치**: `MassiveInsect5.xaml` - LogoCanvas 내 Path 요소들
- **내용**: SVG viewBox `0 0 29.667 31.69`를 30x30 Canvas에 맞추기 위해 RenderTransform 스케일 적용
- **잠재 오류**: Path2, Path3의 transform translate 값이 정확하지 않을 수 있음
- **권장 확인**: 로고가 올바르게 표시되는지 확인

## 변환 특이사항

### CSS → WPF 변환 시 주요 변경점

1. **position: absolute + inset: 0** → Border를 Grid 내에 배치하여 전체 영역 채움
2. **CSS transition** → WPF Storyboard + DoubleAnimation
3. **transition-delay** → BeginTime 속성
4. **::before pseudo-element** → 추가 Border (Overlay) 요소로 구현
5. **:hover 상태** → IsMouseOver Trigger
6. **filter: drop-shadow** → DropShadowEffect

### 애니메이션 타이밍
- Card hover: 1초 (ease-in-out)
- Logo 이동: 0.6초 (ease-in-out)
- Box 슬라이드: 1초 (transition-delay: 0s, 0.2s, 0.4s, 0.6s)
- Box overlay fade: 0.5초 (ease-in-out)
