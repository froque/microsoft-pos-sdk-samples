using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace TestApplication
{
    public partial class BumpBarScreen : TestApplication.DeviceScreenBase
    {
        BumpBar _bumpbar;
        public BumpBarScreen()
        {
            InitializeComponent();

            cbDeviceUnits.Items.Clear();
            cbDeviceUnits.Items.AddRange(Enum.GetNames(typeof(DeviceUnits)));
        }

        public override void SetOpened(bool opened)
        {
            if (_bumpbar == null)
            {
                _bumpbar = (BumpBar)PosCommon;
            }

        }


        private void btnBumpBarSound_Click(object sender, System.EventArgs e)
        {
            try
            {
                DeviceUnits du = (DeviceUnits)Enum.Parse(typeof(DeviceUnits), cbDeviceUnits.Text);
                int freq = int.Parse(tbFrequency.Text, System.Globalization.CultureInfo.CurrentCulture);
                int dur = int.Parse(tbDuration.Text, System.Globalization.CultureInfo.CurrentCulture);
                int cycles = int.Parse(tbCycles.Text, System.Globalization.CultureInfo.CurrentCulture);
                int wait = int.Parse(tbInterSoundWait.Text, System.Globalization.CultureInfo.CurrentCulture);
                _bumpbar.BumpBarSound(du, freq, dur, cycles, wait);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnSetKeyTranslation_Click(object sender, System.EventArgs e)
        {
            try
            {
                DeviceUnits du = (DeviceUnits)Enum.Parse(typeof(DeviceUnits), cbDeviceUnits.Text);
                int codes = int.Parse(tbScanCodes.Text, System.Globalization.CultureInfo.CurrentCulture);
                int key = int.Parse(tbLogicalKey.Text, System.Globalization.CultureInfo.CurrentCulture);
                _bumpbar.SetKeyTranslation(du, codes, key);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

    }
}

