using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VB62DotNetLoader.UI.Forms
{
    public partial class XFormAbout : DevExpress.XtraEditors.XtraForm
    {

        public XFormAbout(string version)
        {
            InitializeComponent();
            lblVersion.Text = version;
            lblResVersion.Text = Properties.Resources.Version;
        }

        private void XFormAbout_Load(object sender, EventArgs e)
        {

        }

       
    }
}