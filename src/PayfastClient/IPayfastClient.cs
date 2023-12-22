using PayfastClient.Models;
using PayfastClient.Models.InitateTransaction;
using Refit;

namespace PayfastClient
{
    public interface IPayfastClient
    {
        Task<InitiateTransactionResponse> InitateTransaction(string itemName, double amount);
    }
}