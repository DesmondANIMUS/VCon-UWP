using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VCon.Models;

namespace VCon.Managers
{
    class VFeedManager
    {
        private static readonly string reUri = Constants.VFEED;

        public async static Task<RootObject_feed> feedFun(string username, string name, string teacher_name, string feedback)
        {
            var http = new HttpClient();
            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("username", username),
                                                               new KeyValuePair<string, string>("name", name),
                                                               new KeyValuePair<string, string>("teacher name", teacher_name),
                                                               new KeyValuePair<string, string>("feedback", feedback)});

            var response = await http.PostAsync(reUri, parameters);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject_feed));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (RootObject_feed)serializer.ReadObject(ms);

            return datax;
        }
    }
}
