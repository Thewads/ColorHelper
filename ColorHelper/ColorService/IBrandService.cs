namespace ColorService;

public interface IBrandService
{
    Task<IList<string>> GetBrands();
}