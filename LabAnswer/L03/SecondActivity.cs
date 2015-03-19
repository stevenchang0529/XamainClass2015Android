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

namespace L03_Navigation
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Second);
            var textView = FindViewById<TextView>(Resource.Id.textView);
            textView.Text = "SecondActivity";

            this.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(MainActivity));
                //lab:啟動Main，設置ActivityFlags.ClearTop會重新建立Activity，並清除在其堆疊之下的Activity。
                i.SetFlags(ActivityFlags.ClearTop);

                //lab:啟動Main，設置ActivityFlags.ClearTop與ActivityFlags.SingleTop，會在堆疊中尋找MainActivity並執行於堆疊的TOP，並清除其堆疊之下的Activity。
               // i.SetFlags(ActivityFlags.ClearTop| ActivityFlags.SingleTop);
                this.StartActivity(i);
            };
        }
    }
}