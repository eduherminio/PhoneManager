using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace PhoneManager.Api.Test.Utils
{
    public static class HttpHelper
    {
        public static TBodyResponse Get<TBodyResponse>(HttpClient client, Uri entityUri, out HttpStatusCode statusCode)
            where TBodyResponse : class
        {
            HttpResponseMessage response = client.GetAsync(entityUri).Result;

            return GetDataFromHttpResponse<TBodyResponse>(response, out statusCode);
        }

        public static TBodyResponse Post<TBodyRequest, TBodyResponse>(
            HttpClient client, Uri entityUri, TBodyRequest dtoToSend, out HttpStatusCode statusCode)
            where TBodyRequest : class
            where TBodyResponse : class
        {
            ByteArrayContent byteContent = Serialize(dtoToSend);

            HttpResponseMessage response = client.PostAsync(entityUri, byteContent).Result;

            return GetDataFromHttpResponse<TBodyResponse>(response, out statusCode);
        }

        private static TBodyResponse GetDataFromHttpResponse<TBodyResponse>(HttpResponseMessage response, out HttpStatusCode statusCode)
            where TBodyResponse : class
        {
            TBodyResponse returnObject = null;

            string responseString = response.Content.ReadAsStringAsync().Result;

            statusCode = response.StatusCode;

            try
            {
                returnObject = Deserialize<TBodyResponse>(responseString);
            }
            catch (Exception) { }

            return returnObject;
        }

        private static ByteArrayContent Serialize<T>(T entity)
        {
            string content = JsonConvert.SerializeObject(entity);
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        private static T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
