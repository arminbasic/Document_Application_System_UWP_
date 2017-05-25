using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPageRequests : Page

    {
        int c = 0;
        public AdminPageRequests()
        {
            this.InitializeComponent();
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            splitView1.IsPaneOpen = !splitView1.IsPaneOpen;
        }
        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected) Frame.Navigate(typeof(MainPage));
            else if (about.IsSelected) Frame.Navigate(typeof(About));
            else if (contact.IsSelected) Frame.Navigate(typeof(Contact));

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
        private async void buttonSee_Click(object sender, RoutedEventArgs e)
        {

            var http = new HttpClient();
            var url = String.Format("http://das.kemoke.net/api/documents");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Document));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Document)serializer.ReadObject(ms);



            string firstString = result.Replace("\"", string.Empty);
            string trim = firstString.Trim();
            string[] att = { ",", "[", "{", "}", "}", ":", "identityNo", "id", "cips", "citizenship", "passport", "crimerecord", "name", "surName", "streetAddress", "city", "cantoon", "zipCode", };
            string[] s = trim.Split(att, StringSplitOptions.RemoveEmptyEntries);
            string n = null;

            

            string show = "\n CIPS:" + s[c+1] + "\n CITIZENSHIP: " + s[c+2] + "\n PASSPORT: " + s[c+3] + "\n CRIMERECORD:" + s[c+4] + "\n NAME:" + s[c+5] + "\n SURNAME:" + s[c+6] + "\n JMBG: " + s[c+7] + "\n STREET ADDRESS: " + s[c+8] + "\n CITY: " + s[c+9] + "\n CANTON: " + s[c+10] + "\n ZIP/POSTAL CODE: " + s[c+11];

            textBlock.Text = show;

            c = c + 12;
                
              

        }

        private void buttonApprove_Click(object sender, RoutedEventArgs e)
        {

        }


        private void buttonDecline_Click(object sender, RoutedEventArgs e)
        {

        }

        public class Document
        {
            public static int id { get; set; }
            public string cips { get; set; }
            public string citizenship { get; set; }
            public string passport { get; set; }
            public string crimerecord { get; set; }
            public string name { get; set; }
            public string surName { get; set; }
            public string identityNo { get; set; }
            public string streetAddress { get; set; }
            public string city { get; set; }
            public string cantoon { get; set; }
            public string zipCode { get; set; }


            public Document(string cipss, string cit, string pass, string crime, string namee, string sn, string iNO, string address, string cityy, string cant, string zip)
            {
                cips = cipss;
                citizenship = cit;
                passport = pass;
                crimerecord = crime;
                name = namee;
                surName = sn;
                identityNo = iNO;
                streetAddress = address;
                city = cityy;
                cantoon = cant;
                zipCode = zip;
            }

            public Document()
            {

            }

            public string getCips()
            {
                return cips;
            }

            public string getCit()
            {
                return citizenship;
            }

            public string getPassp()
            {
                return passport;
            }

            public string Tostring()
            {
                return cips + citizenship + passport + crimerecord + name + surName + identityNo + streetAddress + city + cantoon + zipCode;
            }

        }
    }
}
