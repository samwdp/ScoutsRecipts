using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Database;

namespace ScoutsRecipts
{
    [Activity(Label = "ScoutsRecipts", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {

        private Toolbar toolbar;
        private DBHelper dBHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);

            dBHelper = new DBHelper(this);
            
        }
    } 
}

