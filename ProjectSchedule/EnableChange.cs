using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchedule
{
    public partial class AddForm
    {
        private void everyEnableChange(bool temp)
        {
            repeatEnableChange(temp);
            rangeEnableChange(temp);
            timeEnableChange(temp);
        }
        private void repeatEnableChange(bool temp)
        {
            repeatCategory.Enabled = temp;
            repeatDatePicker.Enabled = temp;
            repeatHH1.Enabled = temp;
            repeatHH2.Enabled = temp;
            repeatMM1.Enabled = temp;
            repeatMM2.Enabled = temp;
            repeatAddButton.Enabled = temp;
            repeatViewButton.Enabled = temp;

            label반복.Enabled = temp;
            label19.Enabled = temp;
            label18.Enabled = temp;
            label17.Enabled = temp;
            label16.Enabled = temp;
            label15.Enabled = temp;
            label14.Enabled = temp;
        }

        private void rangeEnableChange(bool temp)
        {
            repeatRangePicker1.Enabled = temp;
            repeatRangePicker2.Enabled = temp;

            label기간.Enabled = temp;
            label6.Enabled = temp;
            label8.Enabled = temp;
        }

        private void timeEnableChange(bool temp)
        {
            timeHH1.Enabled = temp;
            timeHH2.Enabled = temp;
            timeMM1.Enabled = temp;
            timeMM2.Enabled = temp;

            label시간.Enabled = temp;
            label7.Enabled = temp;
            label9.Enabled = temp;
            label10.Enabled = temp;
            label11.Enabled = temp;
            label12.Enabled = temp;
            label13.Enabled = temp;
        }

        private void timePartOneEnableChange(bool temp)
        {
            timeHH1.Enabled = temp;
            timeMM1.Enabled = temp;
            label시간.Enabled = temp;
            label10.Enabled= temp;
            label11.Enabled= temp;
        }

        private void rangePartOneEnableChange(bool temp)
        {
            label기간.Enabled = temp;
            repeatRangePicker1.Enabled = temp;
        }
    }

    public partial class ClassAddForm
    {
        private void repeatEnableChange(bool temp)
        {
            repeatHH1.Enabled = temp;
            repeatHH2.Enabled = temp;
            repeatMM1.Enabled = temp;
            repeatMM2.Enabled = temp;
            repeatAddButton.Enabled = temp;
            repeatViewButton.Enabled = temp;
            repeatDatePicker.Enabled = temp;

            label19.Enabled = temp;
            label18.Enabled = temp;
            label17.Enabled = temp;
            label16.Enabled = temp;
            label15.Enabled = temp;
            label14.Enabled = temp;
        }
    }
}
