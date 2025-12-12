# TinyMayfly20 AvaloniaUI 변환 로그

## 프로젝트 정보
- **원본**: uiverse.io by M4NT (notification)
- **변환 날짜**: 2025-12-12
- **대상 프레임워크**: .NET 9.0 + Avalonia 11.2.2

## 변환 개요

CSS `box-shadow`를 사용한 픽셀 아트 Goku 캐릭터가 있는 알림 컨트롤.
호버 시 전체 컨트롤과 텍스트가 위로 이동하는 애니메이션 포함.

## 컴파일 에러 및 수정 내용

### 에러 1: BorderDashArray 속성 미지원
**에러 메시지**:
```
Unable to resolve suitable regular or attached property BorderDashArray on type Avalonia.Controls:Avalonia.Controls.Border
```

**원인**: AvaloniaUI의 `Border` 컨트롤은 `BorderDashArray` 속성을 지원하지 않음.

**수정 방법**: `BorderDashArray="4,2"` 속성 제거. CSS의 `border: 1px dashed` 효과를 직접 구현하려면 별도의 커스텀 컨트롤이 필요함.

**수정 전**:
```xml
<Border BorderDashArray="4,2" ... />
```

**수정 후**:
```xml
<!-- Note: CSS dashed border is not directly supported in AvaloniaUI Border -->
<Border BorderThickness="1" ... />
```

### 에러 2: STAThread 속성 네임스페이스 누락
**에러 메시지**:
```
'STAThreadAttribute' 형식 또는 네임스페이스 이름을 찾을 수 없습니다.
```

**원인**: `System` 네임스페이스 using 문 누락.

**수정 방법**: `Program.cs`에 `using System;` 추가.

### 에러 3: StyleInclude 타입 불일치
**에러 메시지**:
```
Resource is defined as "Avalonia.Controls.ResourceDictionary" type, but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles`에서 `StyleInclude`로 참조하는 리소스는 `IStyle` 타입이어야 하는데, `ResourceDictionary` 타입으로 정의됨.

**수정 방법**: `Generic.axaml`을 `Styles` 루트 요소로 변경하고, 내부에서 `Styles.Resources`로 `ResourceDictionary` 병합.

**수정 전 (Generic.axaml)**:
```xml
<ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..."/>
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

**수정 후 (Generic.axaml)**:
```xml
<Styles>
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="..."/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## Runtime Error 가능성 (직접 확인 필요)

### 1. 픽셀 아트 렌더링 성능
- **위치**: `PixelArtControl.cs` - `Render` 메서드
- **잠재적 문제**: 수백 개의 픽셀을 매 프레임마다 `FillRectangle`으로 그리면 성능 저하 가능
- **권장 확인**: 애니메이션 실행 중 프레임 드롭 여부 확인

### 2. 애니메이션 중첩
- **위치**: `TinyMayfly20.axaml` - 여러 요소의 호버 애니메이션
- **잠재적 문제**: `:pointerover`와 `:not(:pointerover)` 상태 전환 시 애니메이션이 부자연스러울 수 있음
- **권장 확인**: 마우스를 빠르게 진입/이탈 시 애니메이션 상태 확인

### 3. ClipToBounds 설정
- **위치**: 여러 컨트롤의 `ClipToBounds="False"` 설정
- **잠재적 문제**: 픽셀 아트가 부모 컨테이너를 넘어 렌더링되어 레이아웃 문제 발생 가능
- **권장 확인**: 다른 컨트롤과 함께 배치 시 겹침 여부 확인

### 4. CSS 피처 미구현
- **Dashed Border**: CSS의 `border: dashed` 효과가 일반 실선으로 대체됨
- **Font**: 원본 CSS의 'VT323' 폰트가 'Consolas, monospace'로 대체됨
- **권장 확인**: 시각적 차이가 허용 범위 내인지 확인

## 파일 구조

```
TinyMayfly20/AvaloniaUI/
├── TinyMayfly20.Avalonia.slnx
├── TinyMayfly20.Avalonia.Lib/
│   ├── TinyMayfly20.Avalonia.Lib.csproj
│   ├── Controls/
│   │   ├── TinyMayfly20.cs           # 메인 컨트롤
│   │   ├── PixelArtControl.cs        # 픽셀 아트 렌더링 컨트롤
│   │   └── GokuPixelData.cs          # Goku 픽셀 데이터
│   └── Themes/
│       ├── Generic.axaml             # 스타일 진입점
│       └── TinyMayfly20.axaml        # 컨트롤 테마
└── TinyMayfly20.Avalonia.Gallery/
    ├── TinyMayfly20.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── Program.cs
    └── app.manifest
```
