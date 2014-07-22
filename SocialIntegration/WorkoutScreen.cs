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
    [Activity(Label = "Workout Screen", MainLauncher = false, Icon = "@drawable/icon")]
    public class WorkoutScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.WorkoutScreen);
                Button DoWorkout = FindViewById<Button>(Resource.Id.button1);


                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Application.Context.Assets, "Roboto-Regular.ttf");

                //Change button font
                DoWorkout.SetTypeface(font, TypefaceStyle.Normal);


            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}