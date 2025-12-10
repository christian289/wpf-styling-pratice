# WebToDesktop - uiverse.io to WPF 자동 변환 시스템

uiverse.io의 UI 컴포넌트를 자동으로 WPF CustomControl로 변환하는 GitHub Actions 자동화 시스템입니다.

## 전체 아키텍처

```
┌────────────────────────────────────────────────────────────────────┐
│                         GitHub Actions                              │
│              (스케줄: 하루 5번 자동 실행)                              │
└─────────────────────────┬──────────────────────────────────────────┘
                          │ 트리거
                          ▼
┌────────────────────────────────────────────────────────────────────┐
│              Self-hosted Runner (로컬 PC)                           │
│                    C:\actions-runner\                              │
└─────────────────────────┬──────────────────────────────────────────┘
                          │ 실행
                          ▼
┌────────────────────────────────────────────────────────────────────┐
│                    워크플로우 단계                                   │
│                                                                     │
│  1. download-component.js  →  uiverse.io에서 HTML 다운로드          │
│  2. extract-html-css.js    →  HTML에서 CSS 분리                     │
│  3. Claude Code CLI        →  /wpf-custom-control 커맨드 실행       │
│  4. Git commit & push      →  결과물 저장                           │
└────────────────────────────────────────────────────────────────────┘
```

## 파일 구조

```
wpf-styling-pratice/
├── .github/workflows/
│   └── web-to-wpf-converter.yml    # GitHub Actions 워크플로우
├── scripts/
│   ├── download-component.js       # 컴포넌트 다운로드 스크립트
│   ├── extract-html-css.js         # HTML/CSS 분리 스크립트
│   └── package.json                # Node.js 의존성
└── WebToDesktop/
    ├── README.md                   # 이 문서
    ├── source/                     # 다운로드된 원본 HTML/CSS
    │   └── {날짜}_{컴포넌트명}/
    │       ├── {컴포넌트명}.html
    │       ├── {컴포넌트명}.css
    │       └── metadata.json
    ├── Log/                        # 변환 오류 해결 로그
    │   └── {컴포넌트명}_{날짜}.md
    └── {컴포넌트명}.Wpf.UI/        # 변환된 WPF 프로젝트들
```

## 스크립트 설명

### scripts/download-component.js

**역할**: uiverse-io/galaxy 저장소에서 랜덤 UI 컴포넌트 다운로드

**동작 흐름**:
1. GitHub API로 uiverse-io/galaxy 저장소 접근
2. 카테고리 중 하나 랜덤 선택 (Buttons, Cards, Checkboxes, Forms, Inputs, loaders, Notifications, Patterns, Radio-buttons, Toggle-switches, Tooltips)
3. 해당 카테고리에서 HTML 파일 랜덤 선택
4. 이미 처리한 파일은 건너뜀 (.processed.log 확인)
5. 파일명에서 PascalCase 컨트롤 이름 생성 (예: `big-ape-36` → `BigApe36`)

**출력**:
```
WebToDesktop/source/{날짜}_{컴포넌트명}/
├── {컴포넌트명}.html     # 원본 HTML (CSS 포함)
└── metadata.json         # 메타데이터 (원본 파일명, 카테고리, 다운로드 시간)
```

### scripts/extract-html-css.js

**역할**: 다운로드한 HTML에서 `<style>` 태그의 CSS를 분리

**필요한 이유**:
- uiverse.io 컴포넌트는 `<style>` 태그가 HTML 안에 인라인으로 포함됨
- `/wpf-custom-control` 커맨드는 HTML과 CSS를 별도 파일로 받음

**출력**:
```
WebToDesktop/source/{날짜}_{컴포넌트명}/
├── {컴포넌트명}.structure.html  # CSS 제거된 HTML 구조
└── {컴포넌트명}.css             # 추출된 CSS
```

## Self-hosted Runner

### 왜 Self-hosted Runner를 사용하는가?

