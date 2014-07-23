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
    [Activity(Label = "Goal Selection", MainLauncher = false, Icon = "@drawable/icon")]
    public class GoalSelection : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.GoalSelection);
                Button btn_GetLean = FindViewById<Button>(Resource.Id.GetLean);
                Button btn_GetToned = FindViewById<Button>(Resource.Id.GetToned);
                Button btn_ImpromptuWorkout = FindViewById<Button>(Resource.Id.ImpromptuWorkout);

                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "RobotoCondensed-Regular.ttf");
                btn_GetLean.SetTypeface(font, TypefaceStyle.Normal);
                btn_GetToned.SetTypeface(font, TypefaceStyle.Normal);
                btn_ImpromptuWorkout.SetTypeface(font, TypefaceStyle.Normal);

                btn_GetLean.Click += delegate
                {
                    StartActivity(typeof(DifficultySelection));
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