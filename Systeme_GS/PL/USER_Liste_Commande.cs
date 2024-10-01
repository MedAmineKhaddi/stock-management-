using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Systeme_GS.PL
{
    public partial class USER_Liste_Commande : UserControl
    {
        private static USER_Liste_Commande UserCommande;
        private dbStockContext db;

        //creer un instance pour le usercontrol
        public static USER_Liste_Commande Instance
        {
            get
            {
                if(UserCommande == null)
                {
                    UserCommande = new USER_Liste_Commande();
                }
                return UserCommande;
            }
        }
        public USER_Liste_Commande()
        {
            InitializeComponent();
            db = new dbStockContext();
        }
        //Remplir datagridView commande
        public void Remplirdata()
        {
            dvgCommande.Rows.Clear();
            Client c = new Client();
            string NomPrenom;
            foreach(var LC in db.Commandes)
            {
                //Afficher Nom+Prenom de Client
                c = db.Clients.Single(s => s.ID_Client == LC.ID_Client);
                NomPrenom = c.Nom_Client + " " + c.Prenom_Client;
                dvgCommande.Rows.Add(LC.ID_Commande, LC.DATE_Commande,NomPrenom,LC.Total_HT,LC.TVA,LC.Total_TTC) ;
            }
                
        }

        private void USER_Liste_Commande_Load(object sender, EventArgs e)
        {
            Remplirdata();
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            PL.FRM_Detail_Commande frmC = new FRM_Detail_Commande(this);
            frmC.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Recherche Entre deux date
            var listecommande = db.Commandes.ToList(); //liste des commandes
            if(dvgCommande.Rows.Count !=0 )
            {
                listecommande = listecommande.Where(s => s.DATE_Commande >= dateD.Value.Date && s.DATE_Commande <= dateF.Value.Date).ToList();

                //remplir datagridView
                dvgCommande.Rows.Clear();
                Client c = new Client();
                string NomPrenom;
                foreach (var LC in listecommande)
                {
                    //Afficher Nom+Prenom de Client
                    c = db.Clients.Single(s => s.ID_Client == LC.ID_Client);
                    NomPrenom = c.Nom_Client + " " + c.Prenom_Client;
                    dvgCommande.Rows.Add(LC.ID_Commande, LC.DATE_Commande, LC.DATE_Commande, NomPrenom, LC.Total_HT, LC.TVA, LC.Total_TTC);
                }
            }

        }

        private void btnimprimerselect_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORTE frmrap = new RAP.FRM_RAPPORTE();
            db = new dbStockContext();
            try
            {
                // commande selectionner 
                int IdCommande = (int)dvgCommande.CurrentRow.Cells[0].Value;
                var Commande = db.Commandes.Single(s => s.ID_Commande == IdCommande);

                //Client 
                var ClientCommande = db.Clients.Single(s => s.ID_Client == Commande.ID_Client);

                //Detail De Commande
                var listedateil = db.Details_Commande.Where(s => s.ID_Commande == IdCommande).ToList();

                //Ajouter listedetail dans datasource de rapport
                frmrap.RPAfficher.LocalReport.ReportEmbeddedResource = " Systeme_GS.Systeme_GS.RAP.RPT_Commande.rdlc";
                frmrap.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("dataCommande", listedateil));

                //Ajouter information de Client
                ReportParameter NomPrenom = new ReportParameter("NomPrenomClient",ClientCommande.Nom_Client+" "+ClientCommande.Prenom_Client);
                ReportParameter Adresse = new ReportParameter("AdresseC", ClientCommande.Adresse_Client);
                ReportParameter Telephone = new ReportParameter("TelephoneC", ClientCommande.Telephone_Client);
                ReportParameter Email = new ReportParameter("EmailC", ClientCommande.Emai_Client);

                //Ajouter Les infos De Commande
                ReportParameter NumeroCommande = new ReportParameter("IdCommande", IdCommande.ToString());
                ReportParameter DateCommande = new ReportParameter("DateCommande", Commande.DATE_Commande.ToString());

                //Ajouter Les Touteaux
                ReportParameter Totalht = new ReportParameter("Totalht", Commande.Total_HT);
                ReportParameter Tva = new ReportParameter("Tva", Commande.TVA);
                ReportParameter Totalttc = new ReportParameter("Totalttc", Commande.Total_TTC);

                //Enregistrer les valeurs
                frmrap.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { NomPrenom, Adresse, Telephone, Email, NumeroCommande, DateCommande, Totalht, Tva, Totalttc });
                frmrap.RPAfficher.RefreshReport();
                frmrap.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dvgCommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
