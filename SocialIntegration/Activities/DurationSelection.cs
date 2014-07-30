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
    [Activity(Label = "Duration Selection", MainLauncher = false, Icon = "@drawable/icon")]
    public class DurationSelection : SlidingMenuParentActivity
    {
        public static FragmentDurationSelection fragmentSample = new FragmentDurationSelection();
        private static Handler handler = new Handler();
        private bool useLogo = false;
        private bool showHomeUp = false;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
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