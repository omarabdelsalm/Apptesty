using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Apptesty
{
    public class AdmobUnitIds
    {
        // For Banner Ad
        private static string _bannerId { get; set; }
        public static string BannerId
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android)
                    _bannerId = "ca-app-pub-9816794170840872/8649063901";
                else if (Device.RuntimePlatform == Device.iOS)
                    _bannerId = "ca-app-pub-9816794170840872/4800186338";

                return _bannerId;
            }
        }

        // For Interstitial Ad
        private static string _interstitialId { get; set; }
        public static string InterstitialId
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android)
                    _interstitialId = "ca-app-pub-9816794170840872/8440114684";
                else if (Device.RuntimePlatform == Device.iOS)
                    _interstitialId = "ca-app-pub-9816794170840872/4800186338";

                return _interstitialId;
            }
        }


        // For Rewarded Ad
        private static string _rewardedId { get; set; }
        public static string RewardedId
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android)
                    _rewardedId = "ca-app-pub-9816794170840872/8165728031";
                else if (Device.RuntimePlatform == Device.iOS)
                    _rewardedId = "ca-app-pub-9816794170840872/4800186338";

                return _rewardedId;
            }
        }
    }
}
