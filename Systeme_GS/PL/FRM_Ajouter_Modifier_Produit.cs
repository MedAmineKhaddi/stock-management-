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

namespace Systeme_GS.PL
{
    public partial class FRM_Ajouter_Modifier_Produit : Form
    {
        private dbStockContext db;
        private UserControl userProduit;

        public FRM_Ajouter_Modifier_Produit(UserControl user)
        {
            InitializeComponent();
            db = new dbStockContext();
            this.userProduit = user;
            //afficher les categories dans combobox
            combocategorie.DataSource = db.Categories.ToList();
            //pour donner seument les nom de categorie
            combocategorie.DisplayMember = "Nom_Categorie"; //afficher les nom de categorie
            combocategorie.ValueMember = "ID_Categorie";
        }

        

        string testobligatoire()
        {
            if(txtNomP.Text=="Nom de Produit"||txtNomP.Text=="")
            {
                return "Entrer le Nom de Produit";
            }
            if(txtQuantite.Text=="Quantité"||txtQuantite.Text=="")
            {
                return "Entrer la Quantité de Produit";

            }
            if (txtprix.Text == "Prix"||txtprix.Text=="")
            {
                return "Entrer le Prix de Produit";
            }
            if(picProduit.Image==null)
            {
                return "Enter l'Image de Produit";
            }
            if(combocategorie.Text=="")
            {
                return "Entrer la Categorie de Produit";
            }

            return null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomP_Enter(object sender, EventArgs e)
        {
            if(txtNomP.Text =="Nom de Produit")
            {
                txtNomP.Text = "";
                txtNomP.ForeColor = Color.White;
            }
        }

        private void txtNomP_Leave(object sender, EventArgs e)
        {
            if (txtNomP.Text == "")
            {
                txtNomP.Text = "Nom de Produit";
                txtNomP.ForeColor = Color.Silver;
            }
        }

        private void txtQuantite_Enter(object sender, EventArgs e)
        {
            if (txtQuantite.Text == "Quantité")
            {
                txtQuantite.Text = "";
                txtQuantite.ForeColor = Color.White;
            }
        }

        private void txtQuantite_Leave(object sender, EventArgs e)
        {
            if (txtQuantite.Text == "")
            {
                txtQuantite.Text = "Quantité";
                txtQuantite.ForeColor = Color.Silver;
            }
        }

        private void txtprix_Enter(object sender, EventArgs e)
        {
            if (txtprix.Text == "Prix")
            {
                txtprix.Text = "";
                txtprix.ForeColor = Color.White;
            }
        }

        private void txtprix_Leave(object sender, EventArgs e)
        {
            if (txtprix.Text == "")
            {
                txtprix.Text = "Prix";
                txtprix.ForeColor = Color.Silver;
            }
        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnparcourire_Click(object sender, EventArgs e)
        {
            //Afficher fichier Image
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "|*.JPG;*.PNG;*.GIF;*.BMP"; //pour afficher soft les images
            if(OP.ShowDialog()==DialogResult.OK)
            {
                picProduit.Image = Image.FromFile(OP.FileName);

            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            //Vider les champs
            txtNomP.Text = "Nom de Produit";txtNomP.ForeColor = Color.Silver;
            txtQuantite.Text = "Quantité";txtQuantite.ForeColor = Color.Silver;
            txtprix.Text = "Prix";txtprix.ForeColor = Color.Silver;
            combocategorie.Text = "";
            picProduit.Image = null;

        }

        private void txtQuantite_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox numérique
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void txtprix_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox numérique
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }
        public int IDPRODUIT;

        private void FRM_Ajouter_Modifier_Produit_Load(object sender, EventArgs e)
        {

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(testobligatoire()!=null)
            {
                MessageBox.Show(testobligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(lblTitre.Text=="Ajouter Produit")
                {
                    BL.CLS_Produit clproduit = new BL.CLS_Produit();
                    //convertire image en format byte
                    //ajouter system.IO comme bibliotheque
                    MemoryStream MR = new MemoryStream();
                    picProduit.Image.Save(MR, picProduit.Image.RawFormat);
                    byte[] byteimagep = MR.ToArray(); //convertir image on format byte[]
                    if(clproduit.Ajouter_Produit(txtNomP.Text,int.Parse(txtQuantite.Text),txtprix.Text,byteimagep,Convert.ToInt32(combocategorie.SelectedValue))==true)
                    {
                        MessageBox.Show("Produit ajouter avec succés", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        (userProduit as USER_Liste_Produit).Actualiserdvg();
                    }else
                    {
                        MessageBox.Show("Produit existe d'eja", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else //Modifier titre de formulaire
                {
                    MemoryStream MR = new MemoryStream();
                    picProduit.Image.Save(MR, picProduit.Image.RawFormat);
                    byte[] byteimagep = MR.ToArray(); //convertir image on format byte[]
                    BL.CLS_Produit clsproduit = new BL.CLS_Produit();
                    DialogResult RS = MessageBox.Show("Voulez-Vous Vraiment modifier", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(RS == DialogResult.Yes)
                    {
                        clsproduit.Modifier_Produit(IDPRODUIT, txtNomP.Text, int.Parse(txtQuantite.Text), txtprix.Text, byteimagep, Convert.ToInt32(combocategorie.SelectedValue));
                        MessageBox.Show("Produit Modifier avec succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //Actualiser datagridview
                        (userProduit as USER_Liste_Produit).Actualiserdvg();
                        Close(); //pour quitter formulaire si produit modifier 
                    }
                    else
                    {
                        MessageBox.Show("Modification annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    
                    
                
                }
            }
        }
    }
}
