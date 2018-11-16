using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardToKeystrokes
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern uint SendInput(int nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] inputs, int cbSize);

        private GlobalHotkey ghk;

        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        public class Modifiers
        {
            //modifiers
            public const int NOMOD = 0x0000;
            public const int ALT = 0x0001;
            public const int CTRL = 0x0002;
            public const int SHIFT = 0x0004;
            public const int WIN = 0x0008;
        }

        Char[] SpecialCharacters = "~!@#$%^&*()_+{}|:\"<>?".ToCharArray();

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public INPUTTYPE type;
            public INPUT_U u;

            public static INPUT VirtualKeyDown(byte keyCode)
            {
                var input = new INPUT() { type = INPUTTYPE.Keyboard };
                input.u.ki = new KEYBDINPUT() { virtualKey = keyCode };

                return input;
            }

            public static INPUT VirtualKeyUp(byte keyCode)
            {
                var input = new INPUT() { type = INPUTTYPE.Keyboard };
                input.u.ki = new KEYBDINPUT() { virtualKey = keyCode, flags = KEYEVENTF.KeyUp };

                return input;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT_U
        {
            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort virtualKey;
            public ushort scanCode;
            public KEYEVENTF flags;
            public uint time;

            public IntPtr extraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr extraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParam;
            public short lParam;
        }

        private enum INPUTTYPE : uint
        {
            Keyboard = 1
        }

        private enum KEYEVENTF : uint
        {
            KeyUp = 2,
        }

        public Form1()
        {
            InitializeComponent();
            ghk = new GlobalHotkey(Modifiers.CTRL + Modifiers.SHIFT, Keys.Space, Handle);
        }

        private void HandleHotkey()
        {
            int batchSize;
            try
            {
                batchSize = Convert.ToInt32(batchSizeTB.Text);
            }
            catch
            {
                batchSize = 1000;
            }
            int delay;
            try
            {
                delay = Convert.ToInt32(delayTB.Text);
            }
            catch
            {
                delay = 2000;
            }
            String cp = Clipboard.GetText();

            // wait until there are no modifiers
            while ((Control.ModifierKeys) != 0)
            {
                System.Threading.Thread.Sleep(10);
            }
            WriteLine("Typed " + cp.Length + " characters.");
            if (cb_shiftReturn.Checked)
            {
                cp = cp.Replace("\r\n", "\n");
            }
            Char[] characters = cp.ToCharArray();
            List<INPUT> inputs = new List<INPUT>();
            foreach (Char character in characters)
            {
                short shorty = VkKeyScan(character);
                Boolean addShift = checkShift(character, shorty);

                if (cb_shiftReturn.Checked && character == '\n')
                {
                    addShift = true;
                }

                if (addShift)
                {
                    inputs.Add(INPUT.VirtualKeyDown((byte)Keys.LShiftKey));
                }
                inputs.Add(INPUT.VirtualKeyDown((byte)shorty));
                inputs.Add(INPUT.VirtualKeyUp((byte)shorty));
                if (addShift)
                {
                    inputs.Add(INPUT.VirtualKeyUp((byte)Keys.LShiftKey));
                }

                var error = Marshal.GetLastWin32Error();
            }

            INPUT[] inputsToSend = inputs.ToArray();
            int i = 0;
            while (i < inputsToSend.Length)
            {
                int newExtent = i + batchSize;
                if (inputsToSend.Length < newExtent)
                {
                    newExtent = inputsToSend.Length;
                }
                INPUT[] chunk = new ArraySegment<INPUT>(inputsToSend, i, newExtent - i).ToArray();
                SendInput(chunk.Length, chunk, Marshal.SizeOf(typeof(INPUT)));
                i = newExtent;
                System.Threading.Thread.Sleep(delay);
            }
        }

        private Boolean checkShift(Char character, short shorty)
        {
            Boolean res = false;
            string charString = character.ToString();
            string upper = charString.ToUpper();
            string lower = charString.ToLower();
            if (upper == lower)
            {
                if (SpecialCharacters.Contains(character))
                {
                    res = true;
                }
            }
            else if (charString == upper)
            {
                res = true;
            }
            return res;
        }

        protected override void WndProc(ref Message m)
        {
            //windows message id for hotkey
            int WM_HOTKEY_MSG_ID = 0x0312;
            if (m.Msg == WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLine("Trying to register CTRL+SHIFT+Space");
            if (ghk.Register())
            {
                WriteLine("Hotkey registered.");
            }
            else
            {
                WriteLine("Hotkey failed to register");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");
        }

        private void WriteLine(string text)
        {
            textBox1.Text += text + Environment.NewLine;
        }
    }
}
