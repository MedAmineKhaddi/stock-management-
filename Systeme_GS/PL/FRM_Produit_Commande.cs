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
    public partial class FRM_Produit_Commande : Form
    {
        public Form frmdetail;
        public FRM_Produit_Commande(Form frm)
        {
            InitializeComponent();
            frmdetail = frm;
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtquantité_KeyPress(object sender, KeyPressEventArgs e)
        {
            //text forme numérique
           
        }

        private void txtremise_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtquantité_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtremise_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //Si textbox Quantite et textbox Remise est Vide
            int quantite, Rms;
            if (txtquantité.Text!="")
            {
                quantite = int.Parse(txtquantité.Text);
            }
            else
            {
                quantite = 1;
            }
            if(txtremise.Text!="")
            {
                Rms =int.Parse(txtremise.Text);
            }
            else
            {
                Rms = 0;
            }
            //Ajouter Produit dans zone de Commande
            BL.D_Commande DERAIL = new BL.D_Commande
            {
                Id = int.Parse(lblid.Text),
                Nom = lblnom.Text,
                Quantite = quantite,
                Prix = lblprix.Text,
                Remise = Rms.ToString(),
                Total = txttotal.Text,
            };
            //Ajouter dans liste
            if(grpproduit.Text == "Vendre Produit")
            {
                if (BL.D_Commande.listeDetail.SingleOrDefault(s => s.Id == DERAIL.Id) != null)
                {
                    MessageBox.Show("Produit d'eja existe dans Liste de Commande", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    BL.D_Commande.listeDetail.Add(DERAIL);
                }
            }
            else
            {
                //Modifier Liste
                DialogResult PR = MessageBox.Show("Voulez-Vous Vraiment Modifier cette Commande", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(PR == DialogResult.Yes)
                {
                    //trouver index de Produit modifier
                    int index = BL.D_Commande.listeDetail.FindIndex(s => s.Id == int.Parse(lblid.Text));
                    BL.D_Commande.listeDetail[index] = DERAIL;
                    MessageBox.Show("Modification Avec Succées", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {
                    MessageBox.Show("Modification est Annulée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }

            //Actualiser datagrid
            (frmdetail as FRM_Detail_Commande).Actualise_DetailCommande();
        }

        private void txtremise_TextChanged_1(object sender, EventArgs e)
        {
            if (txtremise.Text != "")
            {
                int quantite;
                if (txtquantité.Text != "")
                {
                    quantite = int.Parse(txtquantité.Text);
                }
                else
                {
                    quantite = 1;
                }
                {

                    int prix = int.Parse(lblprix.Text);
                    int total = quantite * prix;
                    int remise = int.Parse(txtremise.Text);
                    txttotal.Text = (total - (total * remise / 100)).ToString();
                }

            }
            else
            {
                int quantite;
                if (txtquantité.Text != "")
                {
                    quantite = int.Parse(txtquantité.Text);
                }
                else
                {
                    quantite = 1;
                }

                int prix = int.Parse(lblprix.Text);
                txttotal.Text = (quantite * prix).ToString();
            }

        }

        private void txtquantité_TextChanged_1(object sender, EventArgs e)
        {
            if (txtquantité.Text != "")
            {
                int Quantite = int.Parse(txtquantité.Text);
                int prix = int.Parse(lblprix.Text);
                if (int.Parse(txtquantité.Text) > int.Parse(lblstock.Text))
                {
                    MessageBox.Show("Il y a sulment " + int.Parse(lblstock.Text) + " dans le Stock", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtquantité.Text = "";
                    txttotal.Text = lblprix.Text;
                }
                else
                {
                    //Calculer total
                    txttotal.Text = (Quantite * prix).ToString();
                }


            }
            else
            {
                txttotal.Text = lblprix.Text;
            }
        }

        private void txttotal_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtquantité_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtremise_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //text forme numérique
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
