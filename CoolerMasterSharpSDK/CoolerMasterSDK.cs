using CoolerMasterSharpSDK.Datatypes;
using CoolerMasterSharpSDK.Enums;
using CoolerMasterSharpSDK.Helpers;
using System;
using System.Runtime.InteropServices;

namespace CoolerMasterSharpSDK
{
    public class CoolerMasterSDK
    {
        /// <summary>
        /// Handle to the module
        /// </summary>
        private IntPtr DllHandler { get; set; }

        /// <summary>
        /// Max LED Row for Matrix Size
        /// </summary>
        public const byte MaxLedRow = 7;

        /// <summary>
        /// Max LED Column for Matrix Size
        /// </summary>
        public const byte MaxLedColumn = 24;

        private KeyCallbackEventHandler keyCallbackEventHandler;
        public event EventHandler<KeyCallbackEventArgs> KeyCallback;

        #region Pointers
        private GetSDKVersionPointer getSDKVersionPointer;
        private GetNowTimePointer getNowTimePointer;
        private GetCPUUsagePointer getCPUUsagePointer;
        private GetRamUsagePointer getRamUsagePointer;
        private GetVolumePeekPointer getVolumePeekPointer;
        private SetControlDevicePointer setControlDevicePointer;
        private IsDevicePluggedPointer isDevicePluggedPointer;
        private GetDeviceLayoutPointer getDeviceLayoutPointer;
        private EnableLedControlPointer enableLedControlPointer;
        private SwitchLedEffectPointer switchLedEffectPointer;
        private SetFullLedColorPointer setFullLedColorPointer;
        private SetAllLedColorPointer setAllLedColorPointer;
        private SetLedColorPointer setLedColorPointer;
        private EnableKeyInterruptPointer enableKeyInterruptPointer;
        private SetKeyCallBackPointer setKeyCallBackPointer;
        #endregion

