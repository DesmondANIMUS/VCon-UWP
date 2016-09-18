using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MessMail : Page
    {

        private string perName;
        public MessMail()
        {
            this.InitializeComponent();
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            perName = (string)localSettings.Values["name"];
            DataContext = (Application.Current as App).SwypeChat;
        }

        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        private void mailBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateMail));
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {            
            (Application.Current as App).Broadcast(new ChatMessage { Username = perName, Message = text.Text });
            text.Text = "";
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
