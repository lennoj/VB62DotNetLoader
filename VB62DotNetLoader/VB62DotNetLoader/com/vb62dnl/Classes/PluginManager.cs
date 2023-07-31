using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using VB62DotNetLoader.com.vb62dnl.Interfaces;
using System.Threading.Tasks;
//using System.Threading.Tasks;


namespace VB62DotNetLoader.com.vb62dnl.Classes
{
    public sealed class PluginManager
    {
        public delegate void VBSub(Object returnValue);

        private Dictionary<string, Plugin> LoadedLibPlugins;
        private Dictionary<string, AssemblyLoader> LoadedLibs;
        private Process Source;
        private string ApplicationCaller;
        private bool __QuiteMode;
        private bool __AutoUnload;
        private bool __DebugMode;
        private string __CoreDLLPath;
        private string __CoreDLL;
        private Assembly __CoreASM;
        private string __LoadedConfigPath;

        public bool QuiteMode { get { return this.__QuiteMode; } set { this.__QuiteMode = value; } }
        public bool AutoUnload { get { return this.__AutoUnload; } set { this.__AutoUnload = value; } }
        public bool DebugMode { get { return this.__DebugMode; } set { this.__DebugMode = value; } }
        public string CoreExecutableDirectory { get { return this.__CoreDLLPath; } }
        public string CoreExecutableFile { get { return this.__CoreDLL; } }
        public Process SourceProcess { get { return this.Source; } }
        public int ProcessId { get { return this.Source.Id; } }
        public string ProcessName { get { return this.Source.ProcessName; } }
        public string ProcessExecutablePath { get { return this.Source.MainModule.FileName; } }
        public string CoreImageRuntime { get { return this.__CoreASM.ImageRuntimeVersion.ToString(); } }
        public string CoreVersion { get { return this.__CoreASM.GetName().Version.ToString(); } }
        public string CoreArchitecture { get { return this.__CoreASM.GetName().ProcessorArchitecture.ToString(); } }
        public string CoreName { get { return this.__CoreASM.GetName().Name; } }
        public string ApplicationExecutablePath { get { return Application.ExecutablePath; } }
        public string LoadedConfiguration { get { return this.__LoadedConfigPath; } set { this.__LoadedConfigPath = value; } }
        
        public PluginManager(Process source, string ApplicationCaller, bool initializeLocalLogger = false) 
        {
            Assembly executingAsm = Assembly.GetExecutingAssembly();
            __CoreASM = executingAsm;
            this.Source = source;
            this.ApplicationCaller = ApplicationCaller;
            this.LoadedLibPlugins = new Dictionary<string, Plugin>();
            this.LoadedLibs = new Dictionary<string, AssemblyLoader>();
            this.__QuiteMode = false;
            this.__DebugMode = false;
            this.__AutoUnload = true;
            this.__CoreDLLPath = new FileInfo(executingAsm.Location).Directory.FullName;
            this.__CoreDLL = new FileInfo(executingAsm.Location).FullName;

            InitializeLookAndFeel();

            if (initializeLocalLogger)
                InitializeLocalLogger();
        }

        private void InitializeLookAndFeel()
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
        }

