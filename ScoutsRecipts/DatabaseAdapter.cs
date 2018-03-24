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
    class DatabaseAdapter
    {
        DBHelper helper;

        public DatabaseAdapter(Context context)
        {
            helper = new DBHelper(context);
        }

        public long InsertChild(string firstName, string lastName, string email, string phone, string parentName)
        {
            SQLiteDatabase db = helper.WritableDatabase;
            ContentValues contentValues = new ContentValues();
            contentValues.Put(DBHelper.CHILD_FIRST_NAME, firstName);
            contentValues.Put(DBHelper.CHILD_LAST_NAME, lastName);
            contentValues.Put(DBHelper.CHILD_EMAIL, email);
            contentValues.Put(DBHelper.CHILD_PHONE, phone);
            contentValues.Put(DBHelper.CHILD_PARENT_NAME, parentName);
            long id = db.Insert(DBHelper.CHILD_TABLE_NAME, null, contentValues);
            return id;
        }




        private class DBHelper : SQLiteOpenHelper
        {
            private static string DATABASE_NAME = "scouts.db";
            public static string CHILD_TABLE_NAME = "Child";
            public static string EVENT_TABLE_NAME = "Event";
            public static string CHLD_TO_EVENT_LINK_TABLE_NAME = "Child_Event";
            private static int VERSION_NUMBER = 1;

            //Child table columns
            private static string CHILD_ID = "child_id";
            public static string CHILD_FIRST_NAME = "f_name";
            public static string CHILD_LAST_NAME = "l_name";
            public static string CHILD_EMAIL = "email";
            public static string CHILD_PHONE = "phone";
            public static string CHILD_PARENT_NAME = "p_name";

            //Event table columns;
            private static string EVENT_ID = "event_id";
            public static string EVENT_NAME = "name";
            public static string EVENT_PRICE = "price";
            public static string EVENT_DATE = "date";
                          
            //link table columns
            public static string LINK_CHILD_ID = "child_id";
            public static string LINK_EVENT_ID = "event_id";
            public static string LINK_CURRENT_PAID = "current_paid";
                     
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
            }

            public override void OnCreate(SQLiteDatabase db)
            {
                try
                {
                    db.ExecSQL(CREATE_CHILD_TABLE);
                    db.ExecSQL(CREATE_EVENT_TABLE);
                    db.ExecSQL(CREATE_LINK_TABLE);

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
}