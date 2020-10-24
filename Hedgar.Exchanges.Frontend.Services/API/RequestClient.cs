using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.API
{
    public class RequestClient
    {
        private RestClient client;
        public RequestClient()
        {
            this.client = new RestClient();
        }

        public RequestClient(string urlBase)
        {
            this.client = new RestClient(urlBase);
        }

        public T Get<T>(string url)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);

            var response = client.Get<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }

        public T Post<T>(string url, object param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(param);

            var response = client.Post<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }

        public T Post<T>(string url, List<KeyValuePair<string, object>> param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            //request.AddJsonBody(param);
            param.ForEach(p => request.AddParameter(p.Key, p.Value));

            var response = client.Post<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }

        public T Put<T>(string url, object param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(param);

            var response = client.Put<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }

        public T Put<T>(string url, List<KeyValuePair<string, object>> param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            //request.AddJsonBody(param);
            param.ForEach(p => request.AddParameter(p.Key, p.Value));

            var response = client.Put<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }


        public T Get<T>(string url, List<KeyValuePair<string, string>> param = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);

            if (param != null)
            {
                param.ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.GetOrPost));
            }

            var response = client.Get<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }


        public async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);

            var response = await client.ExecuteGetAsync<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }
        public async Task<T> PostAsync<T>(string url, object param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(param);

            var response = await client.ExecutePostAsync<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }
        public async Task<T> PostAsync<T>(string url, List<KeyValuePair<string, object>> param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);

            param.ForEach(p => request.AddParameter(p.Key, p.Value));

            var response = await client.ExecutePostAsync<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço desejado");
        }

        public void AdicionarCookies(List<Cookie> cookies)
        {
            this.client.CookieContainer = new CookieContainer();

            cookies.ForEach(cookie => this.client.CookieContainer.Add(cookie));
        }
    }
}
