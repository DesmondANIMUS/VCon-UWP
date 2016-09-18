using System;
using System.Collections.ObjectModel;
using VCon.Managers;
using VCon.Models;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppFeatures : Page
    {
        public ObservableCollection<Datum> gettingFeatures { get; set; }

        public AppFeatures()
        {
            this.InitializeComponent();
            gettingFeatures = new ObservableCollection<Datum>();
        }

        #region Navigation        
        private void MasterListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch(MasterListView.SelectedIndex)
            {
                case 0:
                    Frame.Navigate(typeof(Notice));
                    break;
                case 1:
                    Frame.Navigate(typeof(TimeTable));
                    break;
                case 2:
                    Frame.Navigate(typeof(Internal_Marks));
                    break;
                case 4:
                    Frame.Navigate(typeof(MessMail));
                    break;
                case 5:
                    Frame.Navigate(typeof(Profile));
                    break;
                case 6:
                    Frame.Navigate(typeof(FeedSuggest));
                    break;
            }
        }

        private void feedFly_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Reset_Password));
        }

        private void logFly_Click(object sender, RoutedEventArgs e)
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

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["loggedIn"] = logOut;
            Frame.Navigate(typeof(MainPage));
        }

        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About_Us));
        }

        private void cortana_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CortanaFeats));
        }

        #endregion

        #region Page loaded
        private async void appPage_Loaded(object sender, RoutedEventArgs e)
        {

            var store = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///VCommands.xml"));
            await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(store);

            try
            {

                featRing.IsActive = true;
                featRing.Visibility = Visibility.Visible;

                var checkVer = await ConfigManager.versionControl();

                // Read data from a simple setting
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                string loggedIn = (string)localSettings.Values["loggedIn"];

                if (string.IsNullOrWhiteSpace((string)localSettings.Values["loggedIn"]))
                    Frame.Navigate(typeof(MainPage));

                if (loggedIn.Equals("false") || loggedIn.Equals(null))
                    Frame.Navigate(typeof(MainPage));

                else if (loggedIn.Equals("true"))
                {
                    if (checkVer.cur_ver == 1)
                        await featureManager.getActualDataAsync(gettingFeatures);

                    else
                    {
                        var dialog = new MessageDialog("Please update your app to latest version to continue");
                        await dialog.ShowAsync();
                        CoreApplication.Exit();
                    }
                }

                featRing.IsActive = false;
                featRing.Visibility = Visibility.Collapsed;

            }
            catch (Exception) { }
        }
        #endregion

        #region Useful but not working
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    // Getting result from the parameter call
        //    SpeechRecognitionResult vcResult = e.Parameter as SpeechRecognitionResult;

        //    if(vcResult != null)
        //    {
        //        // What did the user say?
        //        string recoText = vcResult.Text;

        //        // Store the semantics in dictionary for later use 
        //        IReadOnlyDictionary<string, IReadOnlyList<string>> semantics = vcResult.SemanticInterpretation.Properties;

        //        string voiceCommandName = vcResult.RulePath[0];
        //        // vcResult.RulePath.First() works the same way             

        //        if (voiceCommandName == "showNotice")
        //            Frame.Navigate(typeof(Notice));

        //        else if (voiceCommandName == "subSug")
        //            Frame.Navigate(typeof(VSuggest));

        //        else if (voiceCommandName == "subFeed")
        //            Frame.Navigate(typeof(VFeed));

        //        else
        //            Frame.Navigate(typeof(CortanaFeats));
        //    }
        //}
        #endregion
    }
}
