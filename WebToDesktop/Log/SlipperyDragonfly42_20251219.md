# SlipperyDragonfly42 변환 로그

## 변환 정보

- **변환일**: 2025-12-19
- **원본 소스**: uiverse.io (iZOXVL)
- **컨트롤 유형**: 로그인 폼 (Login Form)

## 빌드 결과

**상태**: 성공 (경고 0개, 오류 0개)

## 컴파일 에러

없음

## 잠재적 런타임 오류 가능성

### 1. PasswordBox 바인딩 제한

- **문제**: WPF의 `PasswordBox`는 보안상의 이유로 `Password` 속성에 대한 직접 바인딩을 지원하지 않음
- **현재 구현**: `PART_PasswordBox`라는 이름으로 PasswordBox를 정의했으나, Password 속성 바인딩이 구현되지 않음
- **해결 방안**:
  - AttachedProperty를 사용하여 바인딩 구현
  - 또는 `OnApplyTemplate()`에서 `PART_PasswordBox`를 찾아 `PasswordChanged` 이벤트 핸들러 연결

### 2. TextBox Placeholder 동작

- **문제**: PasswordBox의 Placeholder는 입력 시작 시 숨겨지는 로직이 없음 (Focus 상태에서만 처리됨)
- **현재 구현**: TextBox는 `Text` 속성의 빈 문자열 체크로 Placeholder 표시
- **해결 방안**: PasswordBox는 별도의 `HasPassword` AttachedProperty 구현 필요

### 3. 폰트 의존성

- **문제**: `FontWeight="ExtraBold"`, `FontWeight="Medium"` 사용
- **가능성**: 일부 시스템 폰트에서 지원하지 않을 수 있음
- **해결 방안**: 필요시 특정 폰트 패밀리 지정

## 생성된 파일 목록

```
SlipperyDragonfly42.Wpf.UI/
├── Controls/
│   └── SlipperyDragonfly42.cs
└── Themes/
    ├── Generic.xaml
    ├── SlipperyDragonfly42.xaml
    └── SlipperyDragonfly42Resources.xaml

SlipperyDragonfly42.Wpf.Gallery/
├── App.xaml
└── MainWindow.xaml
```

## CSS → WPF 변환 내역

| CSS (Tailwind) | 값 | WPF 리소스 키 |
|----------------|-----|---------------|
| `bg-gray-800` | `#1f2937` | `SlipperyDragonfly42.Background.Card` |
| `bg-gray-700` | `#374151` | `SlipperyDragonfly42.Background.Input` |
| `text-white` | `#ffffff` | `SlipperyDragonfly42.Foreground.Title` |
| `text-gray-400` | `#9ca3af` | `SlipperyDragonfly42.Foreground.Subtitle` |
| `bg-indigo-500` | `#6366f1` | `SlipperyDragonfly42.Background.Button` |
| `hover:bg-indigo-600` | `#4f46e5` | `SlipperyDragonfly42.Background.ButtonHover` |
| `text-indigo-500` | `#6366f1` | `SlipperyDragonfly42.Foreground.Link` |
| `hover:text-indigo-400` | `#818cf8` | `SlipperyDragonfly42.Foreground.LinkHover` |
| `text-gray-900` | `#111827` | `SlipperyDragonfly42.Foreground.Button` |
| `rounded-lg` | `8px` | `SlipperyDragonfly42.CornerRadius.Card` |
| `rounded-md` | `6px` | `SlipperyDragonfly42.CornerRadius.Input` |
| `box-shadow` | 복합 | `SlipperyDragonfly42.Shadow.Card` (DropShadowEffect) |
