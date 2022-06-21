﻿using ColorService.Converters;
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
        paintProvider.Setup(x => x.RetrieveAllPaints()).ReturnsAsync(new List<Paint>
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

        var result = colorService.GetClosestPaints(r, g, b).Result;
        
        Assert.NotNull(result);
        Assert.Equal(3,result.Count);
    }
    
    [Fact]
    public void ReturnMaxOf5ClosestPaints()
    {
        var paintProvider = new Mock<IPaintProvider>();
        paintProvider.Setup(x => x.RetrieveAllPaints()).ReturnsAsync(new List<Paint>
        {
            new() { Brand = "Brand 1", Name = "Name 1", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 1", Name = "Name 2", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 2", Name = "Name 1", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 2", Name = "Name 2", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 2", Name = "Name 3", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 2", Name = "Name 4", Lab = new() { L = 0, A = 0, B = 0 } },
            new() { Brand = "Brand 2", Name = "Name 5", Lab = new() { L = 0, A = 0, B = 0 } }
        });
        var converter = new RgbToLabConverter();
        
        var colorService = new ColorService.ColorService(paintProvider.Object, converter);

        int r = 0;
        int g = 0;
        int b = 0;

        var result = colorService.GetClosestPaints(r, g, b).Result;
        
        Assert.NotNull(result);
        Assert.Equal(5,result.Count);
    }
}