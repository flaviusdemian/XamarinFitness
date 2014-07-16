using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using SocialIntegrationCore.Implementation;
using Xamarin.Social;


namespace SocialIntegration
{
    [Activity(Label = "SocialIntegration", MainLauncher = true, Icon = "@drawable/icon")]
    public class InitialScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.InitialScreen);
            Button LogIn = FindViewById<Button>(Resource.Id.LoginButton);

            LogIn.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

        }
    }
}