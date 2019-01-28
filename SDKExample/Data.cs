using CoolerMasterSharpSDK.Datatypes;
using CoolerMasterSharpSDK.Enums;
using CoolerMasterSharpSDK.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string systemTime;

        public string SystemTime
        {
            get { return systemTime; }
            set {
                systemTime = value;
                OnPropertyChanged("SystemTime");
            }
        }

        private int cpuUsage;

        public int CPUUsage
        {
            get { return cpuUsage; }
            set {
                cpuUsage = value;
                OnPropertyChanged("CPUUsage");
            }
        }

        public uint CPUErrorCode { get; set; }

        private int ramUsage;

        public int RamUsage
        {
            get { return ramUsage; }
            set {
                ramUsage = value;
                OnPropertyChanged("RamUsage");
            }
        }

        private float volumePeak;

        public float VolumePeak
        {
            get { return volumePeak; }
            set {
                volumePeak = value;
                OnPropertyChanged("VolumePeak");
            }
        }

        private Devices device;

        public Devices Device
        {
            get { return device; }
            set {
                device = value;
                OnPropertyChanged("Device");
            }
        }

        private KeyboardLayouts? keyboardLayout;

        public KeyboardLayouts? KeyboardLayout
        {
            get { return keyboardLayout; }
            set {
                keyboardLayout = value;
                OnPropertyChanged("KeyboardLayout");
            }
        }

        private Effects effect;

        public Effects Effect
        {
            get { return effect; }
            set {
                effect = value;
                OnPropertyChanged("Effect");
            }
        }

        private ColorMatrix colorMatrix;

        public ColorMatrix ColorMatrix
        {
            get { return colorMatrix; }
            set {
                colorMatrix = value;
                OnPropertyChanged("ColorMatrix");
            }
        }

        private int dllVersion;

        public int DLLVersion
        {
            get { return dllVersion; }
            set {
                dllVersion = value;
                OnPropertyChanged("DLLVersion");
            }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set {
                status = value;
                OnPropertyChanged("Status");
            }
        }



        public bool LEDControl { get; set; }

        public Data()
        {
            colorMatrix = new ColorMatrix();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