        #region Delegates
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate int GetSDKVersionPointer();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate IntPtr GetNowTimePointer();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate int GetCPUUsagePointer(out uint errorCode);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate int GetRamUsagePointer();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate float GetVolumePeekPointer();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate void SetControlDevicePointer(Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool IsDevicePluggedPointer(Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate KeyboardLayouts GetDeviceLayoutPointer(Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool EnableLedControlPointer(bool enable, Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool SwitchLedEffectPointer(Effects effect, Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool SetFullLedColorPointer(byte r, byte g, byte b, Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool SetAllLedColorPointer(ColorMatrix matrix, Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool SetLedColorPointer(int row, int column, byte r, byte g, byte b, Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool EnableKeyInterruptPointer(bool enable, Devices device);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate void SetKeyCallBackPointer(KeyCallbackEventHandler handler, Devices device);
        private delegate void KeyCallbackEventHandler(int row, int column, bool pressed);
        #endregion

        public CoolerMasterSDK()
        {
            /// If the environment is x64, then use the dll located in the x64 folder, otherwise, use the dll located in the x86 folder.
            string path = $"{Environment.CurrentDirectory}\\Dlls\\{(Environment.Is64BitProcess ? "x64" : "x86")}\\SDKDLL.dll";

            // Loads the dll
            DllHandler = LoadLibrary(path);

            if (DllHandler == null)
                throw new Exception(Marshal.GetLastWin32Error().ToString());

            keyCallbackEventHandler = new KeyCallbackEventHandler(OnCallback);

            // Initiallize Pointers
            InitializeSDK();
        }

        private void InitializeSDK()
        {
            getSDKVersionPointer = (GetSDKVersionPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "GetCM_SDK_DllVer"), typeof(GetSDKVersionPointer));
            getNowTimePointer = (GetNowTimePointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "GetNowTime"), typeof(GetNowTimePointer));
            getCPUUsagePointer = (GetCPUUsagePointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "GetNowCPUUsage"), typeof(GetCPUUsagePointer));
            getRamUsagePointer = (GetRamUsagePointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "GetRamUsage"), typeof(GetRamUsagePointer));
            getVolumePeekPointer = (GetVolumePeekPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "GetNowVolumePeekValue"), typeof(GetVolumePeekPointer));
            setControlDevicePointer = (SetControlDevicePointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "SetControlDevice"), typeof(SetControlDevicePointer));
            isDevicePluggedPointer = (IsDevicePluggedPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "IsDevicePlug"), typeof(IsDevicePluggedPointer));
            getDeviceLayoutPointer = (GetDeviceLayoutPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "GetDeviceLayout"), typeof(GetDeviceLayoutPointer));
            enableLedControlPointer = (EnableLedControlPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "EnableLedControl"), typeof(EnableLedControlPointer));
            switchLedEffectPointer = (SwitchLedEffectPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "SwitchLedEffect"), typeof(SwitchLedEffectPointer));
            setFullLedColorPointer = (SetFullLedColorPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "SetFullLedColor"), typeof(SetFullLedColorPointer));
            setAllLedColorPointer = (SetAllLedColorPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "SetAllLedColor"), typeof(SetAllLedColorPointer));
            setLedColorPointer = (SetLedColorPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "SetLedColor"), typeof(SetLedColorPointer));
            enableKeyInterruptPointer = (EnableKeyInterruptPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "EnableKeyInterrupt"), typeof(EnableKeyInterruptPointer));
            setKeyCallBackPointer = (SetKeyCallBackPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(DllHandler, "SetKeyCallBack"), typeof(SetKeyCallBackPointer));
            keyCallbackEventHandler = new KeyCallbackEventHandler(OnCallback);
        }

        #region kernel32 Helpers
        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// <para>
        /// <a href="https://docs.microsoft.com/es-es/windows/desktop/api/libloaderapi/nf-libloaderapi-loadlibrarya">Read more</a>
        /// </para>
        /// </summary>
        /// <param name="path">
        /// <para>The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). The name specified is the file name of the module and is not related to the name stored in the library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.</para>
        /// <para>If the string specifies a full path, the function searches only that path for the module.</para>
        /// <para>If the string specifies a relative path or a module name without a path, the function uses a standard search strategy to find the module; for more information, see the Remarks.</para>
        /// <para>If the function cannot find the module, the function fails.When specifying a path, be sure to use backslashes (), not forward slashes (/). For more information about paths, see Naming a File or Directory.</para>
        /// <para>If the string specifies a module name without a path and the file name extension is omitted, the function appends the default library extension .dll to the module name.To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.</para>
        ///</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is a handle to the module.</para>
        /// <para>If the function fails, the return value is NULL.To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string path);

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// </summary>
        /// <param name="module">A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or GetModuleHandleEx function returns this handle.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is nonzero.</para>
        /// <para>If the function fails, the return value is zero.To get extended error information, call the GetLastError function.</para>
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr module);

        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="module">
        /// <para>A handle to the DLL module that contains the function or variable. The LoadLibrary, LoadLibraryEx, LoadPackagedLibrary, or GetModuleHandle function returns this handle.</para>
        /// <para>The GetProcAddress function does not retrieve addresses from modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. For more information, see LoadLibraryEx.</para>
        /// </param>
        /// <param name="name">The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is the address of the exported function or variable.</para>
        /// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr module, string name);
        #endregion

        #region SDK Methods
        /// <summary>
        /// Get SDK Dll's Version.
        /// </summary>
        /// <returns>DLL's Version</returns>
        public int GetSDKVersion => getSDKVersionPointer();

        /// <summary>
        /// Obtain current system time.
        /// </summary>
        /// <returns>String with format %Y %m/%d %H:%M %S</returns>
        public string GetNowTime => Marshal.PtrToStringUni(getNowTimePointer());

        /// <summary>
        /// Obtain current CPU usuage ratio.
        /// </summary>
        /// <returns>0 ~ 100 integer</returns>
        public int GetNowCPUUsage(out uint errorCode) => getCPUUsagePointer(out errorCode);

        /// <summary>
        /// Obtain current RAM usuage ratio.
        /// </summary>
        /// <returns>0 ~ 100 integer</returns>
        public int GetRamUsage => getRamUsagePointer();

        /// <summary>
        /// Obtain current volume
        /// </summary>
        /// <returns>0 ~ 1 float</returns>
        public float GetVolumePeak => getVolumePeekPointer();

        /// <summary>
        /// Set default operating device.
        /// </summary>
        /// <param name="device">Target device</param>
        public void SetControlDevice(Devices device) => setControlDevicePointer(device);

        /// <summary>
        /// Verify if the deviced is plugged in.
        /// </summary>
        /// <param name="device">Target device</param>
        /// <returns>true plugged in, false not plugged in</returns>
        public bool IsDevicePlugged(Devices device) => isDevicePluggedPointer(device);

        /// <summary>
        /// Obtain current device layout.
        /// </summary>
        /// <param name="device">Target device</param>
        /// <returns><see cref="KeyboardLayouts"/></returns>
        public KeyboardLayouts GetDeviceLayout(Devices device) => getDeviceLayoutPointer(device);

        /// <summary>
        /// Set control over device’s LED.
        /// </summary>
        /// <param name="enable">true controlled by SW, false controlled by FW</param>
        /// <param name="device">Target device</param>
        /// <returns>true Success,false Fail</returns>
        public bool EnableLedControl(bool enable, Devices device) => enableLedControlPointer(enable, device);

        /// <summary>
        /// Switch device current effect.
        /// </summary>
        /// <param name="effect">Index value of the effect</param>
        /// <param name="device">Target device</param>
        /// <returns>true Success，false Fail</returns>
        public bool SwitchLedEffect(Effects effect, Devices device) => switchLedEffectPointer(effect, device);

        /// <summary>
        /// Set entire keyboard LED one color.
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <param name="device">Target device</param>
        /// <returns>true Success，false Fail</returns>
        public bool SetFullLedColor(byte r, byte g, byte b, Devices device) => setFullLedColorPointer(r, g, b, device);

        /// <summary>
        /// Set Keyboard "every LED" color.
        /// </summary>
        /// <param name="matrix"><see cref="ColorMatrix"/> KeyColor matrix</param>
        /// <param name="device">Target device</param>
        /// <returns>true Success,false Fail</returns>
        public bool SetAllLedColor(ColorMatrix matrix, Devices device) => setAllLedColorPointer(matrix, device);

        /// <summary>
        /// Set single Key LED color.
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="column">Column</param>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <param name="device">Target device</param>
        /// <returns>true Success,false Fail</returns>
        public bool SetLedColor(int row, int column, byte r, byte g, byte b, Devices device) => setLedColorPointer(row, column, r, g, b, device);

        /// <summary>
        /// To enable the call back function.
        /// </summary>
        /// <param name="enable">true enable, false disable</param>
        /// <param name="device">Target device</param>
        /// <returns>true Success,false Fail</returns>
        public bool EnableKeyInterrupt(bool enable, Devices device) => enableKeyInterruptPointer(enable, device);

        /// <summary>
        /// To enable the call back function.
        /// </summary>
        /// <param name="device">Target device</param>
        /// <returns>true Success,false Fail</returns>
        public void SetKeyCallBack(bool enable, Devices device)
        {
            if(enable) setKeyCallBackPointer(keyCallbackEventHandler, device);
            else setKeyCallBackPointer(null, device);
        }

        private void OnCallback(int row, int column, bool pressed)
        {
            KeyCallback(this, new KeyCallbackEventArgs(row, column, pressed));
        }
        #endregion
    }
}
