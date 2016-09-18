using System;
using VCon.Managers;
using VCon.Models;
using Windows.ApplicationModel.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VCon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string batchData, shiftData, email, mobile;
        public static string uid, username, name, key;
        private string loggedIn = "false";
        private readonly int currentVersion = Constants.VERSION;
        #region Version Control
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                verContRing.IsActive = true;
                verContRing.Visibility = Visibility.Visible;

                var checkVer = await ConfigManager.versionControl();

                if (checkVer.cur_ver != currentVersion)
                {
                    var dialog = new MessageDialog("Please update your app to latest version to continue");
                    await dialog.ShowAsync();
                    CoreApplication.Exit();
                }

                verContRing.IsActive = false;
                verContRing.Visibility = Visibility.Collapsed;

            }
            catch (Exception x) { x.ToString(); }
        }
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Login
        private async void loginBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loginRing.IsActive = true;
                loginRing.Visibility = Visibility.Visible;

                var personData = await LoginData.getLogin(userBox.Text, passwordBox.Password);

                batchData = personData.data.batch;
                shiftData = personData.data.shift;
                uid = personData.data.uid.ToString();
                username = personData.data.username;
                name = personData.data.name;
                key = personData.data.password;
                email = personData.data.email;
                mobile = personData.data.mobile as string;

                var keepTemp = Windows.Storage.ApplicationData.Current.LocalSettings;
                keepTemp.Values["username"] = username;
                keepTemp.Values["name"] = name;
                keepTemp.Values["uid"] = uid;
                keepTemp.Values["batch"] = batchData;
                keepTemp.Values["shift"] = shiftData;
                keepTemp.Values["key"] = key;
                keepTemp.Values["email"] = email;
                keepTemp.Values["mobile"] = mobile;

                #region Login Check
                if (personData.data.password.Equals(passwordBox.Password))
                {
                    Frame.Navigate(typeof(Pages.AppFeatures));

                    loggedIn = "true";

                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                    // Create a simple setting

                    localSettings.Values["loggedIn"] = loggedIn;
                }
                #endregion

                else
                {
                    userBox.Visibility = Visibility.Collapsed;
                    passwordBox.Visibility = Visibility.Collapsed;
                    loginBut.Visibility = Visibility.Collapsed;
                    useBlock.Visibility = Visibility.Collapsed;
                    pasBlock.Visibility = Visibility.Collapsed;
                    errorElipse.Visibility = Visibility.Visible;
                }


                loginRing.IsActive = false;
                loginRing.Visibility = Visibility.Collapsed;
            }

            catch (Exception ex) { ex.ToString(); }
        }
        #endregion

    }
}
