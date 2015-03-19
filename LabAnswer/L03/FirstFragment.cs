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

            //lab:���o��Activity�ǨӪ��ѼƳ]�w��textView�W
            textView.Text = Value ?? "FirstActivity";


            view.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                //lab:�������SecondFragment�A�ñN�ثe��Fragment��AddToBackStack��k�[�JFragment���|
                //�i�A�[�WSetTransition�]�w�������ʵe�ĪG
                FragmentManager.BeginTransaction()
                    .AddToBackStack(null)
                    .SetTransition(FragmentTransit.FragmentOpen)
                    .Replace(Resource.Id.frameLayout, new SecondFragment())
                    .Commit();
            };
            return view;
        }
    }
}