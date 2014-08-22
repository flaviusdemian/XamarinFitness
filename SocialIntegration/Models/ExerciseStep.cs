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
    public class ExerciseStep
    {
        public int ID { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int ExerciseID { get; set; }
    }
}