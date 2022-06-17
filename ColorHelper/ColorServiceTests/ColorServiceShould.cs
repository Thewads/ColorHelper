using ColorService.Converters;
using ColorService.Models;
using ColorService.Providers;
using Moq;

namespace ColorServiceTests;

public class ColorServiceShould
{
    [Fact]
    public void ReturnListOfClosePaintsWhenPaintsArePopulated()
    {
        var paintProvider = new Mock<IPaintProvider>();
        paintProvider.Setup(x => x.RetrieveAllPaints()).Returns(new List<Paint>
        {
            new() { Brand = "Brand 1", Name = "Name 1", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 1", Name = "Name 2", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 2", Name = "Name 1", Lab = new() { L = 0, A = 0, B = 0 } }
        });
        var converter = new RgbToLabConverter();
        
        var colorService = new ColorService.ColorService(paintProvider.Object, converter);

        int r = 0;
        int g = 0;
        int b = 0;

        var result = colorService.GetClosestPaints(r, g, b);
        
        Assert.NotNull(result);
        Assert.Equal(3,result.Count);
    }

    [Fact]
    public void Test()
    {
        var colorService = new ColorService.ColorService(new JsonProvider(), new RgbToLabConverter());
        
        var result = colorService.GetClosestPaints(255, 0, 0);
        Assert.NotNull(result);
        Assert.Equal(4,result.Count);
    }
}