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
    public sealed partial class VFeed : Page
    {
        private static string teacherName;

        public VFeed()
        {
            this.InitializeComponent();
            fillCombo();
        }

        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FeedSuggest));
        }

        #region Faculty List
        private void fillCombo()
        {
            facultyNameBox.Items.Add("AppTeam");
            facultyNameBox.Items.Add("Dr. M.Bala Subramanian");
            facultyNameBox.Items.Add("Dr. Rajan Gupta");
            facultyNameBox.Items.Add("Dr. Deepali Kamthania");
            facultyNameBox.Items.Add("Dr. Mukta Narang");
            facultyNameBox.Items.Add("Ms. Kanta Malik");
            facultyNameBox.Items.Add("Ms. Indu Sahu");
            facultyNameBox.Items.Add("Ms. Vani Nijhawan");
            facultyNameBox.Items.Add("Ms. Neha Verma Malhotra");
            facultyNameBox.Items.Add("Ms. Meenu Chopra");
            facultyNameBox.Items.Add("Ms. Pooja Thakar");
            facultyNameBox.Items.Add("Mr. Dheeraj Malhotra");
            facultyNameBox.Items.Add("Ms. Neha Kohli");
            facultyNameBox.Items.Add("Ms. Neha Goel");
            facultyNameBox.Items.Add("Ms. Shefali Kapoor");
            facultyNameBox.Items.Add("Ms. Aastha Bhardwaj");
            facultyNameBox.Items.Add("Mr. Sachin Gupta");
            facultyNameBox.Items.Add("Mr. Priyanka Gupta");
            facultyNameBox.Items.Add("Ms. Cosmena Mahapatra");
            facultyNameBox.Items.Add("Ms. Anupama Jha");
            facultyNameBox.Items.Add("Ms. Shailee Bhatia");
            facultyNameBox.Items.Add("Ms. Seema Sharma");
            facultyNameBox.Items.Add("Ms. Megha Bansal");
            facultyNameBox.Items.Add("Ms. Alpana Sharma");
            facultyNameBox.Items.Add("Ms. Rashmi Bakshi");
            facultyNameBox.Items.Add("Ms. Prerna Ajmani");
            facultyNameBox.Items.Add("Ms. Sakshi Khullar");
            facultyNameBox.Items.Add("Ms. Nivedita Palia");
            facultyNameBox.Items.Add("Ms. Shikha Shokeen");
            facultyNameBox.Items.Add("Ms. Neetu Bhatiya Kapoor");
            facultyNameBox.Items.Add("Ms. Neetu Goel");
            facultyNameBox.Items.Add("Ms. Rashmi Dhruv");
            facultyNameBox.Items.Add("Ms. Kriti Sharma");
            facultyNameBox.Items.Add("Ms. Disha Verma");
            facultyNameBox.Items.Add("Ms. Mitanshi Rusagi");
            facultyNameBox.Items.Add("Ms. Ivy Jain");
            facultyNameBox.Items.Add("Ms. Neha Singh");
            facultyNameBox.Items.Add("Ms. Yogita Thareja");
            facultyNameBox.Items.Add("Ms. Sandhya Sharma");
        }
        #endregion

        private void facultyNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teacherName = facultyNameBox.SelectedValue as string;
            facName.Visibility = Visibility.Collapsed;
        }

        private async void PostFeed_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ring.IsActive = true;
                ring.Visibility = Visibility.Visible;

                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string username = (string)localSettings.Values["username"];
                string name = (string)localSettings.Values["name"];


                var check = await VFeedManager.feedFun(username, name, teacherName, feedbackBox.Text);

                if (check.success.Equals(true) || check.success.Equals("true"))
                    feedSuc();

                else
                {
                    ring.IsActive = false;
                    ring.Visibility = Visibility.Collapsed;

                    if (feedbackBox.Text.Equals(null) || feedbackBox.Text.Equals("") || feedbackBox.Text.Equals(" "))
                    {
                        var dialog = new MessageDialog("Feedback Box is empty");
                        await dialog.ShowAsync();
                    }

                   else if (teacherName.Equals(null) || teacherName.Equals("") || teacherName.Equals(" "))
                    {
                        var dialog = new MessageDialog("Faculty name not selected");
                        await dialog.ShowAsync();
                    }

                    else
                    {
                        var dialog = new MessageDialog("Something went wrong");
                        await dialog.ShowAsync();
                    }
                }
            }
            catch (Exception) { }
        }

        private async void feedSuc()
        {
            ring.IsActive = false;
            ring.Visibility = Visibility.Collapsed;

            var dialog = new MessageDialog("Thank you for your feedback");
            await dialog.ShowAsync();
        }
    }
}
