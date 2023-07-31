using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using VB62DotNetLoader.UI.Forms;
using VB62DotNetLoader.UI.Classes;
using DevExpress.XtraEditors;
using VB62DotNetLoader.com.vb62dnl.Classes;
using System.Data;
using DevExpress.XtraGrid.Views.Base;


namespace VB62DotNetLoader.UI.Classes
{
    public sealed class DotNetVB6PluginBrowser
    {
        private Object View;
   
        public DotNetVB6PluginBrowser(XtraForm View)
        {
            this.View = View;

            // Construct an initial DefaultView (Dataview)
            XFormConfigurationManager frm = (XFormConfigurationManager)this.View;

            // Library List
            DataTable dt = new DataTable();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in frm.PluginGridView.Columns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            frm.PluginGrid.DataSource = (DataView)dt.DefaultView;

            // Library's Plugin List
            dt = new DataTable();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in frm.PluginContentGridView.Columns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            frm.PluginContentGrid.DataSource = (DataView)dt.DefaultView;

            // Library's Type Method List
            dt = new DataTable();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in frm.PluginContentMethodsGridView.Columns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            frm.PluginContentMethodsGrid.DataSource = (DataView)dt.DefaultView;
            
            
        }


        public void ShowBrowser()
        {
            XFormConfigurationManager frm = (XFormConfigurationManager)this.View;
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Supported Plugins";
            ofd.Filter = "Dynamic Link Library(dll)|*.dll|DotNet-To-VB6(DNVB)|*.DNVB|All Files|*.*";
            ofd.Multiselect = true;
            DialogResult result = ofd.ShowDialog(frm);

            if (result != DialogResult.OK)
                return;


            foreach (string file in ofd.FileNames)
            {
                if (File.Exists(file))
                {

                    FileInfo info = new FileInfo(file);
                    // Try loading all plugins in the file
                    PluginManager pm = new PluginManager(frm.ObjectSource, frm.ObjectApplicationCaller, false);
                    if (pm.LoadLibraryTypes(file))
                    {
                        Assembly assembly = Assembly.LoadFile(file);
                        AssemblyInformation asmInfo = new AssemblyInformation(assembly);

                        if (pm.GetPlugins().Count > 0)
                        {
                            BaseView bv = frm.PluginGrid.DefaultView;
                            DataView view = (DataView)bv.DataSource;
                            view.Table.Rows.Add(info.Name, info.FullName, assembly.GetName().Version, assembly.ImageRuntimeVersion, asmInfo.Description, true);                            
                        }

                        pm.UnloadAllLibraries();
                        pm.ClearLibraries();
                        assembly = null;
                        asmInfo = null;
                        Application.DoEvents();

                    }
                }
            }


            if (frm.PluginGridView.DataRowCount > 0)
            {
                frm.PluginGridView.SelectRow(0);   
            }
        }

       

       
        public void LoadDLLToUI(string FilePath, bool status)
        {
            XFormConfigurationManager frm = (XFormConfigurationManager)this.View;

            if (File.Exists(FilePath))
            {

                FileInfo info = new FileInfo(FilePath);
                // Try loading all plugins in the file
                PluginManager pm = new PluginManager(frm.ObjectSource, frm.ObjectApplicationCaller,false);
                if (pm.LoadLibraryTypes(FilePath))
                {
                    Assembly assembly = Assembly.LoadFile(FilePath);
                    AssemblyInformation asmInfo = new AssemblyInformation(assembly);

                    BaseView bv = frm.PluginGrid.DefaultView;
                    DataView view = (DataView)bv.DataSource;

                    frm.ClearGrid(frm.PluginGrid);

                    if (pm.GetPlugins().Count > 0)
                    {
                     
                        view.Table.Rows.Add(info.Name, info.FullName, assembly.GetName().Version, assembly.ImageRuntimeVersion, asmInfo.Description, status);   
                    }
                           
                    pm.UnloadAllLibraries();
                    pm.ClearLibraries();
                    assembly = null;
                    asmInfo = null;
                    Application.DoEvents();
                }
            }

            if (frm.PluginGridView.DataRowCount > 0)
            {
                frm.PluginGridView.SelectRow(0);
            }
        }

       

        public void LibrarySelected(string FilePath)
        {
            XFormConfigurationManager frm = (XFormConfigurationManager)this.View;

            if (File.Exists(FilePath))
            {
                FileInfo info = new FileInfo(FilePath);
                // Try loading all plugins in the file
                PluginManager pm = new PluginManager(frm.ObjectSource, frm.ObjectApplicationCaller,false);
                if (pm.LoadLibraryTypes(FilePath))
                {
                    Assembly assembly = Assembly.LoadFile(FilePath);
                    AssemblyInformation asmInfo = new AssemblyInformation(assembly);
                    frm.PluginContentGridView.ClearSelection();
                    frm.PluginContentGridView.ClearSorting();
                    frm.PluginContentGridView.SelectAll();
                    frm.PluginContentGridView.DeleteSelectedRows();

                    BaseView bv = frm.PluginContentGrid.DefaultView;
                    DataView view = (DataView)bv.DataSource;

                    frm.ClearGrid(frm.PluginContentGrid);

                    foreach (Plugin lp in pm.GetPlugins())
                    {
                        view.Table.Rows.Add(lp.PlugInName, lp.TypeName, lp.PlugInPath, lp.PlugInVersion, lp.PlugInAuthor, lp.PlugInDescription, (lp.PlugInResources == null ? 0 : lp.PlugInResources.Length).ToString() + " byte(s)");   
                        Application.DoEvents();
                    }

                    pm.UnloadAllLibraries();
                    pm.ClearLibraries();
                    assembly = null;
                    asmInfo = null;
                    Application.DoEvents();
                }
            }
        }


        public void PluginTypeSelected(string AssemblyPath,string PluginTypeName)
        {
            XFormConfigurationManager frm = (XFormConfigurationManager)this.View;

            if (File.Exists(AssemblyPath))
            {
                AssemblyLoader loader = AssemblyLoader.Load(AssemblyPath,false);
                Type t = loader.GetClassType(PluginTypeName, true);

                if (t != null)
                {
                    List<MethodInfo> m = loader.GetMethods(t);

                    BaseView bv = frm.PluginContentMethodsGrid.DefaultView;
                    DataView view = (DataView)bv.DataSource;

                    while (view.Count > 0)
                        view.Delete(0);

                    foreach (MethodInfo method in m)
                    {
                        string parameters = "";
                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            parameters += parameter.ParameterType.FullName + ", ";   
                        }

                        parameters = parameters.Trim();
                        if(parameters.Length > 1)
                            parameters = parameters.Remove(parameters.Length - 1,1);

                        view.Table.Rows.Add(method.Name, method.MemberType.ToString(), method.ReturnType.FullName, (method.IsPrivate ? "Private" : "Public"), (method.IsStatic ? "Yes" : "No"), parameters);
                        Application.DoEvents();
                    }

                    loader.Dispose();
                    loader = null;
                }
            }
        }


      


    }
}
