using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;                                                   

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeedSuggest : Page
    {
        public FeedSuggest()
        {
            this.InitializeComponent();
        }


        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(VFeed));
        }

        private void Suggestion_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(VSuggest));
        }
    }
}
