using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BIMS.Services
{
    public class ChapaService
    {
        private readonly string _chapaPayoutUrl = "https://api.chapa.co/v1/disburse";
        private readonly string _chapaSecretKey = "CHASECK_TEST-7gsEVIkbNCJXgIpMdFYbmhDzUTGZ0Cvy"; // Replace with your Chapa API key

        public async Task<bool> SendPayout(string bankAccountNumber, string bankCode, string amount, string reason)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_chapaSecretKey}");

                var requestData = new
                {
                    account_number = bankAccountNumber,
                    bank_code = bankCode,
                    amount = amount,
                    currency = "ETB",
                    reason = reason
                };

                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_chapaPayoutUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseString);

                return result.status == "success";
            }
        }
    }
}
