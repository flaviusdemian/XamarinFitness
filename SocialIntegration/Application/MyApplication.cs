using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.Threading.Tasks;
using System.IO;
using SocialIntegration.Models;


namespace SocialIntegration.Application
{
    [Application(Debuggable = true)]
    //, ManageSpaceActivity = typeof(InitialScreenActivity))]
    public class MyApplication : Android.App.Application
    {
        private static String dbName = "db";
        private static String dbPath;
        public static SQLiteAsyncConnection sqLConnection { get; private set; }
        private string result;
        //private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            try
            {
                base.OnCreate();
                InitializeDB();
                // do application specific things here
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task InitializeDB()
        {
            try
            {
                dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

                //if (!File.Exists(dbPath))
                //{
                using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
                //}
                sqLConnection = new SQLiteAsyncConnection(dbPath, true);
                await ReadDB();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async Task ReadDB()
        {
            try
            {
                var result = await sqLConnection.Table<Exercise>().ToListAsync();
                int x = 0;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public static int GetImageIdFromName(string imageName, Context context)
        {
            try
            {
                int id = context.Resources.GetIdentifier(String.Format("{0}:{1}/{2}", context.PackageName, "drawable", imageName), null, null);
                return id;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return 0;
        }

        public static List<Exercise> Exercises { get; set; }
    }
}