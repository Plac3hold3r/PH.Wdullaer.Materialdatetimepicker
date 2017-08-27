//using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Com.Wdullaer.Materialdatetimepicker.Date;
using Java.Util;

namespace TestApp.Views
{
    [Android.App.Activity(
        Label = "TestApp",
        MainLauncher = true,
        Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener
    {
        public void OnDateSet(DatePickerDialog p0, int p1, int p2, int p3)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var datePicker = FindViewById<Button>(Resource.Id.btn_date_picker);
            datePicker.Click += DatePicker_Click;
        }

        private void DatePicker_Click(object sender, System.EventArgs e)
        {
            Calendar now = Calendar.Instance;
            DatePickerDialog dpd = new DatePickerDialog();
            dpd.Initialize(
                    this,
                    now.Get(CalendarField.Year),
                    now.Get(CalendarField.Month),
                    now.Get(CalendarField.DayOfMonth)
            );
            //dpd.setThemeDark(modeDarkDate.isChecked());
            //dpd.vibrate(vibrateDate.isChecked());
            //dpd.dismissOnPause(dismissDate.isChecked());
            // dpd.showYearPickerFirst(showYearFirst.isChecked());
            //dpd.setVersion(showVersion2.isChecked() ? DatePickerDialog.Version.VERSION_2 : DatePickerDialog.Version.VERSION_1);
            //if (modeCustomAccentDate.isChecked())
            //{
            //    dpd.setAccentColor(Color.parseColor("#9C27B0"));
            //}
            //if (titleDate.isChecked())
            //{
            //    dpd.setTitle("DatePicker Title");
            //}
            //if (highlightDays.isChecked())
            //{
            //    Calendar date1 = Calendar.getInstance();
            //    Calendar date2 = Calendar.getInstance();
            //    date2.add(Calendar.WEEK_OF_MONTH, -1);
            //    Calendar date3 = Calendar.getInstance();
            //    date3.add(Calendar.WEEK_OF_MONTH, 1);
            //    Calendar[] days = { date1, date2, date3 };
            //    dpd.setHighlightedDays(days);
            //}
            //if (limitSelectableDays.isChecked())
            //{
            //    Calendar[] days = new Calendar[13];
            //    for (int i = -6; i < 7; i++)
            //    {
            //        Calendar day = Calendar.getInstance();
            //        day.add(Calendar.DAY_OF_MONTH, i * 2);
            //        days[i + 6] = day;
            //    }
            //    dpd.setSelectableDays(days);
            //}
            dpd.Show(FragmentManager, "Datepickerdialog");
        }
    }
}

