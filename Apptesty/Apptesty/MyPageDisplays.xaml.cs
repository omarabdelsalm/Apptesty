using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPageDisplays : ContentPage
    {
        public MyPageDisplays(string person, string name, string phon, string point)
        {
            InitializeComponent();
            perId.Text = person;
            nameEt.Text = name;
            phonEt.Text = phon;
            pointEt.Text = point;
            parcode.BarcodeValue = person;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Call this from your PCL code
            if (ipaddress.Text == null && port.Text == null)
            {
                await DisplayAlert("", "please insert ip and port for your printer", "ok");
                return;
                
            }
            // Variables
            string ipAddress = ipaddress.Text.ToString();
            int portNumber = Convert.ToInt32(port.Text);
            List<string> myText = new List<string>() {
                 perId.Text.ToString() ,
                nameEt.Text.ToString(),
                 phonEt.Text.ToString(),
                 pointEt.Text.ToString(),
                 parcode.BarcodeValue.ToString()
            };

            // Try to find the platform specific services
            
                var printer = DependencyService.Get<Apptesty.IPrinter>();
                if (printer == null)
                {
                    // Do not proceed if no services found for the platform
                    await DisplayAlert("Error", "No implementation provided for this platform", "OK");
                    return;
                }

                try
                {
                    // Call the method, declare by the IPrinter interface
                    printer.Print(ipAddress, portNumber, myText);
                }
                catch (Exception ex)
                {
                    // Exception here could mean difficulties in connecting to the printer etc
                     DisplayAlert("Error", $"Failed to print redemption slip\nReason: {ex.Message}", "OK");
                ipaddress.Text = "";
                port.Text = "";
            }
            

        }
    }
}