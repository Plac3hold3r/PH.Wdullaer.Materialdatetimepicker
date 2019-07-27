using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ViewPager.Widget;
using Google.Android.Material.Tabs;
using SampleApp.Adapters;

namespace SampleApp.Views
{
    [Activity(
        MainLauncher = true,
        Label = "@string/app_name",
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            SetSupportActionBar(FindViewById<Toolbar>(Resource.Id.toolbar));

            var adapter = new PickerAdapter(SupportFragmentManager);
            var viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.Adapter = adapter;

            TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            for (int i = 0; i < adapter.Count; i++)
                tabLayout.GetTabAt(i).SetText(adapter.GetTitle(i));
        }
    }
}
