using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VCon.Models;

namespace VCon.Managers
{
    class ConfigManager
    {
        private readonly static string versionUrl = Constants.VCONFIG;
        public async static Task<appVersion> versionControl()
        {

            var http = new HttpClient();

            var response = await http.GetAsync(versionUrl);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(appVersion));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (appVersion)serializer.ReadObject(ms);

            return datax;
        }
    }
}
