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
    public sealed partial class VSuggest : Page
    {
        public VSuggest()
        {
            this.InitializeComponent();
        }

        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FeedSuggest));
        }

        private async void PostSuggestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ring.IsActive = true;
                ring.Visibility = Visibility.Visible;


                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string username = (string)localSettings.Values["username"];
                string name = (string)localSettings.Values["name"];

                var check = await VSuggestManager.suggestFun(username, name, feedbackBox.Text);
                if (check.success.Equals(true) || check.success.Equals("true"))
                    sugCom();


                else
                {
                    ring.IsActive = false;
                    ring.Visibility = Visibility.Collapsed;

                    if (feedbackBox.Text.Equals(null) || feedbackBox.Text.Equals("") || feedbackBox.Text.Equals(" "))
                    {
                        var dialog = new MessageDialog("Suggestion Box is empty");
                        await dialog.ShowAsync();
                    }

                    else
                    {
                        var dialog = new MessageDialog("Something went wrong");
                        await dialog.ShowAsync();
                    }
                }

            }

            catch (Exception x) { x.ToString(); }
        }

        private async void sugCom()
        {
            ring.IsActive = false;
            ring.Visibility = Visibility.Collapsed;

            var dialog = new MessageDialog("Your suggestion has been noted");
            await dialog.ShowAsync();
        }
    }
}
