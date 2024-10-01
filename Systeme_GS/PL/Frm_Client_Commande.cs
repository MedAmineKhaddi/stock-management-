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
    public partial class Frm_Client_Commande : Form
    {
        private dbStockContext db;
        public Frm_Client_Commande()
        {
            InitializeComponent();
            db = new dbStockContext();
        }

        private void Frm_Client_Commande_Load(object sender, EventArgs e)
        {
            //remplire datagridView par liste des clients
            foreach(var LC in db.Clients)
            {
                dvgclient.Rows.Add(LC.ID_Client,LC.Nom_Client,LC.Prenom_Client,LC.Adresse_Client,LC.Telephone_Client,LC.Emai_Client,LC.Pays_Client,LC.Ville_Client);
            }
        }

        private void dvgclient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //quitter formulaire
            Close();
        }
    }
}
