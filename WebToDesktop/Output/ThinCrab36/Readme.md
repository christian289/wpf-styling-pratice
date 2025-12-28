# ThinCrab36

Cards 스타일 컨트롤 - Brutalist 디자인의 경고 카드

## 원본 정보

- **원작자**: 0xnihilism
- **원본 링크**: [https://uiverse.io/0xnihilism/thin-crab-36](https://uiverse.io/0xnihilism/thin-crab-36)
- **태그**: icon, minimalist, notification, card, hover, brutalist

## 미리보기

Brutalist 스타일의 경고 카드로, 다음 요소를 포함합니다:
- 아이콘 + 제목 헤더
- 메시지 본문
- 두 개의 액션 버튼 (Secondary/Primary)
- 호버 시 shine 효과 애니메이션
- 클릭 시 눌림 효과

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project ThinCrab36.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project ThinCrab36.Avalonia.Gallery
```

## 사용법

```xml
<controls:ThinCrab36
    Title="Warning"
    Message="This is a brutalist card with a very angry button."
    SecondaryButtonText="Mark as Read"
    PrimaryButtonText="Okay" />
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Title` | string | "Warning" | 헤더 제목 |
| `Message` | string | (기본 메시지) | 본문 메시지 |
| `PrimaryButtonText` | string | "Okay" | 기본 버튼 텍스트 (검은색 배경) |
| `SecondaryButtonText` | string | "Mark as Read" | 보조 버튼 텍스트 (흰색 배경) |
| `IconData` | string | (경고 아이콘) | SVG Path 데이터 |
| `PrimaryCommand` | ICommand | null | 기본 버튼 클릭 명령 |
| `SecondaryCommand` | ICommand | null | 보조 버튼 클릭 명령 |

### 이벤트

| 이벤트 | 설명 |
|--------|------|
| `PrimaryClick` | 기본 버튼 클릭 시 발생 |
| `SecondaryClick` | 보조 버튼 클릭 시 발생 |

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `width: 320px` | `Width="320"` |
| `border: 4px solid #000` | `BorderThickness="4"` + `BorderBrush="#000"` |
| `background-color: #fff` | `Background="#FFFFFF"` |
| `padding: 1.5rem` | `Padding="24"` |
| `box-shadow: 10px 10px 0 #000` | 별도 `Border` 레이어 (Margin="10,10,0,0") |
| `font-family: Arial` | `FontFamily="Arial, sans-serif"` |
| `font-weight: 900` | `FontWeight="Black"` |
| `font-weight: 700` | `FontWeight="Bold"` |
| `font-weight: 600` | `FontWeight="SemiBold"` |
| `text-transform: uppercase` | `Typography.Capitals="AllSmallCaps"` |
| `border-bottom: 2px solid` | `BorderThickness="0,0,0,2"` |
| `transition: all 0.2s` | `Trigger` + `Storyboard` |
| `transform: translate(-2px, -2px)` | `Margin="-2,-2,7,7"` |
| `::before` (shine effect) | `Rectangle` + `LinearGradientBrush` + `TranslateTransform` 애니메이션 |

## 프로젝트 구조

```
ThinCrab36/
├── Readme.md
├── Wpf/
│   ├── ThinCrab36.Wpf.slnx
│   ├── ThinCrab36.Wpf.Gallery/     # 데모 애플리케이션
│   └── ThinCrab36.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── ThinCrab36.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── ThinCrab36.xaml
│           └── ThinCrab36Resources.xaml
└── AvaloniaUI/                      # (미구현)
```
