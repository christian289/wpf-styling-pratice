# HardTreefrog45 변환 로그

## 변환 일시
2026-01-05

## 원본 정보
- **원작자**: themrsami
- **원본 링크**: https://uiverse.io/themrsami/hard-treefrog-45
- **카테고리**: Forms (Signup Form)

## 원본 HTML/CSS 분석
- Tailwind CSS 클래스 기반의 Facebook 스타일 회원가입 폼
- 주요 구성 요소:
  - 제목 및 부제목 헤더
  - 닫기 버튼 (X 아이콘)
  - 이름 입력 필드 (First name, Surname)
  - 이메일/전화번호 입력 필드
  - 비밀번호 입력 필드
  - 생년월일 선택 (Day, Month, Year ComboBox)
  - 성별 선택 (Female, Male, Custom RadioButton)
  - 약관 동의 안내 텍스트
  - Sign Up 버튼

## 빌드 결과
**성공** - 컴파일 에러 없음

## 컴파일 에러
없음

## 잠재적 런타임 에러 가능성

### 1. PasswordBox 바인딩 제한
- **위치**: `HardTreefrog45.xaml` - PasswordBox
- **문제**: WPF PasswordBox는 보안상 Password 속성에 직접 바인딩이 불가능
- **현재 상태**: PasswordBox는 스타일만 적용되어 있으며, Password 값 바인딩은 구현되지 않음
- **해결 방안**: AttachedProperty 또는 Behavior를 통한 우회 바인딩 구현 필요

### 2. RadioButton Gender 바인딩
- **위치**: `HardTreefrog45.xaml` - Gender RadioButton 섹션
- **문제**: RadioButton의 IsChecked와 SelectedGender 속성 간의 양방향 바인딩이 구현되지 않음
- **현재 상태**: RadioButton은 UI만 표시되며, SelectedGender 속성에 값이 반영되지 않음
- **해결 방안**: RadioButton에 개별 Command 또는 IsChecked 바인딩과 Converter 필요

### 3. Hyperlink NavigateUri 미설정
- **위치**: `HardTreefrog45.xaml` - 약관 관련 Hyperlink 요소들
- **문제**: NavigateUri가 설정되지 않아 클릭해도 아무 동작 없음
- **현재 상태**: 시각적 표시만 됨
- **해결 방안**: NavigateUri 설정 또는 RequestNavigate 이벤트 핸들러 필요

### 4. TextBox Placeholder 미구현
- **위치**: `HardTreefrog45.xaml` - 모든 TextBox
- **문제**: HTML placeholder와 동일한 watermark 기능이 없음
- **현재 상태**: 빈 TextBox로 표시됨
- **해결 방안**: Adorner 또는 TextBox Template에 Placeholder TextBlock 추가

## 생성된 파일 목록
1. `HardTreefrog45.Wpf.UI/Controls/HardTreefrog45.cs` - CustomControl 클래스
2. `HardTreefrog45.Wpf.UI/Controls/Converters.cs` - 날짜 인덱스 변환 Converter
3. `HardTreefrog45.Wpf.UI/Themes/HardTreefrog45Resources.xaml` - 테마 리소스
4. `HardTreefrog45.Wpf.UI/Themes/HardTreefrog45.xaml` - 스타일 및 ControlTemplate
5. `HardTreefrog45.Wpf.UI/Themes/Generic.xaml` - ResourceDictionary 병합

## CSS → WPF 변환 매핑

| Tailwind CSS | WPF |
|--------------|-----|
| `max-w-[432px]` | `MaxWidth="432"` |
| `bg-white` | `Background="#FFFFFF"` |
| `rounded-md` | `CornerRadius="6"` |
| `shadow-lg drop-shadow-md` | `DropShadowEffect` |
| `px-4 py-3` | `Padding="16,12,16,12"` |
| `font-bold` | `FontWeight="Bold"` |
| `text-gray-500` | `Foreground="#6B7280"` |
| `ring-1 ring-gray-400` | `BorderThickness="1" BorderBrush="#9CA3AF"` |
| `bg-gray-100` | `Background="#F3F4F6"` |
| `flex space-x-3` | `Grid` with `ColumnDefinitions` |
| `flex-1` | `Width="*"` in ColumnDefinition |
