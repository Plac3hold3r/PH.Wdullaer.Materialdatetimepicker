using AndroidX.Fragment.App;
using SampleApp.Views;

namespace SampleApp.Adapters
{
    internal class PickerAdapter : FragmentPagerAdapter
    {
        private const int numberPages = 2;
        private readonly Fragment timePickerFragment;
        private readonly Fragment datePickerFragment;

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
