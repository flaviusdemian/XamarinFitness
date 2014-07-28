using System;
using System.Collections.Generic;
using Java.Lang;
using String = System.String;

namespace SocialIntegration.Models
{
    public class Section : Java.Lang.Object
    {
        public List<SectionItem> SectionItems = new List<SectionItem>();
        public String Title { get; set; }

        public Section(string title)
        {
            Title = title;
        }

        public void AddSectionItem(long id, String title, String icon)
        {
            SectionItems.Add(new SectionItem(id, title, icon));
        }
    }
}