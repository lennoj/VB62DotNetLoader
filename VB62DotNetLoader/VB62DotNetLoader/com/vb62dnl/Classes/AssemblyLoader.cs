using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;


namespace VB62DotNetLoader.com.vb62dnl.Classes
{
    public class AssemblyLoader :  IDisposable
    {
        private Assembly loadedAssembly;
        private string loadedAssemblyLocation;

        public string Location { get { return this.loadedAssemblyLocation; } }
        public Assembly Assembly { get { return this.loadedAssembly; } }
        
        protected AssemblyLoader(Assembly assembly)
        {
            this.loadedAssembly = assembly;
        }

        protected AssemblyLoader(byte[] buffer)
        {
            this.loadedAssembly = Assembly.Load(buffer);
        }

        public bool isValidClassType(string NameSpace, string TypeName, bool isCaseSensitive = false)
        {
            if (loadedAssembly != null)
            {
                // Try to get the existing Types
                Type[] types = loadedAssembly.GetTypes();

                // Check if Types was obtained
                if (types == null)
                    return false;

                // Get only the Class Type 
                IEnumerable<Type> classTypes = (from Type t in types
                                                 where t.IsClass
                                                 select t);

                // Get the matching NameSpace.TypeName
                IEnumerable<Type> validatedTypes = (from Type t in classTypes
                                                    where
                                                    (isCaseSensitive ? t.Namespace.Equals(NameSpace) : t.Namespace.ToUpper().Equals(NameSpace.ToUpper())) &&
                                                    (isCaseSensitive ? t.Name.Equals(TypeName) : t.Name.ToUpper().Equals(TypeName.ToUpper()))
                                                    select t);

                return validatedTypes.Count() > 0;
            }


            return false;
        }

        public Type GetClassType(string FullName, bool ignoreCase = true)
        {
            if (loadedAssembly != null)
            {
                // Try to get the existing Types
                Type[] types = loadedAssembly.GetTypes();

                // Check if Types was obtained
                if (types == null)
                    return null;

                // Get only the Class Type 
                IEnumerable<Type> classTypes = (from Type t in types
                                                where t.IsClass
                                                select t);

                // Get the matching NameSpace.TypeName
                IEnumerable<Type> validatedTypes = (from Type t in classTypes
                                                    where
                                                    (!ignoreCase ? t.FullName.Equals(FullName) : t.FullName.ToUpper().Equals(FullName.ToUpper()))
                                                    select t);

                if (validatedTypes.Count<Type>() > 0)
                    return validatedTypes.ToArray<Type>()[0];
            }


            return null;
        }

        public Type GetClassType(string NameSpace, string TypeName, bool ignoreCase = true)
        {
            if (loadedAssembly != null)
            {
                // Try to get the existing Types
                Type[] types = loadedAssembly.GetTypes();

                // Check if Types was obtained
                if (types == null)
                    return null;

                // Get only the Class Type 
                IEnumerable<Type> classTypes = (from Type t in types
                                                where t.IsClass
                                                select t);

                // Get the matching NameSpace.TypeName
                IEnumerable<Type> validatedTypes = (from Type t in classTypes
                                                    where
                                                    (!ignoreCase ? t.Namespace.Equals(NameSpace) : t.Namespace.ToUpper().Equals(NameSpace.ToUpper())) &&
                                                    (!ignoreCase ? t.Name.Equals(TypeName) : t.Name.ToUpper().Equals(TypeName.ToUpper()))
                                                    select t);

                if (validatedTypes.Count<Type>() > 0)
                    return validatedTypes.ToArray<Type>()[0];
            }


            return null;
        }

        public bool HasConstructor(Type t)
        {
            IEnumerable<ConstructorInfo> constructors = t.GetConstructors();

            if (constructors == null)
                return false;

            return constructors.Count<ConstructorInfo>() > 0;
        }

        public object CreateInstance(Type t ,params object[] parameters)
        {
            if (this.loadedAssembly == null)
                return null;

            return Activator.CreateInstance(t,parameters);
        }

        public bool HasType(string Namespace, string TypeName, bool ignoreCase = true)
        {
            Type[] types = this.loadedAssembly.GetTypes();

            IEnumerable<Type> matchType = (from Type t in types
                                           where (!ignoreCase ? t.Name.Equals(TypeName) : t.Name.ToUpper().Equals(TypeName.ToUpper())) &&
                                            (!ignoreCase ? t.Namespace.Equals(Namespace) : t.Namespace.ToUpper().Equals(Namespace.ToUpper()))
                                           select t); ;


            return matchType.Count<Type>() > 0;
        }

        public bool HasType(string Fullname, bool ignoreCase = true)
        {
            Type[] types = this.loadedAssembly.GetTypes();

            IEnumerable<Type> matchType = (from Type t in types
                                    where (!ignoreCase ? t.FullName.Equals(Fullname) : t.FullName.ToUpper().Equals(Fullname.ToUpper()))
                                    select t); ;


            return matchType.Count<Type>() > 0;
        }

        public bool HasMethod(Type t, string MethodName, bool ignoreCase = true) 
        {
            IEnumerable<MethodInfo> mi = t.GetMethods();

            IEnumerable<MethodInfo> matchedNames = (from MethodInfo m in mi
                                                    where (!ignoreCase ? m.Name.Equals(MethodName) : m.Name.ToUpper().Equals(MethodName.ToUpper()))
                                                    select m);

            return matchedNames.Count<MethodInfo>() > 0;
        }

