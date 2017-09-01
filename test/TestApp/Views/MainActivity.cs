using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V13.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace TestApp.Views
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        ViewPager viewPager;
        PickerAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            adapter = new PickerAdapter(FragmentManager);
            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.Adapter = adapter;

            SetSupportActionBar(FindViewById<Toolbar>(Resource.Id.toolbar));
            TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);
            for (int i = 0; i < adapter.Count; i++)
                tabLayout.GetTabAt(i).SetText(adapter.GetTitle(i));
        }

        private class PickerAdapter : FragmentPagerAdapter
        {
            private static int numberPages = 2;
            Fragment timePickerFragment;
            Fragment datePickerFragment;

            public PickerAdapter(FragmentManager fragmentManager) : base(fragmentManager)
            {
                timePickerFragment = new TimePickerFragment();
                datePickerFragment = new DatePickerFragment();
            }

            public override int Count => numberPages;

            public override Fragment GetItem(int position)
            {
                switch (position)
                {
                    case 0:
                        return timePickerFragment;
                    case 1:
                    default:
                        return datePickerFragment;
                }
            }

            public int GetTitle(int position)
            {
                switch (position)
                {
                    case 0:
                        return Resource.String.tab_title_time;
                    case 1:
                    default:
                        return Resource.String.tab_title_date;
                }
            }
        }
    }
}

