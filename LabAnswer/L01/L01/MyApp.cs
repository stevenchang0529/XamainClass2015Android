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
using Android.Util;
using System.Threading.Tasks;

namespace L01
{
    [Application]
    public  class MyApp:Application
    {
        public string Value { get; set; }

        public MyApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        { }
        public override void OnCreate()
        {
            Value = "i am from Application's Value";
            base.OnCreate();
        }



    }
}