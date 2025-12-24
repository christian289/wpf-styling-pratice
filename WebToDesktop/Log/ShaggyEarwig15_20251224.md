# ShaggyEarwig15 변환 로그

## 변환 일자
2024-12-24

## 원본 정보
- **원작자**: Jack17432
- **원본 링크**: https://uiverse.io/Jack17432/shaggy-earwig-15
- **태그**: glassmorphism, checkbox, hamburger, shadow

## 컴파일 에러 수정 내용

### 에러 1: MC4111 - Trigger 대상을 찾을 수 없음

**에러 메시지:**
```
Trigger 대상 'PART_ShadowLight'을(를) 찾을 수 없습니다.
대상은 모든 Setters, Triggers 또는 대상을 사용하는 Conditions 앞에 표시되어야 합니다.
```

**원인:**
WPF에서 Trigger의 Setter는 중첩된 Effect 내부의 DropShadowEffect 속성(`Direction`, `ShadowDepth`)에 직접 접근할 수 없습니다.

**수정 방법:**
1. 외부 그림자를 별도의 Border(`PART_ShadowDark`)로 분리
2. Pressed 상태에서 외부 그림자 Border의 Opacity를 0으로 설정하여 숨김
3. Effect 전체를 `{x:Null}`로 설정하여 제거
4. 별도의 Inset Shadow 오버레이(`PART_InsetShadow`)를 추가하여 눌림 효과 표현

**수정 전:**
```xml
<Trigger Property="IsPressed" Value="True">
    <Setter TargetName="PART_ShadowLight" Property="Direction" Value="135"/>
    <Setter TargetName="PART_ShadowLight" Property="ShadowDepth" Value="4"/>
</Trigger>
```

**수정 후:**
```xml
<Trigger Property="IsPressed" Value="True">
    <Setter TargetName="PART_ShadowDark" Property="Opacity" Value="0"/>
    <Setter TargetName="PART_Border" Property="Effect" Value="{x:Null}"/>
    <Setter TargetName="PART_InsetShadow" Property="Opacity" Value="0.5"/>
</Trigger>
```

## Runtime Error 가능성

### 1. Neumorphism 그림자 효과 차이
- **설명**: CSS의 `box-shadow: inset`은 내부 그림자를 생성하지만, WPF의 `DropShadowEffect`는 외부 그림자만 지원합니다.
- **현재 구현**: `BlurEffect`와 BorderBrush를 조합한 유사 효과로 대체
- **확인 필요**: 눌림 상태에서 시각적 효과가 원본과 정확히 일치하는지 확인 필요

### 2. 햄버거 바 위치 계산
- **설명**: CSS의 `gap: 13%`와 `translateY(290%)`/`translateY(-270%)`는 상대적 비율 기반이지만, WPF에서는 고정 픽셀 값으로 변환됨
- **현재 구현**: `Y="-7.28"` 및 `Y="7.28"` (56px 기준 계산)
- **확인 필요**: 컨트롤 크기 변경 시 바 간격이 비례적으로 조정되지 않을 수 있음

### 3. CornerRadius 100px 처리
- **설명**: CSS의 `border-radius: 100px`는 완전한 pill 모양을 만들지만, WPF에서는 높이(4px)의 절반인 2px가 적절
- **현재 구현**: `CornerRadius="100"`으로 설정 (충분히 큰 값)
- **확인 필요**: 시각적으로 문제없음

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **에러**: 0개
