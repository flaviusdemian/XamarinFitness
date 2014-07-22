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
using Android.Graphics;

namespace SocialIntegration
{
    [Activity(Label = "Difficulty Selection", MainLauncher = false, Icon = "@drawable/icon")]
    public class DifficultySelection : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.DifficultySelection);
                Button btn_Beginner = FindViewById<Button>(Resource.Id.Beginner);
                Button btn_Intermediate = FindViewById<Button>(Resource.Id.Intermediate);
                Button btn_Advanced = FindViewById<Button>(Resource.Id.Advanced);

                btn_Beginner.Click += delegate
                {
                    StartActivity(typeof(DurationSelection));
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}