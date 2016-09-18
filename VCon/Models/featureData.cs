using System.Collections.Generic;

namespace VCon.Models
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string active { get; set; }
        public string bg_url { get; set; }
    }


    public class RootObject_2
    {
        public bool success { get; set; }
        public List<Datum> data { get; set; }
        public object error { get; set; }
    }
}
