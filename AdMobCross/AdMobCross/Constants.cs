using System;
using Xamarin.Essentials;

namespace AdMobCross
{
    public static class Constants
    {
        public static string AdBannerId
        {
            get
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                    return "ca-app-pub-3940256099942544/6300978111";

                if (DeviceInfo.Platform == DevicePlatform.iOS)
                    return "ca-app-pub-3940256099942544/2934735716";

                return string.Empty;
            }
        }

        public static string AdInterstitialId
        {
            get
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                    return "ca-app-pub-3940256099942544/1033173712";

                if (DeviceInfo.Platform == DevicePlatform.iOS)
                    return "ca-app-pub-3940256099942544/4411468910";

                return string.Empty;
            }
        }
    }
}
