using System.Collections.Generic;

namespace VCon.Models
{

    public class Monday
    {
        public string batch { get; set; }
        public string shift { get; set; }
        public string section { get; set; }
        public string day { get; set; }
        public string lecture_number { get; set; }
        public string name { get; set; }
        public string timing { get; set; }
        public string active { get; set; }
    }

    public class Tuesday
    {
        public string batch { get; set; }
        public string shift { get; set; }
        public string section { get; set; }
        public string day { get; set; }
        public string lecture_number { get; set; }
        public string name { get; set; }
        public string timing { get; set; }
        public string active { get; set; }
    }

    public class Wednesday
    {
        public string batch { get; set; }
        public string shift { get; set; }
        public string section { get; set; }
        public string day { get; set; }
        public string lecture_number { get; set; }
        public string name { get; set; }
        public string timing { get; set; }
        public string active { get; set; }
    }

    public class Thursday
    {
        public string batch { get; set; }
        public string shift { get; set; }
        public string section { get; set; }
        public string day { get; set; }
        public string lecture_number { get; set; }
        public string name { get; set; }
        public string timing { get; set; }
        public string active { get; set; }
    }

    public class Friday
    {
        public string batch { get; set; }
        public string shift { get; set; }
        public string section { get; set; }
        public string day { get; set; }
        public string lecture_number { get; set; }
        public string name { get; set; }
        public string timing { get; set; }
        public string active { get; set; }
    }

    public class Data_Time
    {
        public List<Monday> monday { get; set; }
        public List<Tuesday> tuesday { get; set; }
        public List<Wednesday> wednesday { get; set; }
        public List<Thursday> thursday { get; set; }
        public List<Friday> friday { get; set; }
    }

    public class TimeData
    {
        public bool success { get; set; }
        public Data_Time data { get; set; }
        public object error { get; set; }
    }
}
