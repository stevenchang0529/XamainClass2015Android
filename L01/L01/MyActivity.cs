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

namespace L01
{
    [Activity(Label = "MyActivity"
     //lab:�N��Activity�]���Ұʪ�Activity
        )]
    public class MyActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //lab:�]�w��Activity��Layout��My.axml
        }
    }
}