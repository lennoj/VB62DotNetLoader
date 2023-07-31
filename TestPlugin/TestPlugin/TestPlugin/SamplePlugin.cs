﻿using System;
using System.Collections.Generic;
using System.Text;
using VB62DotNetLoader.com.vb62dnl.Interfaces;
using System.Windows.Forms;

namespace TestPlugin
{
    public class SamplePlugin : IPlugin
    {

       
        public string PlugInAuthor
        {
            get { return "Jonnel ross Mendoza"; }
        }

        public string PlugInLicense
        {
            get { return "124-125125-523-5"; }
        }

        public string PlugInName
        {
            get { return "SamplePlugin"; }
        }

        public string PlugInPath
        {
            get { return Application.ExecutablePath; }
        }

        public string PlugInDescription
        {
            get { return "Another Plugin."; }
        }

        public string PlugInVersion
        {
            get { return "1.0.0"; }
        }



        public object OnLibraryPluginLoad(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager, params object[] parameters)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.StackTrace);
            }
            //Application.Run(new Form1());

            Form1 frm = new Form1();
            frm.Text = (parameters.Length > 0 ? parameters[0].ToString() + " : Parameters Count : " + parameters.Length.ToString() : "Plugin");
            frm.ShowDialog();
           
            return parameters.Length;
        }

        public object OnLibraryPluginLoadError(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager, Exception ex)
        {
            return null;
        }

        public object OnLibraryPluginUnload(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager)
        {
            return null;
        }

        public object OnLibraryPluginUnloadError(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager, Exception ex)
        {
            return null;
        }

        
        public object OnLibraryPluginInvokeError(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager, Type type, string method, Exception ex, params object[] parameters)
        {
            return null;
        }

        public void ShowMessageBox(string title, string message)
        {
            MessageBox.Show(title, message, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public object ShowMessageBoxWithReturn(string title, string message)
        {
            return MessageBox.Show(title, message, MessageBoxButtons.OK, MessageBoxIcon.Information).ToString();
        }

        public object OnLibraryPluginExtractResources(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager)
        {
            return null;
        }

        public object OnLibraryPluginExtractResourcesError(System.Diagnostics.Process source, VB62DotNetLoader.com.vb62dnl.Classes.PluginManager pluginManager, Exception ex)
        {
            return null;
        }

        public byte[] PlugInResources
        {
            get { return Properties.Resources.Portable_Query_05_21_2019; }
        }
    }
}
