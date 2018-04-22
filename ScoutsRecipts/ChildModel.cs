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
    class ChildModel
    {
        String firstName { get; set; }
        String lastName { get; set; }
        String email { get; set; }
        string phone { get; set; }
        string parentName { get; set; }

        public ChildModel(string firstName, string lastName, string email, string phone, string parentName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.parentName = parentName;
        }

        public override string ToString()
        {
            string s = firstName + " " + lastName;
            return s;
        }
    }
}