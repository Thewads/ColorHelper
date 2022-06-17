using ColorService.Models;

namespace ColorService.Converters;

public interface IRgbToLabConverter
{
    Lab Convert(Rgb inputRgb);
}