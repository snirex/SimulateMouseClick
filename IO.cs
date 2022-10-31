using System;
using System.IO;
using System.Windows.Forms;

namespace SimulateMouseClick
{
    internal class IO
    {
        internal static bool WriteFileContent(string fileName, string content)
        {
            try
            {
                File.WriteAllText(fileName, content);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        internal static string ReadFilePath(string filePath)
        {
            string result = "";
            try
            {
                result = File.ReadAllText(filePath);
            }
            catch (IOException ex)
            { }
            return result;
        }
    }
}