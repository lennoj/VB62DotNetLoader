namespace VB62DotNetLoader.UI.Forms
{
    partial class XFormConfigurationManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFormConfigurationManager));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItemFile = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemBrowsePlugin = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLoadConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.gridPluginFiles = new DevExpress.XtraGrid.GridControl();
            this.gridPluginFilesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pluginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginDotNetVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridPluginContents = new DevExpress.XtraGrid.GridControl();
            this.gridPluginContentsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pluginContentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginContentPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginContentVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginContentAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginContentDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pluginResources = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveSelected = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridPluginContentExports = new DevExpress.XtraGrid.GridControl();
            this.gridPluginContentExportsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MemberName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemberType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Visibility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsStatic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Parameters = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblLoadedConfig = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginFilesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContentExports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContentExportsView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barHeaderItem1,
            this.barSubItem4,
            this.barSubItemFile,
            this.barSubItem6,
            this.barButtonItemBrowsePlugin,
            this.barButtonItem10,
            this.barButtonItemLoadConfig,
            this.barButtonItemSaveConfig,
            this.barButtonItemExit,
            this.barButtonAbout});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 21;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(326, 161);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAbout)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItemFile
            // 
            this.barSubItemFile.Caption = "File";
            this.barSubItemFile.Id = 13;
            this.barSubItemFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemBrowsePlugin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemLoadConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSaveConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExit)});
            this.barSubItemFile.Name = "barSubItemFile";
            // 
            // barButtonItemBrowsePlugin
            // 
            this.barButtonItemBrowsePlugin.Caption = "Browse Plugin";
            this.barButtonItemBrowsePlugin.Id = 15;
            this.barButtonItemBrowsePlugin.Name = "barButtonItemBrowsePlugin";
            this.barButtonItemBrowsePlugin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBrowsePlugin_ItemClick);
            // 
            // barButtonItemLoadConfig
            // 
            this.barButtonItemLoadConfig.Caption = "Load Configuration";
            this.barButtonItemLoadConfig.Id = 17;
            this.barButtonItemLoadConfig.Name = "barButtonItemLoadConfig";
            this.barButtonItemLoadConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLoadConfig_ItemClick);
            // 
            // barButtonItemSaveConfig
            // 
            this.barButtonItemSaveConfig.Caption = "Save Configuration";
            this.barButtonItemSaveConfig.Id = 18;
            this.barButtonItemSaveConfig.Name = "barButtonItemSaveConfig";
            this.barButtonItemSaveConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSaveConfig_ItemClick);
            // 
            // barButtonItemExit
            // 
            this.barButtonItemExit.Caption = "Exit";
            this.barButtonItemExit.Id = 19;
            this.barButtonItemExit.Name = "barButtonItemExit";
            this.barButtonItemExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExit_ItemClick);
            // 
            // barButtonAbout
            // 
            this.barButtonAbout.Caption = "About";
            this.barButtonAbout.Id = 20;
            this.barButtonAbout.Name = "barButtonAbout";
            this.barButtonAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonAbout_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1083, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 629);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1083, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 607);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1083, 22);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 607);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "File";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.ActAsDropDown = true;
            this.barButtonItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem2.Caption = "Browse Plugin";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.ActAsDropDown = true;
            this.barButtonItem5.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "File";
            this.barButtonItem8.Id = 7;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Browse Plugin";
            this.barSubItem1.Id = 8;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "barSubItem4";
            this.barSubItem4.Id = 12;
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "barSubItem2";
            this.barSubItem2.Id = 9;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "barSubItem3";
            this.barSubItem3.Id = 10;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "File";
            this.barHeaderItem1.Id = 11;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "Browse Plugin";
            this.barSubItem6.Id = 14;
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "barButtonItem10";
            this.barButtonItem10.Id = 16;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // gridPluginFiles
            // 
            this.gridPluginFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPluginFiles.Location = new System.Drawing.Point(12, 86);
            this.gridPluginFiles.MainView = this.gridPluginFilesView;
            this.gridPluginFiles.MenuManager = this.barManager1;
            this.gridPluginFiles.Name = "gridPluginFiles";
            this.gridPluginFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridPluginFiles.Size = new System.Drawing.Size(1059, 107);
            this.gridPluginFiles.TabIndex = 4;
            this.gridPluginFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPluginFilesView});
            // 
            // gridPluginFilesView
            // 
            this.gridPluginFilesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.pluginName,
            this.pluginPath,
            this.pluginVersion,
            this.pluginDotNetVersion,
            this.pluginDescription,
            this.pluginStatus});
            this.gridPluginFilesView.GridControl = this.gridPluginFiles;
            this.gridPluginFilesView.Name = "gridPluginFilesView";
            this.gridPluginFilesView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridPluginFilesView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridPluginFilesView.OptionsSelection.MultiSelect = true;
            this.gridPluginFilesView.OptionsView.ShowGroupPanel = false;
            this.gridPluginFilesView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridPluginFilesView_SelectionChanged);
            // 
            // pluginName
            // 
            this.pluginName.Caption = "Name";
            this.pluginName.FieldName = "Name";
            this.pluginName.Name = "pluginName";
            this.pluginName.OptionsColumn.AllowEdit = false;
            this.pluginName.Visible = true;
            this.pluginName.VisibleIndex = 0;
            // 
            // pluginPath
            // 
            this.pluginPath.Caption = "Path";
            this.pluginPath.FieldName = "Path";
            this.pluginPath.Name = "pluginPath";
            this.pluginPath.OptionsColumn.AllowEdit = false;
            this.pluginPath.Visible = true;
            this.pluginPath.VisibleIndex = 1;
            // 
            // pluginVersion
            // 
            this.pluginVersion.Caption = "Version";
            this.pluginVersion.FieldName = "Version";
            this.pluginVersion.Name = "pluginVersion";
            this.pluginVersion.OptionsColumn.AllowEdit = false;
            this.pluginVersion.Visible = true;
            this.pluginVersion.VisibleIndex = 2;
            // 
            // pluginDotNetVersion
            // 
            this.pluginDotNetVersion.Caption = ".NET Version";
            this.pluginDotNetVersion.FieldName = "Framework Version";
            this.pluginDotNetVersion.Name = "pluginDotNetVersion";
            this.pluginDotNetVersion.OptionsColumn.AllowEdit = false;
            this.pluginDotNetVersion.Visible = true;
            this.pluginDotNetVersion.VisibleIndex = 3;
            // 
            // pluginDescription
            // 
            this.pluginDescription.Caption = "Description";
            this.pluginDescription.FieldName = "Description";
            this.pluginDescription.Name = "pluginDescription";
            this.pluginDescription.OptionsColumn.AllowEdit = false;
            this.pluginDescription.Visible = true;
            this.pluginDescription.VisibleIndex = 4;
            // 
            // pluginStatus
            // 
            this.pluginStatus.Caption = "Status";
            this.pluginStatus.ColumnEdit = this.repositoryItemCheckEdit1;
            this.pluginStatus.FieldName = "Status";
            this.pluginStatus.Name = "pluginStatus";
            this.pluginStatus.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.pluginStatus.Visible = true;
            this.pluginStatus.VisibleIndex = 5;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridPluginContents
            // 
            this.gridPluginContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPluginContents.Location = new System.Drawing.Point(12, 218);
            this.gridPluginContents.MainView = this.gridPluginContentsView;
            this.gridPluginContents.MenuManager = this.barManager1;
            this.gridPluginContents.Name = "gridPluginContents";
            this.gridPluginContents.Size = new System.Drawing.Size(1059, 158);
            this.gridPluginContents.TabIndex = 5;
            this.gridPluginContents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPluginContentsView});
            // 
            // gridPluginContentsView
            // 
            this.gridPluginContentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.pluginContentName,
            this.pluginFullName,
            this.pluginContentPath,
            this.pluginContentVersion,
            this.pluginContentAuthor,
            this.pluginContentDescription,
            this.pluginResources});
            this.gridPluginContentsView.GridControl = this.gridPluginContents;
            this.gridPluginContentsView.Name = "gridPluginContentsView";
            this.gridPluginContentsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridPluginContentsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridPluginContentsView.OptionsBehavior.Editable = false;
            this.gridPluginContentsView.OptionsView.ShowGroupPanel = false;
            this.gridPluginContentsView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridPluginContentsView_RowClick);
            this.gridPluginContentsView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridPluginContentsView_SelectionChanged);
            // 
            // pluginContentName
            // 
            this.pluginContentName.Caption = "Plugin Name";
            this.pluginContentName.FieldName = "Name";
            this.pluginContentName.Name = "pluginContentName";
            this.pluginContentName.Visible = true;
            this.pluginContentName.VisibleIndex = 0;
            // 
            // pluginFullName
            // 
            this.pluginFullName.Caption = "Plugin Fullname";
            this.pluginFullName.FieldName = "Fullname";
            this.pluginFullName.Name = "pluginFullName";
            this.pluginFullName.Visible = true;
            this.pluginFullName.VisibleIndex = 1;
            // 
            // pluginContentPath
            // 
            this.pluginContentPath.Caption = "Plugin Path";
            this.pluginContentPath.FieldName = "Path";
            this.pluginContentPath.Name = "pluginContentPath";
            this.pluginContentPath.Visible = true;
            this.pluginContentPath.VisibleIndex = 2;
            // 
            // pluginContentVersion
            // 
            this.pluginContentVersion.Caption = "Version";
            this.pluginContentVersion.FieldName = "Version";
            this.pluginContentVersion.Name = "pluginContentVersion";
            this.pluginContentVersion.Visible = true;
            this.pluginContentVersion.VisibleIndex = 3;
            // 
            // pluginContentAuthor
            // 
            this.pluginContentAuthor.Caption = "Author";
            this.pluginContentAuthor.FieldName = "Author";
            this.pluginContentAuthor.Name = "pluginContentAuthor";
            this.pluginContentAuthor.Visible = true;
            this.pluginContentAuthor.VisibleIndex = 4;
            // 
            // pluginContentDescription
            // 
            this.pluginContentDescription.Caption = "Description";
            this.pluginContentDescription.FieldName = "Description";
            this.pluginContentDescription.Name = "pluginContentDescription";
            this.pluginContentDescription.Visible = true;
            this.pluginContentDescription.VisibleIndex = 5;
            // 
            // pluginResources
            // 
            this.pluginResources.Caption = "Plugin Resources";
            this.pluginResources.FieldName = "Resources";
            this.pluginResources.Name = "pluginResources";
            this.pluginResources.Visible = true;
            this.pluginResources.VisibleIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Plugin Files";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 199);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Plugin Contents";
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnselectAll.Location = new System.Drawing.Point(891, 585);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(180, 38);
            this.btnUnselectAll.TabIndex = 8;
            this.btnUnselectAll.Text = "Un-Select All";
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Location = new System.Drawing.Point(705, 585);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(180, 38);
            this.btnSelectAll.TabIndex = 9;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveSelected.Location = new System.Drawing.Point(12, 585);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(180, 38);
            this.btnRemoveSelected.TabIndex = 10;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 382);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(124, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Plugin Content Export List";
            // 
            // gridPluginContentExports
            // 
            this.gridPluginContentExports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPluginContentExports.Location = new System.Drawing.Point(12, 401);
            this.gridPluginContentExports.MainView = this.gridPluginContentExportsView;
            this.gridPluginContentExports.MenuManager = this.barManager1;
            this.gridPluginContentExports.Name = "gridPluginContentExports";
            this.gridPluginContentExports.Size = new System.Drawing.Size(1059, 178);
            this.gridPluginContentExports.TabIndex = 15;
            this.gridPluginContentExports.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPluginContentExportsView});
            // 
            // gridPluginContentExportsView
            // 
            this.gridPluginContentExportsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MemberName,
            this.MemberType,
            this.Type,
            this.Visibility,
            this.IsStatic,
            this.Parameters});
            this.gridPluginContentExportsView.GridControl = this.gridPluginContentExports;
            this.gridPluginContentExportsView.Name = "gridPluginContentExportsView";
            this.gridPluginContentExportsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridPluginContentExportsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridPluginContentExportsView.OptionsBehavior.Editable = false;
            this.gridPluginContentExportsView.OptionsView.ShowGroupPanel = false;
            // 
            // MemberName
            // 
            this.MemberName.Caption = "Member Name";
            this.MemberName.FieldName = "Name";
            this.MemberName.Name = "MemberName";
            this.MemberName.Visible = true;
            this.MemberName.VisibleIndex = 0;
            // 
            // MemberType
            // 
            this.MemberType.Caption = "Member Type";
            this.MemberType.FieldName = "Member Type";
            this.MemberType.Name = "MemberType";
            this.MemberType.Visible = true;
            this.MemberType.VisibleIndex = 1;
            // 
            // Type
            // 
            this.Type.Caption = "Data Type";
            this.Type.FieldName = "Data Type";
            this.Type.Name = "Type";
            this.Type.Visible = true;
            this.Type.VisibleIndex = 2;
            // 
            // Visibility
            // 
            this.Visibility.Caption = "Visibility";
            this.Visibility.FieldName = "Visibility";
            this.Visibility.Name = "Visibility";
            this.Visibility.Visible = true;
            this.Visibility.VisibleIndex = 4;
            // 
            // IsStatic
            // 
            this.IsStatic.Caption = "Is Static";
            this.IsStatic.FieldName = "IsStatic";
            this.IsStatic.Name = "IsStatic";
            this.IsStatic.Visible = true;
            this.IsStatic.VisibleIndex = 5;
            // 
            // Parameters
            // 
            this.Parameters.Caption = "Parameters";
            this.Parameters.FieldName = "Parameters";
            this.Parameters.Name = "Parameters";
            this.Parameters.Visible = true;
            this.Parameters.VisibleIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Loaded Configuration";
            // 
            // lblLoadedConfig
            // 
            this.lblLoadedConfig.Location = new System.Drawing.Point(22, 47);
            this.lblLoadedConfig.Name = "lblLoadedConfig";
            this.lblLoadedConfig.Size = new System.Drawing.Size(83, 13);
            this.lblLoadedConfig.TabIndex = 22;
            this.lblLoadedConfig.Text = "Currently Loaded";
            // 
            // XFormConfigurationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 652);
            this.Controls.Add(this.lblLoadedConfig);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.gridPluginContentExports);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridPluginContents);
            this.Controls.Add(this.gridPluginFiles);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XFormConfigurationManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Manager";
            this.Load += new System.EventHandler(this.XFormConfigurationManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginFilesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContentExports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginContentExportsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItemFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBrowsePlugin;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLoadConfig;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveConfig;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExit;
        private DevExpress.XtraBars.BarButtonItem barButtonAbout;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraGrid.GridControl gridPluginFiles;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPluginFilesView;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridPluginContents;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPluginContentsView;
        private DevExpress.XtraGrid.Columns.GridColumn pluginName;
        private DevExpress.XtraGrid.Columns.GridColumn pluginPath;
        private DevExpress.XtraGrid.Columns.GridColumn pluginVersion;
        private DevExpress.XtraGrid.Columns.GridColumn pluginDotNetVersion;
        private DevExpress.XtraGrid.Columns.GridColumn pluginDescription;
        private DevExpress.XtraGrid.Columns.GridColumn pluginStatus;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnRemoveSelected;
        private DevExpress.XtraGrid.Columns.GridColumn pluginContentName;
        private DevExpress.XtraGrid.Columns.GridColumn pluginContentPath;
        private DevExpress.XtraGrid.Columns.GridColumn pluginContentVersion;
        private DevExpress.XtraGrid.Columns.GridColumn pluginContentAuthor;
        private DevExpress.XtraGrid.Columns.GridColumn pluginContentDescription;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gridPluginContentExports;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPluginContentExportsView;
        private DevExpress.XtraGrid.Columns.GridColumn MemberName;
        private DevExpress.XtraGrid.Columns.GridColumn MemberType;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn pluginFullName;
        private DevExpress.XtraGrid.Columns.GridColumn Visibility;
        private DevExpress.XtraGrid.Columns.GridColumn Parameters;
        private DevExpress.XtraGrid.Columns.GridColumn IsStatic;
        private DevExpress.XtraEditors.LabelControl lblLoadedConfig;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn pluginResources;
    }
}