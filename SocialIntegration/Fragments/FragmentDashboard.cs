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
using Xamarin.ActionbarSherlockBinding.App;
using Android.Graphics;

namespace SocialIntegration.Fragments
{
    public class FragmentDashboard : SherlockFragment
    {
        private ListView lv_searchResults, mySignLanguagelist, mySpokenLanguagelist;
        private View rootView;
        public static ProgressBar pb_searchResultsProgressBar;
        private Display display;
        public Button btn_popover_filters, btn_popoverSearch;
        private ImageView iv_sign_language, iv_spoken_language;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = null;
            try
            {
                rootView = inflater.Inflate(Resource.Layout.Dashboard, container, false);
                InitializeUIElements();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return rootView;
        }

        private void InitializeUIElements()
        {
            try
            {
                Button btn_CreateWorkout = rootView.FindViewById<Button>(Resource.Id.CreateWorkout);
                Button btn_Stats = rootView.FindViewById<Button>(Resource.Id.Stats);

                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Roboto-Regular.ttf");

                //Change button font
                btn_CreateWorkout.SetTypeface(font, TypefaceStyle.Normal);
                btn_Stats.SetTypeface(font, TypefaceStyle.Normal);


                btn_CreateWorkout.Click += delegate
                {
                    SherlockActivity.StartActivity(typeof(GoalSelection));
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}