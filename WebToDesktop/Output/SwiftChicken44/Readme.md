# SwiftChicken44

Inputs 스타일 컨트롤 - 유효성 검사 상태에 따라 시각적 피드백을 제공하는 텍스트 입력 컨트롤

## 원본 정보

- **원작자:** SARAN2004
- **원본 링크:** [https://uiverse.io/SARAN2004/swift-chicken-44](https://uiverse.io/SARAN2004/swift-chicken-44) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project SwiftChicken44.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SwiftChicken44.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:SwiftChicken44 IsValid="True" Text="Valid Input"/>
<controls:SwiftChicken44 IsValid="False" Text="Invalid Input"/>
<controls:SwiftChicken44 IsValid="{x:Null}" Text="Default State"/>
```

### 속성

| 속성 | 타입 | 설명 |
|------|------|------|
| `IsValid` | `bool?` | 유효성 상태 (null: 기본, true: 유효, false: 무효) |
| `Text` | `string` | 입력 텍스트 (TextBox 상속) |

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 속성 | 변환 값 |
|----------|-----|----------|---------|
| `max-width` | `190px` | `MaxWidth` | `190` |
| `height` | `45px` | `Height` | `45` |
| `font-size` | `16px` | `FontSize` | `16` |
| `border-radius` | `5px` | `CornerRadius` | `5` |
| `padding-left` | `15px` | `Padding` | `15,0,5,0` |
| `border` | `1px solid #ccc` | `BorderThickness`, `BorderBrush` | `1,1,1,2`, `#CCCCCC` |
| `border-bottom-width` | `2px` | `BorderThickness` | bottom: `2` |
| `border-color` (valid) | `#00ff2a` | `BorderBrush` | `#00FF2A` |
| `color` (valid) | `#00ff2a` | `Foreground` | `#00FF2A` |
| `box-shadow` (valid) | `2px 2px 8px 1px #00ff2a` | `DropShadowEffect` | `BlurRadius=8`, `Color=#00FF2A` |
| `border-color` (invalid) | `#ff0000` | `BorderBrush` | `#FF0000` |
| `color` (invalid) | `#ff0000` | `Foreground` | `#FF0000` |
| `box-shadow` (invalid) | `2px 2px 8px 1px #ff0000` | `DropShadowEffect` | `BlurRadius=8`, `Color=#FF0000` |
| `transition` | `all 0.3s ease` | - | 미구현 (Trigger로 즉시 전환) |

## 프로젝트 구조

```
SwiftChicken44/
├── Wpf/
│   ├── SwiftChicken44.Wpf.slnx
│   ├── SwiftChicken44.Wpf.Gallery/    # 데모 앱
│   └── SwiftChicken44.Wpf.UI/         # 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SwiftChicken44.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SwiftChicken44.xaml
│           └── SwiftChicken44Resources.xaml
└── AvaloniaUI/                        # (미구현)
```
