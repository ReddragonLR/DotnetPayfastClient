namespace PayfastClient.Test
{
    public class IntegrationTests
    {
        private IPayfastClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new PayfastClient("merchantIdTest", "merhcantKeyTest", "passphraseTest", "https://www.payfast.co.za/eng/process");
        }

        [Test]
        public async Task InitiatePayment_Success()
        {
            try
            {
                var response = await _client.InitateTransaction("testItem", 200.00, "https://www.example.com/return", "https://www.example.com/cancel", "https://www.example.com/notify", "cc");
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}