﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;

namespace L05
{
    [Activity(Label = "L05", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //lab:先在Componets加入Json.net

        protected override void OnCreate(Bundle bundle)
        {
     

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            string api = "http://testmyapi.azurewebsites.net/api/values/";
            var txtAge = this.FindViewById<EditText>(Resource.Id.txtAge);
            var txtName = this.FindViewById<EditText>(Resource.Id.txtName);
            var txtWork = this.FindViewById<EditText>(Resource.Id.txtWork);
            var textView = this.FindViewById<TextView>(Resource.Id.textView);
            this.FindViewById<Button>(Resource.Id.MyButton).Click +=  (sender, e) =>
            {

                //lab:使用 WebClient的DownloadString取得WebAPI上的Json字串


                //lab:將取得的Json顯示於Resource.Id.textView


                //lab:使用 Newtonsoft.Json.JsonConvert的DeserializeObject<T>將字串反序列化回物件

                //lab:把物件的值給予三個對應的TextView


            };
        }
    }



    //lab:由http://json2csharp.com/產生的類別
    public class MyClass
    {

    }

    //有興趣可另外自己做以下連結
    //http://graph.facebook.com/stevenzhang
}
