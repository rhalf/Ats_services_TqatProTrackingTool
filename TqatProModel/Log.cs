﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Diagnostics;

namespace TqatProModel {

    public class Log {
        public static void write(string logMessage, LogType logType, LogFileType logFileType) {

            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\TqatProTrackingTool\\logs";

            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }

            string logTypeValue = Enum.GetName(typeof(LogType), logType);
            string logFileTypeValue = Enum.GetName(typeof(LogFileType), logFileType);
            string dateValue = DateTime.Now.ToString("yyyyMMdd");

            string fileName = fullPath + "\\" + logTypeValue + "_" + dateValue + "." + logFileTypeValue;

            if (!File.Exists(fileName)) {
                try {
                    using (StreamWriter streamWriter = new StreamWriter(fileName, false)) {
                        streamWriter.WriteLine(logMessage);
                    }
                } catch {
                    //Do nothing
                }
            } else {
                try {
                    using (StreamWriter streamWriter = new StreamWriter(fileName, true)) {
                        streamWriter.WriteLine(logMessage);
                    }
                } catch {
                    //Do nothing
                }
            }

        }
        public static void write(Exception exception) {

            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\TqatProTrackingTool\\logs";

            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }

            string logTypeValue = Enum.GetName(typeof(LogType), LogType.EXCEPTION);
            string logFileTypeValue = Enum.GetName(typeof(LogFileType), LogFileType.TXT);
            string dateValue = DateTime.Now.ToString("yyyyMMdd");
            int lineNumber = new StackTrace(exception, true).GetFrame(0).GetFileLineNumber();
            int columnNumber = new StackTrace(exception, true).GetFrame(0).GetFileColumnNumber();

            string fileName = fullPath + "\\" + logTypeValue + "_" + dateValue + "." + logFileTypeValue;


            if (!File.Exists(fileName)) {
                try {
                    using (StreamWriter streamWriter = new StreamWriter(fileName, false)) {
                        streamWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + exception.Message + "\r\n\t\t\t" + exception.TargetSite + "\r\n\t\t\t" + exception.Source + "\r\n\t\t\t" + lineNumber.ToString() + ":" + columnNumber.ToString());
                    }
                } catch {
                    //Do nothing
                }
            } else {
                try {
                    using (StreamWriter streamWriter = new StreamWriter(fileName, true)) {
                        streamWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + exception.Message + "\r\n\t\t\t" + exception.TargetSite + "\r\n\t\t\t" + exception.Source + "\r\n\t\t\t" + lineNumber.ToString() + ":" + columnNumber.ToString());
                    }
                } catch {
                    //Do nothing
                }
            }

        }
    }
}


