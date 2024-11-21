using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V2MCRPLib;

namespace V2MCFormsApp
{
    public class FormLogger : ILogger
    {
        Label LogBox;
        string PackName;

        public ILogger.LogLevel Level { get; set; }
        public FormLogger(ILogger.LogLevel logLevel, Label box)
        {
            Level = logLevel;
            LogBox = box;
        }
        public void Log(string message, ILogger.LogLevel level, bool overwrite = false)
        {
            message = message.Replace("\n", "");
            message = message.Replace("\r", "");
            message = message.Trim();
            //overwrite = Overwrite;
            if (level >= Level)
            {
                if (overwrite)
                {
                    //message = "\r" + message + "                 ";
                    LogBox.Invoke(() => LogBox.Text = message);

                    return;
                }

                try
                {
                    LogBox.Invoke(() => LogBox.Text = message);
                }
                catch (Exception ex)
                {
                    if (ex is not InvalidOperationException)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            
        }
    }
}
