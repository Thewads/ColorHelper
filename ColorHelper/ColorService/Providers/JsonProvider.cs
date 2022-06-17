using ColorService.Models;

namespace ColorService.Providers;

public class JsonProvider : IPaintProvider
{
    public IList<Paint> RetrieveAllPaints()
    {
        return new List<Paint>
        {
            new()
            {
                Brand = "GW",
                Name = "Abaddon Black",
                Rgb = new Rgb{R = 0, G = 0, B = 0},
                Lab = new Lab{L = 0, A = 0, B = 0}
            },
            new()
            {
                Brand = "GW",
                Name = "Screamer Pink",
                Rgb = new Rgb{R = 112, G = 30, B = 66},
                Lab = new Lab{L = 26.06, A = 39.01, B = -2.06}
            },
            new()
            {
                Brand = "GW",
                Name = "Troll Slayer Orange",
                Rgb = new Rgb{R = 241, G = 108, B = 34},
                Lab = new Lab{L = 61.26, A = 47.61, B = 61.55}
            },
            new()
            {
                Brand = "GW",
                Name = "Macragge Blue",
                Rgb = new Rgb{R = 40, G = 60, B = 119},
                Lab = new Lab{L = 26.78, A = 12.7, B = -36.24}
            }
        };
    }
}