using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace L08_SqliteADO
{
    [Activity(Label = "L08_SqliteADO", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string _ConnectionString;
        List<Info> _Data;
        MyAdapter _Adapter;
        ListView _ListView;
        string _DBPath;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            var btnLoad = FindViewById<Button>(Resource.Id.btnLoad);
            _ListView = FindViewById<ListView>(Resource.Id.listView);

            string dbName = "L08.db";
            //DB路徑 FilesDir.Path =\data\data\L08_SqliteADO.L08_SqliteADO\L08.db
            //該路徑要Root過才能進入(模擬器本身有root)
            _DBPath = Path.Combine(FilesDir.Path, dbName);

            if (!File.Exists(_DBPath))//判斷檔案是否存在
            {
                //lab:使用SqliteConnection的CreateFile建立資料庫檔案

            }

            //連線字串
            _ConnectionString =string.Format("Data Source={0};Version=3", _DBPath);

          

            btnCreate.Click +=
                (sender, e) =>
                {
                 
                    ExecuteNonQuery
                        ("Create Table if not exists MyData(Name ntext, Age INTEGER )");
                    Toast.MakeText
                        (this, "執行建立資料表", ToastLength.Short).Show();
                };

            btnAdd.Click +=
                 (sender, e) =>
                 {
                     StartActivityForResult(typeof(AddActivity), 0);
                 };


            btnLoad.Click +=
                 (sender, e) =>
                 {
                   var table=  ExecuteData("Select * FROM MyData");
                   //將DataTable使用Linq 轉成Info物件
                   _Data= table.Rows.Cast<DataRow>().Select(c =>
                       new Info()
                       {
                           Name = c["Name"].ToString(),
                           Age = c["Age"].ToString()
                       }).ToList();



                     _Adapter = new MyAdapter(this, _Data);
                     _ListView.Adapter = _Adapter;
                     Toast.MakeText
                         (this, "查詢所有資料", ToastLength.Short).Show();
                 };

        }

        protected override void OnActivityResult
            (int requestCode, Result resultCode, Intent data)
        {
            //將上頁的結果Insert回Table
            string name = data.GetStringExtra("Name");
            string age = data.GetStringExtra("Age");
            ExecuteNonQuery(string.Format("Insert into MyData Values('{0}',{1})", name, age));
        }

        //使用SqliteConnection搭配DataTable傳回
        private DataTable ExecuteData(string cmdText)
        {
            //建立SqliteConnection物件並open
            using (var conn = new SqliteConnection(_ConnectionString))
            {
                conn.Open();
                //lab:使用SqliteConnection建立Command，指定commandType與其指令

                //lab:使用SqliteDataAdapter給予Command

                //lab:建立DataTable並且使用SqliteDataAdapter的Fill寫入DataTable
                return null;
            }
        }

        //執行Sql指令
        private void ExecuteNonQuery(string cmdText)
        {
            //建立SqliteConnection物件並open
            using (var conn = new SqliteConnection(_ConnectionString))
            {
                conn.Open();
                //lab:使用SqliteConnection建立Command，指定commandType與其指令

                //lab:使用ExecuteNonQuery()執行指令
            }

        }
    }
    public class Info
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
    public class MyAdapter : BaseAdapter<Info>
    {
        List<Info> _Data;
        Activity _Context;

        public MyAdapter(Activity context, List<Info> data)
        {
            _Data = data;
            _Context = context;
        }

        public override int Count
        {
            get { return _Data.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Info this[int position]
        {
            get { return _Data[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _Context.LayoutInflater.Inflate(Resource.Layout.Item, null);
            view.FindViewById<TextView>(Resource.Id.txtName).Text = _Data[position].Name;
            view.FindViewById<TextView>(Resource.Id.txtAge).Text = _Data[position].Age + "歲";
            return view;
        }

    }
}

