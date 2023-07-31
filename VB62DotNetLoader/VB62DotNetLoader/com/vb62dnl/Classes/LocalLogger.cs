using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;


namespace VB62DotNetLoader.com.vb62dnl.Classes
{
    /// <summary>
    /// This class is use for creating txt logs
    /// </summary>
    public class LocalLogger
    {
        public static string ErrorLogs;
        public static string ApplicationLogs;
        /// <summary>
        /// Get the list of running processes
        /// </summary>
        /// <returns>A List<Process> object instance</returns>
        public static List<Process> GetProcesses(Action<Process> callback) 
        {
            List<Process> processList = new List<Process>();

            foreach(Process processItem in Process.GetProcesses())
            {
                if (callback != null) {
                    callback(processItem);
                }
                processList.Add(processItem);
            }

            return processList;
        }

        public static string NegateCrypt(string parameter) 
        {
            byte[] byte_pword = Encoding.ASCII.GetBytes(parameter);
            for (int x = 0; x < byte_pword.Length; x++) 
            {
                byte_pword[x] = (byte)(byte_pword[x] ^ 128);
            }

            string ret = Encoding.ASCII.GetString(byte_pword);

            return ret;
        }

        public static string CreateLogFileName(string RootFolder, string SubFolder, string Filename) 
        {
            string tempFolder = RootFolder;
            tempFolder = tempFolder + @"\" + SubFolder;
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
                Thread.Sleep(1000);
            }

            return tempFolder + @"\" + Filename;
        }

        public static long GetCurrentlyUsedMemory() 
        {
            return System.GC.GetTotalMemory(true);
        }

        public static ulong GetAvailableMemory()
        {
            ComputerInfo info = new ComputerInfo();
            return info.AvailablePhysicalMemory;
        }

        public static ulong GetTotalMemory()
        {
            ComputerInfo info = new ComputerInfo();
            return info.TotalPhysicalMemory;
        }

        private static string GetComputerInformation() 
        {
            ComputerInfo info = new ComputerInfo();

            double total_vm = (double)LocalLogger.GetTotalMemory();
            double total_avm = (double)LocalLogger.GetAvailableMemory();
            double size_ratio = Math.Round((total_avm / total_vm) * 100, 2);


            string _info = "----------------------------------------------------------------\n";
            _info += "The following information can help to determine the following:";
            _info += "\n* Available Memory";
            _info += "\n* Running Applications and resource usage(Memory)";
            _info += "\nOS Fullname: " + info.OSFullName + "\n";
            _info += "OS Platform: " + info.OSPlatform + "\n";
            _info += "OS Version: " + info.OSVersion + "\n";
            _info += "Total Physical Memory: " + Math.Round(total_vm / 1024,2) + " Kbyte(s)";
            _info += "\nTotal Available Physical Memory: " + Math.Round(total_avm / 1024) + " Kbyte(s)";
            _info += "\nTotal CIC Physical Memory Used: " + Math.Round(((double)GetCurrentlyUsedMemory()) / 1024, 2) + " Kbyte(s)";
            _info += "\nTotal Remaining Physical Memory(%): " + size_ratio + "%";
            _info += "\nTotal Process(es) Count: " + GetProcesses(null).Count;
            _info += "\n----------------------------------------------------------------";

            return _info;
        }

        private static void WriteProcessListInLog(string filePath) 
        {
            Action<Process> callback = (Process process) =>
            {
                try
                {
                    string procInfo = "Process: "  + process.Id 
                    + "\nName: " + process.ProcessName
                    + "\nWindow Title: " +  process.MainWindowTitle
                    + "\nPrivate Memory Size: " + Math.Round(((double)process.PrivateMemorySize64) / 1024,2) + " Kbyte(s)"
                    + "\nMemory Used: " + Math.Round(((double)process.WorkingSet64) / 1024, 2) + " byte(s)"
                    + "\nFilePath: " + process.MainModule.FileName;
                    WriteLog(procInfo, filePath , true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    WriteLog("\t\tError:\tCannot obtain other information of process " + process.Id + ";" + process.ProcessName + ";" ,
                            filePath,        
                            true);
                }
            };

            GetProcesses(callback);
        }

        public static string GetCurrentDateTime() 
        {
            return DateTime.Now.ToLocalTime().ToString("MM/dd/yyyy hh:mm:ss");
        }

        public static void WriteLogHeader(string title, string filepath) 
        {
            WriteLog(title,filepath,false);
            WriteLog(GetCurrentDateTime(), filepath,true);
            WriteLog(GetComputerInformation(), filepath, true);
            WriteProcessListInLog(filepath);
        }

        public static void WriteLogFooter(string title, string filepath)
        {
            WriteLog(title, filepath, true);
            WriteLog(GetCurrentDateTime(), filepath, true);
        }

        public static void WriteLog(string dataLine , string filepath , bool append, bool withTimeStamp = false) 
        {
            if (!File.Exists(filepath) && append) append = false;

            if (withTimeStamp)
                dataLine = DateTime.Now.ToLocalTime().ToString("MM/dd/yyyy hh:mm:ss tt") + " -- " + dataLine;

            if (!append)
                WriteLogCreate(dataLine, filepath);
            else
                WriteLogAppend(dataLine, filepath);


        }

        private static void WriteLogCreate(string dataLine, string filepath) 
        {
            FileStream stream = null;
            StreamWriter writer = null;

            try
            {
                stream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                writer = new StreamWriter(stream);

                writer.WriteLine(dataLine);

                writer.Close();
                stream.Close();
                writer.Dispose();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (stream != null)
                {
                    if (stream.CanRead || stream.CanWrite) stream.Close();
                    stream = null;
                }

                if (writer != null)
                {
                    writer = null;
                }
            }
        }

        private static void WriteLogAppend(string dataLine, string filepath)
        {
            FileStream stream = null;
            StreamWriter writer = null;

            try
            {
                stream = new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.None);
                writer = new StreamWriter(stream);

                writer.WriteLine(dataLine);

                writer.Close();
                stream.Close();
                writer.Dispose();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (stream != null)
                {
                    if (stream.CanRead || stream.CanWrite) stream.Close();
                    stream = null;
                }

                if (writer != null)
                {
                    writer = null;
                }
            }
        }


    }
}
