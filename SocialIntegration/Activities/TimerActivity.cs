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

namespace SocialIntegration
{
    [Activity(Label = "Timer Actvity", MainLauncher = false, Icon = "@drawable/icon")]
    public class TimerActivity : Activity
    {
        Button Start;
        Button Stop;
        Button Restart;
        TextView tv_timer;
        private System.Timers.Timer timer;
        private int totalSeconds;
        private int countSeconds;
        private int countMinutes;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.Timer_layout);

                tv_timer = FindViewById<TextView>(Resource.Id.tv_timerActivity_timer);
                timer = new System.Timers.Timer();
                timer.Interval = 1000;
                timer.Elapsed += OnTimedEvent;
                totalSeconds = 100;
                timer.Enabled = false;

                Start = FindViewById<Button>(Resource.Id.btn_timerActivity_1);
                Stop = FindViewById<Button>(Resource.Id.btn_timerActivity_2);
                Restart = FindViewById<Button>(Resource.Id.btn_timerActivity_3);

                //Use custom font 
                Typeface font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "digital-7 (mono).ttf");

                //Change TextView font
                tv_timer.SetTypeface(font, TypefaceStyle.Normal);

                Start.Click += delegate
                {
                    timer.Enabled = true;
                    timer.Start();

                };

                Stop.Click += delegate
                {
                    timer.Stop();
                    timer.Enabled = false;
                };

                Restart.Click += delegate
                {
                    timer.Enabled = true;
                    RunOnUiThread(() =>
                    {
                        totalSeconds = 100;
                        countSeconds = totalSeconds % 60;
                        countMinutes = totalSeconds / 60;
                        string seconds = countSeconds.ToString();
                        string minutes = countMinutes.ToString();

                        if ((countMinutes < 10) && (countSeconds < 10))
                        {
                            tv_timer.Text = string.Format("0{0}:0{1}", minutes, seconds);
                        }
                        else if ((countMinutes < 10) && (countSeconds >= 10))
                        {
                            tv_timer.Text = string.Format("0{0}:{1}", minutes, seconds);
                        }
                        else if ((countMinutes >= 10) && (countSeconds < 10))
                        {
                            tv_timer.Text = string.Format("{0}:0{1}", minutes, seconds);
                        }
                        else
                        {
                            tv_timer.Text = string.Format("{0}:{1}", minutes, seconds);
                        }
                    }
                    );
                    timer.Start();
                    timer.Stop();
                    timer.Enabled = false;
                };

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                totalSeconds--;

                RunOnUiThread(() =>
                {
                    countSeconds = totalSeconds % 60;
                    countMinutes = totalSeconds / 60;
                    string seconds = countSeconds.ToString();
                    string minutes = countMinutes.ToString();
                  
                    if ((countMinutes < 10) && (countSeconds < 10))
                    {
                        tv_timer.Text = string.Format("0{0}:0{1}", minutes, seconds);
                    }
                    else if ((countMinutes < 10) && (countSeconds >= 10))
                    {
                        tv_timer.Text = string.Format("0{0}:{1}", minutes, seconds);
                    }
                    else if ((countMinutes >= 10) && (countSeconds < 10))
                    {
                        tv_timer.Text = string.Format("{0}:0{1}", minutes, seconds);
                    }
                    else
                    {
                        tv_timer.Text = string.Format("{0}:{1}", minutes, seconds);
                    }
                    
                    if (totalSeconds == 0)
                    {
                        timer.Stop();
                        timer.Enabled = false;
                        totalSeconds = 100;
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