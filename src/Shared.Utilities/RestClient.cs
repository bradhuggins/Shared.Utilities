#region Using Statements
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

namespace Shared.Utilities
{
    /// <summary>
    /// Helper class for System.Net.Http.HttpClient
    /// </summary>
    /// <seealso cref="Shared.Utilities.IRestClient" />
    public class RestClient : IRestClient
    {
        private static readonly HttpClientHandler _handler = new HttpClientHandler { };

        private static readonly HttpClient _systemHttpClient = new HttpClient(_handler);

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public Dictionary<string, string> Headers { get; set; }

        private HttpRequestMessage AddHeaders(HttpRequestMessage request)
        {
            if (this.Headers != null)
            {
                foreach (var item in this.Headers)
                {
                    if (!request.Headers.Contains(item.Key))
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }
            }
            return request;
        }

        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <param name="disableWait">if set to <c>true</c> [disable wait].</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string url, HttpContent content = null, bool disableWait = false)
        {
            HttpResponseMessage toReturn = null;
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);
                request = AddHeaders(request);
                if (content != null)
                {
                    request.Content = content;
                }
                if (disableWait)
                {
                    toReturn = await _systemHttpClient.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);
                }
                else
                {
                    toReturn = await _systemHttpClient.SendAsync(request);
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        #region Unused-Extra

        //public HttpResponseMessage Response { get; set; }

        //public async Task<Y> Get<Y>(string url)
        //{
        //    await SendAsync(HttpMethod.Get, url);
        //    Y toReturn = await this.ParseResponseObject<Y>();
        //    return toReturn;
        //}

        //public async Task<Y> Post<X, Y>(string url, X request)
        //{
        //    HttpContent content = JsonHelper.SerializeContent(request);
        //    await SendAsync(HttpMethod.Post, url, content);
        //    Y toReturn = await this.ParseResponseObject<Y>();
        //    return toReturn;
        //}

        //public async Task<Y> Put<X, Y>(string url, X request)
        //{
        //    HttpContent content = JsonHelper.SerializeContent(request);
        //    await SendAsync(HttpMethod.Put, url, content);
        //    Y toReturn = await this.ParseResponseObject<Y>();
        //    return toReturn;
        //}

        //public async Task<Y> Delete<Y>(string url)
        //{
        //    await SendAsync(HttpMethod.Delete, url);
        //    Y toReturn = await this.ParseResponseObject<Y>();
        //    return toReturn;
        //}

        //private async Task<Y> ParseResponseObject<Y>()
        //{
        //    Y toReturn = default(Y);
        //    if(this.Response == null)
        //    {
        //        return toReturn;
        //    }    
        //    try
        //    {
        //        if (!this.Response.IsSuccessStatusCode)
        //        {
        //            this.ErrorMessage = this.Response.StatusCode.ToString() + " " + this.Response.ReasonPhrase;
        //        }
        //        else
        //        {
        //            toReturn = await JsonHelper.DeserializeResponse<Y>(this.Response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.ToString();
        //    }
        //    return toReturn;
        //} 
        #endregion

    }
}
