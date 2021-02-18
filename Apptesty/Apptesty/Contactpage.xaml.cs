using MarcTron.Plugin;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contactpage : ContentPage
    {
        public Contactpage()
        {
            InitializeComponent();
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;
        }

        private void Smsbtn(object sender, EventArgs e)
        {
            // Send Sms
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms("+201200018116", "العابد في انتظار رسائلكم");
        }

        private void Emlbtn(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail("allly2456@gmail.com", "العابد", "ابوبكر في خدمتكم طاب يومكم بكل خير");

                // Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc.
                var email = new EmailMessageBuilder()
                  .To("alll2456@gmail.com")
                  .Cc("cc.plugins@xamarin.com")
                  .Bcc(new[] { "bcc1.plugins@xamarin.com", "bcc2.plugins@xamarin.com" })
                  .Subject("Xamarin Messaging Plugin")
                  .Body("ابوبكر في خدمتكم طاب يومكم بكل خير")
                  .Build();

                emailMessenger.SendEmail(email);
            }
        }

        private void Callbtn(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            // Make Phone Call
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+20823770041","bkr alshobky");

        }
    }
}