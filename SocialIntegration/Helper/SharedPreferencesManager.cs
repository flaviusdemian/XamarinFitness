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

namespace SocialIntegration.Helper
{
    public class SharedPreferencesManager
    {
        public static void SaveSet(string key, string value)
        {
            //store
            var prefs = Android.App.Application.Context.GetSharedPreferences(Constants.APP_NAME, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();
        }

        public static void SaveSet(string key, bool value)
        {
            //store
            var prefs = Android.App.Application.Context.GetSharedPreferences(Constants.APP_NAME, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutBoolean(key, value);
            prefEditor.Commit();
        }

        public static string RetrieveStringSet(string key)
        {
            //retreive 
            var prefs = Android.App.Application.Context.GetSharedPreferences(Constants.APP_NAME, FileCreationMode.Private);
            return prefs.GetString(key, null);
        }

        public static bool RetrieveBooleanSet(string key)
        {
            //retreive 
            var prefs = Android.App.Application.Context.GetSharedPreferences(Constants.APP_NAME, FileCreationMode.Private);
            return prefs.GetBoolean(key, false);
        }
    }
}