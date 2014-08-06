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

namespace SocialIntegration
{   
    [Activity(Label = "Timer Actvity", MainLauncher = false, Icon = "@drawable/icon")]
    public class TimerActivity : Activity
    {
        System.Timers.Timer countDownTimer;
        bool timerStarted = false;
        Button buttonEnd;
        Button buttonStart;
        TextView textView;
        //private sealed long startTime = 30 * 1000;
        //private sealed long interval = 1 * 1000;
        
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.Timer_layout);
                //buttonEnd = FindViewById<Button>(Resource.Id.btn_timer_end);
                //buttonStart = FindViewById<Button>(Resource.Id.btn_timer_pause);
                //textView = FindViewById<TextView>(Resource.Id.tv_timer_countdown);

               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        void buttonEnd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}