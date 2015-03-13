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
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.Result);
            var resultText = this.FindViewById<TextView>(Resource.Id.editText).Text;
            this.FindViewById<Button>(Resource.Id.button).Click += (sender, e) =>
            {
                //lab:將結果放入Intent 使用PutExtra


                //lab:將Intent傳入SetResult並關閉Activity

            };
        }
    }
}