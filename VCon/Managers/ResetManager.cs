using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VCon.Models;

namespace VCon.Managers
{
    class ResetManager
    {
        private static readonly string reUri = Constants.VRESET;

        public async static Task<RootObject_reset> getReset(string uid, string old_pass, string new_pass)
        {
            var http = new HttpClient();

            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("uid", uid),
                                                               new KeyValuePair<string, string>("old_pass", old_pass),
                                                               new KeyValuePair<string, string>("new_pass", new_pass)});

            var response = await http.PostAsync(reUri, parameters);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject_reset));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (RootObject_reset)serializer.ReadObject(ms);

            return datax;
        }
    }
}
