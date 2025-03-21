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


        public ChapaService() { }

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

        public async Task<string?> GetPaymentStatusAsync(int orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_chapaSecretKey}");

                var response = await client.GetAsync($"https://api.chapa.co/v1/transaction/verify/{orderId}");
                var responseString = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (result.status == "success")
                {
                    return result.data.status; // Return the payment status (e.g., "successful", "failed", etc.)
                }

                return null; // If the transaction verification fails
            }
        }

        public async Task<string?> GetPaymentReceiptUrlAsync(int orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_chapaSecretKey}");

                var response = await client.GetAsync($"https://api.chapa.co/v1/transaction/verify/{orderId}");
                var responseString = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (result.status == "success")
                {
                    return result.data.checkout_url; // ✅ Directly return the receipt URL
                }

                return null; // If verification fails
            }
        }



        public async Task<string?> InitiatePaymentAsync(decimal totalAmount, string Email, string firstName, string lastName, string phoneNumber, string orderId, string returnUrl, string callbackUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_chapaSecretKey}");

                var requestData = new
                {
                    amount = totalAmount,
                    currency = "ETB",
                    email = Email,
                    first_name = firstName,
                    last_name = lastName,
                    phone_number = phoneNumber,
                    tx_ref = orderId,
                    return_url = returnUrl,
                    callback_url = callbackUrl,
                    customizations = new
                    {
                        title = "Lidya ena betesebochua",
                        description = "Payment for Order " + orderId
                    }
                };

                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.chapa.co/v1/transaction/initialize", content);
                var responseString = await response.Content.ReadAsStringAsync();

                // ✅ Log response for debugging
                Console.WriteLine("Chapa Response: " + responseString);

                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (result.status == "success")
                {
                    Console.WriteLine("Chapa Checkout URL: " + result.data.checkout_url);
                    return result.data.checkout_url; // Return Chapa checkout URL
                }

                Console.WriteLine("Chapa Payment Error: " + responseString);
                return null; // Payment failed
            }
        }


    }
}
