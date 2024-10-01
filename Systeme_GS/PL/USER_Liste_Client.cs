using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace Systeme_GS.PL
{
    public partial class USER_Liste_Client : UserControl
    {
        private static USER_Liste_Client Userclient;
        private dbStockContext db;
        //créer une instance
        public static USER_Liste_Client Instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new USER_Liste_Client();
                }
                return Userclient;
            }
        }

        public USER_Liste_Client()
        {
            InitializeComponent();
            db = new dbStockContext();
            //desactiver textbox de recherche
            textRecherche.Enabled = false;
        }

        //ajouter data grid view
        public void Actualisedatagrid()
        {
            db = new dbStockContext();
            dvgclient.Rows.Clear();
            foreach (var S in db.Clients)
            {
                //ajouter les ligne dans datagridview
                dvgclient.Rows.Add(false, S.ID_Client, S.Nom_Client, S.Prenom_Client, S.Adresse_Client, S.Telephone_Client, S.Emai_Client, S.Pays_Client, S.Ville_Client);
            }
        }

        //verifier combien de ligne séléctionner
        public string SelectVerif()
        {
            int Nomberligneselect = 0;
            for (int i = 0; i < dvgclient.Rows.Count; i++)
            {
                if ((bool)dvgclient.Rows[i].Cells[0].Value == true)//si ligne est selectionner
                {
                    Nomberligneselect++;
                }
            }
            if (Nomberligneselect == 0)
            {
                return "selectionner le client que vous-voulez modifier";
            }
            if (Nomberligneselect > 1)
            {
                return "selectionner seulement un seul client pour le modifier";
            }
            return null;

        }

        private void textRecherche_Enter(object sender, EventArgs e)
        {
            if (textRecherche.Text == "Recherche")
            {
                textRecherche.Text = "";
                textRecherche.ForeColor = Color.Black;
            }
        }

        private void USER_Liste_Client_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();

        }

        private void btnajouterClient_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Client frmclient = new FRM_Ajouter_Modifier_Client(this);
            frmclient.ShowDialog();
        }



        private void btnmodifierClient_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Client frmclient = new FRM_Ajouter_Modifier_Client(this);
            if (SelectVerif() == null)
            {
                for (int i = 0; i < dvgclient.Rows.Count; i++)
                {
                    if ((bool)dvgclient.Rows[i].Cells[0].Value == true) //si le choix est vrai afficher les infos dans la formulaire client
                    {
                        frmclient.IDselect = (int)dvgclient.Rows[i].Cells[1].Value;
                        frmclient.txtNom.Text = dvgclient.Rows[i].Cells[2].Value.ToString();
                        frmclient.txtPrenom.Text = dvgclient.Rows[i].Cells[3].Value.ToString();
                        frmclient.txtAdresse.Text = dvgclient.Rows[i].Cells[4].Value.ToString();
                        frmclient.txtTelephone.Text = dvgclient.Rows[i].Cells[5].Value.ToString();
                        frmclient.txtEmail.Text = dvgclient.Rows[i].Cells[6].Value.ToString();
                        frmclient.txtPays.Text = dvgclient.Rows[i].Cells[7].Value.ToString();
                        frmclient.txtVille.Text = dvgclient.Rows[i].Cells[8].Value.ToString();

                    }
                }
                frmclient.lblTitre.Text = "Modifier Client";
                frmclient.btnActualiser.Visible = false;
                frmclient.ShowDialog();
            }
            else
            {
                MessageBox.Show(SelectVerif(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnsupprimerClient_Click(object sender, EventArgs e)
        {
            BL.CLS_Client clclient = new BL.CLS_Client();
            int select = 0;
            for (int i = 0; i < dvgclient.Rows.Count; i++)
            {
                if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                {
                    select++;
                }
            }
            if (select == 0)
            {
                MessageBox.Show("Aucun Client Selectionner", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult R = MessageBox.Show("Voulez-Vous Vraiment Supprimer Ce Client", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    for (int i = 0; i < dvgclient.Rows.Count; i++)
                    {
                        if ((bool)dvgclient.Rows[i].Cells[0].Value == true)
                        {
                            clclient.Suppimer_Client(int.Parse(dvgclient.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                    //Actualiser datagridview
                    Actualisedatagrid();
                    MessageBox.Show("Suppression Avec Succées", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppresion est Annulé", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void comboRecherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            //activer le textbox recherche si j'ai choisie un champ
            textRecherche.Enabled = true;
            textRecherche.Text = ""; //vider le textbox de recherche
        }

        private void textRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new dbStockContext();
            var listerecherche = db.Clients.ToList();
            if(textRecherche.Text!="") //pas vide
            {
                switch(comboRecherche.Text)
                {
                    case "Nom":
                        listerecherche = listerecherche.Where(s => s.Nom_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Prenom":
                        listerecherche = listerecherche.Where(s => s.Prenom_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Adresse":
                        listerecherche = listerecherche.Where(s => s.Adresse_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Telephone":
                        listerecherche = listerecherche.Where(s => s.Telephone_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Email":
                        listerecherche = listerecherche.Where(s => s.Emai_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Pays":
                        listerecherche = listerecherche.Where(s => s.Pays_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Ville":
                        listerecherche = listerecherche.Where(s => s.Ville_Client.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                }
            }
            //vider datagridview
            dvgclient.Rows.Clear();
            //ajouter listerecherche dans datagridview client
            foreach(var l in listerecherche)
            {
                dvgclient.Rows.Add(false, l.ID_Client, l.Nom_Client, l.Prenom_Client, l.Adresse_Client, l.Telephone_Client, l.Emai_Client, l.Pays_Client, l.Ville_Client);
            }
        }

        private void textRecherche_Leave(object sender, EventArgs e)
        {

        }
    }
}
