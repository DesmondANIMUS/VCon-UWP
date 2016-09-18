using System;                                       
using VCon.Models;                       
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;          

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Profile : Page
    {
        public Profile()
        {
            this.InitializeComponent();
        }


        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ring.IsActive = true;
                ring.Visibility = Visibility.Visible;

                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                string user = (string)localSettings.Values["username"];
                string key = (string)localSettings.Values["key"];

                var personData = await LoginData.getLogin(user, key);

                //string mob = personData.data.mobile as string;
                //if (mob.Equals(null) || mob.Equals(" ") || mob.Equals("null"))
                //{
                //    batch.Text = personData.data.batch;
                //    shift.Text = personData.data.shift;
                //    roll.Text = personData.data.username;
                //    Name.Text = personData.data.name;
                //    email.Text = personData.data.email;
                //}   

                batch.Text = personData.data.batch;
                shift.Text = personData.data.shift;
                roll.Text = personData.data.username;
                Name.Text = personData.data.name;
                email.Text = personData.data.email;

                ring.IsActive = false;
                ring.Visibility = Visibility.Collapsed;
            }

            catch (Exception) { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Reset_Password));
        }
    }
}
