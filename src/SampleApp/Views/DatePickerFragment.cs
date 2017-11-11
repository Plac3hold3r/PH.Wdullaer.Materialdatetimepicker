using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Util;
using MaterialdDatePicker = Wdullaer.MaterialDateTimePicker.Date;

namespace SampleApp.Views
{
    public class DatePickerFragment : Fragment, MaterialdDatePicker.DatePickerDialog.IOnDateSetListener
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
            var dpd = new MaterialdDatePicker.DatePickerDialog();
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
            dpd.SetVersion(showVersion2.Checked ? MaterialdDatePicker.DatePickerDialog.Version.Version2 : MaterialdDatePicker.DatePickerDialog.Version.Version1);
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
                var days = new Calendar[13];
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
            var dpd = (MaterialdDatePicker.DatePickerDialog)FragmentManager.FindFragmentByTag("Datepickerdialog");
            if (dpd != null)
            {
                dpd.OnDateSetListener = this;
            }
        }

        public void OnDateSet(MaterialdDatePicker.DatePickerDialog view, int year, int monthOfYear, int dayOfMonth)
        {
            dateTextView.Text = "You picked the following date: " + dayOfMonth + "/" + (++monthOfYear) + "/" + year;
        }
    }
}
