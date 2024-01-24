using Newtonsoft.Json;

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
    }
}
