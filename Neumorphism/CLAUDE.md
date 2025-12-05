# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

뉴모피즘(Neumorphism/Soft UI) 디자인 패턴을 구현한 WPF 컨트롤 라이브러리입니다. 듀얼 섀도우 시스템으로 요소가 표면에서 튀어나오거나 눌린 것처럼 보이는 3D 효과를 구현합니다.

## 빌드 및 실행

```bash
# 솔루션 빌드
dotnet build Neumorphism.slnx

# 갤러리 실행
dotnet run --project NeumorphismGallery
```

## 프로젝트 구조

```
Neumorphism/
├── NeumorphismLib/             # 스타일 라이브러리
│   └── Themes/Generic.xaml     # 모든 컨트롤 스타일 정의
└── NeumorphismGallery/         # 데모 애플리케이션
```

## 디자인 원리

### 듀얼 섀도우 시스템

| 상태 | 효과 | 밝은 그림자 | 어두운 그림자 |
|-----|------|------------|--------------|
| 기본 | 튀어나옴 | 315° (좌상) | 135° (우하) |
| 눌림 | 들어감 | 135° (우하) | 315° (좌상) |

### 핵심 컬러

- 배경: `#E0E5EC` (밝은 회색-파랑)
- 밝은 그림자: `#FFFFFF`
- 어두운 그림자: `#A3B1C6`
- 텍스트: `#4A5568`
- 강조색: `#6366F1`

## 스타일링된 컨트롤

Button, ToggleButton, TextBox, CheckBox, RadioButton, ProgressBar, Slider, ComboBox, ListBox, TabControl, TabItem, GroupBox

## 사용 시 주의사항

- **밝은 배경 필수**: `#E0E5EC` 또는 유사한 밝은 색상에서만 동작
- **어두운 배경 불가**: 뉴모피즘은 어두운 테마에서 작동하지 않음
- **접근성 고려**: 대비가 낮아 시각 장애인에게 어려울 수 있음
