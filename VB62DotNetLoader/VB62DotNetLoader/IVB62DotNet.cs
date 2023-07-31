using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VB62DotNetLoader
{
    [Guid("d03e438b-333e-46a3-a920-0929e780e748")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IVB62DotNet
    {
        // Properties
        [DispId(1)]
        string ConfigurationPath { get; }

        [DispId(2)]
        bool QuiteMode { get; set;}

        [DispId(3)]
        bool DebugMode { get; set; }

        [DispId(4)]
        string CoreExecutablePath { get; }

        [DispId(5)]
        string ProcessName { get; }

        [DispId(6)]
        int ProcessId { get;  }

        [DispId(7)]
        string ProcessExecutablePath { get; }

        [DispId(8)]
        string[] GetLoadedLibraries { get; }

        [DispId(9)]
        string[] GetLoadedLibraryTypes { get; }

        [DispId(10)]
        string[] GetLibraryInformation(string LibraryName);

        [DispId(11)]
        string[] GetLibraryTypeInformation(string LibraryTypeName);


        [DispId(12)]
        bool AutoUnload { get; set; }

        // Methods
        [DispId(30)]
        void Dispose();

        [DispId(31)]
        bool LoadLibraries(string FilePath);

        [DispId(32)]
        bool LoadLibrariesByConfig(string FilePath);

        [DispId(33)]
        bool LoadLibrary(string FilePath, string LibraryID);

        [DispId(34)]
        void ShowLibraryConfigurationManager();

        [DispId(35)]
        object Start(string LibraryID, params object[] parameters);

        [DispId(36)]
        object StartAsync(string LibraryID, int OnComplete , params object[] parameters);

        [DispId(37)]
        bool Stop(string LibraryID);

        [DispId(38)]
        bool UnLoadAllLibraries();

        [DispId(39)]
        object InvokeMethod(string LibraryID,string Method, params object[] parameters);

        [DispId(40)]
        object InvokeMethodAsync(string LibraryID,string Method, int OnComplete, params object[] parameters);

        [DispId(41)]
        object isLibraryLoaded(string AbsolutePath);


        [DispId(42)]
        object isLibraryPluginLoaded(string PluginFullName);


        
    }
}
