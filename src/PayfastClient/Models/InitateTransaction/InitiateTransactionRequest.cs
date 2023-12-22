using PayfastClient.Models.Common;

namespace PayfastClient.Models.InitateTransaction
{
    public sealed class InitiateTransactionRequest : ModelBase
    {
        public InitiateTransactionRequest(string passphrase, string merchantId, string merchantKey, double amount, string itemName)
            : base(passphrase)
        {
            this.merchant_id = merchantId;
            this.merchant_key = merchantKey;
            this.amount = amount;
            this.item_name = itemName;
        }

        [PartOfChecksum]
        public string merchant_id { get; }

        [PartOfChecksum]
        public string merchant_key { get; }

        [PartOfChecksum]
        public double amount { get; }

        [PartOfChecksum]
        public string item_name { get; }
    }
}
