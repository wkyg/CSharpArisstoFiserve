using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;
using Org.Simple;

namespace Fiserve
{
    static class Program
    {
        static string tokenId;

        [STAThread]
        static void Main()
        {
            string apiKey = "UhVgbPN3tWWhB6fz9n2ulvwPu7iaXika";
            string apiSecret = "Kqhlqrca1ADeO0fvxiGcMGoMh31Tmw2wGpukLHwN7UZ";

            MerchantCredentials credentials = new MerchantCredentials(apiKey, apiSecret);            
            Gateway gateway = Gateway.Create(credentials, true);

            // For use in production, supply true as the optional production argument:
            // Gateway gateway = Gateway.create(credentials, true);
            // Or supply the production URL directly:
            // string productionURL = "https://prod.api.firstdata.com/gateway/v2";
            // Gateway gateway = Gateway.create(credentials, productionURL);

            /*
            string json_payload = @"{
                ""domain"": """",
                ""token"": """",
                ""publicKeyRequired"": """"
            }";

            AccessTokenRequest payload = JsonConvert.DeserializeObject<AccessTokenRequest>(json_payload);            

            try
            {
                AccessTokenResponse response = gateway.RequestAccessToken(payload);                
                string result = response.ToJson();

                tokenId = JObject.Parse(result)["tokenId"].ToString();
                string status = JObject.Parse(result)["status"].ToString();
                string issuedOn = JObject.Parse(result)["issuedOn"].ToString();
                string expiresInSeconds = JObject.Parse(result)["expiresInSeconds"].ToString();
                string publicKeyBase64 = JObject.Parse(result)["publicKeyBase64"].ToString();
                string algorithm = JObject.Parse(result)["algorithm"].ToString();
                string clientRequestId = JObject.Parse(result)["clientRequestId"].ToString();

                Console.WriteLine(tokenId);
                Console.WriteLine(status);
                Console.WriteLine(issuedOn);
                Console.WriteLine(expiresInSeconds);
                Console.WriteLine(publicKeyBase64);
                Console.WriteLine(algorithm);
                Console.WriteLine(clientRequestId);

                //Console.WriteLine(response.ToJson());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */

            /*
            string tokenizePayload = @"{
                ""requestType"": ""PaymentCardPaymentTokenizationRequest"",         
                ""storeId"": ""4945018794"",
                ""paymentCard"": {  
                    ""number"": ""5256511000568382"",                    
                    ""expiryDate"": {
                        ""month"": ""03"",
                        ""year"": ""25""
                    }
                },
                ""createToken"": {
                    ""reusable"": true,
                    ""declineDeplicates"": false
                },                
                ""accountVerification"": false                
            }";

            PaymentCardPaymentTokenizationRequest tokenize = JsonConvert.DeserializeObject<PaymentCardPaymentTokenizationRequest>(tokenizePayload);

            try
            {
                PaymentTokenizationResponse resp = gateway.CreatePaymentToken(tokenize);//, "Secure3D10AuthenticationRequest", "Malaysia");

                string tokenResult = resp.ToJson();

                Console.WriteLine(tokenResult);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }           
            */

            string json_payload = @"{
                ""storeId"": ""4945018794"",
                ""requestType"": ""PaymentCardPreAuthTransaction"",                
                ""transactionAmount"": {
                    ""total"": ""1"",
                    ""currency"": ""MYR""
                },
                ""paymentMethod"": {
                    ""paymentCard"": {
                        ""number"": ""5256511000568382"",
                        ""securityCode"": ""123"",                       
                        ""expiryDate"": {
                            ""month"": ""03"",
                            ""year"": ""25""
                        }
                    }
                },
                ""createToken"": {
                    ""reusable"": true,
                    ""declineDuplicates"": false
                },
                ""authenticationRequest"": {
                    ""authenticationType"": ""Secure3D10AuthenticationRequest""
                }
            }";

            PaymentCardPreAuthTransaction pay = JsonConvert.DeserializeObject<PaymentCardPreAuthTransaction>(json_payload);

            try
            {
                TransactionResponse resp = gateway.SubmitPrimaryTransaction(pay);//, "Secure3D10AuthenticationRequest", "Malaysia");

                string tokenResult = resp.ToJson();

                Console.WriteLine(tokenResult);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
