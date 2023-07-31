using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VB62DotNetLoader.com.vb62dnl.Classes;

namespace VB62DotNetLoader.UI.Forms
{
    public class ConfigurationInformation
    {
        private string DLLName;
        private string DLLPath;
        private bool DLLStatus;


        public string Name { get { return DLLName; } }
        public string Path { get { return DLLPath; } }
        public bool Status { get { return DLLStatus; } }

        public ConfigurationInformation(string DLLName , string DLLPath, bool Status)
        {
            this.DLLName = DLLName;
            this.DLLPath = DLLPath;
            this.DLLStatus = Status;
        }

        public static void LoadConfiguration(string FilePath,List<ConfigurationInformation> currentConfig, PluginManager pm)
        {
            LocalLogger.WriteLog("VB62DotNetLoader::LoadConfiguration(FilePath,currentConfig) => " + FilePath, LocalLogger.ApplicationLogs, true, true);
            FileStream fs = null;
            StreamReader sr = null;

            // Check if file is Absolute path or Same Directory
            string AbsolutePath = "";

            if (FilePath.Contains(":"))
                AbsolutePath = FilePath;
            else
                AbsolutePath = pm.CoreExecutableDirectory + @"\" + FilePath;

            if (!File.Exists(AbsolutePath)) {
                LocalLogger.WriteLog("VB62DotNetLoader::LoadConfiguration(FilePath,currentConfig) => File "  + Environment.NewLine +  AbsolutePath + " doesn't exist.", LocalLogger.ApplicationLogs, true, true);
                return;
            }

            try
            {
                fs = new FileStream(AbsolutePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fs);


                string _header = sr.ReadLine();
                Console.WriteLine("HEADER: " + _header);
    
                while(!sr.EndOfStream)
                {
                    string _info_line = sr.ReadLine();
                    byte[] buffer = null;
                    buffer = StringToBytes(_info_line);
                    Flip(buffer);
                    _info_line = BytesToString(buffer);

                    string[] _main_token = _info_line.Split('=');
                    string[] _sub_tokens = _main_token[1].Split(';');

                    ConfigurationInformation configItem = new ConfigurationInformation(_sub_tokens[0], _sub_tokens[1], bool.Parse(_sub_tokens[2]));

                    LocalLogger.WriteLog("Loading Plugin: " + configItem.Name + ":" + configItem.Status, LocalLogger.ApplicationLogs, true, true);
              
                    currentConfig.Add(configItem);
                }

                sr.Close();
                fs.Close();
                sr.Dispose();
                fs.Dispose();
                sr = null;
                fs = null;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void SaveConfiguration(string FilePath, List<ConfigurationInformation> currentConfig)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                sw = new StreamWriter(fs);
                int config_id = 1;

                string _header = "VB6DotNetLoader Configuration File Version: " + DateTime.Now.ToLocalTime().ToString("MM-dd-yyyy dddd hh:mm:ss tt");

                sw.WriteLine(_header);
                foreach (ConfigurationInformation elementConfig in currentConfig)
                {
                    string _info_line = config_id.ToString() + "=" + elementConfig.DLLName + ";" + elementConfig.DLLPath + ";" + elementConfig.DLLStatus.ToString();
                    byte[] buffer = null;
                    buffer = StringToBytes(_info_line);
                    Flip(buffer);
                    _info_line = BytesToString(buffer);

                    sw.WriteLine(_info_line);
                }

                sw.Close();
                fs.Close();
                sw.Dispose();
                fs.Dispose();
                sw = null;
                fs = null;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void Flip(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)((byte)buffer[i] ^ (byte)128);
            }
        }

        public static string BytesToString(byte[] buffer)
        {
            string _ret = "";

            for (int i = 0; i < buffer.Length; i++)
            {
                _ret += (char)buffer[i];
            }

            return _ret;
        }

        public static byte[] StringToBytes(string buffer)
        {
            byte[] _ret = new byte[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {
                _ret[i] += (byte)buffer[i];
            }

            return _ret;
        }

    }
}
