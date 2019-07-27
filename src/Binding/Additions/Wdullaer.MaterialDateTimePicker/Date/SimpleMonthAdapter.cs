using AndroidX.RecyclerView.Widget;

namespace Wdullaer.MaterialDateTimePicker.Date
{
    public partial class SimpleMonthAdapter
    {
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            (holder as MonthViewHolder)?.Bind(position, MController, SelectedDay);
        }
    }
}
