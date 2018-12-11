using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Flurl;
using Flurl.Http;
using Labb2OOADSimonOTobias.Objects;
using Newtonsoft.Json;
using Xamarin.Forms;

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
                    List<BreachedSites> result = JsonConvert.DeserializeObject<List<BreachedSites>>(getResp.Content.ReadAsStringAsync().Result);
                    Debug.WriteLine(getResp.Content);
                    Debug.WriteLine(result);
                    callback.Callback(1, result);
                }
                else if (getResp.StatusCode == HttpStatusCode.NotFound)
                {
                    callback.Callback(0, null);
                }
            }
            catch (FlurlHttpException ex)
            {
                string message = ex.ToString();
                callback.Callback(-1, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                callback.Callback(-1, null);
            }
        }

        public static async void RequestImage(string imageUrl, IImageCallback callback)
        {
            try
            {
                var getResp = await imageUrl
                        .WithHeaders(new { Accept = "text/plain", User_Agent = "School project sweden" })
                        .AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (getResp.StatusCode == HttpStatusCode.OK)
                {
                    var result = await getResp.Content.ReadAsByteArrayAsync();
                    var imageSource = ImageSource.FromStream(() => new MemoryStream(result));
                    callback.ImageCallback(imageSource);
                }
                else 
                {
                    callback.ImageCallback(null);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                callback.ImageCallback(null);
            }
        }
    }
}
