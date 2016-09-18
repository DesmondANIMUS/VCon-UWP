using System;     
using VCon.Managers;                         
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;              

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Reset_Password : Page
    {
        public Reset_Password()
        {
            this.InitializeComponent();
        }

        private async void resetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resetRing.IsActive = true;
                resetRing.Visibility = Visibility.Visible;
                resetButton.Visibility = Visibility.Collapsed;


                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string uid = (string)localSettings.Values["uid"];
                string key = (string)localSettings.Values["key"];

                var checkErr = await ResetManager.getReset(uid, oldPassBox.Password, newPassBox.Password);

                if (checkErr.success.Equals(true) || checkErr.success.Equals("true"))
                    resetSuccess();

                else
                {
                    resetRing.IsActive = false;
                    resetRing.Visibility = Visibility.Collapsed;
                    resetButton.Visibility = Visibility.Visible;

                    if (oldPassBox.Password.Equals(null) || oldPassBox.Password.Equals("") || oldPassBox.Password.Equals(" ") || newPassBox.Password.Equals(null) || newPassBox.Password.Equals("") || newPassBox.Password.Equals(" "))
                    {
                        var dialog = new MessageDialog("Password fields cannot be empty");
                        await dialog.ShowAsync();
                    }

                    else if (!(oldPassBox.Password.Equals(key)))
                    {
                        var dialog = new MessageDialog("Old Password is wrong");
                        await dialog.ShowAsync();
                    }

                }

            }

            catch (Exception) { }
        }

        private async void resetSuccess()
        {
            string logOut = "false";

            var keepTemp = Windows.Storage.ApplicationData.Current.LocalSettings;

            keepTemp.Values["username"] = null;
            keepTemp.Values["name"] = null;
            keepTemp.Values["uid"] = null;
            keepTemp.Values["batch"] = null;
            keepTemp.Values["shift"] = null;
            keepTemp.Values["email"] = null;
            keepTemp.Values["mobile"] = null;

            var lSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            lSettings.Values["loggedIn"] = logOut;

            resetRing.IsActive = false;
            resetRing.Visibility = Visibility.Collapsed;

            var dialog = new MessageDialog("Password reset complete");
            await dialog.ShowAsync();

            Frame.Navigate(typeof(MainPage));
        }
    }
}
