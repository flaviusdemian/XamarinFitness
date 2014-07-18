using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using SocialIntegrationCore.Implementation;
using Xamarin.Social;
using Android.Views;


namespace SocialIntegration
{
    [Activity(Label = "SocialIntegration v2", MainLauncher = false, Icon = "@drawable/icon")]
    public class InitialScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.InitialScreen);
                Button LogIn = FindViewById<Button>(Resource.Id.LoginButton);

                LogIn.Click += delegate
                {
                    StartActivity(typeof(MainActivity));
                };
                //Toast.MakeText(this, "Ops", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }


        }
    }
}