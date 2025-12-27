# WisePanda94

Buttons 스타일 컨트롤

## 원본 정보

- **원작자**: SouravBandyopadhyay
- **원본 링크**: [https://uiverse.io/SouravBandyopadhyay/wise-panda-94](https://uiverse.io/SouravBandyopadhyay/wise-panda-94)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project WisePanda94.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project WisePanda94.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| Tailwind CSS 클래스 | WPF 구현 | 설명 |
|---|---|---|
| `bg-white` | `Background="White"` | 흰색 배경 |
| `rounded-full` | `CornerRadius="9999"` | 완전한 둥근 모서리 |
| `px-4 py-2` | `Padding="16,8"` | 수평 16px, 수직 8px 패딩 |
| `shadow-md` | `DropShadowEffect` | 중간 크기 그림자 효과 |
| `hover:scale-110` | `ScaleTransform` + `Storyboard` | 호버 시 1.1배 확대 애니메이션 |
| `transition duration-300` | `Duration="0:0:0.3"` | 300ms 전환 시간 |
| `rotate-45` | `RotateTransform Angle="45"` | 45도 회전 |
| `font-semibold` | `FontWeight="SemiBold"` | 굵은 폰트 |
| `text-black` | `Foreground="Black"` | 검은색 텍스트 |
| `space-x-2` | `Margin="0,0,8,0"` | 요소 간 8px 간격 |
| `cursor-pointer` | `Cursor="Hand"` | 손 모양 커서 |

## 프로젝트 구조

```
WisePanda94/
├── Readme.md
├── Wpf/
│   ├── WisePanda94.Wpf.slnx
│   ├── WisePanda94.Wpf.Gallery/    # 데모 앱
│   └── WisePanda94.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── WisePanda94.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── WisePanda94.xaml
│           └── WisePanda94Resources.xaml
└── AvaloniaUI/                     # (미구현)
```
