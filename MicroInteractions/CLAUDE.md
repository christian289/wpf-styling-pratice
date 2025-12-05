# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

2020년대 마이크로 인터랙션 애니메이션 패턴을 구현한 WPF 컨트롤 라이브러리입니다. 리플 효과, 네비게이션 인디케이터 슬라이드, 회전/탄성 애니메이션 등을 제공합니다.

## 빌드 및 실행

```bash
# 솔루션 빌드
dotnet build MicroInteractions.slnx

# 갤러리 실행
dotnet run --project MicroInteractionsGallery
```

## 프로젝트 구조

```
MicroInteractions/
├── MicroInteractionsLib/       # 스타일 라이브러리
│   └── Themes/Generic.xaml     # 모든 컨트롤 스타일 및 애니메이션
└── MicroInteractionsGallery/   # 데모 애플리케이션
```

## 애니메이션 패턴

| 컨트롤 | 애니메이션 | 이징 함수 |
|-------|-----------|----------|
| Button | 리플 효과 + 스케일 | CubicEase |
| ToggleButton | 360° 플립 회전 | BackEase |
| CheckBox | 360° 회전 스핀 | BackEase |
| RadioButton | 탄성 바운스 | ElasticEase |
| TextBox | 포커스 스케일 | CubicEase |
| ComboBox | 드롭다운 스케일 + 화살표 회전 | BackEase |
| ComboBoxItem | 슬라이드인 | CubicEase |
| ListBoxItem | 슬라이드인 | CubicEase |
| TabControl | 하단 인디케이터 슬라이드 | BackEase |
| Slider | 썸 호버 스케일 | BackEase |

## 기술 구현

- **Storyboard**: 복합 다중 속성 애니메이션
- **Triggers**: 인터랙션 기반 애니메이션용 PropertyTrigger/EventTrigger
- **RenderTransforms**: ScaleTransform, RotateTransform, TranslateTransform
- **Easing Functions**: BackEase, ElasticEase, CubicEase

## 핵심 컬러

- Primary: `#3B82F6` (파랑)
- Accent: `#8B5CF6` (보라)
- Background: `#0A0A0A` (다크)
- Surface: `#1A1A1A`
- Border: `#2A2A2A`
