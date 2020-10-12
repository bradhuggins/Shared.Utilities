#region Using Statements
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Shared.Utilities
{
    /// <summary>
    /// Json helper utilities
    /// </summary>
    public class JsonHelper
    {
        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None,
            //DateFormatstring = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffffzzz"
        };

        /// <summary>
        /// Gets or sets the json serializer settings.
        /// </summary>
        /// <value>
        /// The json serializer settings.
        /// </value>
        public static JsonSerializerSettings JsonSerializerSettings
        {
            get { return _jsonSerializerSettings; }
            set { _jsonSerializerSettings = value; }
        }

        /// <summary>
        /// Serializes the content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>HttpContent</returns>
        public static HttpContent SerializeContent<T>(T item)
        {
            return SerializeContent(item, JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>HttpContent</returns>
        public static HttpContent SerializeContent<T>(T item, JsonSerializerSettings settings)
        {
            HttpContent toReturn;
            string stringJson = JsonConvert.SerializeObject(item, settings);
            toReturn = new StringContent(stringJson, Encoding.UTF8, "application/json");
            return toReturn;
        }

        /// <summary>
        /// Serializes the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>string</returns>
        public static string Serialize<T>(T item)
        {
            return Serialize(item, JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>string</returns>
        public static string Serialize<T>(T item, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(item, settings);
        }

        /// <summary>
        /// Deserializes the specified json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>T</returns>
        public static async Task<T> Deserialize<T>(string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        /// <summary>
        /// Deserializes the specified json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns>T</returns>
        public static async Task<T> Deserialize<T>(string json)
        {
            return await Deserialize<T>(json, new JsonSerializerSettings());
        }

        /// <summary>
        /// Deserializes the specified response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>string</returns>
        public static async Task<string> Deserialize(HttpResponseMessage response)
        {
            string toReturn = await response.Content.ReadAsStringAsync();
            return toReturn;
        }

        /// <summary>
        /// Deserializes the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <returns>T</returns>
        public static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            return await DeserializeResponse<T>(response, new JsonSerializerSettings());
        }

        /// <summary>
        /// Deserializes the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>T</returns>
        public static async Task<T> DeserializeResponse<T>(HttpResponseMessage response, JsonSerializerSettings settings)
        {
            string responsestring = await Deserialize(response);
            return await Deserialize<T>(responsestring, settings);
        }

    }
}
