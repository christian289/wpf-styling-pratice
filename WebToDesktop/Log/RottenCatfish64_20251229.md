# RottenCatfish64 변환 로그

## 변환 일시
2025-12-29

## 원본 정보
- 원작자: AmruthGowda91200
- 원본 링크: https://uiverse.io/AmruthGowda91200/rotten-catfish-64
- 카테고리: Patterns

## 컴파일 에러
없음 - 빌드 성공

## 변환 특이사항

### CSS `repeating-linear-gradient` 변환
원본 CSS는 4개의 `repeating-linear-gradient`를 레이어로 사용하여 복잡한 대각선 줄무늬 패턴을 생성합니다.

```css
background: repeating-linear-gradient(-45deg, #ff7e5f, #ff7e5f 10px, #3f51b5 10px, #3f51b5 20px),
            repeating-linear-gradient(45deg, #3f51b5, #3f51b5 10px, #ff7e5f 10px, #ff7e5f 20px),
            repeating-linear-gradient(-30deg, #3f51b5, #3f51b5 10px, #ff7e5f 10px, #ff7e5f 20px),
            repeating-linear-gradient(30deg, #ff7e5f, #ff7e5f 10px, #3f51b5 10px, #3f51b5 20px);
```

WPF에서는 `repeating-linear-gradient`를 직접 지원하지 않으므로 다음과 같이 변환:
- `DrawingBrush` + `TileMode="Tile"` 사용
- `DrawingGroup`으로 여러 레이어 조합
- `RotateTransform`으로 대각선 각도 구현
- `Opacity`로 레이어 블렌딩 효과

### WPF 구현 방식
```xml
<DrawingBrush TileMode="Tile" Viewport="0,0,40,40" ViewportUnits="Absolute">
    <DrawingBrush.Drawing>
        <DrawingGroup>
            <!-- 여러 각도의 회전된 줄무늬 레이어 -->
        </DrawingGroup>
    </DrawingBrush.Drawing>
</DrawingBrush>
```

## Runtime Error 가능성

### 잠재적 문제
1. **패턴 정확도**: CSS의 4개 레이어 블렌딩과 WPF의 Opacity 기반 블렌딩은 동일하지 않을 수 있음
   - CSS는 각 그라데이션이 독립적으로 쌓이지만, WPF는 DrawingGroup Opacity로 시뮬레이션
   - 실제 렌더링 결과가 원본과 다를 수 있음

2. **타일 경계**: 회전된 DrawingBrush 타일의 경계에서 미세한 이음새가 보일 수 있음
   - 줌 레벨에 따라 픽셀 정렬 문제 발생 가능

3. **성능**: 복잡한 DrawingBrush 패턴은 큰 영역에서 렌더링 성능에 영향을 줄 수 있음

## 생성된 파일
- `RottenCatfish64.Wpf.UI/Controls/RottenCatfish64.cs`
- `RottenCatfish64.Wpf.UI/Themes/RottenCatfish64Resources.xaml`
- `RottenCatfish64.Wpf.UI/Themes/RottenCatfish64.xaml`
- `RottenCatfish64.Wpf.UI/Themes/Generic.xaml`
- `RottenCatfish64.Wpf.Gallery/MainWindow.xaml`
- `RottenCatfish64.Wpf.Gallery/App.xaml`
