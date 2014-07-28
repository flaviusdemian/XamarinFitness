using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using SocialIntegration.Models;
using Exception = System.Exception;
using Object = Java.Lang.Object;
using String = System.String;

namespace SocialIntegration.Adapters
{
    public class SettingsAdapter : BaseExpandableListAdapter
    {
        private Context Context;
        private List<Section> DataSource;
        private Section CurrentItem;
        private int Row;
        private LayoutInflater Inflater;

        public SettingsAdapter(Context context, int resource, List<Section> arrayList)
        {
            this.Context = context;
            this.Row = resource;
            this.DataSource = arrayList;
            Inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override Object GetChild(int groupPosition, int childPosition)
        {
            return DataSource[groupPosition].SectionItems[childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return DataSource[groupPosition].SectionItems[childPosition].Id;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return DataSource[groupPosition].SectionItems.Count;
        }

        public override Object GetGroup(int groupPosition)
        {
            return DataSource[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override int GroupCount
        {
            get { return DataSource.Count; }
        }

        public override bool HasStableIds
        {
            get { return true; }
        }
        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = Inflater.Inflate(Resource.Layout.activity_settings_section_item, parent, false);
            }
            try
            {
                SectionItem oSectionItem = DataSource[groupPosition].SectionItems[childPosition];

                TextView textView = convertView.FindViewById<TextView>(Resource.Id.settings_sectionitem_label);
                textView.Text = oSectionItem.Title;

                ImageView itemIcon = convertView.FindViewById<ImageView>(Resource.Id.settings_sectionitem_icon);
                itemIcon.SetImageDrawable(GetDrawableByName(oSectionItem.Icon, Context));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return convertView;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            try
            {
                if (convertView == null)
                {
                    convertView = Inflater.Inflate(Resource.Layout.activity_settings_section_view, parent, false);
                }

                TextView textView = convertView.FindViewById<TextView>(Resource.Id.settings_section_title);
                if (textView != null)
                {
                    textView.Text = ((Section)GetGroup(groupPosition)).Title;
                }
                return convertView;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return convertView;
        }

        public static Drawable GetDrawableByName(String name, Context context)
        {
            try
            {
                int drawableResource = context.Resources.GetIdentifier(name, "drawable", context.PackageName);
                if (drawableResource == 0)
                {
                    throw new RuntimeException("Can't find drawable with name: " + name);
                }
                return context.Resources.GetDrawable(drawableResource);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }

    }
}

