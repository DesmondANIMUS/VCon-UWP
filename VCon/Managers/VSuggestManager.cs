using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VCon.Models;

namespace VCon.Managers
{
    class VSuggestManager
    {
        private static readonly string sugUri = Constants.VSUGGEST;
        
        public async static Task<RootObject_suggest> suggestFun(string username, string name, string suggestion)
        {
            var http = new HttpClient();
            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("username", username),
                                                               new KeyValuePair<string, string>("name", name),
                                                               new KeyValuePair<string, string>("suggestion", suggestion)});

            var response = await http.PostAsync(sugUri, parameters);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject_suggest));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (RootObject_suggest)serializer.ReadObject(ms);

            return datax;
        }
    }
}
