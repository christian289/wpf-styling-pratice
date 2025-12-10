# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 테마 개요

CSS의 radial-gradient와 box-shadow를 활용한 네온 글로우 버튼입니다. 다크 테마에서 시안/블루 글로우 효과가 돋보입니다.

## 원본 CSS 구조

- `.button`: 외부 컨테이너, radial-gradient 배경
- `.button::after`: 우상단 글로우 효과 (box-shadow)
- `.blob1`: 좌하단 시안/블루 그라데이션 블롭
- `.inner`: 내부 콘텐츠 영역
- `.inner::before`: 시안 오버레이

## 빌드 및 실행

```bash
# WPF
cd Wpf && dotnet run --project NeonGlow.Wpf.Gallery

# Avalonia
cd Avalonia && dotnet run --project NeonGlow.Avalonia.Gallery
```

## 컨트롤

### NeonGlowButton
- WPF: `NeonGlow.Wpf.Lib.Controls.NeonGlowButton`
- Avalonia: `NeonGlow.Avalonia.Lib.Controls.NeonGlowButton`
- 상속: `Button`

## 컬러 팔레트

- 외부 배경: `#FFFFFF` → `#181B1B` (radial-gradient)
- 블롭: `#3FE9FF` → `#0000FF80` → `Transparent`
- 내부: `#777777` → `#0F1111`
- 글로우: `#FFFFFF38`, `#0051FF2D`
