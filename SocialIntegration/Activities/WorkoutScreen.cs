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
using SocialIntegration.Application;
using SocialIntegration.Models;
using System.Threading.Tasks;

namespace SocialIntegration
{
    [Activity(Label = "Workout Screen", MainLauncher = false, Icon = "@drawable/icon")]
    public class WorkoutScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.WorkoutScreen);
                Button DoWorkout = FindViewById<Button>(Resource.Id.button1);


                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Roboto-Regular.ttf");

                //Change button font
                DoWorkout.SetTypeface(font, TypefaceStyle.Normal);

                LoadExercises();

            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        private async Task LoadExercises()
        {
            try
            {
                var associations = await MyApplication.sqLConnection.Table<WorkoutExerciseAssociations>().ToListAsync();
                //associations = associations.Where(assoc => assoc.WorkoutID == 1).ToList();
                if (associations != null)
                {
                    List<Exercises> exercises = new List<Exercises>();
                    foreach (var association in associations)
                    {
                        var returnedExercises = await MyApplication.sqLConnection.Table<Exercises>().Where(ex => ex.ID == association.ExerciseID).ToListAsync();
                        foreach(var ex in returnedExercises)
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
        }
    }
}