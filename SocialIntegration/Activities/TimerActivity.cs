using System;
using System.Timers;
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

namespace SocialIntegration
{
    [Activity(Label = "Timer Actvity", MainLauncher = false, Icon = "@drawable/icon")]
    public class TimerActivity : Activity
    {
        Button Start;
        Button Stop;
        Button Restart;
        TextView tv_timer_workout;
        TextView tv_timer_exercise;
        TextView tv_timer_exercise_description;
        TextView tv_timer_exercise_next;
        ImageView iv_timer;
        ImageView iv_timer_large;
        private System.Timers.Timer timerWorkout;
        private System.Timers.Timer timerExercise;
        private int totalSecondsWorkout;
        private int totalSecondsExercise;
        private int countSecondsWorkout;
        private int countSecondsExercise;
        private int countMinutesWorkout;
        private int countMinutesExercise;
        List<Exercise> exercisesToExecute = null;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.Timer_layout);

                exercisesToExecute = MyApplication.Exercises.Take(2).ToList();
                //workout timer
                tv_timer_workout = FindViewById<TextView>(Resource.Id.tv_timerActivity_timer);
                timerWorkout = new System.Timers.Timer();
                timerWorkout.Interval = 1000;
                timerWorkout.Elapsed += OnTimedEventWorkout;
                totalSecondsWorkout = ComputeTotalTime();
                timerWorkout.Enabled = false;

                //exercise timer
                tv_timer_exercise = FindViewById<TextView>(Resource.Id.tv_timerActivity_timer_large);
                timerExercise = new System.Timers.Timer();
                timerExercise.Interval = 1000;
                timerExercise.Elapsed += OnTimedEventExercise;
                timerExercise.Enabled = false;

                tv_timer_exercise_description = FindViewById<TextView>(Resource.Id.tv_timerActivity_text_row_2);
                tv_timer_exercise_next = FindViewById<TextView>(Resource.Id.tv_timerActivity_description_row_3);

