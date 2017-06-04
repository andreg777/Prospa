using Prospa.Model;

namespace Prospa.Core.Interface
{
    public interface IChequeService
    {
        ChequeModel ConvertNumbersToWords(ChequeModel model);
        string ConvertNumbersToWords(decimal amount);
    }
}
