# QuietCougar91 AvaloniaUI 변환 로그

## 변환 일시
2025-12-29

## 원본
- 출처: Uiverse.io by kyle1dev
- 유형: Tooltip Button
- 기능: 호버 시 텍스트가 위로 이동하고 툴팁이 나타나는 버튼 컨트롤

## 컴파일 에러

### 에러 1: 빈 AXAML 파일
- **에러 내용**: `Avalonia error AVLN1001: File doesn't contain valid XAML: System.Xml.XmlException: Root element is missing.`
- **발생 파일**: `QuietCougar91.Avalonia.Lib\Themes\QuietCougar91Control.axaml`
- **원인**: 빈 파일이 프로젝트에 포함됨
- **수정 방법**: 빈 파일 삭제

### 에러 2: 빈 C# 파일
- **에러 내용**: 빈 파일이 컴파일에 포함됨
- **발생 파일**: `QuietCougar91.Avalonia.Lib\Controls\QuietCougar91Control.cs`
- **원인**: 빈 파일이 프로젝트에 포함됨
- **수정 방법**: 빈 파일 삭제

## 잠재적 런타임 오류

### 1. 애니메이션 FillMode 동작
- **위치**: `QuietCougar91Button.axaml` Line 90-95, 100-108, 112-129
- **위험도**: 낮음
- **설명**: `FillMode="Forward"`를 사용하여 애니메이션 종료 후 상태를 유지하지만, `:not(:pointerover)` 상태에서 원래 상태로 복귀하는 애니메이션이 정의되어 있지 않음. 마우스가 버튼에서 벗어날 때 상태 복원이 즉시 일어나거나 부자연스러울 수 있음.
- **확인 필요**: 실제 실행 시 hover out 시 애니메이션이 부드럽게 작동하는지 확인 필요

### 2. RenderTransform 중첩 가능성
- **위치**: `QuietCougar91Button.axaml` Line 132-138 (pressed 상태)
- **위험도**: 낮음
- **설명**: pressed 상태에서 ScaleTransform을 적용하지만, 기존 hover 상태의 애니메이션과 충돌할 수 있음
- **확인 필요**: 호버 상태에서 클릭 시 애니메이션 전환이 부드러운지 확인 필요

### 3. PathIcon Data 유효성
- **위치**: `QuietCougar91Button.axaml` Line 44-45
- **위험도**: 낮음
- **설명**: 원본 HTML의 SVG path data를 PathIcon에 그대로 적용함. AvaloniaUI의 Geometry 파서가 모든 SVG path 명령을 지원하지 않을 수 있음.
- **확인 필요**: 아이콘이 정상적으로 렌더링되는지 확인 필요

## CSS → AXAML 변환 사항

| CSS 속성 | AXAML 속성 | 비고 |
|---------|-----------|------|
| `linear-gradient(to right, ...)` | `LinearGradientBrush StartPoint="0%,50%" EndPoint="100%,50%"` | - |
| `box-shadow: 0 4px 8px rgba(...)` | `BoxShadow="0 4 8 #80000000"` | rgba → hex alpha |
| `border-radius: 6px` | `CornerRadius="6"` | - |
| `padding: 15px 30px` | `Padding="30,15"` | 순서 주의 (L,T,R,B vs T,R,B,L) |
| `:hover` | `:pointerover` | - |
| `:active` | `:pressed` | - |
| `cursor: pointer` | `Cursor="Hand"` | - |
| `transform: scale(0.95)` | `<ScaleTransform ScaleX="0.95" ScaleY="0.95"/>` | - |
| `transform: translateY(-10px)` | `<TranslateTransform Y="-10"/>` | - |
| `transition: ... 0.4s ease` | `Duration="0:0:0.4" Easing="CubicEaseOut"` | - |

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **오류**: 0개
