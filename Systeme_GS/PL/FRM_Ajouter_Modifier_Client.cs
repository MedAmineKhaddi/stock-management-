using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Systeme_GS.PL
{
    public partial class FRM_Ajouter_Modifier_Client : Form
    {
        private UserControl usclient;
        public FRM_Ajouter_Modifier_Client(UserControl userC)
        {
            InitializeComponent();
            this.usclient = userC;
        }
        //les champs obligatoires
        string testobligatoire()
        {
            if(txtNom.Text=="" || txtNom.Text=="Nom de Client")
            {
                return "Entrer le nom de client";
            }
            if(txtPrenom.Text == "" || txtPrenom.Text == "Prenom de Client")
            {
                return "Entrer le Prenom de client";
            }
            if(txtTelephone.Text == "" || txtTelephone.Text == "Telephone de Client")
            {
                return "Entrer le Telephone de client";
            }
            if(txtAdresse.Text == "" || txtAdresse.Text == "Adresse de Client")
            {
                return "Entrer l'Adresse de client";
            }
            if(txtEmail.Text == "" || txtEmail.Text == "Email de Client")
            {
                return "Entrer Email de client";
            }
            if(txtVille.Text == "" || txtVille.Text == "Ville de Client")
            {
                return "Entrer  Ville de client";
            }
            if(txtPays.Text == "" || txtPays.Text == "Pays de Client")
            {
                return "Entrer Pays de client";
            }
            //Verifier email valide ou pas 
            if(txtEmail.Text != "" || txtEmail.Text != "Email de Client")
            {
                try
                {
                    new MailAddress(txtEmail.Text);

                }catch(Exception e)
                {
                    return "Email Invalide";
                }
            }

       
            return null;
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
            if(txtNom.Text == "Nom de Client")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }
        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "Nom de Client";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void txtAdresse_Enter(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "Adresse de Client")
            {
                txtAdresse.Text = "";
                txtAdresse.ForeColor = Color.White;
            }
        }

        private void txtAdresse_Leave(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "")
            {
                txtAdresse.Text = "Adresse de Client";
                txtAdresse.ForeColor = Color.Silver;
            }
        }

        private void txtPays_Enter(object sender, EventArgs e)
        {
            if (txtPays.Text == "Pays de Client")
            {
                txtPays.Text = "";
                txtPays.ForeColor = Color.White;
            }
        }

        private void txtPays_Leave(object sender, EventArgs e)
        {
            if (txtPays.Text == "")
            {
                txtPays.Text = "Pays de Client";
                txtPays.ForeColor = Color.Silver;
            }
        }

        private void txtPrenom_Enter(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "Prenom de Client")
            {
                txtPrenom.Text = "";
                txtPrenom.ForeColor = Color.White;
            }
        }

        private void txtPrenom_Leave(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "")
            {
                txtPrenom.Text = "Prenom de Client";
                txtPrenom.ForeColor = Color.Silver;
            }
        }

        private void txtTelephone_Enter(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "Telephone de Client")
            {
                txtTelephone.Text = "";
                txtTelephone.ForeColor = Color.White;
            }

        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "Telephone de Client";
                txtTelephone.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email de Client")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email de Client";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtVille_Enter(object sender, EventArgs e)
        {
            if (txtVille.Text == "Ville de Client")
            {
                txtVille.Text = "";
                txtVille.ForeColor = Color.White;
            }
        }

        private void txtVille_Leave(object sender, EventArgs e)
        {
            if (txtVille.Text == "")
            {
                txtVille.Text = "Ville de Client";
                txtVille.ForeColor = Color.Silver;
            }
        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox numérique
            if(e.KeyChar<48 || e.KeyChar>57)
            {
                e.Handled = true;
            }
            if(e.KeyChar==8)
            {
                e.Handled = false;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(testobligatoire()!=null)
            {
                MessageBox.Show(testobligatoire(),"Obligatoire",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }else
            if(lblTitre.Text == "Ajouter Client")
            {
                BL.CLS_Client clclient = new BL.CLS_Client();
                if(clclient.Ajouter_Client(txtNom.Text,txtPrenom.Text,txtAdresse.Text,txtTelephone.Text,txtEmail.Text,txtPays.Text,txtVille.Text)==true)
                {
                    MessageBox.Show("Client Ajouter avec Succés", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usclient as USER_Liste_Client).Actualisedatagrid();
                }
                else
                {
                    MessageBox.Show("Nom et Prenom de Client d'éja existe", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                BL.CLS_Client clclient = new BL.CLS_Client();
               
                DialogResult R = MessageBox.Show("Voulez-Vous Vraiment modifier ce client", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(R==DialogResult.Yes)
                {

                    clclient.Modifier_Client(IDselect, txtNom.Text, txtPrenom.Text, txtAdresse.Text, txtTelephone.Text, txtEmail.Text, txtPays.Text, txtVille.Text);
                    //pour actualiser datagridview
                    (usclient as USER_Liste_Client).Actualisedatagrid();
                    MessageBox.Show("Client modifier avec Succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Modification est annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";txtEmail.ForeColor = Color.Silver;
            txtNom.Text = ""; txtNom.ForeColor = Color.Silver;
            txtPrenom.Text = ""; txtPrenom.ForeColor = Color.Silver;
            txtAdresse.Text = ""; txtAdresse.ForeColor = Color.Silver;
            txtTelephone.Text = ""; txtTelephone.ForeColor = Color.Silver;
            txtPays.Text = ""; txtPays.ForeColor = Color.Silver;
            txtVille.Text = ""; txtVille.ForeColor = Color.Silver;
        }
        public int IDselect;
        private void FRM_Ajouter_Modifier_Client_Load(object sender, EventArgs e)
        {

        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
