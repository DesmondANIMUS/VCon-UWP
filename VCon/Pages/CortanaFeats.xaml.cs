using System;                                                                               
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;                                                             

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VCon.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CortanaFeats : Page
    {
        public CortanaFeats()
        {
            this.InitializeComponent();

            Random random = new Random();
            var ranText = random.Next(5);

            switch (ranText)
            {
                case 1:
                    in1.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in4.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;

                case 2:
                    in5.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in4.Visibility = Visibility.Collapsed;
                    in1.Visibility = Visibility.Collapsed; break;

                case 3:
                    in4.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in1.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;

                case 4:
                    in3.Visibility = Visibility.Visible;
                    in1.Visibility = Visibility.Collapsed;
                    in4.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;

                default:
                    in4.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in1.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;
            }
        }

        private void aboutBut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppFeatures));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            var ranText = random.Next(5);
            switch (ranText)
            {
                case 1:
                    in1.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in4.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;

                case 2:
                    in5.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in4.Visibility = Visibility.Collapsed;
                    in1.Visibility = Visibility.Collapsed; break;

                case 3:
                    in4.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in1.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;

                case 4:
                    in3.Visibility = Visibility.Visible;
                    in1.Visibility = Visibility.Collapsed;
                    in4.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;

                default:
                    in4.Visibility = Visibility.Visible;
                    in3.Visibility = Visibility.Collapsed;
                    in1.Visibility = Visibility.Collapsed;
                    in5.Visibility = Visibility.Collapsed; break;
            }
        }
    }
}