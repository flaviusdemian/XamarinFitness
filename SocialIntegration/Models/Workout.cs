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

namespace SocialIntegration.Models
{
    class Workout
    {
        public int ID { get; set; }
        public int Goal { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public int Equipment { get; set; }
    }
}