using System;

namespace SocialIntegration.Models
{
    public class SectionItem : Java.Lang.Object
    {
        public SectionItem(long id, String title, String icon)
        {
            Id = id;
            Title = title;
            Icon = icon;
        }

        public long Id { get; set; }
        public String Title { get; set; }
        public String Icon { get; set; }
    }
}