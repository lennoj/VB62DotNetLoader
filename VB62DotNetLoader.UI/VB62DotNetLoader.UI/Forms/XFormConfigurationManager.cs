using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraEditors;
using VB62DotNetLoader.com.vb62dnl.Classes;
using VB62DotNetLoader.UI;
using VB62DotNetLoader.UI.Classes;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;

namespace VB62DotNetLoader.UI.Forms
{
    public partial class XFormConfigurationManager : DevExpress.XtraEditors.XtraForm
    {
        private Process source;
        private string ApplicationCaller;
        private DotNetVB6PluginBrowser bs;
        private VB62DotNet MainVB62DNDriver;

        public Process ObjectSource { get { return this.source; } }
        public string ObjectApplicationCaller { get { return this.ApplicationCaller; } }

        public DevExpress.XtraGrid.Views.Grid.GridView PluginGridView { get { return this.gridPluginFilesView; } }
        public DevExpress.XtraGrid.Views.Grid.GridView PluginContentGridView { get { return this.gridPluginContentsView; } }
        public DevExpress.XtraGrid.Views.Grid.GridView PluginContentMethodsGridView { get { return this.gridPluginContentExportsView; } }
        public DevExpress.XtraGrid.GridControl PluginGrid { get { return this.gridPluginFiles; } }
        public DevExpress.XtraGrid.GridControl PluginContentGrid { get { return this.gridPluginContents; } }
        public DevExpress.XtraGrid.GridControl PluginContentMethodsGrid { get { return this.gridPluginContentExports; } }
        public VB62DotNet SourceDriver { get { return this.MainVB62DNDriver; } }

        public XFormConfigurationManager(Process source, string caller, VB62DotNet CurrentMainVB62DNDriver)
        {
            //This set the style to use skin technology
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;

            //Here we specify the skin to use by its name           
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.VisualStudio2013Dark);

            InitializeComponent();
            this.source = source;
            this.ApplicationCaller = caller;
            this.MainVB62DNDriver = CurrentMainVB62DNDriver;
            this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + "Initializing [XFormConfigurationManager] instance", false, true);
         
            this.bs = new DotNetVB6PluginBrowser(this);

