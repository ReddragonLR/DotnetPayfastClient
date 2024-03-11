using PayfastClient.Models;
using PayfastClient.Models.InitateTransaction;
using Refit;

namespace PayfastClient
{
    public interface IPayfastClient
    {
        Task<InitiateTransactionResponse> InitateTransaction(string itemName, double amount, string return_url, string cancel_url, string notify_url, string payment_method);
    }
}