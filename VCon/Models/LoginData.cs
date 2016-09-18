using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace VCon.Models
{
    class LoginData
    {
        private static readonly string loginUri = Constants.VUSER;

        public async static Task<RootObject> getLogin(string username, string password)
        {
            var http = new HttpClient();

            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("username", username),
                                                               new KeyValuePair<string, string>("password", password)});

            var response = await http.PostAsync(loginUri, parameters);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (RootObject)serializer.ReadObject(ms);

            return datax;
        }
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public int uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public object address { get; set; }
        [DataMember]
        public object mobile { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string device_id { get; set; }
        [DataMember]
        public string batch { get; set; }
        [DataMember]
        public string shift { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public bool success { get; set; }
        [DataMember]
        public Data data { get; set; }
        [DataMember]
        public object error { get; set; }
    }
}
