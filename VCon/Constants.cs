namespace VCon
{
    class Constants
    {
        private const string BASE_URL                                                   = "http://ec2-52-38-18-88.us-west-2.compute.amazonaws.com/index.php/vconnect/";
        private const string signalR                                                    = "http://swypeinback.azurewebsites.net";
        private const int version                                                       = 1;

        private const string vsuggest                                                   = BASE_URL + "add_suggestion?";
        private const string vfeed                                                      = BASE_URL + "add_feedback?";
        private const string vtime                                                      = BASE_URL + "get_timetable?";
        private const string vreset                                                     = BASE_URL + "reset_password?";
        private const string vinternal                                                  = BASE_URL + "get_internal_marks";
        private const string vnotice                                                    = BASE_URL + "list_notices?";
        private const string vfeat                                                      = BASE_URL + "app_features";
        private const string vconfig                                                    = BASE_URL + "config";
        private const string vuser                                                      = BASE_URL + "getuser?";

        internal const string VSUGGEST                                                  = vsuggest;
        internal const string VFEED                                                     = vfeed;
        internal const string VTIME                                                     = vreset;
        internal const string VRESET                                                    = vreset;
        internal const string VINTERNAL                                                 = vinternal;
        internal const string VNOTICE                                                   = vnotice;
        internal const string VFEAT                                                     = vfeat;
        internal const string VCONFIG                                                   = vconfig;
        internal const string VUSER                                                     = vuser;
        internal const string VHUB                                                      = signalR;

        internal const int VERSION                                                      = version;
    }
}
