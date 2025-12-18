# HTML/CSS → WPF XAML 변환 케이스 인덱스

## 빠른 검색

| 케이스 | 제목                                 | 태그                                       | 파일                              |
| ------ | ------------------------------------ | ------------------------------------------ | --------------------------------- |
| C001   | Duration 타입 오류                   | `#animation` `#duration` `#staticresource` | [animation.md](animation.md#c001) |
| C002   | 그라데이션 바 개수 오류              | `#transform` `#pseudo-element` `#before`   | [transform.md](transform.md#c002) |
| C003   | Grid.Clip 클리핑 오류                | `#clipping` `#grid` `#rotate`              | [clipping.md](clipping.md#c003)   |
| C004   | OpacityMask 클리핑 오류              | `#clipping` `#opacitymask`                 | [clipping.md](clipping.md#c004)   |
| C005   | ClipToBounds + CornerRadius 오류     | `#clipping` `#cornerradius` `#border`      | [clipping.md](clipping.md#c005)   |
| C006   | 회전 요소 Grid 컨테이너 오류         | `#layout` `#canvas` `#grid` `#rotate`      | [layout.md](layout.md#c006)       |
| C007   | CSS height: 130% 해석 오류           | `#transform` `#height` `#diagonal`         | [transform.md](transform.md#c007) |
| C008   | ContentPresenter Canvas 내 배치 오류 | `#layout` `#canvas` `#alignment`           | [layout.md](layout.md#c008)       |
| C009   | StackPanel.Spacing 속성 없음         | `#layout` `#stackpanel` `#avalonia-only`   | [wpf-limitations.md](wpf-limitations.md#c009) |
| C010   | BooleanToVisibilityConverter.Default 없음 | `#converter` `#singleton`             | [wpf-limitations.md](wpf-limitations.md#c010) |
| C011   | Trigger TargetName Transform 참조 불가 | `#trigger` `#transform` `#property-path` | [wpf-limitations.md](wpf-limitations.md#c011) |
| C012   | CornerRadius.Empty 없음              | `#cornerradius` `#animation`               | [wpf-limitations.md](wpf-limitations.md#c012) |
| C013   | XML 주석에서 '--' 사용 불가           | `#xml` `#comment` `#css-variable`          | [wpf-limitations.md](wpf-limitations.md#c013) |

## 태그별 분류

### #clipping

- [C003: Grid.Clip 클리핑 오류](clipping.md#c003)
- [C004: OpacityMask 클리핑 오류](clipping.md#c004)
- [C005: ClipToBounds + CornerRadius 오류](clipping.md#c005)

### #animation

- [C001: Duration 타입 오류](animation.md#c001)

### #layout

- [C006: 회전 요소 Grid 컨테이너 오류](layout.md#c006)
- [C008: ContentPresenter Canvas 내 배치 오류](layout.md#c008)

### #transform

- [C002: 그라데이션 바 개수 오류](transform.md#c002)
- [C007: CSS height: 130% 해석 오류](transform.md#c007)
- [C011: Trigger TargetName Transform 참조 불가](wpf-limitations.md#c011)

### #wpf-limitations (WPF 제한사항)

- [C009: StackPanel.Spacing 속성 없음](wpf-limitations.md#c009)
- [C010: BooleanToVisibilityConverter.Default 없음](wpf-limitations.md#c010)
- [C011: Trigger TargetName Transform 참조 불가](wpf-limitations.md#c011)
- [C012: CornerRadius.Empty 없음](wpf-limitations.md#c012)
- [C013: XML 주석에서 '--' 사용 불가](wpf-limitations.md#c013)

### #converter

- [C010: BooleanToVisibilityConverter.Default 없음](wpf-limitations.md#c010)

## 케이스 추가 방법

새로운 실수 발견 시 [case-template.md](case-template.md)의 템플릿을 사용하여 해당 카테고리 파일에 추가하고, 이 인덱스도 업데이트.
