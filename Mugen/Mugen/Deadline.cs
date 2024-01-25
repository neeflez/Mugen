using System;
using System.Windows.Controls;

namespace Mugen
{
    public class Deadline : IComparable<Deadline>, ICloneable<Deadline>
    {
        public TextBox DeadlineText { get; }
        public DatePicker? DeadlineTime { get; }

        public Deadline(TextBox _deadlineText, DatePicker? _deadlineTime)
        {
            this.DeadlineText = _deadlineText;
            this.DeadlineTime = _deadlineTime;
        }

        public override string ToString()
        {
            return DeadlineText.Text + "\n" + (DeadlineTime?.SelectedDate?.ToString("dd.MM.yyyy") ?? "No date");
        }

        public int CompareTo(Deadline other)
        {
            if (other == null)
            {
                return 1;
            }

            DateTime? thisDate = this.DeadlineTime?.SelectedDate;
            DateTime? otherDate = other.DeadlineTime?.SelectedDate;

            if (thisDate < otherDate)
            {
                return -1;
            }
            else if (thisDate > otherDate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void SetValues(TextBox deadlineText, DatePicker? deadlineTime)
        {
            this.DeadlineText.Text = deadlineText.Text;
            this.DeadlineTime.SelectedDate = deadlineTime?.SelectedDate;
        }

        public Deadline Clone()
        {
            throw new NotImplementedException();
        }
    }
}
