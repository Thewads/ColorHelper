using System.Net.Http.Json;
using ColorService.Models;
using Newtonsoft.Json;

namespace ColorService.Providers;

public class JsonProvider : IPaintProvider
{
    private IList<Paint> _paints = new List<Paint>();
    private readonly HttpClient _httpClient;
    
    public JsonProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IList<Paint>> RetrieveAllPaints()
    {
        if (!_paints.Any()) await PopulatePaintList();

        return _paints;
    }

    private async Task PopulatePaintList()
    {
        var result = await _httpClient.GetFromJsonAsync<IList<Paint>>("Data/paints.json");
        if (result != null)
            _paints = result;
    }
}