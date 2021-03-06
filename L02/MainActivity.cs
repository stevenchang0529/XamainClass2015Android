﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using Android.Util;
namespace L02_Controls
{
    [Activity(Label = "L02_Controls", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            Log.WriteLine(LogPriority.Info, "lifecycle", "========OnCreate========");
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //取得畫面中的控制項
            var textView=this.FindViewById<TextView>(Resource.Id.textView);
            var editText = this.FindViewById<EditText>(Resource.Id.editText);
            var button = this.FindViewById<Button>(Resource.Id.button);
            var checkBox = this.FindViewById<CheckBox>(Resource.Id.checkBox);
            var radioGroup = this.FindViewById<RadioGroup>(Resource.Id.radioGroup);
            var spinner = this.FindViewById<Spinner>(Resource.Id.spinner);
            var imageView = this.FindViewById<ImageView>(Resource.Id.imageView);
            
            button.Click += (sender, e) =>//按鈕事件
            {
                editText.Text = "按下了BUTTON";
            };

            checkBox.CheckedChange += (sender, e) =>//checkbox事件
            {
                //Visibility為控制項的可見度
                imageView.Visibility = checkBox.Checked ? ViewStates.Visible : ViewStates.Invisible;
            };

            radioGroup.CheckedChange += (sender, e) =>//radioGroup事件
            {
                var index = new int[] { Resource.Id.radioButton1, Resource.Id.radioButton2, Resource.Id.radioButton3 }.ToList();
                //事件參數拿到的是RadioButton的Id，可由ID判斷哪個被選取
                var p = index.IndexOf(e.CheckedId);
                textView.Text = "點選了第" + p + "個";
            };

            //設定下拉選單的資料來源
            spinner.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem,new string[]{"1","2","3"});
            
        }

      


    }
}

