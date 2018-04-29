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

namespace Models
{
    class EventModel
    {
        string name { get; set; }
        string price { get; set; }
        string date { get; set; }

        public EventModel (string name, string price, string time)
        {
            this.name = name;
            this.price = price;
            this.date = date;
        }

        public override string ToString()
        {
            return name + " " + price;
        }
    }
}