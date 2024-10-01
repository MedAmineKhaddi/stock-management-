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
    public partial class FRM_Connexion : Form
    {
        private dbStockContext db;
        private Form frmmenu;
        //classe connexion
        BL.CLS_Connexion C = new BL.CLS_Connexion();
        public FRM_Connexion( Form Menu)
        {
            InitializeComponent();
            this.frmmenu = Menu;
            //initialiser base de donée
            db = new dbStockContext();
        }

        //pour verifier les chapms principales
         public string testobligatoire()
        {
            if(textNom.Text=="" || textNom.Text=="Nom d'utilisateur")
            {
                return "Entrer Votre Nom";
            }
            if(textMotdepasse.Text =="" || textMotdepasse.Text=="Mot de Passe")
            {
                return "Entrer Votre Mot de Passe";
            }
            return null;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textNom_Enter(object sender, EventArgs e)
        {
            if (textNom.Text == "Nom d'utilisateur")
            {
                textNom.Text = "";
                textNom.ForeColor = Color.WhiteSmoke;
            }
        }

        private void textMotdepasse_Enter(object sender, EventArgs e)
        {
            if(textMotdepasse.Text =="Mot de Passe")
            {
                textMotdepasse.Text = "";
                textMotdepasse.UseSystemPasswordChar = false;
                textMotdepasse.PasswordChar = '*';
                textMotdepasse.ForeColor = Color.WhiteSmoke;
            }
        }

        private void textNom_Leave(object sender, EventArgs e)
        {
            if(textNom.Text=="")
            {
                textNom.Text = "Nom d'utilisateur";
                textNom.ForeColor = Color.Silver;
            }
        }

        private void textMotdepasse_Leave(object sender, EventArgs e)
        {
            if (textMotdepasse.Text == "")
            {
                textMotdepasse.Text = "Mot de Passe";
                textMotdepasse.UseSystemPasswordChar = true;
                textMotdepasse.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(testobligatoire()==null)
            {
                if(C.ConnexionValide(db,textNom.Text,textMotdepasse.Text)==true) //Utilisateur existe
                {
                    MessageBox.Show("Connexion a réussi", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (frmmenu as FRM_MENU).activerForm();
                    this.Close();
                } else 
                {
                    MessageBox.Show("Connexion a échoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show(testobligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_Connexion_Load(object sender, EventArgs e)
        {

        }
    }
}
