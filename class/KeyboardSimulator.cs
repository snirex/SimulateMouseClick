using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateMouseClick
{
    public class KeyboardSimulator
    {
        //[DllImport("user32.dll")]
        //public static extern int SetForegroundWindow(IntPtr hWnd);

        //public void TypeText(string text, string processName)
        //{
        //    return;


        //    Process[] prc = Process.GetProcessesByName(processName);
        //    if (prc.Length == 0)
        //        return;
        //    foreach (var p in prc)
        //    {
        //        SetForegroundWindow(p.MainWindowHandle);
        //        for (int i = 0; i < text.Length; i++)
        //        {
        //            SendKeys.SendWait($"{text[i]}");
        //        }
        //    }
        //}
    }
}
