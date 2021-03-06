﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics.Drawables;
using System.IO;

namespace L07
{
    [Activity(Label = "L07", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var listView = this.FindViewById<ListView>(Resource.Id.listView);
            var btnCheckAll = this.FindViewById<Button>(Resource.Id.button1);
            //由Assets讀取data.txt並解析
            string[] items;
            using (var stream = Assets.Open("data.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    items = reader.ReadToEnd().Split(';');
                }
            }
            List<Item> datas = items.Select(c => new Item()
             {
                 Text = c.Split(',')[0].Trim(),
                 Image = "i" + c.Split(',')[1]
             }).ToList();


            //lab:建立自訂的MyAdapter，傳入目前的Activity與來源資料
            var adapter = new MyAdapter() { Context = this, Items = datas };
            listView.Adapter = adapter;


           btnCheckAll.Click += (sender, e) =>
           {
               //lab:點下全選後，應更對來源資料做更新，再讓Adapter根據來源資料使用 NotifyDataSetChanged()去更新畫面
               //而非直接把畫面上的CheckBox更新
               foreach (var i in datas)
                   i.isCheck = true;
               adapter.NotifyDataSetChanged();
                       
           };
        }


        //lab:實作BaseAdapter<T>
        public class MyAdapter :BaseAdapter<Item>
        {
            public List<Item> Items { get; set; }

            public Activity Context { get; set; }

           




            public override Item this[int position]
            {
                get { return Items[position]; }
            }

            public override int Count
            {
                get { return Items.Count; }
            }

            public override long GetItemId(int position)
            {
                return position;
            }


            //lab:1.使用圖片檔案名找回drawable類型物件
            // var drawable = Context.Resources.GetDrawable(Context.Resources.GetIdentifier(item.Image, "drawable", Context.PackageName));

            //lab:2.在畫面中的checkBox的CheckedChange應只註冊一次

            //lab:3.利用checkBox的tag值將目前checkbox所在的索引值記下來，並在CheckedChange中取回即可知道索引
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
  
                if (convertView == null)
                {
                    convertView = this.Context.LayoutInflater.Inflate(Resource.Layout.RowItem, null);
                    convertView.FindViewById<CheckBox>(Resource.Id.chk) .CheckedChange+=(sender,e)=>{
                        var chk = sender as CheckBox;
                        var index = Convert.ToInt32(chk.Tag);
                        Items[index].isCheck = e.IsChecked;
                    };
                }
         
                var item=this.Items[position];
                convertView.FindViewById<ImageView>(Resource.Id.image).SetImageDrawable(Context.Resources.GetDrawable(Context.Resources.GetIdentifier(item.Image, "drawable", Context.PackageName)));
                var checkBox=convertView.FindViewById<CheckBox>(Resource.Id.chk)   ;
                checkBox.Tag = position;
                checkBox.Text=item.Text;
                checkBox.Checked=item.isCheck;
               
                return convertView;

            }
        }

        public class Item
        {
            public string Text { get; set; }
            public string Image { get; set; }
            public bool isCheck { get; set; }
        }
    }
}

