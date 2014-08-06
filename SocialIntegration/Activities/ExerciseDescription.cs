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
using Android.Views.Animations;
using SocialIntegration.Models;
using SocialIntegration.Application;
using System.Threading.Tasks;

namespace SocialIntegration.Activities
{
    [Activity(Label = "Exercise Description", MainLauncher = false, Icon = "@drawable/icon")]
    public class ExerciseDescription : Activity
    {
        ViewFlipper viewFlipper;
        Button buttonPrev, buttonNext;
        ImageView view1, view2, view3;
        private Exercise currentExercise = null;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.ExerciseDescription_layout);



                initializeUIElements(Intent.GetIntExtra("selectedExerise", -1));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task initializeUIElements(int selectedExerise)
        {
            try
            {
                viewFlipper = FindViewById<ViewFlipper>(Resource.Id.vf_activity_exerciseDescription_viewFlipper);
                buttonPrev = FindViewById<Button>(Resource.Id.btn_activity_exerciseDescription_prev);
                buttonNext = FindViewById<Button>(Resource.Id.btn_activity_exerciseDescription_next);

                buttonPrev.Click += delegate
                {
                    viewFlipper.SetInAnimation(this, Android.Resource.Animation.SlideInLeft);
                    viewFlipper.SetOutAnimation(this, Android.Resource.Animation.SlideOutRight);
                    //viewFlipper.DisplayedChild = viewFlipper.IndexOfChild(view2);
                    viewFlipper.ShowPrevious();
                };

                buttonNext.Click += delegate
                {
                    viewFlipper.SetInAnimation(this, Android.Resource.Animation.SlideInLeft);
                    viewFlipper.SetInAnimation(this, Android.Resource.Animation.SlideOutRight);
                    viewFlipper.ShowNext();
                };

                var tv_ExName = FindViewById<TextView>(Resource.Id.btn_workout);
                //tv_ExName.SetText(currentExercise.Name);

                currentExercise = await GetSelectedExercise(selectedExerise);

                List<ExerciseStep> steps = new List<ExerciseStep>();
                var step1 = new ExerciseStep()
                {
                    Description = "Ana are mere si pere",
                    Picture = "burpees_1"
                };
                steps.Add(step1);

                var step2 = new ExerciseStep()
                {
                    Description = "Dana are mere si pere",
                    Picture = "burpees_2"
                };
                steps.Add(step2);

                LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
                foreach (var entry in steps)
                {
                    View view = inflater.Inflate(Resource.Layout.flip_viewer_template, null);
                    viewFlipper.AddView(view);
                    var stepImage = view.FindViewById<ImageView>(Resource.Id.iv_activity_exerciseDescription_picture_1);
                    stepImage.SetImageResource(MyApplication.GetImageIdFromName(entry.Picture, this));
                    var tv_stepDescription = view.FindViewById<TextView>(Resource.Id.tv_activity_exerciseDescription_text);
                    tv_stepDescription.Text = entry.Description;
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task<Exercise> GetSelectedExercise(int selectedExeriseId)
        {
            try
            {
                var result = MyApplication.sqLConnection.Table<Exercise>().Where(ex => ex.ID == selectedExeriseId).FirstOrDefaultAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
    }
}