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
    [Activity(Label = "SocialIntegration", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private ISocialMediaProvider SocialMediaProvider = null;
        //private SocialMediaProviderType SocialMediaProviderType = SocialMediaProviderType.Facebook;


        private const string FacebookAppId = "185496498241687";
        private const string ClientSecret = "5a8688b78f9c039209d0ce4f59345936";

        private const string TwitterConsumerKey = "";
        private const string TwitterConsumerSecret = "";

        private ImageButton btn_LoginWithFacebook, btn_LoginWithtwitter; 
        private Button btn_ShareWithFacebook, btn_ShareWithtwitter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            btn_LoginWithFacebook = FindViewById<ImageButton>(Resource.Id.LoginFacebookButton);
            btn_LoginWithFacebook.Click += (sender, args) => LoginWithFacebook();

            btn_LoginWithtwitter = FindViewById<ImageButton>(Resource.Id.LoginTwitterButton);
            btn_LoginWithtwitter.Click += (sender, args) => LoginWithTwitter();

            btn_ShareWithFacebook = FindViewById<Button>(Resource.Id.ShareFacebookButton);
            btn_ShareWithFacebook.Click += async (sender, args) => await ShareWithFacebook();

            btn_ShareWithtwitter = FindViewById<Button>(Resource.Id.ShareTwitterButton);
            btn_ShareWithtwitter.Click += async (sender, args) => await ShareWithTwitter();
        }

        private void LoginWithFacebook()
        {
            try
            {
                var socialMediaProvider = new FacebookProvider(FacebookAppId, ClientSecret, this);
                socialMediaProvider.Login(this);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void LoginWithTwitter()
        {
            try
            {
                var socialMediaProvider = new TwitterProvider(TwitterConsumerKey, TwitterConsumerSecret, "http://www.google.ro");
                socialMediaProvider.Login(this);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task ShareWithTwitter()
        {
            try
            {
                var socialMediaProvider = new TwitterProvider(TwitterConsumerKey, TwitterConsumerSecret, "http://www.google.ro");
                var item = new Item
                {
                    Text = "I'm sharing great things using #Xamarin #FTW!",
                    Links = new List<Uri>
                    {
                        new Uri("http://xamarin.com"),
                    },
                };
                await socialMediaProvider.Post(this, item);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task ShareWithFacebook()
        {
            try
            {
                var socialMediaProvider = new FacebookProvider(FacebookAppId, ClientSecret, this);
                var item = new Item
                {
                    Text = "I'm sharing great things using #Xamarin #FTW!",
                    Links = new List<Uri>
                    {
                        new Uri("http://xamarin.com"),
                    },
                };
                await socialMediaProvider.Post(this, item);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }


}