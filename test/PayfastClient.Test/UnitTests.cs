using PayfastClient.Models.PaymentNotification;
using System.Collections.Specialized;

namespace PayfastClient.Test
{
    public class UnitTests
    {
        [Test]
        public void BuildNotificationResponse_Success()
        {
            // ARRANGE
            Exception error = null;
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("m_payment_id", "SuperUnique1");
            queryString.Add("pf_payment_id", "1089250");
            queryString.Add("payment_status", "COMPLETE");
            queryString.Add("item_name", "test+product");
            queryString.Add("item_description", "test+description");
            queryString.Add("amount_gross", "200.00");
            queryString.Add("amount_fee", "-4.60");
            queryString.Add("amount_net", "195.40");
            queryString.Add("custom_str1", "");
            queryString.Add("custom_str2", "");
            queryString.Add("custom_str3", "");
            queryString.Add("custom_str4", "");
            queryString.Add("custom_str5", "");
            queryString.Add("custom_int1", "");
            queryString.Add("custom_int2", "");
            queryString.Add("custom_int3", "");
            queryString.Add("custom_int4", "");
            queryString.Add("custom_int5", "");
            queryString.Add("name_first", "");
            queryString.Add("name_last", "");
            queryString.Add("email_address", "");
            queryString.Add("merchant_id", "10000100");
            queryString.Add("signature", "ad8e7685c9522c24365d7ccea8cb3db7");

            // ACT
            try
            {
                var response = Response.FromPayload(queryString.ToString());
            }
            catch (Exception ex)
            {
                error = ex;
            }

            // ASSERT
            Assert.IsNull(error);
        }
    }
}
