using CoolerMasterSharpSDK;
using CoolerMasterSharpSDK.Datatypes;
using CoolerMasterSharpSDK.Enums;
using CoolerMasterSharpSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Data Data { get; set; }
        public CoolerMasterSDK SDK { get; set; }

        public Timer Timer { get; set; }

        public MainWindow()
        {
            SDK = new CoolerMasterSDK();

            Data = new Data();
            InitializeComponent();
            DataContext = Data;
            Timer = new Timer
            {
                Interval = 500,
                AutoReset = true,
                Enabled = true
            };
            Timer.Elapsed += Timer_Elapsed;
            Data.DLLVersion = SDK.GetSDKVersion;
            SDK.KeyCallback += SDK_KeyCallback;
            Data.Status = "Ready";
        }

        private void SDK_KeyCallback(object sender, KeyCallbackEventArgs e)
        {
            Data.Status = $"KeyCallback Event (Row: {e.Row}, Column: {e.Column}, Pressed: {e.Pressed})";
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Data.SystemTime = SDK.GetNowTime;
            uint errorCode = 0x0;
            Data.CPUUsage = SDK.GetNowCPUUsage(out errorCode);
            Data.CPUErrorCode = errorCode;
            Data.RamUsage = SDK.GetRamUsage;
            Data.VolumePeak = SDK.GetVolumePeak;
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Error code 0x{Data.CPUErrorCode.ToString("x")}. There is no data to return.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int[] rows = new int[CoolerMasterSDK.MaxLedRow];
            int[] cols = new int[CoolerMasterSDK.MaxLedColumn];

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = i;
            }

            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = i;
            }

            dropRow.ItemsSource = rows;
            dropCol.ItemsSource = cols;

            dropRow.SelectedIndex = 0;
            dropCol.SelectedIndex = 0;
        }

        private void btnSetDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SDK.SetControlDevice(Data.Device);

                var description = new EnumDescriptionTypeConverter(typeof(Devices)).ConvertTo(Data.Device, typeof(string));

                Data.Status = $"Default operating device is now: {description}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dropDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkKeyEffect.IsChecked = false;

            SDK.EnableKeyInterrupt(checkKeyEffect.IsChecked ?? false, Data.Device);
            SDK.SetKeyCallBack(checkKeyEffect.IsChecked ?? false, Data.Device);

            Data.Device = (Devices)dropDevices.SelectedIndex;

            switch (Data.Device)
            {
                case Devices.DEV_MMouse_L:
                case Devices.DEV_MMouse_S:
                case Devices.DEV_MM520:
                case Devices.DEV_MM530:
                    Data.KeyboardLayout = null;
                    btnGetLayout.IsEnabled = false;
                    break;
                default:
                    btnGetLayout.IsEnabled = true;
                    break;
            }
        }

        private void btnGetLayout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.KeyboardLayout = SDK.GetDeviceLayout(Data.Device);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCheckDevicePlug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var isPlugged = SDK.IsDevicePlugged(Data.Device);

                MessageBox.Show(isPlugged ? "Device is plugged!!!" : "Device is not plugged :(", "Info", MessageBoxButton.OK, isPlugged ? MessageBoxImage.Information : MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLEDControl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = SDK.EnableLedControl(!Data.LEDControl, Data.Device);

                if(result)
                {
                    Data.LEDControl = !Data.LEDControl;
                    btnLEDControl.Content = Data.LEDControl ? "Disable" : "Enable";
                }
                else MessageBox.Show("Operation failed, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSetEffect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = SDK.SwitchLedEffect(Data.Effect, Data.Device);

                if(!result)
                {
                    MessageBox.Show("Could not set this effect, maybe the device does not support this effect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dropEffects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Effect = (Effects)dropEffects.SelectedIndex;
        }

        private void txtMatrixR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMatrixG_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMatrixB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMatrixR_LostFocus(object sender, RoutedEventArgs e)
        {
            int row = (int)dropRow.SelectedItem;
            int col = (int)dropCol.SelectedItem;

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMatrixR.Text)) txtMatrixR.Text = "0";
            else if(int.Parse(txtMatrixR.Text) > 255) txtMatrixR.Text = "255";
            else if (int.Parse(txtMatrixR.Text) < 0) txtMatrixR.Text = "0";

            Data.ColorMatrix.KeyColors[row, col] = new KeyColor(byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text));
        }

        private void txtMatrixG_LostFocus(object sender, RoutedEventArgs e)
        {
            int row = (int)dropRow.SelectedItem;
            int col = (int)dropCol.SelectedItem;

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMatrixG.Text)) txtMatrixG.Text = "0";
            else if(int.Parse(txtMatrixG.Text) > 255) txtMatrixG.Text = "255";
            else if (int.Parse(txtMatrixG.Text) < 0) txtMatrixG.Text = "0";

            Data.ColorMatrix.KeyColors[row, col] = new KeyColor(byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text));
        }

        private void txtMatrixB_LostFocus(object sender, RoutedEventArgs e)
        {
            int row = (int)dropRow.SelectedItem;
            int col = (int)dropCol.SelectedItem;

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtMatrixB.Text)) txtMatrixB.Text = "0";
            else if (int.Parse(txtMatrixB.Text) > 255) txtMatrixB.Text = "255";
            else if (int.Parse(txtMatrixB.Text) < 0) txtMatrixB.Text = "0";

            Data.ColorMatrix.KeyColors[row, col] = new KeyColor(byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text));
        }

        private void btnSetSingleKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int row = (int)dropRow.SelectedItem;
                int col = (int)dropCol.SelectedItem;

                Data.ColorMatrix.KeyColors[row, col] = new KeyColor(byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text));

                bool result = SDK.SetLedColor(row, col, byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text), Data.Device);

                if (!result)
                    MessageBox.Show("Could not set key color, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSetAllKeys_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = SDK.SetAllLedColor(Data.ColorMatrix, Data.Device);

                if (!result)
                    MessageBox.Show("Could not set keys colors, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dropRow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int row = dropRow.SelectedIndex >= 0 ? dropRow.SelectedIndex : 0;
            int col = dropCol.SelectedIndex >= 0 ? dropCol.SelectedIndex : 0;

            Data.ColorMatrix.KeyColors[row, col] = new KeyColor(byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text));
        }

        private void dropCol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int row = dropRow.SelectedIndex >= 0 ? dropRow.SelectedIndex : 0;
            int col = dropCol.SelectedIndex >= 0 ? dropCol.SelectedIndex : 0;

            Data.ColorMatrix.KeyColors[row, col] = new KeyColor(byte.Parse(txtMatrixR.Text), byte.Parse(txtMatrixG.Text), byte.Parse(txtMatrixB.Text));
        }

        private void txtAllColorR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtAllColorG_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtAllColorB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtAllColorR_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtAllColorR.Text)) txtAllColorR.Text = "0";
            else if (int.Parse(txtAllColorR.Text) > 255) txtAllColorR.Text = "255";
            else if (int.Parse(txtAllColorR.Text) < 0) txtAllColorR.Text = "0";
        }

        private void txtAllColorG_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtAllColorG.Text)) txtAllColorG.Text = "0";
            else if (int.Parse(txtAllColorG.Text) > 255) txtAllColorG.Text = "255";
            else if (int.Parse(txtAllColorG.Text) < 0) txtAllColorG.Text = "0";
        }

        private void txtAllColorB_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtAllColorB.Text)) txtAllColorB.Text = "0";
            else if (int.Parse(txtAllColorB.Text) > 255) txtAllColorB.Text = "255";
            else if (int.Parse(txtAllColorB.Text) < 0) txtAllColorB.Text = "0";
        }

        private void btnSetAllColor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = SDK.SetFullLedColor(byte.Parse(txtAllColorR.Text), byte.Parse(txtAllColorG.Text), byte.Parse(txtAllColorB.Text), Data.Device);

                if(!result)
                    MessageBox.Show("Could not set keys colors, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void checkKeyEffect_Checked(object sender, RoutedEventArgs e)
        {
            SDK.EnableKeyInterrupt(checkKeyEffect.IsChecked ?? false, Data.Device);
            SDK.SetKeyCallBack(checkKeyEffect.IsChecked ?? false, Data.Device);
        }
    }
}
