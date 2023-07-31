using System;
using System.Collections.Generic;
using System.Text;
using VB62DotNetLoader.com.vb62dnl.Interfaces;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;


namespace VB62DotNetLoader.com.vb62dnl.Classes
{
    public sealed class Plugin : IPlugin
    {
        private object IPluginInstance;
        private Assembly SourceAssembly;
        private string PluginInstanceTypeName;
       

        public enum PluginState 
        {
            Ready,
            Loaded,
            Unloaded
        }

        private PluginState State;

        public PluginState CurrentState { get { return this.State; } }
        public Assembly Assembly { get { return this.SourceAssembly; } }
        public string TypeName { get { return this.PluginInstanceTypeName; } }
        public IPlugin IPlugin { get { return (IPlugin)this.IPluginInstance; } }
        public Type ActualType { get { return this.IPluginInstance.GetType();  } }
        public object InnerPlugin { get { return this.IPluginInstance;  } }

        public Plugin(object LoadedPlugin, Assembly SourceAssembly, string TypeName)
        {
            this.State = PluginState.Ready;
            this.IPluginInstance = LoadedPlugin;
            this.SourceAssembly = SourceAssembly;
            this.PluginInstanceTypeName = TypeName;
        }


        public string PlugInName
        {
            get { return this.IPlugin.PlugInName; }
        }

        public string PlugInVersion
        {
            get { return this.IPlugin.PlugInVersion; }
        }

        public string PlugInPath
        {
            get { return this.IPlugin.PlugInPath; }
        }

        public string PlugInAuthor
        {
            get { return this.IPlugin.PlugInAuthor; }
        }

        public string PlugInLicense
        {
            get { return this.IPlugin.PlugInLicense; }
        }


        public string PlugInDescription
        {
            get { return this.IPlugin.PlugInDescription; }
        }


        public object OnLibraryPluginLoad(Process source, PluginManager pluginManager, params object[] parameters)
        {
            this.State = PluginState.Loaded;
            return this.IPlugin.OnLibraryPluginLoad(source, pluginManager, parameters);
        }

        public object OnLibraryPluginUnload(Process source, PluginManager pluginManager)
        {
            this.State = PluginState.Unloaded;
            return this.IPlugin.OnLibraryPluginUnload(source, pluginManager);
        }

        public object OnLibraryPluginLoadError(Process source, PluginManager pluginManager, Exception ex)
        {
            return this.IPlugin.OnLibraryPluginLoadError(source, pluginManager, ex);
        }

        public object OnLibraryPluginUnloadError(Process source, PluginManager pluginManager, Exception ex)
        {
            return this.IPlugin.OnLibraryPluginUnloadError(source, pluginManager, ex);
        }


        public object OnLibraryPluginInvokeError(Process source, PluginManager pluginManager, Type type, string method, Exception ex, params object[] parameters)
        {
            return this.IPlugin.OnLibraryPluginInvokeError(source, pluginManager, type, method, ex, parameters);
        }


        public byte[] PlugInResources
        {
            get { return this.IPlugin.PlugInResources; }
        }

        public object OnLibraryPluginExtractResources(Process source, PluginManager pluginManager)
        {
            return this.IPlugin.OnLibraryPluginExtractResources(source, pluginManager);
        }

        public object OnLibraryPluginExtractResourcesError(Process source, PluginManager pluginManager, Exception ex)
        {
            return this.IPlugin.OnLibraryPluginExtractResourcesError(source, pluginManager, ex);
        }
    }
}
