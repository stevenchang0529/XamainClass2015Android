using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using L04.net.azurewebsites.testmyws;
using System.Threading.Tasks;
namespace L04
{
    [Activity(Label = "L04", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        BasicHttpBinding_IService1 service;
        protected  override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //建立WebService Proxy類別
            service = new BasicHttpBinding_IService1();
            var text=this.FindViewById<TextView>(Resource.Id.textView);
            this.FindViewById<Button>(Resource.Id.button).Click += (sender, e) =>
            {
                //lab:使用同步方式，會造成UI執行序卡住




                //lab:使用非同步方式(EAP)



                //lab:使用TAP方式

                //lab:將取得結果設定到text


            };
        }

        //lab:轉換成TAP方式
        private Task<string> GetData(int value)
        {
            return null;
        }
    }


}

