using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
//using Ionic.Zip;


namespace VB62DotNetLoader.com.vb62dnl.Classes
{
    public sealed class ResourceExtractor : IDisposable
    {
        private MemoryStream memFile;
        private string path;

        public ResourceExtractor(byte[] fileBuffer, string Path)
        { 
            this.memFile = new MemoryStream(fileBuffer);
            if(!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            this.path = Path;
        }

        public void RepairFiles(Action<string, string, int, int> onExtractFile, Action onCompleted)
        {
            ExtractFiles(onExtractFile, onCompleted, true);
        }

        public void ExtractFiles(Action<string,string,int,int> onExtractFile, Action onCompleted, bool replaceAll = false)
        {
            AssemblyLoader zipAsm = AssemblyLoader.Load(Properties.Resources.Ionic_Zip, "AppDomain.Application.Embedded.Resources.Ionic_Zip");
            Type tZipFile = zipAsm.GetClassType("Ionic.Zip.ZipFile");
            Type tZipEntry = zipAsm.GetClassType("Ionic.Zip.ZipEntry");

            var zip = zipAsm.InvokeMethod(tZipFile, "Read", true, this.memFile); //  ZipFile.Read(this.memFile);

            if (onExtractFile != null)
                onExtractFile("Initializing","Checking files...", 0 , 0);

            IEnumerable<dynamic> zDirectories = (IEnumerable<dynamic>)
                                                (from dynamic z in (IEnumerable<dynamic>)zipAsm.GetProperty(tZipFile, zip, "Entries") 
                                                   where z.IsDirectory
                                                   select z);


            IEnumerable<object> zFiles = (from z in (IEnumerable<dynamic>)zipAsm.GetProperty(tZipFile, zip, "Entries") 
                                                   where !z.IsDirectory
                                                   select z);

            // check directory if already exist
            int x = 0;
            foreach (dynamic file in zDirectories)
            {
                string parentPath = this.path;
                parentPath = parentPath + @"\" + zipAsm.GetProperty(tZipEntry, file, "FileName");

                if (onExtractFile != null)
                    onExtractFile("Checking",parentPath, x, zDirectories.Count());

                if (!Directory.Exists(parentPath))
                {
                     Directory.CreateDirectory(parentPath);    
                     Thread.Sleep(50);
                }
                else
                {
                    onExtractFile("Existing", parentPath, x, zDirectories.Count());
                }

                x++;
            }

            x = 0;
            foreach (dynamic file in zFiles)
            {
                string parentPath = this.path;
                parentPath = parentPath + @"\" + zipAsm.GetProperty(tZipEntry, file, "FileName");

                if (onExtractFile != null)
                    onExtractFile("Checking",parentPath, x, zFiles.Count());

                if (!File.Exists(parentPath) || replaceAll)
                {
                    file.Extract(this.path);
                    Thread.Sleep(50);
                }
                else
                {
                    onExtractFile("Existing", parentPath, x, zFiles.Count());
                }

                x++;
            }

            zipAsm.Dispose();
            zipAsm = null;

            if (onCompleted != null)
                onCompleted();
        }

        public void Dispose()
        {
            this.memFile.Flush();
            this.memFile.Close();
            this.memFile.Dispose();
            this.memFile = null;
            this.path = null;
        }
    }
}
