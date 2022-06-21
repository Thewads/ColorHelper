using ColorService.Models;

namespace ColorService.Providers;

public interface IPaintProvider
{
    Task<IList<Paint>> RetrieveAllPaints();
    Task<IList<string>> GetBrands();
}