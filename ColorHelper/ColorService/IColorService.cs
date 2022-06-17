using ColorService.Models;

namespace ColorService;

public interface IColorService
{
    IList<Paint> GetClosestPaints(int r, int g, int b);
}