using System;
using System.Net;
using Flurl;
using Flurl.Http;
namespace Labb2OOADSimonOTobias
{
    public class HttpRequest
    {

        private static readonly string URL = "https://haveibeenpwned.com/api/v2/breachedaccount/";

        public static async void Request(string email, ICallback callback)
        {
            string requestUrl = URL + email;
            try
            {
                var getResp = await requestUrl
                    .WithHeaders(new { Accept = "text/plain", User_Agent = "School project sweden" })
                    .AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (getResp.StatusCode == HttpStatusCode.OK)
                {
                    callback.Callback(1);
                }
                else if (getResp.StatusCode == HttpStatusCode.NotFound)
                {
                    callback.Callback(0);
                }
            }
            catch (FlurlHttpException ex)
            {
                string message = ex.ToString();
                callback.Callback(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                callback.Callback(-1);
            }
        }
    }
}
