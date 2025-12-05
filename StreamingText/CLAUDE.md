# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

AI 챗봇(Claude Desktop, ChatGPT 등)에서 볼 수 있는 실시간 타이핑 효과를 구현한 WPF 커스텀 컨트롤입니다.

## 빌드 및 실행

```bash
# 라이브러리 빌드
dotnet build StreamingTextLib

# 갤러리 빌드 및 실행
dotnet build StreamingTextGallery
dotnet run --project StreamingTextGallery
```

## 프로젝트 구조

```
StreamingText/
├── StreamingTextLib/
│   ├── StreamingTextControl.cs   # 메인 컨트롤 클래스
│   └── Themes/Generic.xaml       # 스타일 템플릿
└── StreamingTextGallery/         # 데모 애플리케이션
```

## StreamingTextControl API

### 속성 (DependencyProperty)

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `Text` | string | "" | 표시할 전체 텍스트 |
| `DisplayedText` | string | "" | 현재 표시된 텍스트 (읽기 전용) |
| `CharactersPerSecond` | double | 50.0 | 초당 글자 수 (1~200) |
| `IsStreaming` | bool | false | 스트리밍 중 여부 (읽기 전용) |
| `AutoStart` | bool | true | 자동 시작 여부 |

### 메서드

- `StartStreamingAsync()` - 스트리밍 시작
- `StopStreaming()` - 스트리밍 중지
- `ResetAndRestartAsync()` - 초기화 후 재시작
- `ResetDisplay()` - 표시 초기화
- `SkipToEnd()` - 전체 텍스트 즉시 표시

### 이벤트

- `StreamingCompleted` - 스트리밍 완료 시
- `StreamingCancelled` - 스트리밍 취소 시

## 제공 스타일

- **기본**: 커서(▊) 표시
- **ChatBotStyle**: 다크 테마, Consolas 폰트
- **SimpleStyle**: 미니멀, 파이프(|) 커서

## 기술 구현

- 비동기 `Task` 기반으로 UI 스레드 블로킹 없음
- `CancellationToken`으로 안전한 취소 처리
- `Dispatcher.InvokeAsync`로 UI 업데이트 최적화
