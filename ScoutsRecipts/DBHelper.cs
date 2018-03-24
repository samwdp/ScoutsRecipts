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
using Android.Database.Sqlite;

namespace Database
{
    class DBHelper : SQLiteOpenHelper
    {
        private static string DATABASE_NAME = "scouts.db";
        private static string CHILD_TABLE_NAME = "Child";
        private static string EVENT_TABLE_NAME = "Event";
        private static string CHLD_TO_EVENT_LINK_TABLE_NAME = "Child_Event";
        private static int VERSION_NUMBER = 1;

        //Child table columns
        private static string CHILD_ID = "child_id";
        private static string CHILD_FIRST_NAME = "f_name";
        private static string CHILD_LAST_NAME = "l_name";
        private static string CHILD_EMAIL = "email";
        private static string CHILD_PHONE = "phone";
        private static string CHILD_PARENT_NAME = "p_name";

        //Event table columns;
        private static string EVENT_ID = "event_id";
        private static string EVENT_NAME = "name";
        private static string EVENT_PRICE = "price";
        private static string EVENT_DATE = "date";

        //link table columns
        private static string LINK_CHILD_ID = "child_id";
        private static string LINK_EVENT_ID = "event_id";
        private static string LINK_CURRENT_PAID = "current_paid";

        private static string CREATE_CHILD_TABLE = "CREATE TABLE " + CHILD_TABLE_NAME + " (" + CHILD_ID + " integer PRIMARY KEY AUTOINCREMENT, " + CHILD_FIRST_NAME + " varchar(255), " + CHILD_LAST_NAME + " varchar(255), " + CHILD_EMAIL + " varchar(255), " + CHILD_PHONE + " varchar(255), " + CHILD_PARENT_NAME + " varchar(255));";
        private static string CREATE_EVENT_TABLE = "CREATE TABLE " + EVENT_TABLE_NAME + " (" + EVENT_ID + " integer PRIMARY KEY AUTOINCREMENT, " + EVENT_NAME + " varchar(255), " + EVENT_PRICE + " real, " + EVENT_DATE + " datetime);";
        private static string CREATE_LINK_TABLE = "CREATE TABLE " + CHLD_TO_EVENT_LINK_TABLE_NAME + " (" + LINK_CHILD_ID + " integer, " + LINK_EVENT_ID + " integer, " + LINK_CURRENT_PAID + " real);";

        private static string DROP_CHILD = "DROP TABLE IF EXISTS " + CHILD_TABLE_NAME;
        private static string DROP_EVENT = "DROP TABLE IF EXISTS " + EVENT_TABLE_NAME;
        private static string DROP_LINK = "DROP TABLE IF EXISTS " + CHLD_TO_EVENT_LINK_TABLE_NAME;
        private Context context;

        public DBHelper(Context context) : base(context, name: DATABASE_NAME, factory: null, version: VERSION_NUMBER)
        {
            this.context = context;
            Toast.MakeText(context, "Constructer Called", ToastLength.Long).Show();
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            try
            {
                db.ExecSQL(CREATE_CHILD_TABLE);
                db.ExecSQL(CREATE_EVENT_TABLE);
                db.ExecSQL(CREATE_LINK_TABLE);
                Toast.MakeText(context, "CreatedTable", ToastLength.Long).Show();
            }
            catch (SQLiteException sle)
            {
                Toast.MakeText(context, "Error" + sle, ToastLength.Long).Show();
            }
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            try
            {
                Toast.MakeText(context, "Upgrade", ToastLength.Long).Show();
                db.ExecSQL(DROP_CHILD);
                db.ExecSQL(DROP_EVENT);
                db.ExecSQL(DROP_LINK);
                OnCreate(db);
            }
            catch (SQLiteAbortException sle)
            {
                Toast.MakeText(context, "Error" + sle, ToastLength.Long).Show();
            }
        }
    }
}