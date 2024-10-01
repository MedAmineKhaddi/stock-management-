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
    public partial class FRM_MENU : Form
    {
        public FRM_MENU()
        {
            InitializeComponent();
            panel1.Size = new Size(229, 612);
            pnlParamettre.Visible = false;
        }
        //desactiver formulaire
        public void desactiverForm()
        {
            btnClient.Enabled = false;
            btnCommande.Enabled = false;
            btnCategorie.Enabled = false;
            btnUtilisateur.Enabled = false;
            btnProduit.Enabled = false;
            btncopie.Enabled = false;
            btnrestaurer.Enabled = false;
            btndeconnecter.Enabled = false;
            btnConnecter.Enabled = true;
            pnlbut.Visible = false;
        }

        //activer formulaire
        public void activerForm()
        {
            btnClient.Enabled = true;
            btnCommande.Enabled = true;
            btnCategorie.Enabled = true;
            btnUtilisateur.Enabled = true;
            btnProduit.Enabled = true;
            btncopie.Enabled = true;
            btnrestaurer.Enabled = true;
            btndeconnecter.Enabled = true;
            btnConnecter.Enabled = false;
            pnlbut.Visible = true;
            pnlParamettre.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCategorie_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnCategorie.Top;
            if(!pnlafficher.Controls.Contains(USER_LISTE_Categorie.Instance))
            {
                pnlafficher.Controls.Add(USER_LISTE_Categorie.Instance);
                USER_LISTE_Categorie.Instance.Dock = DockStyle.Fill;
                USER_LISTE_Categorie.Instance.BringToFront();
            }
            else
            {
                USER_LISTE_Categorie.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(panel1.Width == 229)
            {
                panel1.Size = new Size(82, 612);
            }
            else
            {
                panel1.Size = new Size(229,612);
            }
        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnProduit.Top;
            pnlbut.Top = btnProduit.Top;
            if (!pnlafficher.Controls.Contains(USER_Liste_Produit.Instance))
            {
                pnlafficher.Controls.Add(USER_Liste_Produit.Instance);
                USER_Liste_Produit.Instance.Dock = DockStyle.Fill;
                USER_Liste_Produit.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Produit.Instance.BringToFront();
            }
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnCommande.Top;
            
            if (!pnlafficher.Controls.Contains(USER_Liste_Commande.Instance))
            {
                pnlafficher.Controls.Add(USER_Liste_Commande.Instance);
                USER_Liste_Commande.Instance.Dock = DockStyle.Fill;
                USER_Liste_Commande.Instance.BringToFront();

            }
            else
            {
                USER_Liste_Commande.Instance.BringToFront();
            }

        }

        private void btnUtilisateur_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnUtilisateur.Top;
            MessageBox.Show("vous êtes connecté à ce systemede gestion de stock", "UTILISATEUR",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnClient.Top;
            if(!pnlafficher.Controls.Contains(USER_Liste_Client.Instance))
            {
                pnlafficher.Controls.Add(USER_Liste_Client.Instance);
                USER_Liste_Client.Instance.Dock = DockStyle.Fill;
                USER_Liste_Client.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Client.Instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnParamettre_Click(object sender, EventArgs e)
        {
            pnlParamettre.Size = new Size(309, 170);
            pnlParamettre.Visible = !pnlParamettre.Visible;
        }

        private void pnlParamettre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConnecter_Click(object sender, EventArgs e)
        {
            FRM_Connexion frmc = new FRM_Connexion(this);
            frmc.ShowDialog();
        }

        private void FRM_MENU_Load(object sender, EventArgs e)
        {
            desactiverForm();
        }

        private void btndeconnecter_Click(object sender, EventArgs e)
        {
            desactiverForm();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
