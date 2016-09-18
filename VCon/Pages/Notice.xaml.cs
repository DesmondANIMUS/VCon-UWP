using System;
using System.Collections.ObjectModel;
using VCon.Managers;
using VCon.Models;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Notice : Page
    {
        public ObservableCollection<Datum_2> noticeData { get; set; }

        private Uri uriBing;
        private string testUri;
        private bool ttsOn_Off = false;

        public Notice()
        {
            this.InitializeComponent();
            noticeData = new ObservableCollection<Datum_2>();
            ttsOn_Off = false;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                featRing.IsActive = true;
                featRing.Visibility = Visibility.Visible;

                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string batch = (string)localSettings.Values["batch"];
                string shift = (string)localSettings.Values["shift"];

                await NoticeManager.noticeDataRetrival(noticeData, batch, shift);

                featRing.IsActive = false;
                featRing.Visibility = Visibility.Collapsed;
            }

            catch (Exception ex) { ex.ToString(); }
        }

        private void ts0_1_Click(object sender, RoutedEventArgs e)
        {
            ts0_1.IsChecked = true;
            ts2.IsChecked = false;
            if (ts0_1.IsChecked == true)
            {
                ttsOn_Off = true;
                ts0_1.Visibility = Visibility.Collapsed;
                ts2.Visibility = Visibility.Visible;
                speakNotice.Play();
            }
        }


        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        #region Master List
        private void MasterListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ttsOn_Off == true)
            {
                string downPs;

                if (testBlock.Text.Equals(null) || testBlock.Text.Equals(""))
                    downPs = "Attachments are not available";
                else
                    downPs = "Attachments are available";

                SpeakText(speakNotice, titleSpeakBlock.Text, dateSpeakBlock.Text, contentSpeakBlock.Text, issuerSpeakBlock.Text, downPs);
            }

            if (testBlock.Text.Equals(null) || testBlock.Text.Equals(""))
                testBut.IsEnabled = false;
            else
                testBut.IsEnabled = true;
        }
        #endregion

        private async void downloadButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                testUri = testBlock.Text;
                uriBing = new Uri(testUri);
                var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);
            }

            catch (Exception) { }
        }

        #region Speech Synthesis
        private async void SpeakText(MediaElement speakIt, string noticeTitle, string issuedOn, string noContent, string issuedBy, string ifDownPs)
        {

            string textTospeak = "Notice Title: " + noticeTitle + "..." + "Issued on: " + issuedOn + "..." + noContent + "..." + "Issued By: " + issuedBy + "...." + ifDownPs;
            SpeechSynthesizer synth = new SpeechSynthesizer();
            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(textTospeak);

            speakIt.SetSource(stream, ""); // This starts Audio Player because auto play = true
        }
        #endregion

        public void goBack()
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        private void ts2_Click(object sender, RoutedEventArgs e)
        {
            ts0_1.IsChecked = false;
            ts2.IsChecked = true;
            if (ts2.IsChecked == true)
            {
                ttsOn_Off = false;
                ts0_1.Visibility = Visibility.Visible;
                ts2.Visibility = Visibility.Collapsed;
                speakNotice.Pause();
            }
        }


        #region Up and Down
        private void sDown_Click(object sender, RoutedEventArgs e)
        {
            notScroll.ChangeView(0, notScroll.ScrollableHeight, null);

            sUp.Visibility = Visibility.Collapsed;
            sDown.Visibility = Visibility.Collapsed;
        }

        private void sUp_Click(object sender, RoutedEventArgs e)
        {
            notScroll.ChangeView(0, 0, null);

            sUp.Visibility = Visibility.Collapsed;
            sDown.Visibility = Visibility.Collapsed;
        }

        private void notScroll_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var scrollableHeight = notScroll.ScrollableHeight;
            if (scrollableHeight > 0)
            {
                sUp.Visibility = Visibility.Visible;
                sDown.Visibility = Visibility.Visible;
            }

            else
            {
                sUp.Visibility = Visibility.Collapsed;
                sDown.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
    }
}
