using Android.Support.V7.Widget;

namespace MaterialDateTimePicker.Date
{
    public partial class SimpleMonthAdapter
    {
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            (holder as MonthViewHolder)?.Bind(position, MController, SelectedDay);
        }
    }
}