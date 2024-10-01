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
using Microsoft.Office.Interop.Excel;

namespace Systeme_GS.PL
{
    public partial class USER_LISTE_Categorie : UserControl
    {
        private static USER_LISTE_Categorie userCategorie;
        private dbStockContext db;

        //créer un instance pour le usercontrol
        public static USER_LISTE_Categorie Instance
        {
            get
            {
                if(userCategorie == null)
                {
                    userCategorie = new USER_LISTE_Categorie();
                }
                return userCategorie;
            }
        }
        public USER_LISTE_Categorie()
        {
            InitializeComponent();
            db = new dbStockContext();
        }

        public void remplirdatagrid() //remplir datagrid
        {
            db = new dbStockContext();
            dvgCategorie.Rows.Clear();
            foreach(var Cat in  db.Categories)
            {
                dvgCategorie.Rows.Add(false, Cat.ID_Categorie, Cat.Nom_Categorie);
            }
        }

        public string SelectVerif()
        {
            int Nomberligneselect = 0;
            for (int i = 0; i < dvgCategorie.Rows.Count; i++)
            {
                if ((bool)dvgCategorie.Rows[i].Cells[0].Value == true)//si ligne est selectionner
                {
                    Nomberligneselect++;
                }
            }
            if (Nomberligneselect == 0)
            {
                return "selectionner Categorie";
            }
            if (Nomberligneselect > 1)
            {
                return "selectionner seulement un seul Categorie";
            }
            return null;

        }

        private void USER_LISTE_Categorie_Load(object sender, EventArgs e)
        {
            remplirdatagrid();
        }

        private void textRecherche_Enter(object sender, EventArgs e)
        {
            if(textRecherche.Text == "Recherche")
            {
                textRecherche.Text = "";
                textRecherche.ForeColor = Color.Black;
            }
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Categorie frmcat = new FRM_Ajouter_Modifier_Categorie(this);
            frmcat.ShowDialog();
        }

        private void dvgCategorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Categorie frmcat = new PL.FRM_Ajouter_Modifier_Categorie(this);
            if(dvgCategorie.Columns[e.ColumnIndex].Name=="Modifier") //si vous clicker sur button modifier
            {
                //id de categorie
                frmcat.idcategorie = (int)dvgCategorie.Rows[e.RowIndex].Cells[1].Value; 
                //afficher le nom de categorie dans formilaire
                frmcat.lblTitre.Text ="Modifer Categorie";
                frmcat.txtNom.Text = dvgCategorie.Rows[e.RowIndex].Cells[2].Value.ToString();
                frmcat.ShowDialog();
            }

