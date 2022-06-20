using ColorService.Models;

namespace ColorService;

public interface IPaintService
{
    Task<IList<Paint>> GetPaint(string searchTerm);
}