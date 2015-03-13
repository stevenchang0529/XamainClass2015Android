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
using Android.Webkit;

namespace L02_Controls
{
    [Activity(Label = "Main2Activity", MainLauncher = true)]
    public class Main2Activity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.Main2);

            //Toast
            this.FindViewById<Button>(Resource.Id.btnToast).Click += (sender, e) =>
            {
                Toast.MakeText(this, "I am Toast!", ToastLength.Short).Show();
            };


            //Alert物件要透過AlertDialog.Builder 建立
            AlertDialog.Builder bulider = new AlertDialog.Builder(this);
            AlertDialog alert = null;
            bulider
                .SetTitle("I am Title")
                .SetMessage("我是訊息")
                .SetIcon(Android.Resource.Drawable.IcDialogInfo)
                .SetNegativeButton("OK", (sender, e) => 
                { alert.Dismiss(); });//設定Button文字和其Click事件
            
             alert = bulider.Create();
            this.FindViewById<Button>(Resource.Id.btnAlert).Click += (sender, e) =>
            {
                alert.Show();
            };

            //DatePick
            this.FindViewById<Button>(Resource.Id.btnDate).Click += (sender, e) =>
            {
                DatePickerDialog date = new DatePickerDialog(this, (obj, arg) =>
                {
                    //將選到的日期Toast出來
                    Toast.MakeText(this, arg.Date.ToString("yyyy/MM/dd"), ToastLength.Short).Show();

                }, DateTime.Now.Year, DateTime.Now.Month-1, DateTime.Now.Day);//Java月由0算起所以要-1
                date.Show();

            };

            //Progress
            this.FindViewById<Button>(Resource.Id.btnProg).Click += (sender, e) =>
            {
                ProgressDialog progress = new ProgressDialog(this);
                progress.SetMessage("用力讀取中");
                //開啟以下註解可設定讀取畫面不可被取消
                //progress.SetCancelable(false);
                //progress.SetCanceledOnTouchOutside(false);
                progress.Show();

            };


            //AutoCompleteText
           var autoTxt=this.FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView);
                   string[] datasource = new string[] {
            "I love Xamarin!",
            "I don't understand",
            "You are beautiful!",
            "You are handsome",
            "You are smart",
            "He works with me",
            "He is weird.",
            "She looks very busy.",
            "She knows me."
            };
              autoTxt.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, datasource);
              autoTxt.Threshold = 1;//設定輸入多少個字元後跳出提示

            //WebView
             var web= this.FindViewById<WebView>(Resource.Id.webView);
             web.SetWebViewClient(new WebViewClient());//設定WebViewClient避免直接用瀏覽器開啟
             web.Settings.JavaScriptEnabled = true;//啟用Javascript
             web.LoadUrl("http://tw.yahoo.com");//設定載入網址
        }

        
    }
}