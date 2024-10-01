using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Office.Interop.Excel;

namespace Systeme_GS.PL
{
    public partial class USER_Liste_Produit : UserControl
    {
        private static USER_Liste_Produit Userproduit;
        private dbStockContext db;
        //créer une instance
        public static USER_Liste_Produit Instance
        {
            get
            {
                if (Userproduit == null)
                {
                    Userproduit = new USER_Liste_Produit();
                }
                return Userproduit;
            }
        }

        public USER_Liste_Produit()
        {
            InitializeComponent();
            db = new dbStockContext();
        }

        //actualiser datagridview 
        public void Actualiserdvg()
        {
            db = new dbStockContext();
            dvgProduit.Rows.Clear();
            //pour afficher le nom de categorie a partie de idcategorie
            Categorie Cat = new Categorie();
            foreach(var Lis in db.Produits)
            {
                Cat = db.Categories.SingleOrDefault(s => s.ID_Categorie == Lis.ID_Categorie); //si idcategorie dan stable produit égal id categorie dans table categorie
                if(Cat !=null)//si existe
                {
                    dvgProduit.Rows.Add(false, Lis.ID_Produit, Lis.Nom_Produit, Lis.Quantite_Produit, Lis.Prix_Produit, Cat.Nom_Categorie);
                }
            }

            //Colorer stock vide en rouge
            for(int i=0; i<dvgProduit.Rows.Count;i++)
            {
                if ((int)dvgProduit.Rows[i].Cells[3].Value <10) //si stock est inférieure a 10
                {
                    dvgProduit.Rows[i].Cells[3].Style.BackColor = Color.Red;
                }
                else
                {
                    dvgProduit.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;

                }
            }
        }

        //verifier combien de ligne séléctionner
        public string SelectVerif()
        {
            int Nomberligneselect = 0;
            for (int i = 0; i < dvgProduit.Rows.Count; i++)
            {
                if ((bool)dvgProduit.Rows[i].Cells[0].Value == true)//si ligne est selectionner
                {
                    Nomberligneselect++;
                }
            }
            if (Nomberligneselect == 0)
            {
                return "selectionner Produit";
            }
            if (Nomberligneselect > 1)
            {
                return "selectionner seulement un seul Produit";
            }
            return null;

        }

        private void USER_Liste_Produit_Load(object sender, EventArgs e)
        {
            Actualiserdvg();
        }

        private void textRecherche_Enter(object sender, EventArgs e)
        {
            if (textRecherche.Text == "Recherche")
            {
                textRecherche.Text = "";
                textRecherche.ForeColor = Color.Black;
            }
        }

