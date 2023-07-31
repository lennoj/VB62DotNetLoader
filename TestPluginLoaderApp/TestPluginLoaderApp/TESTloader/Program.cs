using System;
using System.Collections.Generic;
using System.Text;
using VB62DotNetLoader.com.vb62dnl.Classes;


namespace TESTloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter plugin name to test");
            Console.Write("((e.g plugin.dll or \"plugin_test.dll\":");
            string pluginPath = Console.ReadLine();

            Console.Write("Enter the Plugin ID:");
            string pluginId = Console.ReadLine();


            PluginManager p = new PluginManager(null, "Testing");
            p.LoadLibrary(pluginPath, pluginId);
            p.Start(pluginId);
        }
    }
}
