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
using Android.Graphics.Drawables;
using SocialIntegration.Application;

namespace SocialIntegration.Adapters
{
    public class ExerciseAdapter : ArrayAdapter<Exercise>
    {
        private Context context;
        private List<Exercise> dataSource, oldDataSource;
        private Exercise currentItem;
        private int row;


        public ExerciseAdapter(Context context, int resource, List<Exercise> arrayList)
            : base(context, resource, arrayList)
        {
            this.context = context;
            this.row = resource;
            this.dataSource = this.oldDataSource = arrayList;
        }

        public List<Exercise> getDataSource()
        {
            return dataSource;
        }
        public void setDataSource(List<Exercise> dataSource)
        {
            this.dataSource = dataSource;
        }

        public void updateDataSource(List<Exercise> dataSource)
        {
            this.dataSource = this.oldDataSource = dataSource;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View view = convertView;
            ExerciseViewHolder holder;
            if (view == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                view = inflater.Inflate(row, null);

                holder = new ExerciseViewHolder();
                view.Tag = holder;
            }
            else
            {
                holder = (ExerciseViewHolder)view.Tag;
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
                        holder.RbRating.Rating = currentItem.Rating;
                    }

                    if (holder.TvName != null)
                    {
                        holder.TvName.Text = currentItem.Name;
                    }

                    if (holder.TvDifficulty != null)
                    {
                        holder.TvDifficulty.Text = currentItem.Difficulty;
                    }

                    if (holder.TvDuration != null)
                    {
                        holder.TvDuration.Text = currentItem.Duration;
                    }
                    if (holder.IvPicture != null)
                    {
                        holder.IvPicture.SetImageResource(MyApplication.GetImageIdFromName(currentItem.Picture, context));
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