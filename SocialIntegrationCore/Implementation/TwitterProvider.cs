using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using SocialIntegrationCore.Interface;
using Xamarin.Auth;
using Xamarin.Social;
using Xamarin.Social.Services;

namespace SocialIntegrationCore.Implementation
{
    public class TwitterProvider : ISocialMediaProvider
    {
        private TwitterService _TwitterService = new TwitterService();
        private static Account _Account;

        public String AccessToken { get; set; }
        public String AccessTokenSecret { get; set; }

        public TwitterProvider(string twitterConsumerKey, string twitterConsumerSecret, string callbackUrl)
        {
            _TwitterService.ConsumerKey = twitterConsumerKey;
            _TwitterService.ConsumerSecret = twitterConsumerSecret;
            _TwitterService.CallbackUrl = new Uri(callbackUrl);
        }

        public void Login(Activity destinationActivity)
        {
            try
            {
                Intent intent = _TwitterService.GetAuthenticateUI(destinationActivity, delegate(Account account)
                {
                    if (account != null)
                    {
                        _Account = account;
                        AccessToken = account.Properties["oauth_token"];
                        AccessTokenSecret = account.Properties["oauth_token_secret"];
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
                IDictionary<String, String> items = new Dictionary<string, string>();
                items.Add("status", "I'm sharing great things using #Xamarin #FTW!");

                Request request = _TwitterService.CreateRequest("POST", new Uri("https://api.twitter.com/1.1/statuses/update.json"), items, _Account);
                var response = await request.GetResponseAsync();
                var content = response.GetResponseText();
                //if (String.IsNullOrWhiteSpace(content) == false)
                //{

                //}
            }
            catch (Exception ex)
            {
                var s = ex.StackTrace;
                ex.ToString();
            }
            return result;
        }
    }
}