namespace PayfastClient.Models.InitateTransaction
{
    public sealed class InitiateTransactionResponse
    {
        public InitiateTransactionResponse()
        {
            Metadata = new Dictionary<string, string>();
            FormHTML = string.Empty;
        }
        public string FormHTML { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
