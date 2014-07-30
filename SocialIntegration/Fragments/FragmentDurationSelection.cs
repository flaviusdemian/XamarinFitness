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
    public class FragmentDurationSelection : SherlockFragment
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
                rootView = inflater.Inflate(Resource.Layout.DurationSelection, container, false);
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
                Button btn_t15min = rootView.FindViewById<Button>(Resource.Id.t15min);
                Button btn_t30min = rootView.FindViewById<Button>(Resource.Id.t30min);
                Button btn_t45min = rootView.FindViewById<Button>(Resource.Id.t45min);

                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "RobotoCondensed-Regular.ttf");
                btn_t15min.SetTypeface(font, TypefaceStyle.Normal);
                btn_t30min.SetTypeface(font, TypefaceStyle.Normal);
                btn_t45min.SetTypeface(font, TypefaceStyle.Normal);

                btn_t15min.Click += delegate
                {
                    SherlockActivity.StartActivity(typeof(EquipmentSelection));
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}