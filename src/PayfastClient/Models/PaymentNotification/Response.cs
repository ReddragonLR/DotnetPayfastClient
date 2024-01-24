using Newtonsoft.Json;
using System.Web;

namespace PayfastClient.Models.PaymentNotification
{
    public sealed class Response
    {
        [JsonProperty("m_payment_id")]
        public string MPaymentId { get; set; }

        [JsonProperty("pf_payment_id")]
        public string PfPaymentId { get; set; }

        [JsonProperty("payment_status")]
        public string PaymentStatus { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        [JsonProperty("amount_gross")]
        public double AmountGross { get; set; }

        [JsonProperty("amount_fee")]
        public double AmountFee { get; set; }

        [JsonProperty("amount_net")]
        public double AmountNet { get; set; }

        [JsonProperty("custom_str1")]
        public string CustomStr1 { get; set; }

        [JsonProperty("custom_str2")]
        public string CustomStr2 { get; set; }

        [JsonProperty("custom_str3")]
        public string CustomStr3 { get; set; }

        [JsonProperty("custom_str4")]
        public string CustomStr4 { get; set; }

        [JsonProperty("custom_str5")]
        public string CustomStr5 { get; set; }

        [JsonProperty("custom_int1")]
        public string CustomInt1 { get; set; }

        [JsonProperty("custom_int2")]
        public string CustomInt2 { get; set; }

        [JsonProperty("custom_int3")]
        public string CustomInt3 { get; set; }

        [JsonProperty("custom_int4")]
        public string CustomInt4 { get; set; }

        [JsonProperty("custom_int5")]
        public string CustomInt5 { get; set; }

        [JsonProperty("name_first")]
        public string NameFirst { get; set; }

        [JsonProperty("name_last")]
        public string NameLast { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        public static Response FromPayload(string payload)
        {
            var keyValues = HttpUtility.ParseQueryString(payload);
            if(keyValues.HasKeys() && ContainsAllRequiredKeys(keyValues.AllKeys))
            {
                return new Response()
                {
                    MPaymentId = keyValues["m_payment_id"],
                    PfPaymentId = keyValues["pf_payment_id"],
                    PaymentStatus = keyValues["payment_status"],
                    ItemName = keyValues["item_name"],
                    ItemDescription = keyValues["item_description"],
                    AmountGross = Convert.ToDouble(keyValues["amount_gross"]),
                    AmountFee = Convert.ToDouble(keyValues["amount_fee"]),
                    AmountNet = Convert.ToDouble(keyValues["amount_net"]),
                    CustomStr1 = keyValues["custom_str1"],
                    CustomStr2 = keyValues["custom_str2"],
                    CustomStr3 = keyValues["custom_str3"],
                    CustomStr4 = keyValues["custom_str4"],
                    CustomStr5 = keyValues["custom_str5"],
                    CustomInt1 = keyValues["custom_int1"],
                    CustomInt2 = keyValues["custom_int2"],
                    CustomInt3 = keyValues["custom_int3"],
                    CustomInt4 = keyValues["custom_int4"],
                    CustomInt5 = keyValues["custom_int5"],
                    NameFirst = keyValues["name_first"],
                    NameLast = keyValues["name_last"],
                    EmailAddress = keyValues["email_address"],
                    MerchantId = keyValues["merchant_id"],
                    Signature = keyValues["signature"]
                };
            }

            throw new ArgumentException($"Payfast payload does not contain any data");
        }

        private static bool ContainsAllRequiredKeys(string?[] allKeys)
        {
            IEnumerable<string> requiredNotificationKeys = new List<string> { "m_payment_id", "pf_payment_id", "payment_status", "item_name", "item_description", "amount_gross", "amount_fee", "amount_net", "custom_str1", "custom_str2", "custom_str3", "custom_str4", "custom_str5", "custom_int1", "custom_int2", "custom_int3", "custom_int4", "custom_int5", "name_first", "name_last", "email_address", "merchant_id", "signature" };
            if (allKeys == null || allKeys.Length == 0) return false;
            return allKeys.All(key => requiredNotificationKeys.Contains(key));
        }
    }
}
