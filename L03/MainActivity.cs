using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace L03_Navigation
{
    [Activity(Label = "L03_Navigation", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

         
            this.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                //lab:StartActivity啟動FirstActivity
                
            };

            this.FindViewById<Button>(Resource.Id.button2).Click += (sender, e) =>
            {
                //lab:使用Intent啟動FirstActivity並用PutExtra傳參數
            };

            this.FindViewById<Button>(Resource.Id.button3).Click += (sender, e) =>
            {
                //lab:使用Intent啟動FirstActivity並設置flag=ActivityFlags.NoHistory
            };

            this.FindViewById<Button>(Resource.Id.button4).Click += (sender, e) =>
            {
                //lab:使用StartActivityForResult啟動ResultActivity

            };

            this.FindViewById<Button>(Resource.Id.btnFragment).Click += (sender, e) =>
            {
                //lab:使用FragmentManager將Resource.Id.frameLayout換為FirstFragment  
            };
        }

        //lab:取得下一個Activity回傳的結果  override  OnActivityResult
    }
}

