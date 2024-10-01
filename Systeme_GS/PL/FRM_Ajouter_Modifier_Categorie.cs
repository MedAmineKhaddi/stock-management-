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
    public partial class FRM_Ajouter_Modifier_Categorie : Form
    {
        private UserControl usercat;
        public FRM_Ajouter_Modifier_Categorie(UserControl usercategorie)
        {
            InitializeComponent();
            this.usercat = usercategorie;
        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
            if(txtNom.Text=="Nom de Categorie")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }

        }
        public int idcategorie;

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            BL.CLS_Categorie clcat = new BL.CLS_Categorie();
            if(txtNom.Text=="" || txtNom.Text == "Nom de Categorie")
            {
                MessageBox.Show("Entrer le Nom de Categorie", "Ajouter Categorie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(lblTitre.Text == "Ajouter Categorie")
                {
                    if(clcat.Ajouter_Categorie(txtNom.Text)==false) //_______________________________________________
                    {
                        MessageBox.Show("Categorie existe d'eja", "Ajouter Categorie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Categorie est Ajouter avec succés", "Ajouter Categorie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        (usercat as USER_LISTE_Categorie).remplirdatagrid();
                    }

                }
                //////////////////////////////////////////
                ///
                if(lblTitre.Text == "Modifer Categorie")
                {
                    
                    DialogResult DR = MessageBox.Show("Voulez-Vous Modifier", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(DR == DialogResult.Yes)
                    {
                        clcat.Modifier_Categorie(idcategorie, txtNom.Text);
                        MessageBox.Show("Categorie Modifier Avec Succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //actualiser dategrid
                        (usercat as USER_LISTE_Categorie).remplirdatagrid();
                    }
                    else
                    {
                        MessageBox.Show("Modification annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            }
        }

        private void FRM_Ajouter_Modifier_Categorie_Load(object sender, EventArgs e)
        {

        }
    }
}
