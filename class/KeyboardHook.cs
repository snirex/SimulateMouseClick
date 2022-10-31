using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateMouseClick
{
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Contorl = 2,
        Shift = 3,
        Win = 8
    }

    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier { get { return _modifier; } }

        public Keys Key { get { return _key; } }
    }

    public sealed class KeyboardHook : IDisposable
    {
        // Register a hot key with windows
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        // Unregister a hot key with windows
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Represents the window that is used internally to get the messages
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                //create the handle for the window
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                //check if we got a hot key pressed
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    //invoke the event to notify the parent
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Memebers

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion

        }

        private readonly Window _window = new Window();
        private int _currentId;
        public KeyboardHook()
        {
            // Register the event of the inner native window
            _window.KeyPressed += (s, a) =>
            {
                if (KeyPressed != null)
                    KeyPressed(this, a);
            };
        }
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void RegisterHotKey(ModifierKeys modifierm, Keys key)
        {
            //increment the counter
            _currentId = _currentId + 1;

            //register the hot key
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifierm, (uint)key))
                throw new InvalidOperationException("Error: Could not register the hot key.");
        }

        public void UnRegisterHotKey(ModifierKeys modifierm, Keys key)
        {
            //increment the counter
            _currentId = _currentId + 1;

            //register the hot key
            if (!UnregisterHotKey(_window.Handle, _currentId))
                throw new InvalidOperationException("Error: Could not un-register the hot key.");
        }

        public void Dispose()
        {
            //unregister all the registered hot keys
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            _window.Dispose();
        }
    }
}
