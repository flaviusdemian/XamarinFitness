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

using Xamarin.ActionbarSherlockBinding.App;
using Xamarin.ActionbarSherlockBinding.Views;
using Xamarin.ActionbarSherlockBinding.Widget;



namespace SocialIntegration
{
    [Activity(Label = "Dashboard", MainLauncher = true, Icon = "@drawable/icon")]
    public class Dashboard : SherlockFragmentActivity
    {
        private static Handler handler = new Handler();
        private bool useLogo = false;
        private bool showHomeUp = false;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                //RequestWindowFeature(WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.Dashboard);
                var ab = base.SupportActionBar;
                
                //set defaults for logo & home up
                ab.SetDisplayHomeAsUpEnabled(showHomeUp);
                ab.SetDisplayUseLogoEnabled(useLogo);

                ////set up list nav
                ab.SetListNavigationCallbacks(ArrayAdapter.CreateFromResource(this, Resource.Array.sections, Resource.Drawable.abs__ic_menu_moreoverflow_normal_holo_light), null);

                Button btn_CreateWorkout = FindViewById<Button>(Resource.Id.CreateWorkout);
                Button btn_Stats = FindViewById<Button>(Resource.Id.Stats);

                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Roboto-Regular.ttf");

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


        public override bool OnCreateOptionsMenu(Xamarin.ActionbarSherlockBinding.Views.IMenu menu)
        {
            try
            {
                //MenuInflater.Inflate(Resource.Menu.myMenu, menu);
                //SupportMenuInflater.Inflate(Resource.Menu.main_menu, menu);
                SupportMenuInflater.Inflate(Resource.Menu.main_menu, menu);
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
            return base.OnCreateOptionsMenu(menu);
        }

    }
}