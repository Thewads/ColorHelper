using ColorService.Models;
using ColorService.Providers;

namespace ColorService;

public class PaintService : IPaintService
{
    private readonly IPaintProvider _paintProvider;
    
    public PaintService(IPaintProvider paintProvider)
    {
        _paintProvider = paintProvider;
    }
    
    public async Task<IList<Paint>> GetPaint(string searchTerm)
    {
        var allPaints = await _paintProvider.RetrieveAllPaints();

        return allPaints.Where(x => x.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }
}