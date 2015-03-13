using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Collections.Generic;
using SQLite;
using System.Linq;
namespace L08_SqliteNet
{

    //lab:使用Components Store加入Sqlite.net
    [Activity(Label = " L08_SqliteNet", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<Info> _Data;
        MyAdapter _Adapter;
        ListView _ListView;
        SQLiteConnection _Conn;
        string _DBPath;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnQuery = FindViewById<Button>(Resource.Id.btnQuery);
            var input = FindViewById<EditText>(Resource.Id.input);
            _ListView = FindViewById<ListView>(Resource.Id.listView);

            string dbName = "L08_SqliteNet.db";
            _DBPath = Path.Combine(FilesDir.Path, dbName);
            _Conn = new SQLiteConnection(_DBPath);


            //lab:使用CreateTable<T>建立Table
  


            List<Info> items = new List<Info>();
            items.Add(new Info() { Age = "12", Name = "Eco" });
            items.Add(new Info() { Age = "13", Name = "Lydia" });
            items.Add(new Info() { Age = "14", Name = "Steven" });
            items.Add(new Info() { Age = "15", Name = "Ben" });
            items.Add(new Info() { Age = "17", Name = "Terry" });
            items.Add(new Info() { Age = "18", Name = "KFC" });
            items.Add(new Info() { Age = "92", Name = "Moss" });
            items.Add(new Info() { Age = "53", Name = "Toyota" });
            items.Add(new Info() { Age = "122", Name = "BMW" });
            items.Add(new Info() { Age = "12", Name = "Zent" });

            //lab:使用InsertAll新增多筆資料


            btnAdd.Click +=
                 (sender, e) =>
                 {
                     StartActivityForResult(typeof(AddActivity), 0);
                 };
            btnQuery.Click +=
                 (sender, e) =>
                 {
                     //lab:使用_Conn.Table<Info> 搭配Linq查詢資料


                     //將查詢的資料建立Adapter
                     _Adapter = new MyAdapter(this, _Data);
                     _ListView.Adapter = _Adapter;
                     Toast.MakeText(this, "查詢完成", ToastLength.Short).Show();
                 };

        }

        protected override void OnActivityResult
            (int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                string name = data.GetStringExtra("Name");
                string age = data.GetStringExtra("Age");

                //lab:使用 Insert新增資料

            }
        }


    }
    public class Info
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
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

