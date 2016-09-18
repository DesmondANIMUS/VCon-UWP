using System.Collections.ObjectModel;

namespace VCon.Models
{
    public class Internal1
    {
        public ObservableCollection<string> subs { get; set; }
        public ObservableCollection<string> values { get; set; }
    }

    public class Data_Internal
    {
        public Internal1 internal1 { get; set; }
        public object internal2 { get; set; }
    }

    public class InternalData
    {
        public bool success { get; set; }
        public Data_Internal data { get; set; }
        public object error { get; set; }
    }
}
