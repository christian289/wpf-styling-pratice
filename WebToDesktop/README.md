# WebToDesktop - uiverse.io to WPF 자동 변환 시스템

uiverse.io의 UI 컴포넌트를 자동으로 WPF CustomControl로 변환하는 GitHub Actions 자동화 시스템입니다.

## 전체 아키텍처

```
┌────────────────────────────────────────────────────────────────────┐
│                         GitHub Actions                             │
│              (스케줄: 하루 5번 자동 실행)                            │
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
│                    워크플로우 단계                                  │
│                                                                    │
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
    ├── CLAUDE.md                   # Claude Code 변환 가이드
    ├── source/                     # 다운로드된 원본 HTML/CSS
    │   └── {날짜}_{컴포넌트명}/
    │       ├── {컴포넌트명}.html
    │       ├── {컴포넌트명}.css
    │       └── metadata.json
    ├── Log/                        # 변환 오류 해결 로그
    │   └── {컴포넌트명}_{날짜}.md
    └── {컴포넌트명}/               # 변환된 컨트롤 폴더
        ├── Readme.md               # 컨트롤 설명 (원본 정보, 빌드 방법)
        └── Wpf/                    # WPF 프로젝트
            ├── {컴포넌트명}.Wpf.slnx
            ├── {컴포넌트명}.Wpf.UI/
            └── {컴포넌트명}.Wpf.Gallery/
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

| KST (한국시간) | UTC          |
| -------------- | ------------ |
| 03:00          | 18:00 (전날) |
| 07:00          | 22:00 (전날) |
| 11:00          | 02:00        |
| 15:00          | 06:00        |
| 19:00          | 10:00        |

## 수동 실행

1. GitHub 저장소 → Actions 탭
2. "Web to WPF Converter" 워크플로우 선택
3. "Run workflow" 클릭

## 필수 요구사항

로컬 PC에 다음이 설치되어 있어야 합니다:

| 소프트웨어  | 확인 명령어        |
| ----------- | ------------------ |
| Node.js     | `node --version`   |
| Git         | `git --version`    |
| .NET SDK    | `dotnet --version` |
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

---

## 새 PC에서 Self-hosted Runner 설정하기

기존 빌드 머신에서 새 PC로 이전하거나 처음 설정할 때 다음 단계를 따르세요.

### 1단계: 기존 Runner 제거 (기존 PC에서)

기존 PC의 Runner를 먼저 제거해야 합니다:

```powershell
# 기존 PC에서 실행
cd C:\actions-runner
.\config.cmd remove --token {REMOVE_TOKEN}
```

> **토큰 발급**: GitHub → Settings → Actions → Runners → 해당 Runner → Remove 클릭 시 토큰 표시

또는 GitHub 웹에서 직접 삭제:
1. GitHub 저장소 → Settings → Actions → Runners
2. 오프라인 상태의 Runner 선택 → "Remove" 클릭

### 2단계: 새 PC에 필수 소프트웨어 설치

```powershell
# 설치 확인
node --version      # v18 이상
npm --version
git --version
dotnet --version    # .NET 9.0 이상
claude --version    # Claude Code CLI
```

**Claude Code CLI 설치**:
```powershell
npm install -g @anthropic-ai/claude-code
claude login   # 브라우저에서 로그인
```

### 3단계: 새 Runner 다운로드 및 구성

1. GitHub 저장소 → Settings → Actions → Runners → "New self-hosted runner"
2. Windows x64 선택
3. 표시된 명령어 실행:

```powershell
# 폴더 생성
mkdir C:\actions-runner && cd C:\actions-runner

# Runner 다운로드 (버전은 GitHub 페이지에서 확인)
Invoke-WebRequest -Uri https://github.com/actions/runner/releases/download/v2.xxx.x/actions-runner-win-x64-2.xxx.x.zip -OutFile actions-runner.zip

# 압축 해제
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory("$PWD\actions-runner.zip", "$PWD")

# Runner 구성 (토큰은 GitHub 페이지에서 복사)
.\config.cmd --url https://github.com/{owner}/{repo} --token {TOKEN}
```

구성 시 질문:
- Runner group: Enter (기본값)
- Runner name: 원하는 이름 입력 (예: `wpf-converter-pc2`)
- Labels: Enter (기본값 `self-hosted,Windows,X64`)
- Work folder: Enter (기본값 `_work`)

### 4단계: Task Scheduler로 자동 시작 설정

PowerShell(관리자)에서 실행:

```powershell
$action = New-ScheduledTaskAction -Execute "C:\actions-runner\run.cmd" -WorkingDirectory "C:\actions-runner"
$trigger = New-ScheduledTaskTrigger -AtStartup
$settings = New-ScheduledTaskSettingsSet -AllowStartIfOnBatteries -DontStopIfGoingOnBatteries -StartWhenAvailable
Register-ScheduledTask -TaskName "GitHub Actions Runner" -Action $action -Trigger $trigger -Settings $settings -RunLevel Highest -User "$env:USERNAME"
```

**비밀번호 입력 필요**: Windows 계정 비밀번호 입력

### 5단계: 수동으로 Runner 시작 및 테스트

```powershell
# Task Scheduler 즉시 실행
Start-ScheduledTask -TaskName "GitHub Actions Runner"

