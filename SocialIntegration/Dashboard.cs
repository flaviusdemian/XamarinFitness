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
                Button btn_CreateWorkout = FindViewById<Button>(Resource.Id.CreateWorkout);
                Button btn_Stats = FindViewById<Button>(Resource.Id.Stats);

                btn_CreateWorkout.Click += delegate
                {
                    StartActivity(typeof(GoalSelection));
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