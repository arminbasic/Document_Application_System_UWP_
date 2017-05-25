using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Text;




// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ApplyPage1 : Page
    {
        public ApplyPage1()
        {
            this.InitializeComponent();
        }


        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (apply.IsSelected) Frame.Navigate(typeof(ApplyPage1));
            else if (home.IsSelected) Frame.Navigate(typeof(MainPage));
            else if (about.IsSelected) Frame.Navigate(typeof(About));
            else if (contact.IsSelected) Frame.Navigate(typeof(Contact));
            else if (adminn.IsSelected) Frame.Navigate(typeof(AdminMode));
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            splitView1.IsPaneOpen = !splitView1.IsPaneOpen;

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private  void ApplyApply_Click(object sender, RoutedEventArgs e)
        {
            
            using (HttpClient client = new HttpClient())
            {
                var request = new Document()
                {
                    cips = cips.IsSelected.ToString(),
                    citizenship = citizenship.IsSelected.ToString(),
                    passport = passport.IsSelected.ToString(),
                    crimerecord = crimerecord.IsSelected.ToString(),
                    name = textBoxName.Text,
                    surName = textBoxSurname.Text,
                    identityNo = textBoxJMBG.Text,
                    streetAddress = textBoxAPAdress.Text,
                    city = textBoxApCoR.Text,
                    cantoon = textBoxCanton.Text,
                    zipCode = textBoxZIP.Text
                };

                var response = client.PostAsync("http://das.kemoke.net/api/documents", new StringContent(JsonConvert.SerializeObject(request).ToString(), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    dynamic content = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    
                }
                
            }

            textBlock1.Text = "YOU HAVE APPLIED FOR DOCUMENT.";



        }




        public class Document
        {
            public static int id { get; set; }
            public  string cips { get; set ;}
              public string citizenship { get; set; }
              public  string passport { get; set; }
              public  string crimerecord { get; set; }
              public string name { get; set; }
              public  string surName { get; set; }
              public  string identityNo { get; set; }
              public string streetAddress { get; set; }
              public string city { get; set; }
              public  string cantoon { get; set; }
              public  string zipCode { get; set; }


            public Document (string cipss, string cit, string pass, string crime, string namee, string sn, string iNO, string address, string cityy, string cant, string zip)
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

            
          }

      
    }

    
}
