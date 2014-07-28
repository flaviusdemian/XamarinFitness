using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SocialIntegration.Application;
using SocialIntegration.Models;

namespace SocialIntegration.Helper
{
    class MenuHelper
    {
        public static List<Section> CreateMenu(Context context)
        {
            List<Section> sectionList = new List<Section>();

            Section oDemoSection = new Section(context.Resources.GetString(Resource.String.SETTINGS_PROFILE));
            oDemoSection.AddSectionItem(101, context.Resources.GetString(Resource.String.SETTINGS_EDIT_PROFILE), "linkedtranslators_settingsicon");
            oDemoSection.AddSectionItem(102, context.Resources.GetString(Resource.String.SETTINGS_VIDEO_CALL), "linkedtranslators_videocallicon");
            oDemoSection.AddSectionItem(103, context.Resources.GetString(Resource.String.SETTINGS_FRIENDS), "linkedtranslators_friendsicon");
            oDemoSection.AddSectionItem(104, context.Resources.GetString(Resource.String.SETTINGS_COMMUNITY), "linkedtranslators_communityicon");

            Section oHelpSection = new Section(context.Resources.GetString(Resource.String.SETTINGS_HELP));
            oHelpSection.AddSectionItem(201, context.Resources.GetString(Resource.String.SETTINGS_HOW_TO_USE), "linkedtranslators_helpicon");
            oHelpSection.AddSectionItem(202, context.Resources.GetString(Resource.String.SETTINGS_RATE_THIS_APP), "linkedtranslators_ratethisappicon");
            oHelpSection.AddSectionItem(203, context.Resources.GetString(Resource.String.SETTINGS_DONATE), "linkedtranslators_paypalicon");
            oHelpSection.AddSectionItem(204, context.Resources.GetString(Resource.String.SETTINGS_ABOUT), "linkedtranslators_abouticon");

            Section oGeneralSection = new Section(context.Resources.GetString(Resource.String.SETTINGS_SETTINGS));
            oGeneralSection.AddSectionItem(301, context.Resources.GetString(Resource.String.SETTINGS_ACCOUNT_SETTINGS), "linkedtranslators_settingsicon");
            oGeneralSection.AddSectionItem(302, context.Resources.GetString(Resource.String.SETTINGS_TERMS_AND_CONDITIONS), "linkedtranslators_termsandconditionsicon");
            oGeneralSection.AddSectionItem(303, context.Resources.GetString(Resource.String.SETTINGS_REPORT_A_PROBLEM), "linkedtranslators_reportaproblemicon");
            oGeneralSection.AddSectionItem(304, context.Resources.GetString(Resource.String.SETTINGS_LOGOUT), "linkedtranslators_logouticon");

            sectionList.Add(oDemoSection);
            sectionList.Add(oHelpSection);
            sectionList.Add(oGeneralSection);
            return sectionList;
        }
    }
}