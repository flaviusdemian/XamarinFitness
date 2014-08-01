using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.ActionbarSherlockBinding.App;
using SocialIntegration.Adapters;
using SocialIntegration.Models;

namespace SocialIntegration.Fragments
{
    public class FragmentExerciseWorkout : SherlockFragment
    {
        private ListView lv_searchResults;
        private View rootView;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            rootView = null;
            try
            {
                rootView = inflater.Inflate(Resource.Layout.WorkoutScreen, container, false);
                initializeUIElements();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return rootView;
        }

        private void initializeUIElements()
        {
            try
            {
                Exercises ex = new Exercises();
                Exercises ex1 = new Exercises();
                List<Exercises> items = new List<Exercises>();
                items.Add(ex1);
                items.Add(ex);
                ExercisesAdapter adapter = new ExercisesAdapter(SherlockActivity, Resource.Layout.Exercise_layout_row, items);
                lv_searchResults = rootView.FindViewById<ListView>(Resource.Id.lv_exercise_layout);
                if (adapter != null && lv_searchResults != null)
                {
                    lv_searchResults.Adapter = adapter;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}