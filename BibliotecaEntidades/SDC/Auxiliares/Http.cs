using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using BibliotecaEntidades.SDC.dto;
using BibliotecaEntidades.SDC.excecoes;
using IWTDotNetLib;
using Newtonsoft.Json;

namespace BibliotecaEntidades.SDC.Auxiliares
{
    internal static class Http
    {
        public static string BaseAddress = null;

        private static HttpClient _client = null;

        private static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    WebProxy proxy = ProxyHelper.GetProxy();
                    if (proxy != null)
                    {                        
                        HttpClientHandler handler = new HttpClientHandler()
                        {
                            Proxy = proxy,
                            UseProxy = true
                        };
                        _client = new HttpClient(handler);
                    }
                    else
                    {
                        _client = new HttpClient();
                    }
                    if (String.IsNullOrEmpty(BaseAddress))
                    {
                        throw new ExcecaoTratada("O BaseAddress [http://ip:porta] não foi informado.");
                    }
                    _client.BaseAddress = new Uri(BaseAddress);
                }
                return _client;
            }
        }

        public static string DoPost(string url, Dictionary<string, string> parametros, string token = null)
        {
            try
            {
                HttpRequestMessage httpContent = new HttpRequestMessage(HttpMethod.Post, url);

                // NOTE: Your server was returning 417 Expectation failed, this is set so the request client doesn't expect 100 and continue.
                httpContent.Headers.ExpectContinue = false;

                var items = parametros.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
                var content = new StringContent(String.Join("&", items), null, "application/x-www-form-urlencoded");
                httpContent.Content = content;
                //httpContent.Content = new FormUrlEncodedContent(parametros);

                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{token}");
                }

                HttpResponseMessage response = Client.SendAsync(httpContent).Result;

                VerificaHttpStatusCode(response);
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        public static string DoPost(string url, Object dto, string token = null)
        {
            try
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(dto), UnicodeEncoding.UTF8, "application/json");
                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{token}");
                }


                HttpResponseMessage response = Client.PostAsync(url, stringContent).Result;

                VerificaHttpStatusCode(response);
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        public static string DoGet(string url, string token = null)
        {
            try
            {
                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{token}");
                }

                return Client.GetStringAsync(url).Result;
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        public static string DoGet(string url, Dictionary<string, string> parametros, string token = null)
        {
            try
            {
                return DoGet(url + ConcatenaParametros(parametros), token);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string ConcatenaParametros(Dictionary<string, string> parametros)
        {
            string result = "";
            if (parametros != null)
            {
                //Concatena os parametros
                string sequenceSeparator = "&";
                result = "?" + parametros.Aggregate(new StringBuilder(),
                           (acc, pair) => acc.AppendFormat("{0}{1}{2}{3}", pair.Key, "=", pair.Value, sequenceSeparator),
                           builder => builder.Length > sequenceSeparator.Length ?
                               builder.ToString(0, builder.Length - sequenceSeparator.Length)
                               : String.Empty
                 );
                
            }
            return result;
        }

        private static void VerificaHttpStatusCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {

                ErrorClass erro = new ErrorClass()
                {
                    errorCode = response.StatusCode,
                    message = response.ReasonPhrase,
                    status = response.StatusCode.ToString()
                };
                throw new ServerErrorException(erro);
            }
        }
    }
}
