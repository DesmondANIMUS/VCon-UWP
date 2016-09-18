using System;
using System.Collections.ObjectModel;
using VCon.Managers;
using VCon.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimeTable : Page
    {
        public ObservableCollection<Monday> getMonday { get; set; }
        public ObservableCollection<Tuesday> getTuesday { get; set; }
        public ObservableCollection<Wednesday> getWednesday { get; set; }
        public ObservableCollection<Thursday> getThursday { get; set; }
        public ObservableCollection<Friday> getFriday { get; set; }

        public TimeTable()
        {
            this.InitializeComponent();
            getMonday = new ObservableCollection<Monday>();
            getTuesday = new ObservableCollection<Tuesday>();
            getWednesday = new ObservableCollection<Wednesday>();
            getThursday = new ObservableCollection<Thursday>();
            getFriday = new ObservableCollection<Friday>();

            fillComboBox();
        }

        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                featRing.IsActive = true;
                featRing.Visibility = Visibility.Visible;

                monBlock.Visibility = Visibility.Collapsed;
                tuBlock.Visibility = Visibility.Collapsed;
                weBlock.Visibility = Visibility.Collapsed;
                thBlock.Visibility = Visibility.Collapsed;
                friBlock.Visibility = Visibility.Collapsed;

                // Read data from a simple setting
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                string batch = (string)localSettings.Values["batch"];
                string shift = (string)localSettings.Values["shift"];
                string section = "A";
                // Hardcoding section for now

                await TimeManager.mondayData(getMonday, batch, shift, section);
                TimeManager.tuesdayData(getTuesday, batch, shift, section);
                TimeManager.wednesdayData(getWednesday, batch, shift, section);
                TimeManager.thursdayData(getThursday, batch, shift, section);
                var fridayTest = TimeManager.fridayData(getFriday, batch, shift, section);

                if (fridayTest.success.Equals(null) || fridayTest.success.Equals("false"))
                {
                    friBlock.Visibility = Visibility.Collapsed;
                }

                featRing.IsActive = false;
                featRing.Visibility = Visibility.Collapsed;
                monBlock.Visibility = Visibility.Visible;
                tuBlock.Visibility = Visibility.Visible;
                weBlock.Visibility = Visibility.Visible;
                thBlock.Visibility = Visibility.Visible;
                friBlock.Visibility = Visibility.Visible;
            }
            catch (Exception) { }
        }

        #region Up and Down
        private void sUp_Click(object sender, RoutedEventArgs e)
        {
            timeScroll.ChangeView(0, 0, null);

            sUp.Visibility = Visibility.Collapsed;
            sDown.Visibility = Visibility.Collapsed;
        }

        private void timeScroll_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var scrollableHeight = timeScroll.ScrollableHeight;
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

        private void sDown_Click(object sender, RoutedEventArgs e)
        {
            timeScroll.ChangeView(0, timeScroll.ScrollableHeight, null);

            sUp.Visibility = Visibility.Collapsed;
            sDown.Visibility = Visibility.Collapsed;
        }
        #endregion

        private void fillComboBox()
        {
            days.Items.Add("All Days");
            days.Items.Add("Monday");
            days.Items.Add("Tuesday");
            days.Items.Add("Wednesday");
            days.Items.Add("Thursday");
            days.Items.Add("Friday");
        }

        #region Box Function
        private void days_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dayName;
            dayName = days.SelectedItem as string;

            switch (dayName)
            {
                case "All Days":
                    // Headers
                    monBlock.Visibility = Visibility.Visible;
                    tuBlock.Visibility = Visibility.Visible;
                    weBlock.Visibility = Visibility.Visible;
                    thBlock.Visibility = Visibility.Visible;
                    friBlock.Visibility = Visibility.Visible;

                    //Lists-1
                    mondayList.Visibility = Visibility.Visible;
                    tuesdayList.Visibility = Visibility.Visible;
                    wedList.Visibility = Visibility.Visible;
                    thursdayList.Visibility = Visibility.Visible;
                    fridayList.Visibility = Visibility.Visible;

                    // Lists-2
                    mondayList2.Visibility = Visibility.Visible;
                    tuesdayList2.Visibility = Visibility.Visible;
                    wedList2.Visibility = Visibility.Visible;
                    thursdayList2.Visibility = Visibility.Visible;
                    fridayList2.Visibility = Visibility.Visible;
                    break;

                case "Monday":
                    // Headers
                    monBlock.Visibility = Visibility.Visible;

                    tuBlock.Visibility = Visibility.Collapsed;
                    weBlock.Visibility = Visibility.Collapsed;
                    thBlock.Visibility = Visibility.Collapsed;
                    friBlock.Visibility = Visibility.Collapsed;

                    //Lists-1
                    mondayList.Visibility = Visibility.Visible;

                    tuesdayList.Visibility = Visibility.Collapsed;
                    wedList.Visibility = Visibility.Collapsed;
                    thursdayList.Visibility = Visibility.Collapsed;
                    fridayList.Visibility = Visibility.Collapsed;

                    // Lists-2
                    mondayList2.Visibility = Visibility.Visible;

                    tuesdayList2.Visibility = Visibility.Collapsed;
                    wedList2.Visibility = Visibility.Collapsed;
                    thursdayList2.Visibility = Visibility.Collapsed;
                    fridayList2.Visibility = Visibility.Collapsed;
                    break;

                case "Tuesday":
                    // Headers
                    tuBlock.Visibility = Visibility.Visible;

                    monBlock.Visibility = Visibility.Collapsed;
                    weBlock.Visibility = Visibility.Collapsed;
                    thBlock.Visibility = Visibility.Collapsed;
                    friBlock.Visibility = Visibility.Collapsed;

                    //Lists-1
                    tuesdayList.Visibility = Visibility.Visible;

                    mondayList.Visibility = Visibility.Collapsed;
                    wedList.Visibility = Visibility.Collapsed;
                    thursdayList.Visibility = Visibility.Collapsed;
                    fridayList.Visibility = Visibility.Collapsed;

                    // Lists-2
                    tuesdayList2.Visibility = Visibility.Visible;

                    mondayList2.Visibility = Visibility.Collapsed;
                    wedList2.Visibility = Visibility.Collapsed;
                    thursdayList2.Visibility = Visibility.Collapsed;
                    fridayList2.Visibility = Visibility.Collapsed;
                    break;

                case "Wednesday":
                    // Headers
                    weBlock.Visibility = Visibility.Visible;

                    tuBlock.Visibility = Visibility.Collapsed;
                    monBlock.Visibility = Visibility.Collapsed;
                    thBlock.Visibility = Visibility.Collapsed;
                    friBlock.Visibility = Visibility.Collapsed;

                    //Lists-1
                    wedList.Visibility = Visibility.Visible;

                    tuesdayList.Visibility = Visibility.Collapsed;
                    mondayList.Visibility = Visibility.Collapsed;
                    thursdayList.Visibility = Visibility.Collapsed;
                    fridayList.Visibility = Visibility.Collapsed;

                    // Lists-2
                    wedList2.Visibility = Visibility.Visible;

                    tuesdayList2.Visibility = Visibility.Collapsed;
                    mondayList2.Visibility = Visibility.Collapsed;
                    thursdayList2.Visibility = Visibility.Collapsed;
                    fridayList2.Visibility = Visibility.Collapsed;
                    break;

                case "Thursday":
                    // Headers
                    thBlock.Visibility = Visibility.Visible;

                    tuBlock.Visibility = Visibility.Collapsed;
                    weBlock.Visibility = Visibility.Collapsed;
                    monBlock.Visibility = Visibility.Collapsed;
                    friBlock.Visibility = Visibility.Collapsed;

                    //Lists-1
                    thursdayList.Visibility = Visibility.Visible;

                    tuesdayList.Visibility = Visibility.Collapsed;
                    wedList.Visibility = Visibility.Collapsed;
                    mondayList.Visibility = Visibility.Collapsed;
                    fridayList.Visibility = Visibility.Collapsed;

                    // Lists-2
                    thursdayList2.Visibility = Visibility.Visible;

                    tuesdayList2.Visibility = Visibility.Collapsed;
                    wedList2.Visibility = Visibility.Collapsed;
                    mondayList2.Visibility = Visibility.Collapsed;
                    fridayList2.Visibility = Visibility.Collapsed;
                    break;

                case "Friday":
                    // Headers
                    friBlock.Visibility = Visibility.Visible;

                    tuBlock.Visibility = Visibility.Collapsed;
                    weBlock.Visibility = Visibility.Collapsed;
                    thBlock.Visibility = Visibility.Collapsed;
                    monBlock.Visibility = Visibility.Collapsed;

                    //Lists-1
                    fridayList.Visibility = Visibility.Visible;

                    tuesdayList.Visibility = Visibility.Collapsed;
                    wedList.Visibility = Visibility.Collapsed;
                    thursdayList.Visibility = Visibility.Collapsed;
                    mondayList.Visibility = Visibility.Collapsed;

                    // Lists-2
                    fridayList2.Visibility = Visibility.Visible;

                    tuesdayList2.Visibility = Visibility.Collapsed;
                    wedList2.Visibility = Visibility.Collapsed;
                    thursdayList2.Visibility = Visibility.Collapsed;
                    mondayList2.Visibility = Visibility.Collapsed;
                    break;

                default:
                    // Headers
                    monBlock.Visibility = Visibility.Visible;
                    tuBlock.Visibility = Visibility.Visible;
                    weBlock.Visibility = Visibility.Visible;
                    thBlock.Visibility = Visibility.Visible;
                    friBlock.Visibility = Visibility.Visible;

                    //Lists-1
                    mondayList.Visibility = Visibility.Visible;
                    tuesdayList.Visibility = Visibility.Visible;
                    wedList.Visibility = Visibility.Visible;
                    thursdayList.Visibility = Visibility.Visible;
                    fridayList.Visibility = Visibility.Visible;

                    // Lists-2
                    mondayList2.Visibility = Visibility.Visible;
                    tuesdayList2.Visibility = Visibility.Visible;
                    wedList2.Visibility = Visibility.Visible;
                    thursdayList2.Visibility = Visibility.Visible;
                    fridayList2.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion
    }
}
