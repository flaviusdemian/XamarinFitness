using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using SocialIntegrationCore.Implementation;
using Xamarin.Social;
using Android.Views;
using Android.Graphics;


namespace SocialIntegration
{
    [Activity(Label = "SocialIntegration v2", MainLauncher = false, Icon = "@drawable/icon")]
    public class InitialScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.InitialScreen);
                Button LogIn = FindViewById<Button>(Resource.Id.LoginButton);


                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Roboto-Regular.ttf");

                //Change button font
                LogIn.SetTypeface(font, TypefaceStyle.Normal);


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