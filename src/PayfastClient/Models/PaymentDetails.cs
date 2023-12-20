using Refit;

namespace PayfastClient.Models
{
    public sealed class PaymentDetails
    {
        public PaymentDetails(string merchantId, string merchantKey, double amount, string itemName)
        {
            MerchantId = merchantId;
            MerchantKey = merchantKey;
            Amount = amount;
            ItemName = itemName;
        }

        [AliasAs("merchant_id")]
        public string MerchantId { get; }

        [AliasAs("merchant_key")]
        public string MerchantKey { get; }

        [AliasAs("amount")]
        public double Amount { get; }

        [AliasAs("item_name")]
        public string ItemName { get; }
    }
}
