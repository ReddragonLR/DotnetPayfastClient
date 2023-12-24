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

        public async Task<InitiateTransactionResponse> InitateTransaction(string itemName, double amount)
        {
            var request = new InitiateTransactionRequest(Passphrase, MerchantId, MerchantKey, amount, itemName);
            StringBuilder htmlFormBuilder = new StringBuilder();
            htmlFormBuilder.Append($"<form action=\"{InitiatePaymentUrl.AbsoluteUri}\" method=\"POST\">");
            foreach (var property in request.ExtractChecksumValues())
            {
                htmlFormBuilder.Append($"<input type=\"hidden\" name=\"{property.Name}\" value=\"{property.Value}\">");
            }
            htmlFormBuilder.Append($"<input type=\"hidden\" name=\"signature\" value=\"{request.ExtractChecksumValuesStringUrlEncodedMD5()}\">");
            htmlFormBuilder.Append("<input type=\"submit\">");
            htmlFormBuilder.Append("</form>");
            return await Task.FromResult(new InitiateTransactionResponse { FormHTML = htmlFormBuilder.ToString() });
        }
    }
}
