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

            //lab:眔パActivity肚ㄓ把计砞﹚textView
            textView.Text = Value ?? "FirstActivity";


            view.FindViewById<Button>(Resource.Id.button1).Click += (sender, e) =>
            {
                //lab:ち传SecondFragment盢ヘ玡FragmentノAddToBackStackよ猭Fragment帮舼
                //SetTransition砞﹚ち传笆礶狦
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