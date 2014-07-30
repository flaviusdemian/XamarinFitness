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
    public class FragmentGoalSelection : SherlockFragment
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
                rootView = inflater.Inflate(Resource.Layout.GoalSelection, container, false);
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
                Button btn_GetLean = rootView.FindViewById<Button>(Resource.Id.GetLean);
                Button btn_GetToned = rootView.FindViewById<Button>(Resource.Id.GetToned);
                Button btn_ImpromptuWorkout = rootView.FindViewById<Button>(Resource.Id.ImpromptuWorkout);

                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "RobotoCondensed-Regular.ttf");
                btn_GetLean.SetTypeface(font, TypefaceStyle.Normal);
                btn_GetToned.SetTypeface(font, TypefaceStyle.Normal);
                btn_ImpromptuWorkout.SetTypeface(font, TypefaceStyle.Normal);

                btn_GetLean.Click += delegate
                {
                    SherlockActivity.StartActivity(typeof(DifficultySelection));
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
