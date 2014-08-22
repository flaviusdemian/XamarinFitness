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
    public class ExerciseDescription : Activity, GestureDetector.IOnGestureListener
    {
        ViewFlipper viewFlipper;
        Button buttonPrev, buttonNext;
        private Exercise currentExercise = null;
        private GestureDetector _gestureDetector;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.ExerciseDescription_layout);

                initializeUIElements(Intent.GetIntExtra(Constants.SelectedExercise, -1));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task initializeUIElements(int selectedExercise)
        {
            try
            {
                viewFlipper = FindViewById<ViewFlipper>(Resource.Id.vf_activity_exerciseDescription_viewFlipper);
                buttonPrev = FindViewById<Button>(Resource.Id.btn_activity_exerciseDescription_prev);
                buttonNext = FindViewById<Button>(Resource.Id.btn_activity_exerciseDescription_next);

                buttonPrev.Click += delegate
                {
                    viewFlipper.SetInAnimation(this, Resource.Animation.slide_in_left);
                    viewFlipper.SetOutAnimation(this, Resource.Animation.slide_out_right);
                    viewFlipper.ShowPrevious();
                };

                buttonNext.Click += delegate
                {
                    viewFlipper.SetInAnimation(this, Resource.Animation.slide_in_right);
                    viewFlipper.SetInAnimation(this, Resource.Animation.slide_out_left);
                    viewFlipper.ShowNext();
                };

                var tv_ExName = FindViewById<TextView>(Resource.Id.btn_workout);
                //tv_ExName.SetText(currentExercise.Name);

                currentExercise = await GetSelectedExercise(selectedExercise);

                List<ExerciseStep> steps = await GetSelectedExerciseSteps();
                //var step1 = new ExerciseStep()
                //{
                //    Description = "Ana are mere si pere",
                //    Picture = "burpees_1"
                //};
                //steps.Add(step1);

                //var step2 = new ExerciseStep()
                //{
                //    Description = "Dana are mere si pere",
                //    Picture = "burpees_2"
                //};
                //steps.Add(step2);

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
                SetUpGesture();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task<List<ExerciseStep>> GetSelectedExerciseSteps()
        {
            List<ExerciseStep> steps = null;
            try
            {
                steps = await MyApplication.sqLConnection.Table<ExerciseStep>().Where(st => st.ExerciseID == currentExercise.ID).ToListAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return steps;
        }

        private void SetUpGesture()
        {
            try
            {
                _gestureDetector = new GestureDetector(this);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            float sensitvity = 50;
            if ((e1.RawX - e2.RawX) > sensitvity)
            {
                viewFlipper.ShowNext();
            }
            else if ((e2.RawX - e1.RawX) > sensitvity)
            {
                viewFlipper.ShowPrevious();
            }
            return true;
        }

        public bool OnDown(MotionEvent e)
        {
            return false;
        }
        public void OnShowPress(MotionEvent e)
        {
        }
        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }

        public void OnLongPress(MotionEvent e)
        {
        }
        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            _gestureDetector.OnTouchEvent(e);
            return false;
        }

        private async Task<Exercise> GetSelectedExercise(int selectedExerciseId)
        {
            try
            {
                var result = MyApplication.sqLConnection.Table<Exercise>().Where(ex => ex.ID == selectedExerciseId).FirstOrDefaultAsync().Result;
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