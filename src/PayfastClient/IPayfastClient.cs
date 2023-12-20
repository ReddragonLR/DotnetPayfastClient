using PayfastClient.Models;
using Refit;

namespace PayfastClient
{
    public interface IPayfastClient
    {
        Task<string> InitateTransaction(string itemName, double amount);
    }
}