            //Pour la Suppression
            if (dvgCategorie.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                BL.CLS_Categorie clscat = new BL.CLS_Categorie();
                DialogResult PR = MessageBox.Show("Voulez-Vous Vraiment Sipprimer Categorie", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(PR == DialogResult.Yes)
                {
                    //verifier si il y a des produit dans cette categorie
                    int idcat = (int)dvgCategorie.Rows[e.RowIndex].Cells[1].Value;
                    int P = db.Produits.Count(s => s.ID_Categorie == idcat); //pour avoire combient des produit qui inclus dans cette categorie
                    if(P==0) //aucun Produit dans cette categorie
                    {
                        clscat.Supprimer_Categorie(idcat);
                        //Actualiser datagridView
                        remplirdatagrid();
                        MessageBox.Show("Categorie Supprimer Avec Succées", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                    }
                    else
                    {
                        //sinon
                        DialogResult PDR = MessageBox.Show("Il y a " + P + " Produit(s) dans cette Categorie, Voulez-Vous Vraiment Suppremier", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(PDR == DialogResult.Yes)
                        {
                            clscat.Supprimer_Categorie(idcat);
                            remplirdatagrid();
                            MessageBox.Show("Categorie Supprimer Avec Succées", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            
                        }
                        else
                        {
                            MessageBox.Show("Supprission est Annuler", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Supprission est Annuler", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
        }

        private void textRecherche_TextChanged(object sender, EventArgs e)
        {
            var maliste = db.Categories.ToList();
            maliste = maliste.Where(s => s.Nom_Categorie.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dvgCategorie.Rows.Clear();
            foreach(var l in maliste)
            {
                dvgCategorie.Rows.Add(false, l.ID_Categorie, l.Nom_Categorie);
            }
        }

        private void btnimprimertout_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORTE frmR = new RAP.FRM_RAPPORTE();
            db = new dbStockContext();
            try
            {
                //Listes Categories
                var listeCat = db.Categories.ToList();
                //Nombre de Categorie
                int NBcategorie = db.Categories.Count();
                //Ajouter datasource
                frmR.RPAfficher.LocalReport.ReportEmbeddedResource = "Systeme_GS.RAP.RPT_LISTES_CATEGORIE.rdlc";
                frmR.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("databasecategorie", listeCat)); //Ajouter data Source 
                //date de systeme
                ReportParameter date = new ReportParameter("Date", DateTime.Now.ToShortDateString());
                //Nombre Categorie
                ReportParameter NbC = new ReportParameter("NBCategorie",  NBcategorie.ToString());
                frmR.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { date, NbC });
                frmR.RPAfficher.RefreshReport();
                frmR.ShowDialog();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            db = new dbStockContext();
            String NomCategorie ="";
            int idcategorie=0;

            if (SelectVerif() != null)
            {
                MessageBox.Show(SelectVerif(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SaveFileDialog sf = new SaveFileDialog() { Filter = "Excel workbook|*xlsx", ValidateNames = true })
                {
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application APP = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb = APP.Workbooks.Add(XlSheetType.xlWorksheet);
                        Worksheet ws = (Worksheet)APP.ActiveSheet;
                        APP.Visible = false;

                        //Nom de Categorie et Id Categorie
                        for(int l=0 ; l<dvgCategorie.Rows.Count; l++)
                        {
                            if((bool)dvgCategorie.Rows[l].Cells[0].Value == true)
                            {
                                NomCategorie = dvgCategorie.Rows[l].Cells[2].Value.ToString();
                                idcategorie =(int) dvgCategorie.Rows[l].Cells[1].Value;
                            }
                        }
                        //Ecrire Nom de Categorie dans fichier Excel
                        ws.Range["A1:D1"].Merge();
                        ws.Range["A1:D1"].Value = NomCategorie;

                        //Ajouter Cells de Produit
                        ws.Cells[2, 1] = "Id Produit";
                        ws.Cells[2, 2] = "Nom Produit";
                        ws.Cells[2, 3] = "Quantité";
                        ws.Cells[2, 4] = "Prix";

                        //liste produit dans cette categorie
                        var listeProduit = db.Produits.Where(s => s.ID_Categorie == idcategorie).ToList();
                        int i = 3;
                        foreach(var LP in listeProduit)
                        {
                            ws.Cells[i, 1] = LP.ID_Produit;
                            ws.Cells[i, 2] = LP.Nom_Produit;
                            ws.Cells[i, 3] = LP.Quantite_Produit;
                            ws.Cells[i, 4] = LP.Prix_Produit;
                            i++;

                        }
                        //Style de fichier Excel
                        //Produit
                        ws.Range["A2:D2"].Interior.Color = Color.Teal;
                        ws.Range["A2:D2"].Font.Color = Color.White;
                        ws.Range["A2:D2"].Font.Size = 14;

                        //Categorie
                        ws.Range["A1:D1"].Interior.Color = Color.DarkGreen;
                        ws.Range["A1:D1"].Font.Color = Color.White;
                        ws.Range["A1:D1"].Font.Size = 14;

                        //centrer text
                        ws.Range["A:D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        ws.Range["A2:D2"].ColumnWidth = 15;

                        //sauvgarder dans excel
                        wb.SaveAs(sf.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false);
                        APP.Quit();
                        MessageBox.Show("Sauvgarde avec Succes dans excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        

                    }
                }
            }
        }
    }
}
