using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using SocialIntegrationCore.Interface;
using Xamarin.Social;
using Xamarin.Social.Services;
using Xamarin.Auth;

namespace SocialIntegrationCore.Implementation
{
    public class FacebookProvider : ISocialMediaProvider
    {
        private FacebookService _FacebookService = new FacebookService();
        private static Account _Account;

        public String AccessToken { get; set; }
        public String AccessTokenSecret { get; set; }

        public FacebookProvider(string facebookAppId, string clientSecret, Activity destinationActivity)
        {
            _FacebookService.ClientId = facebookAppId;
            _FacebookService.ClientSecret = clientSecret;
        }

        public void Login(Activity destinationActivity)
        {
            try
            {
                Intent intent = _FacebookService.GetAuthenticateUI(destinationActivity, delegate(Account account)
                {
                    if (account != null)
                    {
                        AccessToken = account.Properties["access_token"];
                        _Account = account;
                    }
                });
                destinationActivity.StartActivity(intent);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public async Task<bool> Post(Activity destinationActivity, Item item)
        {
            bool result = false;
            try
            {
                #region ShareUI
                //Intent intent = _FacebookService.GetShareUI(destinationActivity, item, shareResult =>
                //{
                //    int x = 0;
                //    x++;
                //    result = true;
                //    //update UI
                //    //shareButton.Text = service.Title + " shared: " + shareResult;
                //});
                #endregion

                IDictionary<String, String> items = new Dictionary<string, string>();
                items.Add("message", "I'm sharing great things using #Xamarin #FTW!");
                items.Add("link", "http://xamarin.com");

                Request request = _FacebookService.CreateRequest("POST", new Uri("https://graph.facebook.com/v2.0/me/feed"), items, _Account);
                var response = await request.GetResponseAsync();
                var content = response.GetResponseText();
                //if (String.IsNullOrWhiteSpace(content) == false)
                //{

                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }
    }
}