# LazyChicken4 변환 로그

## 변환 일시
2025-12-12

## 원본 정보
- 원작자: LeryLey
- 원본 링크: https://uiverse.io/LeryLey/lazy-chicken-4
- 카테고리: Forms

## 컴파일 에러
**없음** - 빌드 성공 (경고 0개, 오류 0개)

## 수정 내용
변환 과정에서 별도의 컴파일 에러가 발생하지 않았습니다.

## Runtime Error 가능성 (직접 확인 필요)

### 1. PasswordBox 바인딩 문제
- **문제**: WPF의 `PasswordBox`는 보안상의 이유로 `Password` 프로퍼티에 직접 바인딩을 지원하지 않음
- **현재 상태**: `PART_PasswordBox`는 XAML에서 바인딩되지 않고 이름만 지정됨
- **해결 방안**:
  - `OnApplyTemplate()`에서 `PasswordChanged` 이벤트 핸들러를 추가하여 `Password` 프로퍼티 동기화
  - 또는 AttachedProperty 패턴 사용

### 2. TextBox Placeholder 표시
- **문제**: `Tag` 속성을 placeholder로 사용하는데, 초기 상태에서 정상 표시되지 않을 수 있음
- **해결 방안**: `Loaded` 이벤트에서 placeholder 가시성 초기화 확인

### 3. Command 실행 시점
- **문제**: `OnApplyTemplate()`에서 버튼 클릭 이벤트 핸들러를 매번 추가하므로, 템플릿이 여러 번 적용되면 핸들러가 중복 등록될 수 있음
- **해결 방안**: 기존 핸들러 제거 후 새 핸들러 등록 패턴 적용

## 변환 매핑

| Tailwind CSS | WPF 구현 |
|--------------|----------|
| `w-80` | `Width="320"` |
| `rounded-lg` | `CornerRadius="8"` |
| `shadow` | `DropShadowEffect` |
| `p-6` | `Padding="24"` |
| `text-slate-700` | `Color="#334155"` |
| `text-slate-500` | `Color="#64748B"` |
| `bg-blue-500` | `Color="#3B82F6"` |
| `hover:bg-blue-600` | `Trigger IsMouseOver` + `Color="#2563EB"` |
| `active:bg-blue-700` | `Trigger IsPressed` + `Color="#1D4ED8"` |
| `focus:border-blue-300` | `Trigger IsFocused` + `Color="#93C5FD"` |
| `border-2` | `BorderThickness="2"` |
| `rounded-md` | `CornerRadius="6"` |
| `ring-2` | `BorderBrush` with ring color |
