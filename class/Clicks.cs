using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//youtube mydcHC6379A
namespace SimulateMouseClick
{
    public class Clicks
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraData);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x0000002,
            LEFTUP = 0x0000004,
            MIDDLEDOWN = 0x0000020,
            MIDDLEUP = 0x0000040,
            MOVE = 0x0000001,
            ABSOLUTE= 0x0008000,
            RIGHTDOWN = 0x0000008,
            RIGHTUP = 0x00000010
        }

        public void leftClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }
        public void rightClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }
        public void middleClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.MIDDLEDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.MIDDLEUP), 0, 0, 0, 0);
        }
        public void doubleClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }        

        public void MoveMouse(Point p)
        {
            Cursor.Position = p;
        }
    }
}
