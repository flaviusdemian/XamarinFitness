using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SocialIntegration
{
    [Activity(Label = "Dashboard", MainLauncher = false, Icon = "@drawable/icon")]
    public class Dashboard : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.Dashboard);
            }
             catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}