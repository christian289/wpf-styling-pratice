using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DangerousQuail58.Wpf.UI.Controls;

public sealed class DangerousQuail58 : ContentControl
{
    public static readonly IValueConverter HeightMultiplierConverter = new HeightMultiplierValueConverter();
    public static readonly IValueConverter CenterOffsetConverter = new CenterOffsetValueConverter();
    public static readonly IMultiValueConverter ClipRectConverter = new ClipRectMultiValueConverter();
    public static readonly IMultiValueConverter RectConverter = new RectMultiValueConverter();

    static DangerousQuail58()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DangerousQuail58),
            new FrameworkPropertyMetadata(typeof(DangerousQuail58)));
    }

    // 높이를 배수로 변환하는 컨버터
    // Converter to multiply height by a factor
    private sealed class HeightMultiplierValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double height && parameter is string multiplierStr &&
                double.TryParse(multiplierStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var multiplier))
            {
                return height * multiplier;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    // 중앙 오프셋 계산 컨버터: (containerSize - elementSize * multiplier) / 2
    // Center offset converter: (containerSize - elementSize * multiplier) / 2
    private sealed class CenterOffsetValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double containerSize && parameter is string multiplierStr &&
                double.TryParse(multiplierStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var multiplier))
            {
                var elementSize = containerSize * multiplier;
                return (containerSize - elementSize) / 2;
            }

            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    // 둥근 모서리 클리핑을 위한 RectangleGeometry 생성 컨버터
    // Converter to create RectangleGeometry for rounded corner clipping
    private sealed class ClipRectMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 3 &&
                values[0] is double width &&
                values[1] is double height &&
                values[2] is CornerRadius cornerRadius)
            {
                // RadiusX, RadiusY는 CornerRadius의 TopLeft 값 사용 (균일한 모서리 가정)
                // Use TopLeft value from CornerRadius for RadiusX/Y (assuming uniform corners)
                var radiusX = cornerRadius.TopLeft;
                var radiusY = cornerRadius.TopLeft;

                return new RectangleGeometry(new Rect(0, 0, width, height), radiusX, radiusY);
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    // Width, Height를 Rect로 변환하는 컨버터
    // Converter to create Rect from Width and Height
    private sealed class RectMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 &&
                values[0] is double width &&
                values[1] is double height)
            {
                return new Rect(0, 0, width, height);
            }

            return Rect.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