                //Defining buttons
                Start = FindViewById<Button>(Resource.Id.btn_timerActivity_1);
                Stop = FindViewById<Button>(Resource.Id.btn_timerActivity_2);
                Restart = FindViewById<Button>(Resource.Id.btn_timerActivity_3);

                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "digital-7 (mono).ttf");

                //Change TextView font
                tv_timer_workout.SetTypeface(font, TypefaceStyle.Normal);
                tv_timer_exercise.SetTypeface(font, TypefaceStyle.Normal);

                //Load large image from database
                iv_timer_large = FindViewById<ImageView>(Resource.Id.iv_timerActivity_image_row_2);


                //Load small image from database
                iv_timer = FindViewById<ImageView>(Resource.Id.iv_timerActivity_image_row_3);


                Start.Click += delegate
                {
                    //start workout timer
                    timerWorkout.Enabled = true;
                    timerWorkout.Start();

                    //start exercise timer
                    timerExercise.Enabled = true;
                    timerExercise.Start();
                };

                Stop.Click += delegate
                {
                    //stop workout timer
                    timerWorkout.Stop();
                    timerWorkout.Enabled = false;

                    //stop exercise timer
                    timerExercise.Stop();
                    timerExercise.Enabled = false;
                };

                Restart.Click += delegate
                {
                    timerWorkout.Enabled = true;
                    timerExercise.Enabled = true;

                    RunOnUiThread(() =>
                    {
                        totalSecondsWorkout = 200;
                        totalSecondsExercise = 100;

                        countSecondsWorkout = totalSecondsWorkout % 60;
                        countSecondsExercise = totalSecondsExercise % 60;

                        countMinutesWorkout = totalSecondsWorkout / 60;
                        countMinutesExercise = totalSecondsExercise / 60;

                        string secondsWorkout = countSecondsWorkout.ToString();
                        string secondsExercise = countSecondsExercise.ToString();

                        string minutesWorkout = countMinutesWorkout.ToString();
                        string minutesExercise = countMinutesExercise.ToString();

                        //tv_timer_workout conditionals
                        if ((countMinutesWorkout < 10) && (countSecondsWorkout < 10))
                        {
                            tv_timer_workout.Text = string.Format("0{0}:0{1}", minutesWorkout, secondsWorkout);
                        }
                        else if ((countMinutesWorkout < 10) && (countSecondsWorkout >= 10))
                        {
                            tv_timer_workout.Text = string.Format("0{0}:{1}", minutesWorkout, secondsWorkout);
                        }
                        else if ((countMinutesWorkout >= 10) && (countSecondsWorkout < 10))
                        {
                            tv_timer_workout.Text = string.Format("{0}:0{1}", minutesWorkout, secondsWorkout);
                        }
                        else
                        {
                            tv_timer_workout.Text = string.Format("{0}:{1}", minutesWorkout, secondsWorkout);
                        }

                        //tv_timer_exercise conditionals
                        if ((countMinutesExercise < 10) && (countSecondsExercise < 10))
                        {
                            tv_timer_exercise.Text = string.Format("0{0}:0{1}", minutesExercise, secondsExercise);
                        }
                        else if ((countMinutesExercise < 10) && (countSecondsExercise >= 10))
                        {
                            tv_timer_exercise.Text = string.Format("0{0}:{1}", minutesExercise, secondsExercise);
                        }
                        else if ((countMinutesExercise >= 10) && (countSecondsExercise < 10))
                        {
                            tv_timer_exercise.Text = string.Format("0{0}:{1}", minutesExercise, secondsExercise);
                        }
                        else
                        {
                            tv_timer_exercise.Text = string.Format("0{0}:{1}", minutesExercise, secondsExercise);
                        }
                    }
                    );
                    timerWorkout.Start();
                    timerExercise.Start();

                    timerWorkout.Stop();
                    timerExercise.Stop();

                    timerWorkout.Enabled = false;
                    timerExercise.Enabled = false;
                };

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            timerWorkout.Start();
            UpdateExercisesInUI(false);

        }

        private void UpdateExercisesInUI(bool removeFirstElement)
        {
            try
            {
                if (MyApplication.Exercises != null)
                {
                    if (removeFirstElement == true)
                    {
                        if (MyApplication.Exercises.Count > 0)
                        {
                            MyApplication.Exercises.RemoveAt(0);
                        }
                    }

                    if (MyApplication.Exercises.Count > 0)
                    {
                        iv_timer_large.SetImageResource(MyApplication.GetImageIdFromName(MyApplication.Exercises[0].Picture, this));
                        tv_timer_exercise_description.Text = MyApplication.Exercises[0].Name;

                        if (MyApplication.Exercises.Count > 1)
                        {
                            iv_timer.SetImageResource(MyApplication.GetImageIdFromName(MyApplication.Exercises[1].Picture, this));
                            tv_timer_exercise_next.Text = String.Format("Next: {0}", MyApplication.Exercises[1].Name);
                        }
                        else
                        {
                            tv_timer_exercise_next.Text = "Done. Go take a shower!";
                        }
                        totalSecondsExercise = MyApplication.Exercises[0].Duration;
                        timerExercise.Start();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
        }

        private int ComputeTotalTime()
        {
            if (MyApplication.Exercises != null)
            {
                return MyApplication.Exercises.Sum(ex => ex.Duration);
            }
            return 0;
        }

        private void OnTimedEventWorkout(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                totalSecondsWorkout--;

                RunOnUiThread(() =>
                {
                    countSecondsWorkout = totalSecondsWorkout % 60;
                    countMinutesWorkout = totalSecondsWorkout / 60;

                    string secondsWorkout = countSecondsWorkout.ToString();
                    string minutesWorkout = countMinutesWorkout.ToString();

                    //tv_timer_workout conditionals
                    if ((countMinutesWorkout < 10) && (countSecondsWorkout < 10))
                    {
                        tv_timer_workout.Text = string.Format("0{0}:0{1}", minutesWorkout, secondsWorkout);
                    }
                    else if ((countMinutesWorkout < 10) && (countSecondsWorkout >= 10))
                    {
                        tv_timer_workout.Text = string.Format("0{0}:{1}", minutesWorkout, secondsWorkout);
                    }
                    else if ((countMinutesWorkout >= 10) && (countSecondsWorkout < 10))
                    {
                        tv_timer_workout.Text = string.Format("{0}:0{1}", minutesWorkout, secondsWorkout);
                    }
                    else
                    {
                        tv_timer_workout.Text = string.Format("{0}:{1}", minutesWorkout, secondsWorkout);
                    }

                    if (totalSecondsWorkout == 0)
                    {
                        timerWorkout.Stop();
                        timerWorkout.Enabled = false;
                        totalSecondsWorkout = 200;
                    }

                });
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void OnTimedEventExercise(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                totalSecondsExercise--;

                RunOnUiThread(() =>
                {
                    countSecondsExercise = totalSecondsExercise % 60;
                    countMinutesExercise = totalSecondsExercise / 60;

                    string secondsExercise = countSecondsExercise.ToString();
                    string minutesExercise = countMinutesExercise.ToString();

                    //tv_timer_exercise conditionals
                    if ((countMinutesExercise < 10) && (countSecondsExercise < 10))
                    {
                        tv_timer_exercise.Text = string.Format("0{0}:0{1}", minutesExercise, secondsExercise);
                    }
                    else if ((countMinutesExercise < 10) && (countSecondsExercise >= 10))
                    {
                        tv_timer_exercise.Text = string.Format("0{0}:{1}", minutesExercise, secondsExercise);
                    }
                    else if ((countMinutesExercise >= 10) && (countSecondsExercise < 10))
                    {
                        tv_timer_exercise.Text = string.Format("0{0}:{1}", minutesExercise, secondsExercise);
                    }
                    else
                    {
                        tv_timer_exercise.Text = string.Format("0{0}:{1}", minutesExercise, secondsExercise);
                    }

                    if (totalSecondsExercise == 0)
                    {
                        timerExercise.Stop();
                        timerExercise.Enabled = false;
                        UpdateExercisesInUI(true);
                    }

                });
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


    }
}