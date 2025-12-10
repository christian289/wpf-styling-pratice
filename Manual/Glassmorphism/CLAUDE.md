# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

글래스모피즘(Glassmorphism) 디자인 패턴을 구현한 WPF 컨트롤 라이브러리입니다. 반투명 배경, 블러 효과, 미묘한 테두리로 유리 같은 UI를 구현합니다.

## 빌드 및 실행

```bash
# 솔루션 빌드
dotnet build Glassmorphism.slnx

# 갤러리 실행
dotnet run --project GlassmorphismGallery
```

## 프로젝트 구조

```
Glassmorphism/
├── GlassmorphismLib/           # 스타일 라이브러리
│   └── Themes/Generic.xaml     # 모든 컨트롤 스타일 정의
└── GlassmorphismGallery/       # 데모 애플리케이션
```

## 스타일링된 컨트롤

Button, TextBox, CheckBox, RadioButton, ProgressBar, Slider, Label, ComboBox, ListBox, TabControl, GroupBox, ToggleButton

## 디자인 특성

- **배경**: 40-80% 불투명도의 반투명 흰색 (`#40FFFFFF` ~ `#30FFFFFF`)
- **테두리**: 60% 불투명 흰색 (`#60FFFFFF`), 1px
- **모서리**: 10-12px 라운드
- **그림자**: 10-20px 블러의 DropShadow
- **호버 효과**: 불투명도 및 그림자 증가
- **포커스 효과**: 강조색 글로우

## 핵심 컬러 팔레트

- Primary: `#667EEA`
- Secondary: `#764BA2`
- Accent: `#F093FB`
- Success: `#48BB78`
- Warning: `#F6AD55`
- Danger: `#FC8181`

## 사용 시 주의사항

글래스모피즘은 **진한 그라데이션 배경**에서만 효과가 살아납니다. 반드시 화려한 배경색 위에서 사용해야 합니다.
