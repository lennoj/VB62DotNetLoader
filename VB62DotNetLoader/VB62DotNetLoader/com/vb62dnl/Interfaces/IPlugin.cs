using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using VB62DotNetLoader.com.vb62dnl.Classes;


namespace VB62DotNetLoader.com.vb62dnl.Interfaces
{
    /// <summary>
    /// Base Interface
    /// Must be Inherited by the Dot Net Library to be loaded
    /// JPMENDOZA 05-23-2019
    /// </summary>
    public interface IPlugin
    {
        string PlugInName           { get; }
        string PlugInVersion        { get; }
        string PlugInPath           { get; }
        string PlugInAuthor         { get; }
        string PlugInLicense        { get; }
        string PlugInDescription    { get; }
        byte[] PlugInResources      { get; }
        
        Object OnLibraryPluginLoad(Process source , PluginManager pluginManager, params object[] parameters);
        Object OnLibraryPluginUnload(Process source, PluginManager pluginManager);
        Object OnLibraryPluginExtractResources(Process source, PluginManager pluginManager);
        Object OnLibraryPluginLoadError(Process source, PluginManager pluginManager, Exception ex);
        Object OnLibraryPluginUnloadError(Process source, PluginManager pluginManager, Exception ex);
        Object OnLibraryPluginInvokeError(Process source, PluginManager pluginManager, Type type, string method, Exception ex , params object[] parameters);
        Object OnLibraryPluginExtractResourcesError(Process source, PluginManager pluginManager, Exception ex);

    }
}
