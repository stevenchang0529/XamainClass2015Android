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
    public class SecondFragment : Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Second, null);
            var textView = view.FindViewById<TextView>(Resource.Id.textView);
            textView.Text = "SecondActivity";

            view.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                //lab:使用PopBackStack將Fragment回上頁
            };
            return view;
        }

     
    }

}