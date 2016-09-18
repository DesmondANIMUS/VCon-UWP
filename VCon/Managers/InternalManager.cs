using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VCon.Models;

namespace VCon.Managers
{
    class InternalManager
    {
        private static readonly string noticeUri = Constants.VINTERNAL;
        private static InternalData dataWrapper;

        public async static Task<InternalData> getInternalData(string batch, string shift, string roll)
        {
            var http = new HttpClient();

            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("batch", batch),
                                                               new KeyValuePair<string, string>("shift", shift),
                                                               new KeyValuePair<string, string>("roll_no", roll)});

            var response = await http.PostAsync(noticeUri, parameters);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(InternalData));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (InternalData)serializer.ReadObject(ms);

            return datax;
        }

        public static async Task getValues(ObservableCollection<string> val, string B, string S, string roll)
        {

            dataWrapper = await getInternalData("2013", "M", "317702013");

            var getVal = dataWrapper.data.internal1.values;

            foreach (var v in getVal)
                val.Add(v);
        }

        public static void getSubs(ObservableCollection<string> sub)
        {
            var getData = dataWrapper.data.internal1.subs;

            foreach (var v in getData)
                sub.Add(v);
        }
    }
}
