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
using SocialIntegration.Models;
using SocialIntegration.ViewHolder;

namespace SocialIntegration.Adapters
{
    public class ExercisesAdapter : ArrayAdapter<Exercises>
    {
        private Context context;
        private List<Exercises> dataSource, oldDataSource;
        private Exercises currentItem;
        private int row;


        public ExercisesAdapter(Context context, int resource, List<Exercises> arrayList)
            : base(context, resource, arrayList)
        {
            this.context = context;
            this.row = resource;
            this.dataSource = this.oldDataSource = arrayList;
        }

        public List<Exercises> getDataSource()
        {
            return dataSource;
        }
        public void setDataSource(List<Exercises> dataSource)
        {
            this.dataSource = dataSource;
        }

        public void updateDataSource(List<Exercises> dataSource)
        {
            this.dataSource = this.oldDataSource = dataSource;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View view = convertView;
            ExercisesViewHolder holder;
            if (view == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                view = inflater.Inflate(row, null);

                holder = new ExercisesViewHolder();
                view.Tag = holder;
            }
            else
            {
                holder = (ExercisesViewHolder)view.Tag;
            }
            try
            {
                if ((dataSource == null) || ((position + 1) > dataSource.Count))
                    return view;

                currentItem = dataSource[position];
                if (currentItem != null)
                {
                    holder.TvName = view.FindViewById<TextView>(Resource.Id.tv_activity_exercise_layout_row_name);
                    holder.TvDifficulty = view.FindViewById<TextView>(Resource.Id.tv_activity_exercise_layout_row_difficulty);
                    holder.TvDuration = view.FindViewById<TextView>(Resource.Id.tv_activity_exercise_layout_row_duration);
                    holder.RbRating = view.FindViewById<RatingBar>(Resource.Id.rb_activity_exercise_layout_row_ratingbar);
                    holder.IvPicture = view.FindViewById<ImageView>(Resource.Id.iv_activity_exercise_layout_row_picture);


                    if (holder.RbRating != null)
                    {
                        holder.RbRating.Rating = 3;
                    }

                    if (holder.TvName != null)
                    {
                        holder.TvName.Text = "WARM UP";
                    }

                    if (holder.TvDifficulty != null)
                    {
                        holder.TvDifficulty.Text = "MODERATE";
                    }

                    if (holder.TvDuration != null)
                    {
                        holder.TvDuration.Text = "10 Min.";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return view;
        }
        public override int Count
        {
            get
            {
                return dataSource.Count;
            }
        }

    }
}