using PayfastClient.Models;
using PayfastClient.Models.InitateTransaction;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayfastClient
{
    public class PayfastClient : IPayfastClient
    {
        public PayfastClient(string merchantId, string merchantKey, string passphrase)
        {
            MerchantId = merchantId;
            MerchantKey = merchantKey;
            Passphrase = passphrase;
        }

        public string MerchantId { get; }
        public string MerchantKey { get; }
        public string Passphrase { get; }
        public Uri InitiatePaymentUrl => new Uri("https://www.payfast.co.za/eng/process");

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
