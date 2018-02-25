using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cheque.Writing.Common.Logger
{
    public class ServiceFileLogger : ILogger
    {
        string _fileName = string.Empty;
        string _dateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        /// <summary>
        /// Initialize a new instance of ServiceLogger.
        /// Log file will be created automatically if not yet exists, else it can be either a fresh new file or append to the existing file.
        /// Default is create a fresh new log file.
        /// </summary>
        /// <param name="append">Default value is True to append to existing log file, False to overwrite and create new log file</param>

        public ServiceFileLogger(bool append = true)
        {
             string appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");
            _fileName = string.Format("{0}\\Platypus{1}.log",appDataFolder, DateTime.Now.ToString("MM-dd-yy"));

            // Log file header line
            string logHeader = $"Creating a file {_fileName}";
            if (!File.Exists(_fileName))
            {
                WriteLogtoFile(logHeader, LogTypes.INFO, false);
            }
            else if (append == false) // create the file only if append is false
            {
                WriteLogtoFile(logHeader, LogTypes.INFO, false);
            }
        }
        /// <summary>
        /// Log Error
        /// </summary>
        public void Error(string message)
        {
            WriteLogtoFile(message, LogTypes.ERROR);
        }

        public void Information(string message)
        {
            WriteLogtoFile(message, LogTypes.INFO);
        }
        /// <summary>
        /// Write Warning 
        /// </summary>
        public void Warning(string message)
        {
            WriteLogtoFile(message, LogTypes.WARNING);
        }

        /// <summary>
        /// Write a line of formatted log message into a log file
        /// </summary>
        /// <param name="text">Formatted log message</param>
        /// <param name="append">True to append, False to overwrite the file</param>
        /// <exception cref="System.IO.IOException"></exception>
        private void WriteLogtoFile(string text, LogTypes logType, bool append = true)
        {
            var currentTime = logType.ToString() + Environment.NewLine + DateTime.Now.ToString(_dateTimeFormat) + Environment.NewLine;
            try
            {
                using (StreamWriter stream = new StreamWriter(_fileName, append, Encoding.UTF8))
                {
                    if (text != "") stream.WriteLine(text);
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
