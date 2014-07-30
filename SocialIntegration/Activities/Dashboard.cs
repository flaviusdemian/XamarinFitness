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
using SlidingMenu;
using SocialIntegration.Fragments;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;



namespace SocialIntegration
{
    [Activity(Label = "Dashboard", MainLauncher = true, Icon = "@drawable/icon")]
    public class Dashboard : SlidingMenuParentActivity
    {
        public static FragmentDashboard fragmentSample = new FragmentDashboard();
        private static Handler handler = new Handler();
        private bool useLogo = false;
        private bool showHomeUp = false;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                var ab = base.SupportActionBar;

                //set defaults for logo & home up
                ab.SetDisplayHomeAsUpEnabled(showHomeUp);
                ab.SetDisplayUseLogoEnabled(useLogo);

                ////set up list nav
                ab.SetListNavigationCallbacks(ArrayAdapter.CreateFromResource(this, Resource.Array.sections, Resource.Drawable.abs__ic_menu_moreoverflow_normal_holo_light), null);
            }
            catch (Exception ex)
            {
                ex.ToString();
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
            }
            return base.OnCreateOptionsMenu(menu);
        }
        protected override void SelectItem()
        {
            try
            {
                FragmentTransaction ft = SupportFragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragmentSample);
                ft.Commit();
                mDrawerListLeft.SetItemChecked(0, true);
                // Close drawer
                mDrawerLayout.CloseDrawer(mDrawerListLeft);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }

}