- **Claude Max 구독**은 API 키를 제공하지 않음
- GitHub의 클라우드 Runner에서는 Claude Code CLI 사용 불가
- Self-hosted Runner를 사용하면 로컬의 Claude Code CLI 활용 가능 (추가 비용 없음)

### 설치 위치

```
C:\actions-runner\
├── run.cmd              # Runner 실행 스크립트
├── config.cmd           # Runner 구성 스크립트
├── bin/                 # Runner 실행 파일들
├── externals/           # 내장 Node.js
├── _diag/               # 진단 로그
├── .credentials         # GitHub 인증 정보
└── .runner              # Runner 설정
```

### Runner 실행 방법

```powershell
cd C:\actions-runner
.\run.cmd
```

### Runner 자동 실행 설정 (Task Scheduler)

PowerShell(관리자)에서 실행:

```powershell
$action = New-ScheduledTaskAction -Execute "C:\actions-runner\run.cmd" -WorkingDirectory "C:\actions-runner"
$trigger = New-ScheduledTaskTrigger -AtStartup
$settings = New-ScheduledTaskSettingsSet -AllowStartIfOnBatteries -DontStopIfGoingOnBatteries -StartWhenAvailable
Register-ScheduledTask -TaskName "GitHub Actions Runner" -Action $action -Trigger $trigger -Settings $settings -RunLevel Highest -User "$env:USERNAME"
```

## 데이터 흐름

```
[uiverse-io/galaxy 저장소]
         │
         │ (1) download-component.js가 랜덤 HTML 다운로드
         ▼
[WebToDesktop/source/20241210_BigApe36/BigApe36.html]
         │
         │ (2) extract-html-css.js가 CSS 분리
         ▼
[BigApe36.html] + [BigApe36.css]
         │
         │ (3) Claude Code CLI 실행
         │     /wpf-custom-control BigApe36 "BigApe36.html" "BigApe36.css"
         ▼
[WebToDesktop/BigApe36.Wpf.UI/]  ← WPF 프로젝트 생성됨
├── Controls/BigApe36.cs
├── Themes/BigApe36.xaml
├── Themes/BigApe36Resources.xaml
└── Themes/Generic.xaml

[WebToDesktop/Log/BigApe36_20241210.md]  ← 오류 해결 로그
         │
         │ (4) Git commit & push
         ▼
[GitHub 저장소에 자동 커밋]
```

## 실행 스케줄

GitHub Actions 워크플로우는 하루 5번 자동 실행됩니다:

| KST (한국시간) | UTC |
|----------------|-----|
| 03:00 | 18:00 (전날) |
| 07:00 | 22:00 (전날) |
| 11:00 | 02:00 |
| 15:00 | 06:00 |
| 19:00 | 10:00 |

## 수동 실행

1. GitHub 저장소 → Actions 탭
2. "Web to WPF Converter" 워크플로우 선택
3. "Run workflow" 클릭

## 필수 요구사항

로컬 PC에 다음이 설치되어 있어야 합니다:

| 소프트웨어 | 확인 명령어 |
|-----------|------------|
| Node.js | `node --version` |
| Git | `git --version` |
| .NET SDK | `dotnet --version` |
| Claude Code | `claude --version` |

## 로그 파일 설명

`WebToDesktop/Log/{컴포넌트명}_{날짜}.md` 파일에는 다음 내용이 기록됩니다:

- **Compile Error**: 빌드 중 발생한 컴파일 오류
- **수정 방법**: Claude가 적용한 수정 내용
- **Runtime Error 가능성**: 직접 확인이 필요한 잠재적 런타임 오류

> **주의**: compile error만 자동으로 해결되며, runtime error는 직접 확인이 필요합니다.

## 관련 Claude Code 설정

- **Command**: `/wpf-custom-control` - WPF CustomControl 생성
- **Skill**: `html-css-to-wpf-xaml` - HTML/CSS를 WPF XAML로 변환 시 참고하는 가이드
