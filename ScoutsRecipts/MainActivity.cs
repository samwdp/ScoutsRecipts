using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Database.Sqlite;
using Database;

namespace ScoutsRecipts
{
    [Activity(Label = "ScoutsRecipts", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {

        private Toolbar toolbar;
        private Button addChild;
        private EditText first, last, email, phone, parent;
        DatabaseAdapter databaseAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            first = FindViewById<EditText>(Resource.Id.fisrtName);
            last = FindViewById<EditText>(Resource.Id.secondName);
            email = FindViewById<EditText>(Resource.Id.email);
            phone = FindViewById<EditText>(Resource.Id.phone);
            parent = FindViewById<EditText>(Resource.Id.parentName);
            addChild = FindViewById<Button>(Resource.Id.addChild);
            SetActionBar(toolbar);

            databaseAdapter = new DatabaseAdapter(this); 

            addChild.Click += (sender, e)=>{
                AddChild();
            };
        }

        public void AddChild()
        {
            string fisrtName = first.Text;
            string secondName = last.Text;
            string phoneN = phone.Text;
            string memail = email.Text;
            string parentName = parent.Text;
            long id = databaseAdapter.InsertChild(fisrtName, secondName, memail, phoneN, parentName);
            if (id < 0)
            {
                Toast.MakeText(this, "Unzuccessful", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Successful", ToastLength.Long).Show();
            }
            
        }
    } 
}

