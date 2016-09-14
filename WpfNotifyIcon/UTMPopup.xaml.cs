using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfNotifyIcon
{
    /// <summary>
    /// Interaction logic for FirstPopup.xaml
    /// </summary>
    public partial class UTMPopup 
    {
        string _ignoredURL;

        private string utmSource;
        private string utmMedium;
        private string utmCampaign;

        public string IgnoredURL
        {
            get { return _ignoredURL; }
            set { _ignoredURL = value; }
        }
        public UTMPopup()
        {
            InitializeComponent();
            utmSource = "";
            utmMedium = "";
            utmCampaign = "";
        }

        private void ignoreButton_Click(object sender, RoutedEventArgs e)
        {
            IgnoredURL = urlTextBox.Text;
            this.IsOpen = false;
            
        }

        private void generateUTM_Click(object sender, RoutedEventArgs e)
        {
            utmStackPanel.Visibility = Visibility.Visible;
        }

      

      

       

        private void sourceComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            utmSource = "utm_source=" + (sender as ComboBox).SelectedItem as String;
        }

        private void mediumComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            utmMedium = "utm_medium=" + (sender as ComboBox).SelectedItem as String; 
        }

        private void campaignComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            utmCampaign = "utm_campagn=" + (sender as ComboBox).SelectedItem as String; ;
            StringBuilder utmStringBuilder = new StringBuilder(urlTextBox.Text);
            utmStringBuilder.Append("?");
            utmStringBuilder.Append(utmSource);
            utmStringBuilder.Append("&");
            utmStringBuilder.Append(utmMedium);
            utmStringBuilder.Append("&");
            utmStringBuilder.Append(utmCampaign);


            utmUrlTextBox.Text = utmStringBuilder.ToString();
        }
    }
}
