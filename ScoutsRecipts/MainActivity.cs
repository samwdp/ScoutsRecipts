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
        private Button addChild, viewChild;
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
            addChild = FindViewById<Button>(Resource.Id.addChildDB);

            SetActionBar(toolbar);

            databaseAdapter = new DatabaseAdapter(this); 

            addChild.Click += (sender, e)=>{
                //DatabaseCalls.AddChild(first.Text, last.Text, phone.Text, email.Text, parent.Text, this, databaseAdapter);
                DatabaseCalls.GetChildren(this, databaseAdapter);
            };

           
        }

        
    } 
}

