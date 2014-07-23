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
    class MyApplication : Android.App.Application
    {
        private static String dbPath;
        private static SQLiteAsyncConnection sqLConnection;
        //private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            InitializeDB();
            // do application specific things here
        }

        private async Task InitializeDB()
        {
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Constants.DB_NAME);
            sqLConnection = new SQLiteAsyncConnection(dbPath, true);


            var prefs = Android.App.Application.Context.GetSharedPreferences(Constants.APP_NAME, FileCreationMode.Private);
            var dbIsInitialized = prefs.GetBoolean(Constants.DB_INIT_KEY, false);
            //get key value for dbinit 
            if (dbIsInitialized == false)
            {
                //insert the db for the first time
                try
                {
                    await PopulateDB();
                    //var prefEditor = prefs.Edit();
                    //prefEditor.PutBoolean(Constants.DB_INIT_KEY, true);
                    //prefEditor.Commit();
                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();
                }
            }
        }

        private async Task PopulateDB()
        {
            try
            {
                CreateTablesResult result = await sqLConnection.CreateTableAsync<Difficulty>();
                result = await sqLConnection.CreateTableAsync<Duration>();
                //Duration duration = new Duration() { ID = 1, Value = 15 };
                //int count = await sqLConnection.InsertAsync(duration);

                //Duration duration2 = new Duration() { ID = 2, Value = 45 };
                //count = await sqLConnection.InsertAsync(duration2);

                var list = await sqLConnection.Table<Duration>().ToListAsync();
                
                result = await sqLConnection.CreateTableAsync<Equipment>();
                result = await sqLConnection.CreateTableAsync<Exercises>();
                result = await sqLConnection.CreateTableAsync<Goal>();
                result = await sqLConnection.CreateTableAsync<Workout>();
                result = await sqLConnection.CreateTableAsync<WorkoutExerciseAssociations>();
                int x = 0;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //public async Task ReadWords()
        //{
        //    //try
        //    //{
        //    //    List<Word> words = await sqLConnection.Table<Word>().ToListAsync();
        //    //    int x = 0;
        //    //}
        //    //catch (System.Exception ex)
        //    //{
        //    //    ex.ToString();
        //    //}
        //}
    }
}