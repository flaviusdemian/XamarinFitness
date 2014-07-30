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
    public class FragmentDifficultySelection : SherlockFragment
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
                rootView = inflater.Inflate(Resource.Layout.DifficultySelection, container, false);
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
                Button btn_Beginner = rootView.FindViewById<Button>(Resource.Id.Beginner);
                Button btn_Intermediate = rootView.FindViewById<Button>(Resource.Id.Intermediate);
                Button btn_Advanced = rootView.FindViewById<Button>(Resource.Id.Advanced);

                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "RobotoCondensed-Regular.ttf");
                btn_Beginner.SetTypeface(font, TypefaceStyle.Normal);
                btn_Intermediate.SetTypeface(font, TypefaceStyle.Normal);
                btn_Advanced.SetTypeface(font, TypefaceStyle.Normal);

                btn_Beginner.Click += delegate
                {
                    SherlockActivity.StartActivity(typeof(DurationSelection));
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }   
}