using ColorService.Converters;
using ColorService.Models;
using ColorService.Providers;
using Colourful;

namespace ColorService;

public class ColorService : IColorService
{
    private readonly IPaintProvider _paintProvider;
    private readonly IRgbToLabConverter _rgbToLabConverter;
    
    public ColorService(IPaintProvider paintProvider, IRgbToLabConverter rgbToLabConverter)
    {
        _paintProvider = paintProvider;
        _rgbToLabConverter = rgbToLabConverter;
    }
    
    public async Task<IList<Paint>> GetClosestPaints(int r, int g, int b, List<string> selectedBrands)
    {
        var labColor = _rgbToLabConverter.Convert(new Rgb { R = r, G = g, B = b });

        IList<Paint> allPaints = await _paintProvider.RetrieveAllPaints();
        IList<Tuple<Paint, double>> closestPaints = new List<Tuple<Paint, double>>();
        
        foreach (var paint in allPaints.Where(x => selectedBrands.Contains(x.Brand)))
        {
            var distance = new CIE76ColorDifference().ComputeDifference(
                new LabColor(labColor.L, labColor.A, labColor.B),
                new LabColor(paint.Lab.L, paint.Lab.A, paint.Lab.B));
            
            closestPaints.Add(new Tuple<Paint, double>(paint, distance));
        }

        return closestPaints.OrderBy(x => x.Item2).Take(5).Select(x => x.Item1).ToList();
    }
}

