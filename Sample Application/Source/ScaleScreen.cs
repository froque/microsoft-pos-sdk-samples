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
    public partial class ScaleScreen : TestApplication.DeviceScreenBase
    {
        Scale s;

        public ScaleScreen()
        {
            InitializeComponent();
        }

        public override void SetOpened(bool opened)
        {
            if (s == null)
            {
                s = (Scale)PosCommon;
                s.DataEvent += new DataEventHandler(_scale_DataEvent);
            }
        }


        void _scale_DataEvent(object sender, DataEventArgs e)
        {
            string str = "Item Weight: " + e.Status.ToString(System.Globalization.CultureInfo.CurrentCulture) + "\r\n";

            if (s.CapTareWeight)
                str += "Tare Weight: " + s.TareWeight.ToString(System.Globalization.CultureInfo.CurrentCulture) + "\r\n";
            if (s.CapPriceCalculating)
            {
                str += "Unit Price: " + s.UnitPrice.ToString(System.Globalization.CultureInfo.CurrentCulture) + "\r\n";
                str += "Sales Price: " + s.SalesPrice.ToString(System.Globalization.CultureInfo.CurrentCulture) + "\r\n";
            }

            DisplayMessage(str);
                
        }

        #region Scale

        private void tbTareWeight_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                s.TareWeight = Decimal.Parse(tbTareWeight.Text, System.Globalization.CultureInfo.CurrentCulture);
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void tbUnitPrice_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                s.UnitPrice = Decimal.Parse(tbUnitPrice.Text, System.Globalization.CultureInfo.CurrentCulture);
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnDisplayText_Click(object sender, System.EventArgs e)
        {
            try
            {
                s.DisplayText(tbDisplayText.Text);
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnReadWeight_Click(object sender, System.EventArgs e)
        {
            try
            {
                Decimal weight = s.ReadWeight(Int32.Parse(textBox6.Text, System.Globalization.CultureInfo.CurrentCulture));
                lblResult.Text = "Weight: " + weight.ToString(System.Globalization.CultureInfo.CurrentCulture);
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }

        private void btnZeroScale_Click(object sender, System.EventArgs e)
        {
            try
            {
                s.ZeroScale();
                
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
        #endregion


    

    }
}

