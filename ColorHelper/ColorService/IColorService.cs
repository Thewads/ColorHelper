using ColorService.Models;

namespace ColorService;

public interface IColorService
{
    Task<IList<Paint>> GetClosestPaints(int r, int g, int b, List<string> selectedBrands = null!);
}