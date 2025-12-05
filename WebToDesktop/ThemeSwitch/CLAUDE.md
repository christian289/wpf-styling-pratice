# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 테마 개요

낮/밤 테마 전환을 위한 토글 스위치입니다. 해, 달, 구름, 별 애니메이션이 포함된 스키모어픽 디자인입니다.

## 원본 CSS 구조

- `.theme-switch__container`: 외부 컨테이너, 둥근 모서리
- `.theme-switch__clouds`: 하단 구름 레이어 (box-shadow 다중 복제)
- `.theme-switch__stars-container`: 별 SVG 컨테이너
- `.theme-switch__circle-container`: 해/달 주변 글로우 링
- `.theme-switch__sun-moon-container`: 해/달 원형
- `.theme-switch__moon`: 달 (translateX로 슬라이드)
- `.theme-switch__spot`: 달 표면 점

## 빌드 및 실행

```bash
# WPF
cd Wpf && dotnet run --project ThemeSwitch.Wpf.Gallery

# Avalonia
cd Avalonia && dotnet run --project ThemeSwitch.Avalonia.Gallery
```

## 컨트롤

### ThemeSwitchToggle
- WPF: `ThemeSwitch.Wpf.Lib.Controls.ThemeSwitchToggle`
- Avalonia: `ThemeSwitch.Avalonia.Lib.Controls.ThemeSwitchToggle`
- 상속: `ToggleButton`
- 상태: `IsChecked=False` (낮), `IsChecked=True` (밤)

## 컬러 팔레트

- 낮 배경: `#3D7EAE`
- 밤 배경: `#1D1F2C`
- 해: `#ECCA2F`
- 달: `#C4C9D1`
- 달 점: `#959DB1`
- 구름 (전경): `#F3FDFF`
- 구름 (배경): `#AACADF`
- 별: `#FFFFFF`

## 애니메이션

- 배경색 전환: 0.5초
- 해/달 이동: 0.3초
- 달 슬라이드: 0.5초
- 구름 이동: 0.5초
- 별 표시: 0.5초
- 이징: CubicEaseOut
