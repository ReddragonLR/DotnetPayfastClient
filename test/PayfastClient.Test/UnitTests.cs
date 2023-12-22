namespace PayfastClient.Test
{
    public class UnitTests
    {
        private IPayfastClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new PayfastClient("merchantIdTest", "merhcantKeyTest", "passphraseTest");
        }

        [Test]
        public async Task InitiatePayment_Success()
        {
            try
            {
                var response = await _client.InitateTransaction("testItem", 200.00);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}