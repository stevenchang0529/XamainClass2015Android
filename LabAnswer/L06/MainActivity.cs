using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace L06
{
    [Activity(Label = "L06", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var listView = this.FindViewById<ListView>(Resource.Id.listView);

            //讀取Assets\data.txt資料
            string[] items;
            using (var stream = Assets.Open("data.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    items = reader.ReadToEnd().Split(',');
                }
            }



            //lab:使用ArrayAdapter，並使用Android提供的Layout  Android.Resource.Layout.SimpleListItem1
           // ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, items);

            //lab:同樣使用ArrayAdapter，但更改為自己定義的Layout
            ArrayAdapter adapter = new ArrayAdapter(this,Resource.Layout.RowItem,Resource.Id.txtRow, items);

            listView.Adapter = adapter;


            //lab:為ListView建立ItemClick事件
            listView.ItemClick += (sender, e) =>
            {
                int index = e.Position;//點擊的索引位置
                Toast.MakeText(this, items[index], ToastLength.Short).Show();
            };
        }
    }
}

