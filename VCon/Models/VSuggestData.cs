namespace VCon.Models
{
    public class Data_sug
    {
        public string username { get; set; }
        public string name { get; set; }
        public string suggestion { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
    }

    public class RootObject_suggest
    {
        public bool success { get; set; }
        public Data_sug data { get; set; }
        public object error { get; set; }
    }
}
