namespace VCon.Models
{
    public class Data_feed
    {
        public string username { get; set; }
        public string name { get; set; }
        public string feedback { get; set; }
        public string teacher_name { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
    }

    public class RootObject_feed
    {
        public bool success { get; set; }
        public Data_feed data { get; set; }
        public object error { get; set; }
    }
}
