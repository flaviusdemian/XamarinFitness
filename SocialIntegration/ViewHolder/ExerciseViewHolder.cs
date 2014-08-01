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

namespace SocialIntegration.ViewHolder
{
    public class ExerciseViewHolder : Java.Lang.Object
    {
        public TextView TvName { get; set; }
        public TextView TvDifficulty { get; set; }
        public RatingBar RbRating { get; set; }
        public TextView TvDuration { get; set; }
        public ImageView IvPicture { get; set; }
    }
}