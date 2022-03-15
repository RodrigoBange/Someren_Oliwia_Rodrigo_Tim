using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public static class ErrorLogger
    {
        // Constructor 
        public static string LogError(Exception ex)
        {
            // Get file path to save to Log.txt
            string writePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string filePath = Path.Combine(writePath, "Log.txt");

            using (StreamWriter writer = new StreamWriter(filePath, true)) //If file exists, add to it or create a new file
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine($"An error occured: {ex.Message}");
                writer.WriteLine(ex.StackTrace);
                writer.WriteLine("-----------");

                //Close writer
                writer.Close();
            }

            // Return location of saved log
            return filePath;
        }
    }
}