# 또는 직접 실행
cd C:\actions-runner
.\run.cmd
```

GitHub에서 Runner 상태 확인:
- Settings → Actions → Runners → "Idle" 상태면 성공

---

## 트러블슈팅

### 1. `node`, `dotnet`, `claude` 명령어를 찾을 수 없음

**원인**: Task Scheduler로 백그라운드 실행 시 PATH 환경변수가 로드되지 않음

**해결**: 워크플로우에서 PATH를 직접 설정 (이미 적용됨)

```yaml
env:
  PATH_ADDITIONS: C:\Program Files\nodejs;C:\Users\{사용자명}\AppData\Roaming\npm;C:\Program Files\dotnet;C:\Program Files\Git\cmd

steps:
  - name: Setup PATH environment
    run: |
      $newPath = "${{ env.PATH_ADDITIONS }};$env:PATH"
      echo "PATH=$newPath" >> $env:GITHUB_ENV
```

> **새 PC에서**: `PATH_ADDITIONS`의 경로가 실제 설치 경로와 일치하는지 확인

### 2. `git diff --staged --quiet` 오류

**원인**: PowerShell에서 exit code 1을 오류로 처리

**해결**: `$LASTEXITCODE` 사용 (이미 적용됨)

```powershell
git diff --staged --quiet
if ($LASTEXITCODE -ne 0) {
    "has_changes=true" >> $env:GITHUB_OUTPUT
} else {
    "has_changes=false" >> $env:GITHUB_OUTPUT
}
exit 0  # 항상 성공으로 종료
```

### 3. Runner가 오프라인 상태

**확인**:
```powershell
Get-Process -Name "Runner.Listener" -ErrorAction SilentlyContinue
```

**해결**:
```powershell
# Task Scheduler로 시작
Start-ScheduledTask -TaskName "GitHub Actions Runner"

# 또는 직접 시작
cd C:\actions-runner && .\run.cmd
```

### 4. 스케줄 워크플로우가 실행되지 않음

**확인사항**:
- 워크플로우 파일이 default branch (main)에 있는지 확인
- Self-hosted runner가 "Idle" 상태인지 확인
- GitHub Actions 스케줄은 최대 15-60분 지연될 수 있음

---

## 워크플로우 핵심 설정 설명

### Claude Code CLI 실행 옵션

```powershell
claude -p $prompt --allowedTools "Bash,Read,Write,Edit,Glob,Grep" --max-turns 50 --dangerously-skip-permissions
```

| 옵션 | 설명 |
|------|------|
| `-p` | 프롬프트 모드 (대화형이 아닌 단일 실행) |
| `--allowedTools` | 허용할 도구 목록 |
| `--max-turns` | 최대 실행 턴 수 |
| `--dangerously-skip-permissions` | 모든 권한 자동 승인 (자동화에 필수) |

### 프롬프트 구조

```
/wpf-custom-control {컨트롤명} "{HTML경로}" "{CSS경로}"

추가 지시사항...
```

슬래시 커맨드(`/wpf-custom-control`)와 추가 지시사항을 하나의 프롬프트로 묶어서 전달합니다.
Claude Code는 슬래시 커맨드를 먼저 확장(expand)한 후 전체 컨텍스트를 처리합니다.

---

## 자동화 구축 히스토리

이 자동화 시스템은 다음 과정을 거쳐 구축되었습니다:

1. **초기 설계**: uiverse.io 크롤링 → WPF 변환 자동화 기획
2. **데이터 소스 결정**: Playwright 대신 uiverse-io/galaxy GitHub 저장소 활용 (API 친화적)
3. **Runner 선택**: Claude Max 구독은 API 키가 없으므로 Self-hosted Runner 사용
4. **스크립트 개발**: download-component.js, extract-html-css.js 작성
5. **워크플로우 작성**: GitHub Actions YAML 작성
6. **트러블슈팅**: bash→pwsh, PATH 문제, git diff exit code 문제 해결
7. **폴더 구조 개선**: `{컨트롤명}/Wpf/` 구조로 변경, Readme.md 자동 생성

---

## 변경 이력

| 날짜 | 변경 내용 |
|------|----------|
| 2025-12-10 | 초기 자동화 시스템 구축 |
| 2025-12-10 | 폴더 구조 개선: `{컨트롤명}/Wpf/` 구조, Readme.md 자동 생성 |
