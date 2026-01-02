# SpottyZebra83 변환 로그

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개

## 컴파일 에러

없음. 빌드가 성공적으로 완료되었습니다.

## Runtime Error 가능성 (직접 확인 필요)

### 1. 툴팁 위치 오프셋 조정 필요 가능성

- **위치**: `SpottyZebra83.xaml` - TooltipContainer의 `Margin="0,-60,0,0"`
- **상황**: 툴팁이 컨트롤 상단에 올바르게 표시되지 않을 수 있음
- **확인 방법**: 실행 후 호버 시 툴팁 위치 확인
- **해결 방법**: Margin 값 조정

### 2. 슬라이드 애니메이션 TranslateTransform 값

- **위치**: `SpottyZebra83.xaml` - HoverBackgroundTranslate 및 DefaultTextTranslate의 X 값이 180으로 하드코딩
- **상황**: Width가 180px로 고정되어 있어, 다른 크기로 변경 시 애니메이션이 부자연스러울 수 있음
- **확인 방법**: Width 속성을 다른 값으로 변경하여 테스트
- **해결 방법**: 동적 바인딩 또는 Converter 사용 고려

### 3. Shake 애니메이션 타이밍

- **위치**: `SpottyZebra83.xaml` - DoubleAnimationUsingKeyFrames (TooltipRotate)
- **상황**: CSS의 `animation: shake 0.5s ease-in-out both`와 WPF 구현 간 미세한 타이밍 차이가 있을 수 있음
- **확인 방법**: 호버 시 흔들림 애니메이션의 자연스러움 확인
- **해결 방법**: KeyTime 값 미세 조정

### 4. DropShadowEffect 성능

- **위치**: MainBorder와 TooltipContainer에 DropShadowEffect 적용
- **상황**: DropShadowEffect는 GPU 집약적이며, 많은 컨트롤 인스턴스 사용 시 성능 저하 가능
- **확인 방법**: 여러 컨트롤을 동시에 렌더링하여 프레임 드롭 확인
- **해결 방법**: 필요 시 Effect 비활성화 또는 비트맵 캐싱 사용

## CSS 변환 시 참고 사항

| CSS 속성 | WPF 변환 | 비고 |
|---------|---------|------|
| `cubic-bezier(0.23, 1, 0.32, 1)` | `CubicEase EaseOut` | 정확한 cubic-bezier 값 대신 근사 이징 사용 |
| `transform-origin: -100%` | 미적용 | WPF에서 음수 RenderTransformOrigin 지원 제한적 |
| `text-transform: uppercase` | 수동 대문자 사용 | WPF에 text-transform 없음, TextBlock에 직접 대문자 입력 필요 |
| `scale: 0` (CSS 속성) | `ScaleTransform` | CSS의 독립 scale 속성을 transform으로 변환 |
