using ColorService.Exceptions;
using ColorService.Models;
using Colourful;

namespace ColorService.Converters;

public class RgbToLabConverter : IRgbToLabConverter
{
    public Lab Convert(Rgb inputRgb)
    {
        if (!inputRgb.IsValid()) throw new InvalidRgbException("Invalid RGB values provided");
        
        RGBColor rgbColor = new RGBColor(inputRgb.R / 255.0, inputRgb.G / 255.0, inputRgb.B / 255.0);
        IColorConverter<RGBColor, LabColor> converter = new ConverterBuilder()
            .FromRGB(RGBWorkingSpaces.sRGB)
            .ToLab()
            .Build();
        var result = converter.Convert(rgbColor);

        return new Lab
        {
            L = Math.Round(result.L, 2),
            A = Math.Round(result.a, 2),
            B = Math.Round(result.b, 2)
        };
    }
}

