using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeyEvents
{
    public partial class Form1 : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;

        //public Form1()
        //{
        //    InitializeComponent();         
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //labelOutput.Text += $" {e.KeyChar}";
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //labelOutput.Text += $" {e.KeyCode}";

        }
        private static LowLevelKeyboardProc _keyboardProc = KeyboardHookCallback;
        private static LowLevelMouseProc _mouseProc = mousehookcallback;
        private static IntPtr _keyboardHookID = IntPtr.Zero;
        private static IntPtr _mouseHookID = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
            _keyboardHookID = SetHook(_keyboardProc, WH_KEYBOARD_LL);
            _mouseHookID = SetHook(_mouseProc, WH_MOUSE_LL);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_keyboardHookID);
            UnhookWindowsHookEx(_mouseHookID);
            base.OnFormClosing(e);
        }

        private static IntPtr SetHook(Delegate proc, int hookType)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(hookType, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        //Nhan ban phim
        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                UpdateLabel($" {(Keys)vkCode}");
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }

        private static IntPtr mousehookcallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    UpdateLabel(" Mouse_Left_Button_Clicked");
                }
                else if (wParam == (IntPtr)WM_RBUTTONDOWN)
                {
                    UpdateLabel(" Mouse_Right_Button_Clicked");
                }
            }
            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }
        private static void UpdateLabel(string text)
        {
            if (Application.OpenForms.Count > 0)
            {
                var form = Application.OpenForms[0] as Form1;
                if (form != null && form.labelOutput.InvokeRequired)
                {
                    form.labelOutput.Invoke(new Action(() => form.labelOutput.Text = text));
                }
                else if (form != null)
                {
                    form.labelOutput.Text += text;
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, Delegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}