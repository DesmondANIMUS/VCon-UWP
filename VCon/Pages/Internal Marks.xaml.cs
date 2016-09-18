using System;
using System.Collections.ObjectModel;
using VCon.Managers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Internal_Marks : Page
    {
        public ObservableCollection<string> subList;
        public ObservableCollection<string> valueList;

        public Internal_Marks()
        {
            this.InitializeComponent();

            subList = new ObservableCollection<string>();
            valueList = new ObservableCollection<string>();
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
                string username = (string)localSettings.Values["username"];
                string batch = (string)localSettings.Values["batch"];
                string shift = (string)localSettings.Values["shift"];

                await InternalManager.getValues(valueList, batch, shift, username);
                InternalManager.getSubs(subList);


                ring.IsActive = false;
                ring.Visibility = Visibility.Collapsed;
            }

            catch (Exception) { }
        }
    }
}
