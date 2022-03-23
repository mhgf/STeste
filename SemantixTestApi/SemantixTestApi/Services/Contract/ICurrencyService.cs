using SemantixTestApi.Model;
using SemantixTestApi.Shared.Enum;

namespace SemantixTestApi.Services.Contract
{
    public interface ICurrencyService
    {
        Task<ModelCurrency?> GetCurrencyAsync(CurrencyType type);
    }
}
