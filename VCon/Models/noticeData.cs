using System.Collections.Generic;

namespace VCon.Models
{
    public class Datum_2
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string issuer { get; set; }
        public string issuer_id { get; set; }
        public string date { get; set; }
        public string file_url { get; set; }
        public string batch { get; set; }
        public string shift { get; set; }
        public object section { get; set; }
    }

    public class RootObject_3
    {
        public bool success { get; set; }
        public List<Datum_2> data { get; set; }
        public object error { get; set; }
    }
}
