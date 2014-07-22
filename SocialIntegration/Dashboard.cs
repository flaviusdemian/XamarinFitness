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
    [Activity(Label = "Dashboard", MainLauncher = true, Icon = "@drawable/icon")]
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

                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Application.Context.Assets, "Roboto-Regular.ttf");

                //Change button font
                btn_CreateWorkout.SetTypeface(font, TypefaceStyle.Normal);
                btn_Stats.SetTypeface(font, TypefaceStyle.Normal);


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