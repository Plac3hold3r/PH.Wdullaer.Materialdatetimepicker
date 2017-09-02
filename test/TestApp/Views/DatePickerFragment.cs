using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Util;
using Materialdatetimepicker = Com.Wdullaer.Materialdatetimepicker.Date;

namespace TestApp.Views
{
    public class DatePickerFragment : Fragment, Materialdatetimepicker.DatePickerDialog.IOnDateSetListener
    {
        private TextView dateTextView;
        private CheckBox modeDarkDate;
        private CheckBox modeCustomAccentDate;
        private CheckBox vibrateDate;
        private CheckBox dismissDate;
        private CheckBox titleDate;
        private CheckBox showYearFirst;
        private CheckBox showVersion2;
        private CheckBox limitSelectableDays;
        private CheckBox highlightDays;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.datepicker_layout, container, false);

            // Find our View instances
            dateTextView = view.FindViewById<TextView>(Resource.Id.date_textview);
            Button dateButton = view.FindViewById<Button>(Resource.Id.date_button);
            modeDarkDate = view.FindViewById<CheckBox>(Resource.Id.mode_dark_date);
            modeCustomAccentDate = view.FindViewById<CheckBox>(Resource.Id.mode_custom_accent_date);
            vibrateDate = view.FindViewById<CheckBox>(Resource.Id.vibrate_date);
            dismissDate = view.FindViewById<CheckBox>(Resource.Id.dismiss_date);
            titleDate = view.FindViewById<CheckBox>(Resource.Id.title_date);
            showYearFirst = view.FindViewById<CheckBox>(Resource.Id.show_year_first);
            showVersion2 = view.FindViewById<CheckBox>(Resource.Id.show_version_2);
            limitSelectableDays = view.FindViewById<CheckBox>(Resource.Id.limit_dates);
            highlightDays = view.FindViewById<CheckBox>(Resource.Id.highlight_dates);

            dateButton.Click += DateButton_Click;

            return view;
        }

        private void DateButton_Click(object sender, System.EventArgs e)
        {
            Calendar now = Calendar.Instance;
            var dpd = new Materialdatetimepicker.DatePickerDialog();
            dpd.Initialize(
                    this,
                    now.Get(CalendarField.Year),
                    now.Get(CalendarField.Month),
                    now.Get(CalendarField.DayOfMonth)
            );
            dpd.SetThemeDark(modeDarkDate.Checked);
            dpd.Vibrate(vibrateDate.Checked);
            dpd.DismissOnPause(dismissDate.Checked);
            dpd.ShowYearPickerFirst(showYearFirst.Checked);
            dpd.SetVersion(showVersion2.Checked ? Materialdatetimepicker.DatePickerDialog.Version.Version2 : Materialdatetimepicker.DatePickerDialog.Version.Version1);
            if (modeCustomAccentDate.Checked)
            {
                dpd.AccentColor = Color.ParseColor("#9C27B0");
            }
            if (titleDate.Checked)
            {
                dpd.SetTitle("DatePicker Title");
            }
            if (highlightDays.Checked)
            {
                Calendar date1 = Calendar.Instance;
                Calendar date2 = Calendar.Instance;
                date2.Add(CalendarField.WeekOfMonth, -1);
                Calendar date3 = Calendar.Instance;
                date3.Add(CalendarField.WeekOfMonth, 1);
                Calendar[] days = { date1, date2, date3 };
                dpd.SetHighlightedDays(days);
            }
            if (limitSelectableDays.Checked)
            {
                Calendar[] days = new Calendar[13];
                for (int i = -6; i < 7; i++)
                {
                    Calendar day = Calendar.Instance;
                    day.Add(CalendarField.DayOfMonth, i * 2);
                    days[i + 6] = day;
                }
                dpd.SetSelectableDays(days);
            }
            dpd.Show(FragmentManager, "Datepickerdialog");
        }

        public override void OnResume()
        {
            base.OnResume();
            var dpd = (Materialdatetimepicker.DatePickerDialog)FragmentManager.FindFragmentByTag("Datepickerdialog");
            if (dpd != null) dpd.SetOnDateSetListener(this);
        }

        public void OnDateSet(Materialdatetimepicker.DatePickerDialog p0, int p1, int p2, int p3)
        {
            string date = "You picked the following date: " + p3 + "/" + (++p2) + "/" + p1;
            dateTextView.Text = date;
        }
    }
}