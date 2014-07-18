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

namespace SocialIntegration
{
    [Activity(Label = "Equipment Selection", MainLauncher = false, Icon = "@drawable/icon")]
    public class EquipmentSelection : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                RequestWindowFeature(WindowFeatures.NoTitle);

                SetContentView(Resource.Layout.EquipmentSelection);
                Button btn_Equip = FindViewById<Button>(Resource.Id.Equip);
                Button btn_wEquip = FindViewById<Button>(Resource.Id.wEquip);

                btn_Equip.Click += delegate
                {
                    StartActivity(typeof(WorkoutScreen));
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
    }
}