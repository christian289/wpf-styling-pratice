# LovelyBulldog50

Inputs 스타일 컨트롤 - 유효성 검사 애니메이션이 있는 텍스트 입력 컨트롤

## 원본 정보

- **원작자:** sonusng
- **원본 링크:** [https://uiverse.io/sonusng/lovely-bulldog-50](https://uiverse.io/sonusng/lovely-bulldog-50)

## 기능

- 입력이 비어있을 때 빨간색 테두리와 shake 애니메이션 (3회)
- 텍스트 입력 시 녹색 테두리로 변경 (유효 상태)
- 투명 배경에 둥근 모서리
- Placeholder 텍스트 지원

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project LovelyBulldog50.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project LovelyBulldog50.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|---------|--------|----------|--------|
| `width` | `210px` | `Width` | `210` |
| `height` | `50px` | `Height` | `50` |
| `padding` | `0 16px` | `Padding` | `16,0` |
| `background` | `transparent` | `Background` | `Transparent` |
| `border-radius` | `4px` | `CornerRadius` | `4` |
| `border` | `1px solid #fe4567` | `BorderBrush`, `BorderThickness` | `#FE4567`, `1` |
| `color` | `#f9f9f9` | `Foreground` | `#F9F9F9` |
| `input:valid` border-color | `#45feaf` | Trigger on `IsValid` | `#45FEAF` |
| `@keyframes shake_541` | `translate: ±8px` | `DoubleAnimationUsingKeyFrames` | `TranslateTransform.X` |
| `animation-duration` | `0.14s` | `Duration` | `0:0:0.14` |
| `animation-iteration-count` | `3` | `RepeatBehavior` | `3x` |

## 프로젝트 구조

```
LovelyBulldog50/
├── Readme.md
├── Wpf/
│   ├── LovelyBulldog50.Wpf.slnx
│   ├── LovelyBulldog50.Wpf.Gallery/     # 데모 애플리케이션
│   └── LovelyBulldog50.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── LovelyBulldog50.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── LovelyBulldog50.xaml
│           └── LovelyBulldog50Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 사용 방법

```xml
<controls:LovelyBulldog50 PlaceholderText="Your Name" />
```

## 속성

| 속성 | 타입 | 설명 |
|-----|------|------|
| `PlaceholderText` | `string` | 입력 전 표시되는 힌트 텍스트 |
| `IsValid` | `bool` | 텍스트가 입력되면 `true` (자동 설정) |
