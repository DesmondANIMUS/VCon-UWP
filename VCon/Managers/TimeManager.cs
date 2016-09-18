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
    class TimeManager
    {
        private static readonly string reUri = Constants.VTIME;
        public static TimeData dataWrapper;

        private async static Task<TimeData> getTime(string batch, string shift, string section)
        {
            var http = new HttpClient();

            var parameters = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("batch", batch),
                                                               new KeyValuePair<string, string>("shift", shift),
                                                               new KeyValuePair<string, string>("section", section)});

            var response = await http.PostAsync(reUri, parameters);

            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(TimeData));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var datax = (TimeData)serializer.ReadObject(ms);

            return datax;
        }

        public static async Task mondayData(ObservableCollection<Monday> timeMonday, string B, string S, string sec)
        {
            dataWrapper = await getTime(B, S, sec);

            var getData = dataWrapper.data.monday;
            foreach (var noData in getData)
            {
                timeMonday.Add(noData);
            }
        }

        public static void tuesdayData(ObservableCollection<Tuesday> timeTuesday, string B, string S, string sec)
        {
            var getData = dataWrapper.data.tuesday;
            foreach (var noData in getData)
            {
                timeTuesday.Add(noData);
            }
        }

        public static void wednesdayData(ObservableCollection<Wednesday> timeWednesday, string B, string S, string sec)
        {
            var getData = dataWrapper.data.wednesday;
            foreach (var noData in getData)
            {
                timeWednesday.Add(noData);
            }
        }

        public static void thursdayData(ObservableCollection<Thursday> timeThursday, string B, string S, string sec)
        {
            var getData = dataWrapper.data.thursday;
            foreach (var noData in getData)
            {
                timeThursday.Add(noData);
            }
        }

        public static TimeData fridayData(ObservableCollection<Friday> timeFriday, string B, string S, string sec)
        {
            var getData = dataWrapper.data.friday;
            foreach (var noData in getData)
            {
                timeFriday.Add(noData);
            }

            return dataWrapper;
        }
    }
}