            this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + "Initializing [XFormConfigurationManager] instance -- OK", false, true);
            this.Text = CurrentMainVB62DNDriver.PluginManager.GetCoreDescription() + " v" +CurrentMainVB62DNDriver.PluginManager.GetCoreVersion() + " - Plugin Configuration Manager" ;
        }

        private void barButtonItemSaveConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Save Configuration", false, true);

            if (gridPluginFilesView.DataRowCount == 0)
            {
                XtraMessageBox.Show(this, "Please select at least 1 valid Library to save a configuration.", "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ConfigurationInformation> configs = new List<ConfigurationInformation>();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Configuration";
            sfd.Filter = "Configuration File(*.CFG)|*.cfg|All Files|*.*";
            DialogResult result = sfd.ShowDialog(this);

            for (int i = 0; i < gridPluginFilesView.DataRowCount; i++)
            {
                configs.Add(new ConfigurationInformation(
                    gridPluginFilesView.GetRowCellValue(i, "Name").ToString(), 
                    gridPluginFilesView.GetRowCellValue(i, "Path").ToString(), 
                    bool.Parse(gridPluginFilesView.GetRowCellValue(i, "Status").ToString())));
            }  

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    ConfigurationInformation.SaveConfiguration(sfd.FileName, configs);
                    XtraMessageBox.Show(this, "Configuration saved!", "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                    ex.StackTrace, true, true);

                    XtraMessageBox.Show(this, "An error occured while trying to save configuration file." + Environment.NewLine +
                    ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void barButtonItemLoadConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Load Configuration", false, true);
            List<ConfigurationInformation> configs = new List<ConfigurationInformation>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Load Configuration";
            ofd.Filter = "Configuration File(*.CFG)|*.cfg|All Files|*.*";
            DialogResult result = ofd.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    this.Enabled = false;
                    ConfigurationInformation.LoadConfiguration(ofd.FileName, configs, this.MainVB62DNDriver.PluginManager);

                    gridPluginFilesView.ClearSelection();
                    gridPluginFilesView.ClearSorting();
                    gridPluginFilesView.SelectAll();
                    gridPluginFilesView.DeleteSelectedRows();

                    gridPluginContentsView.ClearSelection();
                    gridPluginContentsView.ClearSorting();
                    gridPluginContentsView.SelectAll();
                    gridPluginContentsView.DeleteSelectedRows();

                    foreach (ConfigurationInformation configItem in configs)
                    {
                        bs.LoadDLLToUI(configItem.Path, configItem.Status);
                    }

                    XtraMessageBox.Show(this, "Configuration loaded", "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.MainVB62DNDriver.LoadLibrariesByConfig(ofd.FileName);
                }
                catch (Exception ex)
                {
                    this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                    ex.StackTrace, true, true);

                    XtraMessageBox.Show(this, "An error occured while trying to load configuration file." + Environment.NewLine +
                    ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    this.Enabled = true;
                }
            }
        }

        private void barButtonItemExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Close Configuration Manager", false, true);
            Close();
        }

        private void gridPluginFilesView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Load Types in Plugin", false, true);
            try
            {
                int[] selected = gridPluginFilesView.GetSelectedRows();
                if (selected.Length >= 1)
                    bs.LibrarySelected(this.gridPluginFilesView.GetRowCellValue(selected[0], "Path").ToString());
            }
            catch (Exception ex)
            {
                this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                    ex.StackTrace, true, true);

                XtraMessageBox.Show(this, "An error occured while trying to view Plugin List of the Library." + Environment.NewLine +
                    ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridPluginFilesView.SelectAll();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            gridPluginFilesView.ClearSelection();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            gridPluginContentsView.SelectAll();
            gridPluginContentsView.DeleteSelectedRows();

            int[] selected = gridPluginFilesView.GetSelectedRows();


            if (selected.Length > 0)
            {
                ClearGrid(this.PluginContentGrid);
                ClearGrid(this.PluginContentMethodsGrid);
            }

            for (int x = 0; x < selected.Length; x++)
            {
                gridPluginFilesView.DeleteRow(selected[x]);
            }

            if (gridPluginFilesView.DataRowCount > 0)
                gridPluginFilesView.SelectRow(0);
        }

        public void ClearGrid(DevExpress.XtraGrid.GridControl grid)
        {
            BaseView bv = grid.DefaultView;
            DataView view = (DataView)bv.DataSource;

            while (view.Count > 0)
                view.Delete(0);
        }   

        private void barButtonItemBrowsePlugin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to browse Valid Library/Assembly", false, true);
            try
            {
                DotNetVB6PluginBrowser browser = new DotNetVB6PluginBrowser(this);
                browser.ShowBrowser();
            }
            catch (Exception ex)
            {
                this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                    ex.StackTrace, true, true);

                XtraMessageBox.Show(this, "An error occured while trying to view Contents of the Library." + Environment.NewLine +
                   ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void XFormConfigurationManager_Load(object sender, EventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Load provided Configuration File " + this.SourceDriver.ConfigurationPath,false, true);

            if (this.SourceDriver.ConfigurationPath == null)
            {
                this.SourceDriver.PluginManager.WriteApplicationLog("UI: No configuration file loaded -- loading currently loaded Libraries",false, true);
                foreach (Plugin p in this.MainVB62DNDriver.PluginManager.GetPlugins())
                {
                    bs.LoadDLLToUI(p.Assembly.Location, true);
                }
                return;
            }

            if (!System.IO.File.Exists(this.SourceDriver.ConfigurationPath))
            {
                this.SourceDriver.PluginManager.WriteApplicationLog("UI: File not found " + this.SourceDriver.ConfigurationPath + " -- loading currently loaded Libraries", false, true);
                foreach (Plugin p in this.MainVB62DNDriver.PluginManager.GetPlugins())
                {
                    bs.LoadDLLToUI(p.Assembly.Location, true);
                }
                return;
            }

            Task t = new Task(() =>
            {
                CrossThread.Invoke(this, () =>
                {
                    try
                    {
                        this.Enabled = false;
                        this.lblLoadedConfig.Text = this.SourceDriver.PluginManager.LoadedConfiguration;
                        List<ConfigurationInformation> configs = new List<ConfigurationInformation>();
                        ConfigurationInformation.LoadConfiguration(this.SourceDriver.ConfigurationPath, configs, this.MainVB62DNDriver.PluginManager);

                        gridPluginFilesView.ClearSelection();
                        gridPluginFilesView.ClearSorting();
                        gridPluginFilesView.SelectAll();
                        gridPluginFilesView.DeleteSelectedRows();

                        gridPluginContentsView.ClearSelection();
                        gridPluginContentsView.ClearSorting();
                        gridPluginContentsView.SelectAll();
                        gridPluginContentsView.DeleteSelectedRows();

                        foreach (ConfigurationInformation configItem in configs)
                        {
                            bs.LoadDLLToUI(configItem.Path, configItem.Status);
                        }

                        this.MainVB62DNDriver.LoadLibrariesByConfig(this.SourceDriver.ConfigurationPath);
                    }
                    catch (Exception ex)
                    {
                        this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                        ex.StackTrace, true, true);

                        XtraMessageBox.Show(this, "An error occured while trying to load configuration file." + Environment.NewLine +
                        ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    finally 
                    {
                        this.Enabled = true;
                        Application.DoEvents();
                        this.Refresh();
                    }
                });
            });

            t.Start();
        }

        private void gridPluginContentsView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            /*
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Load Methods in selected Type", false, true);
            try
            {
                int[] selectedType = gridPluginContentsView.GetSelectedRows();
                int[] selectedLibrary = gridPluginFilesView.GetSelectedRows();
                if (selectedType.Length >= 1 && selectedLibrary.Length >= 1)
                    bs.PluginTypeSelected(this.gridPluginFilesView.GetRowCellValue(selectedType[0], "Path").ToString(), this.gridPluginContentsView.GetRowCellValue(selectedLibrary[0], "Fullname").ToString());
            }
            catch (Exception ex)
            {
                this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                    ex.StackTrace, true, true);

                XtraMessageBox.Show(this, "An error occured while trying to view Type Methods." + Environment.NewLine +
                    ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
             */
        }

        private void gridPluginContentsView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.SourceDriver.PluginManager.WriteApplicationLog("UI: Attempting to Load Methods in selected Type", false, true);
            try
            {
                int[] selectedType = gridPluginContentsView.GetSelectedRows();
                int[] selectedLibrary = gridPluginFilesView.GetSelectedRows();
                if (selectedType.Length >= 1 && selectedLibrary.Length >= 1)
                    bs.PluginTypeSelected(this.gridPluginFilesView.GetRowCellValue(selectedLibrary[0], "Path").ToString(), this.gridPluginContentsView.GetRowCellValue(selectedType[0], "Fullname").ToString());
            }
            catch (Exception ex)
            {
                this.SourceDriver.PluginManager.WriteApplicationLog("UI:" + ex.Message + Environment.NewLine +
                    ex.StackTrace, true, true);

                XtraMessageBox.Show(this, "An error occured while trying to view Type Methods." + Environment.NewLine +
                    ex.Message, "VB6 TO DOTNET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void barButtonAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFormAbout frmAbout = new XFormAbout(this.MainVB62DNDriver.PluginManager.GetCoreVersion());
            frmAbout.ShowDialog(this);
        }

     
   
    }
}