# OrangeNewt83

Cards 스타일 컨트롤 - 회전 효과가 있는 음식 메뉴 카드

## 원본 정보

- **원작자**: ElSombrero2
- **원본 링크**: [https://uiverse.io/ElSombrero2/orange-newt-83](https://uiverse.io/ElSombrero2/orange-newt-83) (클릭 시 원본 CSS/HTML 확인 가능)

## 미리보기

배경 카드와 전면 카드가 서로 반대 방향으로 회전되어 있으며, 호버 시 두 카드가 정렬됩니다.

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project OrangeNewt83.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project OrangeNewt83.Avalonia.Gallery
```

## 컨트롤 속성

| 속성 | 타입 | 설명 |
|------|------|------|
| `Icon` | `object` | 아이콘 콘텐츠 (SVG Path, 이미지 등) |
| `Title` | `string` | 제목 텍스트 |
| `Info` | `string` | 정보 텍스트 (예: "30 Min \| 165 Sell") |
| `Price` | `string` | 가격 텍스트 |
| `PricePrefix` | `string` | 가격 접두사 (기본값: $) |

## 사용 예시

```xml
<controls:OrangeNewt83 Title="Spicy Burger"
                       Info="30 Min | 165 Sell"
                       Price="2.50">
    <controls:OrangeNewt83.Icon>
        <Viewbox Width="80" Height="80">
            <!-- SVG Path 또는 이미지 -->
        </Viewbox>
    </controls:OrangeNewt83.Icon>
</controls:OrangeNewt83>
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `width: 190px` | `Width="190"` | 카드 너비 |
| `height: 254px` | `Height="254"` | 카드 높이 |
| `border-radius: 5px` | `CornerRadius="5"` | 모서리 둥글기 |
| `box-shadow: 0px 0px 5px 1px #00000022` | `DropShadowEffect` | 그림자 효과 |
| `transform: rotateZ(5deg)` | `RotateTransform Angle="5"` | 회전 변환 |
| `transform: rotateZ(-5deg)` | `RotateTransform Angle="-5"` | 반대 방향 회전 |
| `transition: transform 300ms` | `DoubleAnimation Duration="0:0:0.3"` | 애니메이션 |
| `::before` | 별도 `Border` 요소 | 가상 요소를 실제 요소로 구현 |
| `:hover` | `IsMouseOver` Trigger | 호버 상태 |
| `background-color: #ee9933` | `SolidColorBrush` | 배경색 |
| `color: #00000066` | `SolidColorBrush` (40% 투명도) | 텍스트 색상 |

## 파일 구조

```
OrangeNewt83/
├── Readme.md
├── Wpf/
│   ├── OrangeNewt83.Wpf.slnx
│   ├── OrangeNewt83.Wpf.Gallery/
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── OrangeNewt83.Wpf.UI/
│       ├── Controls/
│       │   └── OrangeNewt83.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── OrangeNewt83.xaml
│           └── OrangeNewt83Resources.xaml
└── AvaloniaUI/
    └── (미구현)
```

## 제한 사항

- CSS `:active` 상태(클릭 시 그림자 제거)는 WPF `ContentControl`에서 지원되지 않아 구현되지 않음
- 필요시 `ButtonBase` 상속으로 변경하여 `IsPressed` 속성 사용 가능
