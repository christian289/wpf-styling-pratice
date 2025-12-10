# RudeMouse79

Radio-buttons 스타일의 세그먼트 선택 컨트롤입니다.

![Category](https://img.shields.io/badge/Category-Radio--buttons-5D5FEF)

## 원본

이 컨트롤은 [uiverse.io](https://uiverse.io)의 CSS 컴포넌트를 WPF로 변환한 것입니다.

**원본 UI**: [https://uiverse.io/Yaya12085/rude-mouse-79](https://uiverse.io/Yaya12085/rude-mouse-79)

**원작자**: Yaya12085

## 구현

이 프로젝트는 **Claude Code (Opus 4.5)** 를 사용하여 자동 변환되었습니다.

### 지원 플랫폼

| 플랫폼 | 프레임워크 | 상태 |
|--------|-----------|------|
| WPF | .NET 10.0 | ✅ 완료 |

## 빌드 및 실행

```bash
cd Wpf && dotnet run --project RudeMouse79.Wpf.Gallery
```

## 기능

- Selector 기반 라디오 버튼 그룹
- 부드러운 선택 전환 애니메이션
- 세그먼트 스타일 UI
- MVVM 패턴 지원 (SelectedIndex 바인딩)

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `display: flex` | `UniformGrid Rows="1"` (ItemsPanel) |
| `flex: 1 1 auto` | UniformGrid 균등 분할 |
| `border-radius: 0.5rem` | `CornerRadius="8"` |
| `transition: all .15s` | `ColorAnimation Duration="0:0:0.15"` |
| `font-weight: 600` | `FontWeight="SemiBold"` |

## 변환 로그

변환 과정에서 발생한 컴파일 에러 및 수정 내용은 프로젝트 루트의 `Log/RudeMouse79_20251210.md` 파일을 참고하세요.

## 라이선스

원본 UI 컴포넌트의 라이선스를 따릅니다.
