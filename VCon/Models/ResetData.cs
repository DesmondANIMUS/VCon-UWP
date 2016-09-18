namespace VCon.Models
{
    public class Data_reset
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public object address { get; set; }
        public object mobile { get; set; }
        public string email { get; set; }
        public string device_id { get; set; }
    }

    public class RootObject_reset
    {
        public bool success { get; set; }
        public Data_reset data { get; set; }
        public object error { get; set; }
    }
}
