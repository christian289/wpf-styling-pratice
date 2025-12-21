# PinkCheetah76 변환 로그

## 변환 일시
2025-12-21

## 원본 정보
- 원작자: SiddhantEngineer
- 원본 링크: https://uiverse.io/SiddhantEngineer/pink-cheetah-76
- 카테고리: Buttons

## 컴파일 에러 및 수정 내역

### 에러 1: XML 주석 내 '--' 사용 불가
- **파일**: `PinkCheetah76.Wpf.UI/Themes/PinkCheetah76Resources.xaml`
- **에러 메시지**: `MC3000: 'An XML comment cannot contain '--', and '-' cannot be the last character.'`
- **원인**: CSS 변수 `--button-accent`를 주석에 그대로 사용
- **수정 방법**: `--button-accent` → `[button-accent]` 형식으로 변경 (skill 가이드 준수)

### 에러 2: WPF StackPanel에 Spacing 속성 없음
- **파일**: `PinkCheetah76.Wpf.Gallery/MainWindow.xaml`
- **에러 메시지**: `MC3072: XML 네임스페이스에 'Spacing' 속성이 없습니다.`
- **원인**: WPF의 StackPanel은 Spacing 속성을 지원하지 않음 (AvaloniaUI와 다름)
- **수정 방법**: 각 자식 요소에 `Margin="0,0,0,20"` 적용

## 잠재적 런타임 오류 (확인 필요)

### 1. 3D 버튼 눌림 효과 시각적 이슈
- **설명**: CSS의 `box-shadow` 다중 레이어를 WPF Border 중첩으로 구현함
- **우려사항**: 눌렸을 때 Margin 변경으로 레이어 위치 조정하는데, 크기가 변하거나 깜빡임이 있을 수 있음
- **검증 방법**: 실행 후 버튼 클릭 시 시각적 확인 필요

### 2. 텍스트 그림자 효과
- **설명**: CSS `text-shadow: 0px 0px 1px black` (3회 중첩)를 WPF `DropShadowEffect`로 구현
- **우려사항**: WPF의 DropShadowEffect는 단일 그림자만 지원하므로 원본과 다를 수 있음
- **검증 방법**: 실행 후 텍스트 가독성 확인 필요

### 3. color-mix 근사값 사용
- **설명**: CSS `color-mix(in oklab, #FF0000 80%, black)`을 `#CC0000`으로 근사화
- **우려사항**: 정확한 색상 계산이 아닌 추정값이므로 원본과 색상 차이 있을 수 있음
- **검증 방법**: 원본 웹 버전과 색상 비교 필요
