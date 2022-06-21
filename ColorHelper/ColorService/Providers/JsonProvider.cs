using System.Net.Http.Json;
using ColorService.Models;
using Newtonsoft.Json;

namespace ColorService.Providers;

public class JsonProvider : IPaintProvider
{
    private readonly List<Paint> _paints = new();
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
        var paintBrands = await _httpClient.GetFromJsonAsync<List<PaintBrandFile>>("Data/paints.json") ?? new List<PaintBrandFile>();

        foreach (var paintBrand in paintBrands)
        {
            var paintsInBrand = await _httpClient.GetFromJsonAsync<List<Paint>>("Data/" + paintBrand.File);
            if(paintsInBrand != null)
                _paints.AddRange(paintsInBrand);
        }
    }
}