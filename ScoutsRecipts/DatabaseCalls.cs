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
using Database;
using Models;

namespace ScoutsRecipts
{
    static class DatabaseCalls
    {

        public static void AddChild(string firstName, string secondName, string phoneN, string mEmail, string parentName, Context context, DatabaseAdapter databaseAdapter)
        {
            if (firstName.Length == 0 || secondName.Length == 0 || phoneN.Length == 0 || mEmail.Length == 0 || parentName.Length == 0)
            {
                Toast.MakeText(context, "One or more fields are empty. Please insert data into all fields", ToastLength.Long).Show();
            }
            else
            {
                long id = databaseAdapter.InsertChild(firstName, secondName, mEmail, phoneN, parentName);
                if (id < 0)
                {
                    Toast.MakeText(context, "Unsuccessful", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(context, "Successful", ToastLength.Long).Show();

                }
            }

        }

        public static void GetChildren(Context context, DatabaseAdapter databaseAdapter)
        {
            var children = databaseAdapter.GetChildren();
            Toast.MakeText(context, "Successful", ToastLength.Long).Show();

        }
    }
}