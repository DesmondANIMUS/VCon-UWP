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
    class NoticeManager
    {
        private static readonly string noticeUri = Constants.VNOTICE;

        #region Notice Data Wrapper
        private async static Task<RootObject_3> rootNoticeData(string batch, string shift)
        {
            var http = new HttpClient();

            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("batch", batch),
                                                               new KeyValuePair<string, string>("shift", shift)});

            var response = await http.PostAsync(noticeUri, parameters);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject_3));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (RootObject_3)serializer.ReadObject(ms);

            return datax;
        }
        #endregion

        #region Actual Notice Data
        public static async Task noticeDataRetrival(ObservableCollection<Datum_2> noticeData, string B, string S)
        {
            var dataWrapper = await rootNoticeData(B, S);
            var getData = dataWrapper.data;
            foreach (var noData in getData)
            {
                noticeData.Add(noData);
            }
        }
        #endregion
    }
}
