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
    [Activity(Label = "Duration Selection", MainLauncher = false, Icon = "@drawable/icon")]
    public class DurationSelection : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.DurationSelection);
                Button btn_t15min = FindViewById<Button>(Resource.Id.t15min);
                Button btn_t30min = FindViewById<Button>(Resource.Id.t30min);
                Button btn_t45min = FindViewById<Button>(Resource.Id.t45min);

                Typeface font = Typeface.CreateFromAsset(Application.Context.Assets, "RobotoCondensed-Regular.ttf");
                btn_t15min.SetTypeface(font, TypefaceStyle.Normal);
                btn_t30min.SetTypeface(font, TypefaceStyle.Normal);
                btn_t45min.SetTypeface(font, TypefaceStyle.Normal);

                btn_t15min.Click += delegate
                {
                    StartActivity(typeof(EquipmentSelection));
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