using ColorService.Models;

namespace ColorService.Providers;

public interface IPaintProvider
{
    IList<Paint> RetrieveAllPaints();
}