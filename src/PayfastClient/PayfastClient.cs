using PayfastClient.Models.InitateTransaction;
using System.Text;

namespace PayfastClient
{
    public class PayfastClient : IPayfastClient
    {
        public PayfastClient(string merchantId, string merchantKey, string passphrase, string initiatePaymentUrl)
        {
            MerchantId = merchantId;
            MerchantKey = merchantKey;
            Passphrase = passphrase;
            try
            {
                InitiatePaymentUrl = new Uri(initiatePaymentUrl);
            }
            catch
            {
                throw new ArgumentException($"Invalid url: [{initiatePaymentUrl}]");
            }
        }

        public string MerchantId { get; }
        public string MerchantKey { get; }
        public string Passphrase { get; }
        public Uri InitiatePaymentUrl { get; }

        public async Task<InitiateTransactionResponse> InitateTransaction(string itemName, double amount, string return_url, string cancel_url, string notify_url, string payment_method)
        {
            var request = new InitiateTransactionRequest(Passphrase, MerchantId, MerchantKey, return_url, cancel_url, notify_url, payment_method, amount, itemName);
            StringBuilder htmlFormBuilder = new StringBuilder();
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            htmlFormBuilder.Append($"<form action=\"{InitiatePaymentUrl.AbsoluteUri}\" method=\"POST\">");
            foreach (var property in request.ExtractChecksumValues())
            {
                htmlFormBuilder.Append($"<input type=\"hidden\" name=\"{property.Name}\" value=\"{property.Value}\">");
                metadata.Add(property.Name, property.Value);
            }
            htmlFormBuilder.Append($"<input type=\"hidden\" name=\"signature\" value=\"{request.ExtractChecksumValuesStringUrlEncodedMD5()}\">");
            metadata.Add("signature", request.ExtractChecksumValuesStringUrlEncodedMD5());

            htmlFormBuilder.Append("<input type=\"submit\">");
            htmlFormBuilder.Append("</form>");

            return await Task.FromResult(new InitiateTransactionResponse { FormHTML = htmlFormBuilder.ToString(), Metadata = metadata });
        }
    }
}