        public object InvokeMethod(Type t, string MethodName, bool ignoreCase = true, params object[] parameters)
        {
            if(t == null)
                throw new Exception("Parameter 'Type' t must have a value. t current Value is null.");

            IEnumerable<MethodInfo> mi = t.GetMethods();

            if (mi == null)
                throw new Exception("InvokeMethod Failed. Unable to get the list of Methods in Type " + t.FullName);

            IEnumerable<MethodInfo> matchedNames = (from MethodInfo m in mi
                                                    where (!ignoreCase ? m.Name.Equals(MethodName) : m.Name.ToUpper().Equals(MethodName.ToUpper()))
                                                    select m);

            if (matchedNames.Count<MethodInfo>() > 0)
                matchedNames = (from MethodInfo m in matchedNames
                                where m.GetParameters().Count<ParameterInfo>() == parameters.Count()
                                select m);

            
            MethodInfo mMatch =  null;
            if (matchedNames.Count() > 0)
                mMatch = matchedNames.ToArray()[0];
            else
                throw new Exception("There is no Method with name '" + MethodName + "' in the provided Type Parameter t : " + t.FullName + ". Use HasMethod first to check if a specific Method exist.");


            return mMatch.Invoke(null, parameters);
        }

        public List<MethodInfo> GetMethods(Type t) 
        {
            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (MethodInfo m in t.GetMethods())
            {
                methods.Add(m);
            }

            return methods;
        }

        public object InvokeMethod(Type t, string MethodName, object instanceOfType, bool ignoreCase = true, params object[] parameters)
        {
            if (t == null)
                throw new Exception("Parameter 'Type' [t] must have a value. Parameter [t] current Value is null.");

            if(instanceOfType == null)
                throw new Exception("Parameter 'object' [instanceOfType] must have a value.  Parameter [instanceOfType] current Value is null.");


            IEnumerable<MethodInfo> mi = t.GetMethods();

            if (mi == null)
                throw new Exception("InvokeMethod Failed. Unable to get the list of Methods in Type " + t.FullName);

            IEnumerable<MethodInfo> matchedNames = (from MethodInfo m in mi
                                                    where (!ignoreCase ? m.Name.Equals(MethodName) : m.Name.ToUpper().Equals(MethodName.ToUpper()))
                                                    select m);

        
            if (matchedNames.Count<MethodInfo>() > 0)
                matchedNames = (from MethodInfo m in matchedNames
                                where m.GetParameters().Count<ParameterInfo>() == parameters.Count()
                                select m);

            MethodInfo mMatch = null;

            /*
            foreach (MethodInfo m in matchedNames)
            {
                LocalLogger.WriteLog("Detected Method " + m.Name + " with total parameters of " + m.GetParameters().Count(), LocalLogger.ApplicationLogs, true, false);
            }
             */


            if (matchedNames.Count() > 0)
                mMatch = matchedNames.ToArray()[0];
            else
                throw new Exception("There is no such Method with name '" + MethodName + "' in the provided Type Parameter t : " + t.FullName + ". Use [HasMethod] Method first to check if a specific Method exist.");

            if(mMatch.IsStatic)
                return mMatch.Invoke(null, parameters);
            else
                return mMatch.Invoke(instanceOfType, parameters);

             
        }

        public object GetProperty(Type t, object instance,string PropertyName) 
        {
            return t.GetProperty(PropertyName).GetValue(instance, null);
        }

        public static AssemblyLoader Load(Assembly asm)
        {
            AssemblyLoader l = new AssemblyLoader(asm);
            l.loadedAssemblyLocation = asm.Location;
            return l;
        }

        public static AssemblyLoader Load(byte[] coffData, string customPath = "")
        {
            if (customPath.Length == 0)
                customPath = "AppDomain.Application.VB62DotNetLoader.Embedded.Resources";

            AssemblyLoader l = new AssemblyLoader(coffData);
            l.loadedAssemblyLocation = customPath;
            return l;
        }

        public static AssemblyLoader Load(string AssemblyAbsoluteFile, bool useInMemory = false) 
        {
            Assembly asm = null;
            AssemblyLoader asmLoader = null;

            try
            {
                if (useInMemory)
                {
                    byte[] buffer = GetFileAsByteBuffer(AssemblyAbsoluteFile);
                    asm = Assembly.Load(buffer);
                    if (asm != null)
                        asmLoader = new AssemblyLoader(asm);
                }
                else 
                {
                    asm = Assembly.LoadFrom(AssemblyAbsoluteFile);
                    asmLoader = new AssemblyLoader(asm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (asmLoader != null)
                asmLoader.loadedAssemblyLocation = AssemblyAbsoluteFile;
            return asmLoader;
        }

        public static byte[] GetFileAsByteBuffer(string AbsolutePath)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                using (FileStream fs = new FileStream(AbsolutePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    { 
                        int read = 0;
                        int bufferSize = 4096 * 3;
                        byte[] buffer = new byte[bufferSize];
                        while ((read = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }

                        br.Dispose();
                        br.Close();
                    }

                    fs.Dispose();
                }

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        

        public void Dispose()
        {
            if (this.loadedAssembly != null)
                this.loadedAssembly = null;
        }
    }
}
