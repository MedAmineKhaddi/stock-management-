using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systeme_GS.PL
{
    public partial class FRM_Ajouter_Stock : Form
    {
        public FRM_Ajouter_Stock()
        {
            InitializeComponent();
        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtQuantite_Enter(object sender, EventArgs e)
        {
            if (txtQuantite.Text == "Quantité")
            {
                txtQuantite.Text = "";
                txtQuantite.ForeColor = Color.White;
            }
        }

        private void txtQuantite_Leave(object sender, EventArgs e)
        {
            if (txtQuantite.Text == "")
            {
                txtQuantite.Text = "Quantité";
                txtQuantite.ForeColor = Color.Silver;
            }
        }
    }
}
