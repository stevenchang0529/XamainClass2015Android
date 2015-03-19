using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using L05_WebService.net.azurewebsites.testmyws;
using System.Threading.Tasks;
namespace L05_WebService
{
    [Activity(Label = "L05_WebService", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        BasicHttpBinding_IService1 service;
        protected  override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //建立WebService Proxy類別
             service = new BasicHttpBinding_IService1();
             var text = this.FindViewById<TextView>(Resource.Id.textView);
            this.FindViewById<Button>(Resource.Id.button).Click +=async (sender, e) =>
            {
                //lab:使用同步方式，會造成UI執行序卡住
               // var result = service.GetData(999, true);

                //lab:使用非同步方式(EAP)
                //service.GetDataAsync(999, true);
                //service.GetDataCompleted += (s, arg) =>
                //{
                //    this.FindViewById<TextView>(Resource.Id.textView).Text = arg.Result;
                //};



                //lab:使用TAP方式
                var result=await this.GetData(999);

                //lab:將取得結果設定到text
                text.Text = result;
            };
        }

        //lab:轉換成TAP方式
        private Task<string> GetData(int value)
        {
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            service.GetDataCompleted += (sender, e) =>
            {
                task.SetResult(e.Result);
            };
            service.GetDataAsync(value, true);
            return task.Task;
        }
    }


}

