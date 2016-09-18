using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VCon.Models;

namespace VCon.Managers
{
    class featureManager
    {
        private static readonly string loginUri = Constants.VFEAT;


        public static async Task getActualDataAsync(ObservableCollection<Datum> appFeatureData)
        {
            var dataWrapper = await getFeaturesAsync();
            var data = dataWrapper.data;
            foreach (var appData in data)
            {
                appFeatureData.Add(appData);
            }
        }


        private async static Task<RootObject_2> getFeaturesAsync()
        {
            var http = new HttpClient();
            var response = await http.GetAsync(loginUri);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject_2));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (RootObject_2)serializer.ReadObject(ms);

            return datax;
        }
    }
}