        private void InitializeLocalLogger() {
            string Folder = "Logs";
            string ParentFolder = new FileInfo(this.__CoreDLL).Directory.FullName  + @"\" + Folder;
            string TimeStampFolder = DateTime.Now.ToLocalTime().ToString("MMddyyyy_hhmmssstt");

            LocalLogger.ApplicationLogs = LocalLogger.CreateLogFileName(ParentFolder, TimeStampFolder, "AppLogs.stg");
            LocalLogger.ErrorLogs = LocalLogger.CreateLogFileName(ParentFolder, TimeStampFolder, "ErrorLogs.stg");

            LocalLogger.WriteLog(Properties.Resources.Title, LocalLogger.ApplicationLogs, true, true);
            LocalLogger.WriteLog(Properties.Resources.Description, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("Version: " +  Properties.Resources.Version, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("Build: " + Properties.Resources.Build, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("Author:"  + Properties.Resources.Author, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("Runtime: " + Properties.Resources.Framework, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("Framework: " + Properties.Resources.Runtime, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("CorePath: " + CoreExecutableDirectory, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("CoreExecutableFile: " + CoreExecutableFile, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("CoreName: " + CoreName, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("CoreVersion: " + CoreVersion, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("CoreRuntimeVersion: " + CoreImageRuntime, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("CoreArchitecture: " + CoreArchitecture, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("AppProcessID: " + ProcessId.ToString(), LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("AppProcessName: " + ProcessName, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("AppProcessExecutableFile: " + ProcessExecutablePath, LocalLogger.ApplicationLogs, true, false);
            LocalLogger.WriteLog("ApplicationExecutablePath: " + ApplicationExecutablePath, LocalLogger.ApplicationLogs, true, false);

            if(this.DebugMode)
                LocalLogger.WriteLog("Debugging Mode : ACTIVATED", LocalLogger.ApplicationLogs, true, false);

            if (this.AutoUnload)
                LocalLogger.WriteLog("Auto Unload Library Plugin Instance: ACTIVATED", LocalLogger.ApplicationLogs, true, false);

            if (this.QuiteMode)
                LocalLogger.WriteLog("Quite Mode : ACTIVATED", LocalLogger.ApplicationLogs, true, false);

            LocalLogger.WriteLog("Loaded Assemblies", LocalLogger.ApplicationLogs, true, false);
            foreach (Module loadedAssembly in this.__CoreASM.GetLoadedModules(true))
            {
                Assembly lAsm = loadedAssembly.Assembly;
                LocalLogger.WriteLog("Loaded Assembly " + lAsm.Location + ";" +  lAsm.GetName().Name , LocalLogger.ApplicationLogs, true, false);
            }

            LocalLogger.WriteLog("------------------------------------------ STARTED ------------------------------------------------", LocalLogger.ApplicationLogs, true, false);



            LocalLogger.WriteLog(Properties.Resources.Title, LocalLogger.ErrorLogs, true, true);
            LocalLogger.WriteLog(Properties.Resources.Description, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("Version: " + Properties.Resources.Version, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("Build: " + Properties.Resources.Build, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("Author:" + Properties.Resources.Author, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("Runtime: " + Properties.Resources.Framework, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("Framework: " + Properties.Resources.Runtime, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("CorePath: " + CoreExecutableDirectory, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("CoreExecutableFile: " + CoreExecutableFile, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("CoreName: " + CoreName, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("CoreVersion: " + CoreVersion, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("CoreRuntimeVersion: " + CoreImageRuntime, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("CoreArchitecture: " + CoreArchitecture, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("AppProcessID: " + ProcessId.ToString(), LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("AppProcessName: " + ProcessName, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("AppProcessExecutableFile: " + ProcessExecutablePath, LocalLogger.ErrorLogs, true, false);
            LocalLogger.WriteLog("------------------------------------------ STARTED ------------------------------------------------", LocalLogger.ErrorLogs, true, false);

        }

        public Dictionary<string,Plugin>.ValueCollection GetPlugins()
        {
            return LoadedLibPlugins.Values;
        }

        public Dictionary<string, AssemblyLoader>.ValueCollection GetLibraries()
        {
            return LoadedLibs.Values;
        }

        public Dictionary<string, Plugin>.KeyCollection GetLoadedLibTypeNames()
        {
            return LoadedLibPlugins.Keys;
        }

        public Dictionary<string, AssemblyLoader>.KeyCollection GetLoadedLibNames()
        {
            return LoadedLibs.Keys;
        }

        public string GetCoreVersion()
        {
            return Properties.Resources.Version;
        }

        public string GetCoreDescription()
        {
            return Properties.Resources.Description;
        }


        public AssemblyLoader GetLibraryByName(string AssemblyName)
        {
            if (LoadedLibs.ContainsKey(AssemblyName))
                return this.LoadedLibs[AssemblyName];

            return null;
        }


        public Plugin this[string LibraryID]
        {
            get 
            {
                if (LoadedLibPlugins.ContainsKey(LibraryID))
                    return this.LoadedLibPlugins[LibraryID];

                
                return null;
            }
        }


        private void StartLibraryPluginLoadAsync(string LibraryID, VBSub vbSubPtr, params object[] parameters) 
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

            Task aTask = new Task(() =>
            {
                object ret = null;

                lock (vbSubPtr)
                {
                    try
                    {
                        ret = this[LibraryID].OnLibraryPluginLoad(this.Source, this, parameters);
                    }
                    catch (Exception LLError)
                    {
                        LocalLogger.WriteLog(LLError.Message +
                         Environment.NewLine + LLError.StackTrace, LocalLogger.ErrorLogs, true, true);

                        if (!this.__QuiteMode)
                        {
                            MessageBox.Show(null, LLError.Message +
                            Environment.NewLine + LLError.StackTrace, "Error 0x01::OnLibraryPluginLoad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this[LibraryID].OnLibraryPluginLoadError(this.Source, this, LLError);

                        ret = null;
                    }
                    finally
                    {
                        try
                        {
                            if(this.__AutoUnload)
                                this[LibraryID].OnLibraryPluginUnload(this.Source, this);
                        }
                        catch (Exception ULError)
                        {
                            LocalLogger.WriteLog(ULError.Message +
                                Environment.NewLine + ULError.StackTrace, LocalLogger.ErrorLogs, true, true);

                            if (!this.__QuiteMode)
                            {
                                MessageBox.Show(null, ULError.Message +
                                Environment.NewLine + ULError.StackTrace, "Error 0x02::OnLibraryPluginUnload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            this[LibraryID].OnLibraryPluginLoadError(this.Source, this, ULError);

                            ret = null;
                        }
                    }

                    try
                    {
                        if (ret == null)
                            ret = "Nothing";


                        //LocalLogger.WriteLog("Attempting to Call 'vbSub(ret)' with Pointer " + ptr.ToString(), LocalLogger.ApplicationLogs, true, true);
                        //LocalLogger.WriteLog("Actual Pointer Value: " + vPtr.ToString(), LocalLogger.ApplicationLogs, true, false);
                        //LocalLogger.WriteLog("32-Bit Pointer: " + ptr.ToInt32(), LocalLogger.ApplicationLogs, true, false);
                        //LocalLogger.WriteLog("64-Bit Pointer: " + ptr.ToInt64(), LocalLogger.ApplicationLogs, true, false);
                        //VBSub vbSub = (VBSub)Marshal.GetDelegateForFunctionPointer(ptr, typeof(VBSub));

                        if (vbSubPtr != null)
                        {
                            dispatcher.BeginInvoke(vbSubPtr, ret);
                        }
                    }
                    catch (Exception completetionError)
                    {
                        LocalLogger.WriteLog(completetionError.Message +
                                Environment.NewLine + completetionError.StackTrace, LocalLogger.ErrorLogs, true, true);
                    }
                }
                
                
            });
            
            aTask.Start();
           
        }

        public object Start(string LibraryID, VBSub vbSubPtr = null , bool isAsync = false, params object[] parameters)
        {
            LocalLogger.WriteLog("Start(LibraryID,OnComplete,isAsync,parameters) => " + LibraryID + "," + vbSubPtr.ToString() + ";" + isAsync + ";" + parameters.Length.ToString(), LocalLogger.ApplicationLogs, true, true);
            object returnObj = null;

            try
            {
                if (!IsLibraryPluginLoaded(LibraryID))
                {
                    LocalLogger.WriteLog("Library " + LibraryID + " not Loaded! -- Call LoadLibrary first", LocalLogger.ApplicationLogs, true, true);
                    
                    if(!this.QuiteMode)
                        MessageBox.Show(null, "Library " + LibraryID + " not Loaded! -- Call LoadLibrary first", "Error Start", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    if (isAsync && vbSubPtr != null)
                        vbSubPtr(returnObj);

                    return returnObj;
                }

                if (isAsync && vbSubPtr != null)
                {
                    StartLibraryPluginLoadAsync(LibraryID, vbSubPtr, parameters);
                    return "RUNNING";
                }
                else
                {
                    returnObj = this[LibraryID].OnLibraryPluginLoad(this.Source, this, parameters);
                }
            }
            catch (Exception LLError)
            {
                LocalLogger.WriteLog(LLError.Message +
                 Environment.NewLine + LLError.StackTrace, LocalLogger.ErrorLogs, true, true);

                if (!this.__QuiteMode) {
                    MessageBox.Show(null, LLError.Message +
                    Environment.NewLine + LLError.StackTrace, "Error 0x01::OnLibraryPluginLoad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                this[LibraryID].OnLibraryPluginLoadError(this.Source, this, LLError);

                returnObj = null;
            }
            finally 
            {
                try
                {
                    if(this.__AutoUnload)
                        this[LibraryID].OnLibraryPluginUnload(this.Source, this);
                }
                catch (Exception ULError)
                {
                    LocalLogger.WriteLog(ULError.Message +
                        Environment.NewLine + ULError.StackTrace, LocalLogger.ErrorLogs, true, true);
                    

                    if (!this.__QuiteMode)
                    {
                        MessageBox.Show(null, ULError.Message +
                        Environment.NewLine + ULError.StackTrace, "Error 0x02::OnLibraryPluginUnload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this[LibraryID].OnLibraryPluginUnloadError(this.Source, this, ULError);
                    returnObj = null;
                }
            }

            return returnObj;
        }

        public void InvokeMethodAsync(string LibraryID, string Method, VBSub vbSubPtr, params object[] parameters)
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

            Task aTask = new Task(() =>
            {
                object ret = null;

                lock (vbSubPtr)
                {
                    Type t = null;
                    try
                    {
                        AssemblyLoader asm = AssemblyLoader.Load(this[LibraryID].Assembly);
                        t = asm.GetClassType(this[LibraryID].TypeName, true);
                        ret = asm.InvokeMethod(t, Method, this[LibraryID].InnerPlugin, true, parameters);
                    }
                    catch (Exception LLError)
                    {
                        LocalLogger.WriteLog(LLError.Message +
                         Environment.NewLine + LLError.StackTrace, LocalLogger.ErrorLogs, true, true);

                        if (!this.__QuiteMode)
                        {
                            MessageBox.Show(null, LLError.Message +
                            Environment.NewLine + LLError.StackTrace, "Error InvokeMethodAsync", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ret = this[LibraryID].OnLibraryPluginInvokeError(this.Source, this, t, Method, LLError, parameters);
                    }

                    try
                    {
                        if (ret == null)
                            ret = "Nothing";

                        if (vbSubPtr != null)
                        {
                            dispatcher.BeginInvoke(vbSubPtr, ret);
                        }
                    }
                    catch (Exception completetionError)
                    {
                        LocalLogger.WriteLog(completetionError.Message +
                                Environment.NewLine + completetionError.StackTrace, LocalLogger.ErrorLogs, true, true);
                    }
                }


            });

            aTask.Start();
        }

        public bool IsLibraryPluginLoaded(string LibraryID)
        {
            return this[LibraryID] != null;
        }

        public object InvokeMethod(string LibraryID, string Method, VBSub vbSubPtr = null, bool isAsync = false, params object[] parameters)
        {
            LocalLogger.WriteLog("InvokeMethod(LibraryID,Method,OnComplete,isAsync,parameters) => " + LibraryID + ";" + Method + ";" + vbSubPtr.ToString() + ";" + isAsync + ";" + parameters.Length.ToString(), LocalLogger.ApplicationLogs, true, true);
            object returnObj = null;
            Type t = null;

            try
            {
                if (!IsLibraryPluginLoaded(LibraryID))
                {
                    LocalLogger.WriteLog("Library " + LibraryID + " not Loaded! -- Call LoadLibrary first", LocalLogger.ApplicationLogs, true, true);

                    if (!this.QuiteMode) 
                        MessageBox.Show(null, "Library " + LibraryID + " not Loaded! -- Call LoadLibrary first", "Error InvokeMethod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return returnObj;
                }

                if (isAsync && vbSubPtr != null)
                {
                    InvokeMethodAsync(LibraryID,Method, vbSubPtr, parameters);
                    return "RUNNING";
                }
                else
                {
                    AssemblyLoader asm = AssemblyLoader.Load(this[LibraryID].Assembly);
                    t = asm.GetClassType(this[LibraryID].TypeName);
                    returnObj = asm.InvokeMethod(t, Method, this[LibraryID].InnerPlugin, true, parameters);
                }
            }
            catch (Exception LLError)
            {
                LocalLogger.WriteLog(LLError.Message +
                 Environment.NewLine + LLError.StackTrace, LocalLogger.ErrorLogs, true, true);

                if (!this.__QuiteMode)
                {
                    MessageBox.Show(null, LLError.Message +
                    Environment.NewLine + LLError.StackTrace, "Error InvokeMethod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                returnObj = this[LibraryID].OnLibraryPluginInvokeError(this.Source, this, t, Method, LLError, parameters);

            }
           

            return returnObj;
        }


        /// <summary>
        /// Load Specific Library(.NET DLL) and Load all the Type(Class) that inherites the correct interface template
        /// </summary>
        /// <param name="LibraryPath">The file path of the .NET DLL</param>
        /// <returns>Return TRUE if success, return FALSE if Failed.</returns>
        public bool LoadLibraryTypes(string LibraryPath)
        {
            LocalLogger.WriteLog("LoadLibraryTypes(LibraryPath) => " + LibraryPath, LocalLogger.ApplicationLogs, true, true);
            // Check if file is Absolute path or Same Directory
            AssemblyLoader DotNetAssembly = null;
            string AbsolutePath = "";

            if (LibraryPath.Contains(":"))
                AbsolutePath = LibraryPath;
            else
                AbsolutePath = new FileInfo(CoreExecutableFile).Directory.FullName + @"\" + LibraryPath;

            if (IsLibraryLoaded(AbsolutePath))
            {
                DotNetAssembly = GetLoadedAssembly(AbsolutePath);
                LocalLogger.WriteLog("Assembly " + DotNetAssembly.Location + " is already been loaded in the current AppDomain.", LocalLogger.ApplicationLogs, true, true);
            }
            else 
            {
                // Check if file EXISTS
                if (!File.Exists(AbsolutePath))
                {
                    LocalLogger.WriteLog("Failed to load file " + Environment.NewLine + AbsolutePath + "\nDirectory or File doesn't exist.", LocalLogger.ErrorLogs, true, true);

                    if (!this.QuiteMode)
                        MessageBox.Show(null, "Failed to load file " + Environment.NewLine + AbsolutePath + "\nDirectory or File doesn't exist.", "Error 0x03::LoadLibraryTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }


            // Check if the File Inherits the Interface
            try
            {
                if (DotNetAssembly != null)
                    LocalLogger.WriteLog("Skipping Loading Process of Assembly : " + AbsolutePath, LocalLogger.ApplicationLogs, true, true);
                else
                {
                    LocalLogger.WriteLog("Loading Assembly File " + AbsolutePath, LocalLogger.ApplicationLogs, true, true);
                    DotNetAssembly = AssemblyLoader.Load(AbsolutePath);
                }
                
                int totalAdded = 0;
                
                if (DotNetAssembly != null)
                {
                    LocalLogger.WriteLog("Loading Assembly Reference Assemblies", LocalLogger.ApplicationLogs, true, true);
                    AssemblyName[] modules = DotNetAssembly.Assembly.GetReferencedAssemblies();
                    Object pluginInstance = null;

                    foreach (AssemblyName refAsm in modules)
                    {
                        LocalLogger.WriteLog("Assembly " + DotNetAssembly.Assembly.GetName().Name + " requires " + refAsm.Name + ";" + refAsm.Version, LocalLogger.ApplicationLogs, true, true);
                    }

                    // Get All the Types
                    LocalLogger.WriteLog("Loading Assembly Types of Assembly File " + DotNetAssembly.Assembly.GetName().Name, LocalLogger.ApplicationLogs, true, true);
                    Type[] DLLTypes = DotNetAssembly.Assembly.GetTypes();

                    // Load all Class Type which inherit the correct template
                    foreach (Type elementType in DLLTypes)
                    {
                        pluginInstance = null;
                        string TypeFullName = elementType.Namespace + "." + elementType.Name;

                        try
                        {
                            LocalLogger.WriteLog("Attempting to create instance of Type [" + TypeFullName + "]", LocalLogger.ApplicationLogs, true, true);
                            pluginInstance = DotNetAssembly.CreateInstance(elementType);
                        }
                        catch (Exception CreateInstanceException)
                        {
                            LocalLogger.WriteLog("Unable to create instance of Type [" + TypeFullName + "]"  , LocalLogger.ErrorLogs, true, true);
                            LocalLogger.WriteLog(CreateInstanceException.Message +
                            Environment.NewLine + CreateInstanceException.StackTrace, LocalLogger.ErrorLogs, true, true);
                        }

                        if (pluginInstance != null)
                        {
                            if ((pluginInstance is IPlugin))
                            {
                                if (!LoadedLibPlugins.ContainsKey(TypeFullName))
                                {
                                    LocalLogger.WriteLog("Instance of type [" + TypeFullName + "] added.", LocalLogger.ApplicationLogs, true, true);
                                    this.LoadedLibPlugins.Add(TypeFullName, new Plugin(pluginInstance, DotNetAssembly.Assembly, TypeFullName));
                                    if (this[TypeFullName].PlugInResources != null) 
                                    {
                                        if (this[TypeFullName].PlugInResources.Length > 0)
                                        { 
                                            FileInfo f = new FileInfo(AbsolutePath);
                                            ResourceExtractor re = new ResourceExtractor(this[TypeFullName].PlugInResources, f.Directory.FullName);
                                            re.ExtractFiles((string status, string file, int progress, int total) => { }, () => { }, false);
                                        }
                                    }
                                }
                                else
                                {
                                    LocalLogger.WriteLog("Instance of type [" + TypeFullName + "] already exist. Removing the existing instance", LocalLogger.ApplicationLogs, true, true);
                                    this.LoadedLibPlugins.Remove(TypeFullName);
                                    LocalLogger.WriteLog("Instance of type [" + TypeFullName + "] added.", LocalLogger.ApplicationLogs, true, true);
                                    this.LoadedLibPlugins.Add(TypeFullName, new Plugin(pluginInstance, DotNetAssembly.Assembly, TypeFullName));
                                }
                                totalAdded++;
                            }
                        }
                    }

                    if(totalAdded > 0)
                        if (!this.LoadedLibs.ContainsKey(DotNetAssembly.Assembly.GetName().Name))
                            this.LoadedLibs.Add(DotNetAssembly.Assembly.GetName().Name, DotNetAssembly);

                    return true;
                }
            }
            catch (Exception LoadAssemblyError)
            {
                LocalLogger.WriteLog("Failed to load file " + Environment.NewLine + AbsolutePath +
                    Environment.NewLine + "File might not be accessible or corrupted!" +
                    Environment.NewLine + LoadAssemblyError.Message +
                    Environment.NewLine + LoadAssemblyError.StackTrace, LocalLogger.ErrorLogs, true, true);

                if (LoadAssemblyError is ReflectionTypeLoadException)
                {
                    foreach (Exception inner in ((ReflectionTypeLoadException)LoadAssemblyError).LoaderExceptions)
                    {
                        LocalLogger.WriteLog(inner.Message, LocalLogger.ErrorLogs, true, false);
                    }
                }

                if (!this.__QuiteMode)
                {
                    MessageBox.Show(null, "Failed to load file " + Environment.NewLine + AbsolutePath +
                    Environment.NewLine + "File might not be accessible or corrupted!" +
                    Environment.NewLine + LoadAssemblyError.Message, "Error 0x04::LoadLibraryTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        /// <summary>
        /// Load Specific Library(.NET DLL) and Specific Type(Class) 
        /// </summary>
        /// <param name="LibraryPath">The file path of the .NET DLL</param>
        /// <param name="LibraryID">The Class-Type that is in the Loaded Assembly of .NET DLL</param>
        /// <returns>Return TRUE if success, return FALSE if Failed.</returns>
        public bool LoadLibrary(string LibraryPath , string LibraryID) 
        {
            LocalLogger.WriteLog("LoadLibrary(LibraryPath,LibraryID) => " + LibraryPath + ";" + LibraryID, LocalLogger.ApplicationLogs, true, true);
            // Check if file is Absolute path or Same Directory
            AssemblyLoader DotNetAssembly = null;
            string AbsolutePath = "";
            IPlugin loadedPlugin;
            
            if (LibraryPath.Contains(":"))
                AbsolutePath = LibraryPath;
            else
                AbsolutePath = new FileInfo(CoreExecutableFile).Directory.FullName + @"\" + LibraryPath;

            // Check if file EXISTS
            if (!File.Exists(AbsolutePath))
            {
                LocalLogger.WriteLog("Failed to load file " + Environment.NewLine + AbsolutePath + "\nDirectory or File doesn't exist.", LocalLogger.ErrorLogs, true, true);
                MessageBox.Show(null, "Failed to load file " + Environment.NewLine + AbsolutePath + "\nDirectory or File doesn't exist.", "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (IsLibraryLoaded(AbsolutePath))
            {
                DotNetAssembly = GetLoadedAssembly(AbsolutePath);
                LocalLogger.WriteLog("Assembly " + DotNetAssembly.Location + " is already been loaded in the current AppDomain.", LocalLogger.ApplicationLogs, true, true);
            }
            else
            {
                // Check if file EXISTS
                if (!File.Exists(AbsolutePath))
                {
                    LocalLogger.WriteLog("Failed to load file " + Environment.NewLine + AbsolutePath + "\nDirectory or File doesn't exist.", LocalLogger.ErrorLogs, true, true);

                    if (!this.QuiteMode)
                        MessageBox.Show(null, "Failed to load file " + Environment.NewLine + AbsolutePath + "\nDirectory or File doesn't exist.", "Error 0x03::LoadLibraryTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }


            // Check if the File Inherits the Interface
            try
            {
                if (DotNetAssembly != null)
                    LocalLogger.WriteLog("Skipping Loading Process of Assembly : " + AbsolutePath, LocalLogger.ApplicationLogs, true, true);
                else
                {
                    LocalLogger.WriteLog("Loading Assembly File " + AbsolutePath, LocalLogger.ApplicationLogs, true, true);
                    DotNetAssembly = AssemblyLoader.Load(AbsolutePath);
                }

                if (DotNetAssembly != null)
                {
                    LocalLogger.WriteLog("Loading Assembly Reference Assemblies", LocalLogger.ApplicationLogs, true, true);
                    AssemblyName[] modules = DotNetAssembly.Assembly.GetReferencedAssemblies();
                    Object pluginInstance = null;

                    foreach (AssemblyName refAsm in modules)
                    {
                        LocalLogger.WriteLog("Assembly " + DotNetAssembly.Assembly.GetName().Name + " requires " + refAsm.Name + ";" + refAsm.Version, LocalLogger.ApplicationLogs, true, true);
                    }

                    // Get All the Types
                    LocalLogger.WriteLog("Loading Assembly Types of Assembly File " + DotNetAssembly.Assembly.GetName().Name, LocalLogger.ApplicationLogs, true, true);
                    if (!DotNetAssembly.HasType(LibraryID, true))
                    {
                        LocalLogger.WriteLog("Unable to find Type '" + LibraryID + "'" + Environment.NewLine + "Type not found!" + Environment.NewLine, LocalLogger.ErrorLogs, true, true);
                        if (!this.__QuiteMode)
                        {
                            throw new Exception("Unable to find Type '" + LibraryID + "'" + Environment.NewLine + "Type not found!" + Environment.NewLine);
                        }
                    }

                    Type t = DotNetAssembly.GetClassType(LibraryID, true);
                    pluginInstance = DotNetAssembly.CreateInstance(t);

                    if (pluginInstance == null)
                    {
                        LocalLogger.WriteLog("Failed to Create Instance of Object Type '" + LibraryID + "'", LocalLogger.ErrorLogs, true, true);
                        if (!this.__QuiteMode)
                        {
                            throw new Exception("Failed to Create Instance of Object Type '" + LibraryID + "'");
                        }
                    }


                    if (!(pluginInstance is IPlugin))
                    {
                        LocalLogger.WriteLog("Type '" + LibraryID + "' doesn't inherit proper interface!" + Environment.NewLine + "Invalid Library Template!" + Environment.NewLine, LocalLogger.ErrorLogs, true, true);
                        if (!this.__QuiteMode)
                        {
                            throw new Exception("Type '" + LibraryID + "' doesn't inherit proper interface!" + Environment.NewLine + "Invalid Library Template!" + Environment.NewLine);
                        }
                    }

                    loadedPlugin = (IPlugin)pluginInstance;

                    if (!LoadedLibPlugins.ContainsKey(LibraryID))
                    {
                        LocalLogger.WriteLog("Instance of type [" + LibraryID + "] added.", LocalLogger.ApplicationLogs, true, true);
                        this.LoadedLibPlugins.Add(LibraryID, new Plugin(loadedPlugin, DotNetAssembly.Assembly, LibraryID));
                        if (this[LibraryID].PlugInResources != null)
                        {
                            if (this[LibraryID].PlugInResources.Length > 0)
                            {
                                FileInfo f = new FileInfo(AbsolutePath);
                                ResourceExtractor re = new ResourceExtractor(this[LibraryID].PlugInResources, f.Directory.FullName);
                                re.ExtractFiles((string status, string file, int progress, int total) => { }, () => { }, false);
                            }
                        }
                    }
                    else
                    {
                        LocalLogger.WriteLog("Instance of type [" + LibraryID + "] already exist. Removing the existing instance", LocalLogger.ApplicationLogs, true, true);
                        this.LoadedLibPlugins.Remove(LibraryID);
                        LocalLogger.WriteLog("Instance of type [" + LibraryID + "] added.", LocalLogger.ApplicationLogs, true, true);
                        this.LoadedLibPlugins.Add(LibraryID, new Plugin(loadedPlugin, DotNetAssembly.Assembly, LibraryID));
                    }

                    if(!this.LoadedLibs.ContainsKey(DotNetAssembly.Assembly.GetName().Name))
                        this.LoadedLibs.Add(DotNetAssembly.Assembly.GetName().Name, DotNetAssembly);


                    return true;
                }
            }
            catch (Exception LoadAssemblyError)
            {
                LocalLogger.WriteLog("Failed to load file " + Environment.NewLine + AbsolutePath +
                   Environment.NewLine + "File might not be accessible or corrupted!" +
                   Environment.NewLine + LoadAssemblyError.Message + 
                   Environment.NewLine + LoadAssemblyError.StackTrace, LocalLogger.ErrorLogs, true, true);

                if (LoadAssemblyError is ReflectionTypeLoadException)
                {
                    foreach (Exception inner in ((ReflectionTypeLoadException)LoadAssemblyError).LoaderExceptions)
                    {
                        LocalLogger.WriteLog(inner.Message, LocalLogger.ErrorLogs, true, false);
                    }
                }

                if (!this.__QuiteMode)
                {
                    MessageBox.Show(null, "Failed to load file " + Environment.NewLine + AbsolutePath +
                    Environment.NewLine + "File might not be accessible or corrupted!" +
                    Environment.NewLine + LoadAssemblyError.Message, "Error 0x05::LoadLibrary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }

            return false;
        }

        public bool Stop(string LibraryID)
        {
            LocalLogger.WriteLog("Stop(LibraryID) => " + LibraryID, LocalLogger.ApplicationLogs, true, true);
            if (LoadedLibPlugins.ContainsKey(LibraryID))
            {
                try
                {
                    Plugin p = this[LibraryID];
                    p.OnLibraryPluginUnload(this.Source,this);
                    this.LoadedLibPlugins.Remove(LibraryID);
                    return true;
                }
                catch (Exception ULError)
                {
                    LocalLogger.WriteLog(ULError.Message +
                        Environment.NewLine + ULError.StackTrace, LocalLogger.ErrorLogs, true, true);

                    if (!this.__QuiteMode)
                    {
                        MessageBox.Show(null, ULError.Message +
                        Environment.NewLine + ULError.StackTrace, "Error 0x05::OnLibraryPluginUnload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this[LibraryID].OnLibraryPluginUnloadError(this.Source,this, ULError);
                    }
                    
                    return false;
                }
            }

            return true;
        }

        public bool UnloadAllLibraries() 
        {
            LocalLogger.WriteLog("UnloadAllLibraries()", LocalLogger.ApplicationLogs, true, true);
            try
            {
                foreach (Plugin elementPlugin in LoadedLibPlugins.Values)
                {
                    if (elementPlugin.CurrentState == Plugin.PluginState.Loaded)
                        elementPlugin.OnLibraryPluginUnload(this.Source,this);
                }

                LoadedLibs.Clear();
            }
            catch (Exception ULError)
            {
                LocalLogger.WriteLog(ULError.Message +
                     Environment.NewLine + ULError.StackTrace, LocalLogger.ErrorLogs, true, true);

                if (!this.__QuiteMode)
                {
                    MessageBox.Show(null, ULError.Message +
                         Environment.NewLine + ULError.StackTrace, "Error 0x06::UnloadAllLibraries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }

            return true;
        }

        public void ClearLibraries() 
        {
            LocalLogger.WriteLog("ClearLibraries()", LocalLogger.ApplicationLogs, true, true);
            LoadedLibPlugins.Clear();
            LoadedLibs.Clear();
        }

        public void Dispose()
        {
            LocalLogger.WriteLog("Dispose()", LocalLogger.ApplicationLogs, true, true);
            UnloadAllLibraries();
            ClearLibraries();
            Source = null;
            ApplicationCaller = null;
        }

        private byte[] ReadModule(string name,string path)
        {
            try
            {
                LocalLogger.WriteLog("ReadModule() Attempting to Read File :" + name + "; " + path  , LocalLogger.ApplicationLogs, true, true);
                using(FileStream fs = new FileStream(path,FileMode.Open, FileAccess.Read,  FileShare.Read))
                {
                     MemoryStream ms = new MemoryStream();
                     using(BinaryReader br = new BinaryReader(fs))
                     {
                         byte[] buffer = new byte[4096];
                         int read = 0;
                         while((read = br.Read(buffer, 0, buffer.Length)) > 0)
                         {
                             ms.Write(buffer, 0, read);
                         }
                         br.Dispose();
                         br.Close();
                     }

                     fs.Dispose();
                     LocalLogger.WriteLog("ReadModule() Attempting to Read File :" + name + "; " + path + " success. Total Size: " + ms.Length, LocalLogger.ApplicationLogs, true, true);
                     return ms.ToArray();
                }
               
            }
            catch (Exception ex)
            {
                LocalLogger.WriteLog("ReadModule() Failed: " + name + "; " + path + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, LocalLogger.ErrorLogs, true, true);
                return new byte[] { };
            }
        }

        public bool IsLibraryLoaded(string AbsolutePath)
        {
            if (!AbsolutePath.Contains(":"))
                AbsolutePath = new FileInfo(CoreExecutableFile).Directory.FullName + @"\" + AbsolutePath;


            if (this.LoadedLibs.Count == 0)
                return false;


            IEnumerable<AssemblyLoader> asms = (from AssemblyLoader a in this.LoadedLibs.Values
                                          where a.Location.ToUpper().Equals(AbsolutePath.ToUpper())
                                          select a);

            return asms.Count<AssemblyLoader>() > 0;
        }

        public AssemblyLoader GetLoadedAssembly(string AbsolutePath)
        {
            IEnumerable<AssemblyLoader> asms = (from AssemblyLoader a in this.LoadedLibs.Values
                                                where a.Location.ToUpper().Equals(AbsolutePath.ToUpper())
                                                select a);

            return asms.ToArray<AssemblyLoader>()[0];
        }

        public void WriteApplicationLog(string Message,bool isError = false, bool hasTimeStamp = true)
        {
            if(isError)
                LocalLogger.WriteLog(Message, LocalLogger.ErrorLogs, true, hasTimeStamp);
            else
                LocalLogger.WriteLog(Message, LocalLogger.ApplicationLogs, true, hasTimeStamp);
        }

    
    }
}