        private void textRecherche_Leave(object sender, EventArgs e)
        {

        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifier_Produit frmProduit = new PL.FRM_Ajouter_Modifier_Produit(this);
            frmProduit.ShowDialog();
        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            Produit PR = new Produit();
            if(SelectVerif()!=null)
            {
                MessageBox.Show(SelectVerif(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else{
                PL.FRM_Ajouter_Modifier_Produit frmproduit = new FRM_Ajouter_Modifier_Produit(this);
                frmproduit.lblTitre.Text = "Modifier Produit";
                frmproduit.btnActualiser.Visible = false;
                for (int i = 0; i < dvgProduit.Rows.Count; i++)
                {
                    if ((bool)dvgProduit.Rows[i].Cells[0].Value == true)//si ligne selectionner 
                    {
                        int MYIDSELECT = (int)dvgProduit.Rows[i].Cells[1].Value;  //le variable MYIDSELECT = id de ligne selectionner 
                        PR = db.Produits.SingleOrDefault(s => s.ID_Produit == MYIDSELECT); //certifier si id de produit == id selectionner dans datagridview
                        if (PR != null) //if existe
                        {

                            frmproduit.combocategorie.Text = dvgProduit.Rows[i].Cells[5].Value.ToString();
                            frmproduit.txtNomP.Text = dvgProduit.Rows[i].Cells[2].Value.ToString();
                            frmproduit.txtQuantite.Text = dvgProduit.Rows[i].Cells[3].Value.ToString();
                            frmproduit.txtprix.Text = dvgProduit.Rows[i].Cells[4].Value.ToString();
                            frmproduit.IDPRODUIT = (int)dvgProduit.Rows[i].Cells[1].Value;
                            //Afficher image de produit pour modifier
                            MemoryStream MS = new MemoryStream(PR.Image_Produit); //pour convertire image de produit pour afficher dans pictbox
                            frmproduit.picProduit.Image = Image.FromStream(MS);



                        }

                       

                        

                    }
                }

                        
                frmproduit.ShowDialog();
            }
            
        }

        private void btnafficherphoto_Click(object sender, EventArgs e)
        {
            Produit PR = new Produit();
            if(SelectVerif()!=null)
            {
                MessageBox.Show(SelectVerif(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                for(int i=0;i<dvgProduit.Rows.Count;i++)
                {
                    if((bool)dvgProduit.Rows[i].Cells[0].Value==true)//si ligne selectionner 
                    {
                        int MYIDSELECT = (int)dvgProduit.Rows[i].Cells[1].Value;  //le variable MYIDSELECT = id de ligne selectionner 
                        PR = db.Produits.SingleOrDefault(s => s.ID_Produit == MYIDSELECT); //certifier si id de produit == id selectionner dans datagridview
                        if(PR!=null) //if existe
                        {
                            FRM_Photo_Produit frmP = new FRM_Photo_Produit();
                            //declare system.IO
                            MemoryStream MS = new MemoryStream(PR.Image_Produit); //pour convertire image de produit pour afficher dans pictbox
                            frmP.ProduitImage.Image = Image.FromStream(MS);
                            frmP.ProduitNom.Text = dvgProduit.Rows[i].Cells[2].Value.ToString();

                            //Afficher Formulaire
                            frmP.ShowDialog();

                        }
                    }
                }
            }

        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            if(SelectVerif() == "selectionner Produit")
            {
                MessageBox.Show(SelectVerif() , "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult DR = MessageBox.Show("Voulez-Vous vraiment Supprimer ce Produit", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(DR == DialogResult.Yes)
                //verifier combien des lignes sélectionner

                {
                    for (int i = 0; i < dvgProduit.Rows.Count; i++)
                    {
                        if ((bool)dvgProduit.Rows[i].Cells[0].Value == true) //si ligne cocher
                        {
                            BL.CLS_Produit clproduit = new BL.CLS_Produit();
                            int idselect = (int)dvgProduit.Rows[i].Cells[1].Value; //id de ligne cocher
                            clproduit.Supprimer_Produit(idselect);
                        }
                    }

                    //Actualiser datagridView
                    Actualiserdvg();
                    MessageBox.Show("Produit Supprimer avec Succés", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    MessageBox.Show("Suppresion est annulé", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
                
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
            //ajouter listerecherche dans datagridview client
            Categorie cat = new Categorie();
            foreach (var l in listerecherche)
            {
                cat = db.Categories.SingleOrDefault(s => s.ID_Categorie == l.ID_Categorie); //pour afficher no de categorie 
                dvgProduit.Rows.Add(false,l.ID_Produit,l.Nom_Produit,l.Quantite_Produit,l.Prix_Produit,cat.Nom_Categorie);
            }









        }

        private void btnimprimerselect_Click(object sender, EventArgs e)
        {
            db = new dbStockContext();
            int idselect =0;
            string Nomcategorie = null;
            RAP.FRM_RAPPORTE frmrpt = new RAP.FRM_RAPPORTE();
            Produit PR = new Produit();
            if(SelectVerif()!=null)
            {
                MessageBox.Show(SelectVerif(), "Imprimer Produit", MessageBoxButtons.OK, MessageBoxIcon.Error); //verifier si l'utilisateur cocher plusieur ligne 
            }
            else
            {
                for(int i=0;i<dvgProduit.Rows.Count;i++)
                {
                    if((bool)dvgProduit.Rows[i].Cells[0].Value==true) //si ligne est cocher
                    {
                        idselect = (int)dvgProduit.Rows[i].Cells[1].Value; //id de ligne selectionner
                        Nomcategorie = dvgProduit.Rows[i].Cells[5].Value.ToString(); //Nom de categorie

                    }
                }
                //////////////////////////////
                PR = db.Produits.SingleOrDefault(s => s.ID_Produit == idselect);
                if(PR!=null) //si le produit existe
                {
                    //donner le rapporte
                    frmrpt.RPAfficher.LocalReport.ReportEmbeddedResource = "Systeme_GS.RAP.RPT_Produit.rdlc";//chemin de rapporte
                    //Add librery Microsoft.reporting.winforms
                    ReportParameter Pcategorie = new ReportParameter("RPCategorie", Nomcategorie);//Nom de Categorie
                    ReportParameter PNom = new ReportParameter("RPNom", PR.Nom_Produit);//Nom de Produit
                    ReportParameter PQuantite = new ReportParameter("RPQuantité", PR.Quantite_Produit.ToString());//Quantite
                    ReportParameter PPrix = new ReportParameter("RPPrix", PR.Prix_Produit);//Prix
                    string ImageString = Convert.ToBase64String(PR.Image_Produit);
                    ReportParameter PImage = new ReportParameter("RPImage", ImageString);
                    //sauvgarder les nouveau paramettre dans la rapporte 'report'
                    frmrpt.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { Pcategorie, PNom, PQuantite, PPrix, PImage });
                    frmrpt.RPAfficher.RefreshReport();
                    frmrpt.ShowDialog(); //pour afficher la formulaire 

                }
                
            }
        }

        private void btnimprimertout_Click(object sender, EventArgs e)
        {
            RAP.FRM_RAPPORTE frrpt = new RAP.FRM_RAPPORTE();
            db = new dbStockContext();
            try
            {
                var listeProduit = db.Produits.ToList();  //Liste des produit 
                frrpt.RPAfficher.LocalReport.ReportEmbeddedResource = "Systeme_GS.RAP.RPT_LISTES_PRODUITS.rdlc"; //chemin de rapporte

                //Ajouter data Source
                frrpt.RPAfficher.LocalReport.DataSources.Add(new ReportDataSource("databaseproduit", listeProduit)); //liste des produit 
                ReportParameter date = new ReportParameter("Date", DateTime.Now.ToString()); //date system
                frrpt.RPAfficher.LocalReport.SetParameters(new ReportParameter[] { date });
                frrpt.RPAfficher.RefreshReport();
                frrpt.ShowDialog(); //pour afficher formulaire 
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
            


        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            db = new dbStockContext();
            using (SaveFileDialog SFD = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true }) //filtrer seulemnt les fichier excel
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;

                    //Ajouter les ligne de fichier excel
                    ws.Cells[1, 1] = "Id Produit";
                    ws.Cells[1, 2] = "Nom Produit";
                    ws.Cells[1, 3] = "Quantité";
                    ws.Cells[1, 4] = "Prix";

                    //Ajouter liste de produit de base de donnée dans fichier excel
                    var ListeProduit = db.Produits.ToList(); //listes des produit 
                    int i = 2;
                    foreach (var L in ListeProduit)
                    {
                        ws.Cells[i, 1] = L.ID_Produit;
                        ws.Cells[i, 2] = L.Nom_Produit;
                        ws.Cells[i, 3] = L.Quantite_Produit;
                        ws.Cells[i, 4] = L.Prix_Produit;
                        i++;

                    }
                    //changer style de fichier ----------------------
                    ws.Range["A1:D1"].Interior.Color = Color.Teal; //background color
                    ws.Range["A1:D1"].Font.Color = Color.White; //textColor color
                    ws.Range["A1:D1"].Font.Size = 15; //size text

                    //centraliser le text
                    ws.Range["A:D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    ws.Range["A1:D1"].ColumnWidth = 16; //change colon size

                    //-----------------------------------------------
                    wb.SaveAs(SFD.FileName); //sauvgarder dans fichier excel
                    app.Quit();
                    MessageBox.Show("Sauvgarde avec Succées dans Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pour actualiser datagridView
            Actualiserdvg();
        }
    }
}
