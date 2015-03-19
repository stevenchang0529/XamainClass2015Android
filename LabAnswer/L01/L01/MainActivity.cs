using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content.PM;

namespace L01
{
    //MainLauncher為指定主要進入點的activity
    [Activity(Label = "L01", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
          
            button.Click += delegate { 
                button.Text = string.Format("{0} clicks!", count++);
                string value = null;

                //lab:由自動的Application類別MyApp取得屬性Value
                MyApp app = this.Application as MyApp;
                value = app.Value;

                Toast.MakeText(this, value, ToastLength.Short).Show();

                //開啟此行可觀察OnDestroy() this.Finish();
            };

            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnCreate========");



        }



        protected override void OnStart()
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnStart========");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnResume========");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnPause========");
            base.OnPause();
        }

        protected override void OnRestart()
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnRestart========");
            base.OnRestart();
        }

        protected override void OnStop()
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnStop========");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnDestroy========");
            base.OnDestroy();
        }

    }
}

