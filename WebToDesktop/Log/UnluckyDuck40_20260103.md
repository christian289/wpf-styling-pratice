# UnluckyDuck40 변환 로그

## 변환 일시
2026-01-03

## 원본 정보
- 원작자: boryanakrasteva
- 원본 링크: https://uiverse.io/boryanakrasteva/unlucky-duck-40
- 카테고리: Buttons (social, button, share)

## 컴파일 에러 및 수정 사항

### 에러 1: CharacterSpacing 속성 미지원
- **에러 메시지**: `XML 네임스페이스에 'CharacterSpacing' 속성이 없습니다.`
- **원인**: CSS `letter-spacing: 2.5px`를 WPF `CharacterSpacing` 속성으로 변환했으나, WPF TextBlock에는 해당 속성이 없음
- **수정 방법**: `CharacterSpacing="150"` 속성 제거
- **영향**: 글자 간격이 기본값으로 유지됨 (원본 CSS의 letter-spacing 효과 없음)

### 에러 2: StackPanel Spacing 속성 미지원
- **에러 메시지**: `XML 네임스페이스에 'Spacing' 속성이 없습니다.`
- **원인**: WPF StackPanel에는 `Spacing` 속성이 없음 (Avalonia/UWP에서만 지원)
- **수정 방법**: `Spacing="20"` 속성 제거, 개별 요소의 Margin으로 간격 조정
- **영향**: 없음 (기존 Margin 값이 이미 적용되어 있음)

## 잠재적 런타임 오류

### 1. Instagram 그라데이션 렌더링
- **위치**: `UnluckyDuck40.xaml` Instagram 아이콘 부분
- **설명**: CSS `radial-gradient`를 WPF `RadialGradientBrush`로 변환함. CSS의 `gradientTransform`(회전/이동)은 WPF에서 직접 지원되지 않아 근사값으로 변환함
- **가능성**: 그라데이션 모양이 원본과 약간 다를 수 있음
- **확인 필요**: 런타임에서 Instagram 아이콘 색상 확인 필요

### 2. Twitter Path 변환
- **위치**: `UnluckyDuck40Resources.xaml` TwitterIcon.PathData
- **설명**: SVG path가 다른 좌표계(translate 변환 포함)에서 작성됨. Canvas RenderTransform으로 보정함
- **가능성**: 아이콘이 잘리거나 위치가 어긋날 수 있음
- **확인 필요**: 런타임에서 Twitter 아이콘 표시 확인 필요

### 3. 호버 애니메이션 타이밍
- **위치**: `UnluckyDuck40.xaml` ControlTemplate.Triggers
- **설명**: CSS `transition: .2s linear`를 WPF Storyboard로 변환함
- **가능성**: 애니메이션 이징이 CSS와 약간 다를 수 있음
- **확인 필요**: 호버 시 소셜 아이콘 패널의 슬라이드 업 애니메이션 확인 필요

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 속성 | 비고 |
|---------|---------|------|
| `width: 130px` | `Width="130"` | |
| `height: 40px` | `Height="40"` | |
| `border-radius: 20px` | `CornerRadius="20"` | |
| `border: 1px solid black` | `BorderThickness="1" BorderBrush="Black"` | |
| `background-color: transparent` | `Background="Transparent"` | |
| `filter: drop-shadow(...)` | `DropShadowEffect` | |
| `opacity: 0` | `Opacity="0"` | |
| `visibility: hidden` | Opacity로 처리 | WPF에서는 Visibility 애니메이션 대신 Opacity 사용 |
| `transition: .2s linear` | `Duration="0:0:0.2"` Storyboard | |
| `top: -120%` | `TranslateTransform Y="-48"` | 40px × 120% = 48px |
| `letter-spacing: 2.5px` | (미지원) | WPF TextBlock에서 지원 안 함 |
| `text-transform: uppercase` | (Code-behind 필요) | XAML에서 직접 지원 안 함, Text 값을 대문자로 설정 |
| `gap: 10px` | `Margin="10,0"` | StackPanel 간격 |
| `radial-gradient` | `RadialGradientBrush` | |
| `linear-gradient` | `LinearGradientBrush` | |
