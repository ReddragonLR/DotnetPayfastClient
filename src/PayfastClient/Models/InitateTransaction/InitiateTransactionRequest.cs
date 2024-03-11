using PayfastClient.Models.Common;

namespace PayfastClient.Models.InitateTransaction
{
    public sealed class InitiateTransactionRequest : ModelBase
    {
        public InitiateTransactionRequest(string passphrase, string merchantId, string merchantKey, string return_url, string cancel_url, string notify_url, string payment_method, double amount, string itemName)
            : base(passphrase)
        {
            this.merchant_id = merchantId;
            this.merchant_key = merchantKey;
            this.return_url = return_url;
            this.cancel_url = cancel_url;
            this.notify_url = notify_url;
            this.payment_method = payment_method;
            this.amount = amount;
            this.item_name = itemName;
        }

        [PartOfChecksum]
        public string merchant_id { get; }

        [PartOfChecksum]
        public string merchant_key { get; }

        [PartOfChecksum]
        public string return_url { get; }

        [PartOfChecksum]
        public string cancel_url { get; }

        [PartOfChecksum]
        public string notify_url { get; }

        [PartOfChecksum]
        public string payment_method { get; }

        [PartOfChecksum]
        public double amount { get;  }

        [PartOfChecksum]
        public string item_name { get; }
    }
}
