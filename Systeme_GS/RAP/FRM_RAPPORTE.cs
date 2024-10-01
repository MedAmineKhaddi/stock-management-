using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systeme_GS.RAP
{
    public partial class FRM_RAPPORTE : Form
    {
        public FRM_RAPPORTE()
        {
            InitializeComponent();
        }

        private void FRM_RAPPORTE_Load(object sender, EventArgs e)
        {

            this.RPAfficher.RefreshReport();
        }
    }
}
