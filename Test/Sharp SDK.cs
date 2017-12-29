using Sharp_SDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class form : Form
    {
        private bool led_control = false;

        public form()
        {
            InitializeComponent();
            this.devices.DataSource = Enum.GetValues(typeof(DEVICE_INDEX));
            this.effects.DataSource = Enum.GetValues(typeof(EFF_INDEX));
            this.row.Maximum = SDK.MAX_LED_ROW - 1;
            this.column.Maximum = SDK.MAX_LED_COLUMN - 1;
            this.single_red.Maximum = 255;
            this.single_green.Maximum = 255;
            this.single_blue.Maximum = 255;
            this.all_red.Maximum = 255;
            this.all_green.Maximum = 255;
            this.all_blue.Maximum = 255;
        }

        private void control_Click(object sender, EventArgs e)
        {
            this.led_control = this.led_control ? false : true;
            this.control.Text = this.led_control ? "Disable" : "Enable";
            SDK.EnableLedControl(led_control);
        }

        private void devices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(devices.SelectedIndex == 4 || devices.SelectedIndex == 5)
            {
                get_layout.Enabled = false;
            }
            else
            {
                txt_layout.Text = "";
                get_layout.Enabled = true;
            }

            SDK.SetControlDevice((DEVICE_INDEX)devices.SelectedIndex);
        }

        private void get_layout_Click(object sender, EventArgs e)
        {
            switch (SDK.GetDeviceLayout())
            {
                case LAYOUT_KEYOBARD.LAYOUT_UNINIT: txt_layout.Text = "UNINIT"; break;
                case LAYOUT_KEYOBARD.LAYOUT_EU: txt_layout.Text = "EU"; break;
                case LAYOUT_KEYOBARD.LAYOUT_US: txt_layout.Text = "US"; break;
            }
        }

        private void set_effect_Click(object sender, EventArgs e)
        {
            SDK.SwitchLedEffect((EFF_INDEX)effects.SelectedValue);
        }

        private void set_single_Click(object sender, EventArgs e)
        {
            SDK.SetLedColor((byte)this.row.Value, (byte)this.column.Value, (byte)this.single_red.Value, (byte)this.single_green.Value, (byte)this.single_blue.Value);
        }

        private void set_all_Click(object sender, EventArgs e)
        {
            SDK.SetFullLedColor((byte)this.all_red.Value, (byte)this.all_green.Value, (byte)this.all_blue.Value);
        }
    }
}
