using ColorService.Converters;
using ColorService.Exceptions;
using ColorService.Models;

namespace ColorServiceTests;

public class RgbToLabConverterShould
{
    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0)] //black
    [InlineData(255, 255, 255,100, 0, 0)] //white
    [InlineData(255, 0, 0, 54.29, 80.81, 69.89)] //red
    public void ConvertRgbToLab(int r, int g, int b, double l, double a, double labB)
    {
        var inputRgb = new Rgb
        {
            R = r, G = g, B = b
        };

        var outputLab = new RgbToLabConverter().Convert(inputRgb);
        
        Assert.Equal(l, outputLab.L);
        Assert.Equal(a, outputLab.A);
        Assert.Equal(labB, outputLab.B);
    }

    [Theory]
    [InlineData(-1,0,0)]
    [InlineData(0,-1,0)]
    [InlineData(0,0,-1)]
    [InlineData(256,0,0)]
    [InlineData(0,256,0)]
    [InlineData(0,0,256)]
    public void ThrowExceptionForInvalidRgb(int r, int g, int b)
    {
        var inputRgb = new Rgb
        {
            R = r, G = g, B = b
        };

        Assert.Throws<InvalidRgbException>(() => new RgbToLabConverter().Convert(inputRgb));
    }
}