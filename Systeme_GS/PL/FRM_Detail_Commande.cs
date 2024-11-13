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
    public partial class FRM_Detail_Commande : Form
    {
        private UserControl userCommande;
        private UserControl userProduit;
        private dbStockContext db;
        public FRM_Detail_Commande(UserControl user)
        {
            InitializeComponent();
            db = new dbStockContext();
            userCommande = user;
        }
        //Remplir dataGridView de Commande Par Liste qui Déclarer dans la classe D_Commande
        public void Actualise_DetailCommande()
        {
            //Calculer  Les Touteaux
            float Totalht=0,Tva=0,Totalttc=0;
            if(txttva.Text!="")
            {
                Tva = float.Parse(txttva.Text);
            }
            dvgdetailCommande.Rows.Clear();
            foreach(var L in BL.D_Commande.listeDetail)
            {
                dvgdetailCommande.Rows.Add(L.Id, L.Nom, L.Quantite, L.Prix, L.Remise, L.Total);
                Totalht = Totalht + float.Parse(L.Total);
            }
            txttotalht.Text = Totalht.ToString();
            //Calculer Total TTC
            Totalttc = (Totalht + (Totalht * Tva / 100));
            //Afficher Total TTC dans textbox 
            txttotalttc.Text = Totalttc.ToString();

        }

        //fonction remplire datagridView de Produit
        public void RempliredvgProduit()
        {
            db = new dbStockContext();
            foreach(var l in db.Produits)
            {
                dvgProduit.Rows.Add(l.ID_Produit, l.Nom_Produit, l.Quantite_Produit, l.Prix_Produit);
            }
            //Colorer stock vide en rouge
            for (int i = 0; i < dvgProduit.Rows.Count; i++)
            {
                if ((int)dvgProduit.Rows[i].Cells[2].Value < 10) //si stock est inférieure a 10
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
                else
                {
                    dvgProduit.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;

                }
            }

            //vider ligne selectionneer
            dvgProduit.ClearSelection();
        }

        private void FRM_Detail_Commande_Load(object sender, EventArgs e)
        {
            RempliredvgProduit();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            Close();

            //Vider la liste des produit commander 
            BL.D_Commande.listeDetail.Clear();
        }

        private void textRecherche_Enter(object sender, EventArgs e)
        {
            if(textRecherche.Text == "Recherche")
            {
                textRecherche.Text = "";
                textRecherche.ForeColor = Color.White;
            }
        }

        private void textRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new dbStockContext();
            var listerecherche = db.Produits.ToList();
            //recherche seulment par Le Nom de Produit  
            listerecherche = listerecherche.Where(s => s.Nom_Produit.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();




            //vider datagridview
            dvgProduit.Rows.Clear();
             
            foreach (var l in listerecherche)
            {
                dvgProduit.Rows.Add(l.ID_Produit, l.Nom_Produit, l.Quantite_Produit, l.Prix_Produit);
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            PL.Frm_Client_Commande frmC = new Frm_Client_Commande();
            frmC.ShowDialog();

            //Afficher les information de Client
            IDCLIENT = (int)frmC.dvgclient.CurrentRow.Cells[0].Value;
            txtNom.Text = frmC.dvgclient.CurrentRow.Cells[1].Value.ToString();
            txtprenomc.Text = frmC.dvgclient.CurrentRow.Cells[2].Value.ToString();
            txtemailc.Text = frmC.dvgclient.CurrentRow.Cells[5].Value.ToString();
            txttelephonec.Text = frmC.dvgclient.CurrentRow.Cells[4].Value.ToString();
            txtpaysc.Text = frmC.dvgclient.CurrentRow.Cells[6].Value.ToString();
            txtvillec.Text = frmC.dvgclient.CurrentRow.Cells[3].Value.ToString();
        }

        private void dvgProduit_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FRM_Produit_Commande frmp = new FRM_Produit_Commande(this);
            //si le stock est vide
            if ((int)dvgProduit.CurrentRow.Cells[2].Value == 0)
            {
                MessageBox.Show("Stock est Vide", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Afficher les information de Produit
                frmp.lblid.Text = dvgProduit.CurrentRow.Cells[0].Value.ToString();
                frmp.lblnom.Text = dvgProduit.CurrentRow.Cells[1].Value.ToString();
                frmp.lblstock.Text = dvgProduit.CurrentRow.Cells[2].Value.ToString();
                frmp.lblprix.Text = dvgProduit.CurrentRow.Cells[3].Value.ToString();
                frmp.txttotal.Text = dvgProduit.CurrentRow.Cells[3].Value.ToString();
                frmp.ShowDialog();
            }

        }

        private void txtemailc_TextChanged(object sender, EventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_Produit_Commande frm = new FRM_Produit_Commande(this);
            Produit PR = new Produit();
            if(dvgdetailCommande.CurrentRow!=null)
            {
                frm.grpproduit.Text = "Modifer Produit";
                //Afficher les information de Produit Modifier
                frm.lblid.Text = dvgdetailCommande.CurrentRow.Cells[0].Value.ToString();
                frm.lblnom.Text = dvgdetailCommande.CurrentRow.Cells[1].Value.ToString();

                //Importer Stock de Produit
                int IDP = int.Parse(dvgdetailCommande.CurrentRow.Cells[0].Value.ToString());
                PR = db.Produits.Single(s => s.ID_Produit == IDP);
                frm.lblstock.Text = PR.Quantite_Produit.ToString();
                ///////////////////////////////////////////////
                frm.lblprix.Text = dvgdetailCommande.CurrentRow.Cells[3].Value.ToString();
                frm.txtquantité.Text = dvgdetailCommande.CurrentRow.Cells[2].Value.ToString();
                frm.txtremise.Text = dvgdetailCommande.CurrentRow.Cells[4].Value.ToString();
                frm.txttotal.Text = dvgdetailCommande.CurrentRow.Cells[5].Value.ToString();


                frm.ShowDialog();

                //sauvgarder les changement

            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dvgdetailCommande.CurrentRow != null)
            {
                DialogResult PR = MessageBox.Show("Voulez-Vous Vraiment Supprimer Cette Commande", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (PR == DialogResult.Yes)
                {

                    int index = BL.D_Commande.listeDetail.FindIndex(s => s.Id == int.Parse(dvgdetailCommande.CurrentRow.Cells[0].Value.ToString()));
                    BL.D_Commande.listeDetail.RemoveAt(index);

                    //Actualiser datagridView
                    Actualise_DetailCommande();

                    MessageBox.Show("Suppresion Avec Succées", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppresion est Annulée ", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txttva_TextChanged(object sender, EventArgs e)
        {
            //Calculer TTC
            Actualise_DetailCommande();
        }
        //Id_Client 
        public int IDCLIENT;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            BL.CLS_Produit cls_pr = new BL.CLS_Produit();
            BL.CLS_Commande_DetailCommande clscommande = new BL.CLS_Commande_DetailCommande();
            if (dvgdetailCommande.Rows.Count == 0) //Si datagridView est Vide
            {
                MessageBox.Show("Ajouter des Produit", "Enregistrer", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (txtNom.Text == "")
                {
                    MessageBox.Show("Ajouter Un Client", "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Enregistrer Commande
                    clscommande.Ajouter_Commande(commandedate.Value, IDCLIENT, txttotalht.Text, txttva.Text, txttotalttc.Text);

                    //Enregistrer liste Details_Commande dans base de donnée
                    foreach(var LD in BL.D_Commande.listeDetail)
                    {
                        // Modifier la table produit 
                        Produit PR = new Produit();
                        
                        clscommande.Ajouter_Detail(LD.Id, LD.Nom, LD.Quantite, LD.Prix, LD.Remise, LD.Total);
                        cls_pr.Modifier_quantité(LD.Id, LD.Quantite);
                        db.SaveChangesAsync();
                       
                    }
                    (userCommande as USER_Liste_Commande).Remplirdata();
                


                    //vider liste
                    BL.D_Commande.listeDetail.Clear();
                    //quitter formulaire
                    Close();
                    MessageBox.Show("Commande Ajouter Avec Succées", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }
    }
}
