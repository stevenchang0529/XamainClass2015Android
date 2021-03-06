using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace L03_Navigation
{
    public class FirstFragment : Fragment
    {
        public string Value { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view=inflater.Inflate(Resource.Layout.First, null);
            var textView = view.FindViewById<TextView>(Resource.Id.textView);

            //lab:取得由Activity傳來的參數設定到textView上



            view.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                //lab:切換到到SecondFragment，並將目前的Fragment用AddToBackStack方法加入Fragment堆疊
                //可再加上SetTransition設定切換的動畫效果
            };
            return view;
        }
    }
}