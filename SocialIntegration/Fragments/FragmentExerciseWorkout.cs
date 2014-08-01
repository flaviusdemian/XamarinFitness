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
using SocialIntegration.Application;
using System.Threading.Tasks;

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

        private async Task initializeUIElements()
        {
            try
            {
                var exercises = await LoadExercises();
                ExerciseAdapter adapter = new ExerciseAdapter(SherlockActivity, Resource.Layout.Exercise_layout_row, exercises);
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

        private async Task<List<Exercise>> LoadExercises()
        {
            List<Exercise> exercises = null;
            try
            {
                var associations = await MyApplication.sqLConnection.Table<WorkoutExerciseAssociations>().ToListAsync();
                //associations = associations.Where(assoc => assoc.WorkoutID == 1).ToList();
                if (associations != null)
                {
                    exercises = new List<Exercise>();
                    foreach (var association in associations)
                    {
                        var returnedExercises = await MyApplication.sqLConnection.Table<Exercise>().Where(ex => ex.ID == association.ExerciseID).ToListAsync();
                        foreach (var ex in returnedExercises)
                        {
                            if (exercises.Contains(ex) == false)
                            {
                                exercises.Add(ex);
                            }
                        }
                    }
                }
                int x = 0;
                x++;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return exercises;
        }
    }
}