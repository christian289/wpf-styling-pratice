# PlasticMule29 변환 로그

## 변환 일시
2024-12-30

## 원본 정보
- 원작자: cssbuttons-io
- 원본 링크: https://uiverse.io/cssbuttons-io/plastic-mule-29
- 카테고리: Buttons

## 컴파일 에러 및 수정

### 에러 1: StackPanel.Spacing 속성 없음

**에러 내용:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다. 줄 11 위치 77.
```

**원인:**
- WPF의 StackPanel에는 `Spacing` 속성이 없음
- `Spacing`은 AvaloniaUI에서 지원하는 속성

**수정 방법:**
- `Spacing="20"` 속성 제거
- 각 자식 요소에 `Margin` 속성 추가로 간격 구현

**수정 전:**
```xml
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="20">
    <controls:PlasticMule29 Content="BUTTON" />
    <controls:PlasticMule29 Content="CLICK ME" />
    <controls:PlasticMule29 Content="SUBMIT" />
</StackPanel>
```

**수정 후:**
```xml
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
    <controls:PlasticMule29 Content="BUTTON" Margin="0,0,0,20" />
    <controls:PlasticMule29 Content="CLICK ME" Margin="0,0,0,20" />
    <controls:PlasticMule29 Content="SUBMIT" />
</StackPanel>
```

## 잠재적 런타임 오류

### 1. CSS inset box-shadow의 완벽한 재현 어려움
- **설명:** CSS의 `inset box-shadow`는 그라데이션 blur 효과가 있지만, WPF에서는 단색 Border로 시뮬레이션
- **영향:** 시각적으로 약간 다를 수 있음
- **확인 필요:** 실행하여 시각적 차이 확인

### 2. DropShadowEffect 성능
- **설명:** DropShadowEffect는 렌더링 성능에 영향을 줄 수 있음
- **영향:** 많은 버튼을 동시에 표시할 경우 프레임 저하 가능
- **확인 필요:** 대량의 버튼 배치 시 성능 테스트

### 3. 애니메이션 타이밍 차이
- **설명:** CSS `cubic-bezier(0,.8,.26,.99)`를 WPF 기본 easing으로 대체
- **영향:** 애니메이션 느낌이 원본과 약간 다를 수 있음
- **확인 필요:** 실행하여 애니메이션 동작 확인

## 최종 빌드 결과
- **상태:** 성공
- **경고:** 0개
- **오류:** 0개
