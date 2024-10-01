using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_GS.BL
{
    class CLS_Commande_DetailCommande
    {
        //Creation des instances 
        private dbStockContext db = new dbStockContext();
        private Commande Clscmd;
        private Details_Commande Clsd;
        public int IdCommande;

        //Sauvgarder les Commandes 
        public void Ajouter_Commande(DateTime dateCommande,int Idclient,string totalht,string tva,string totalttc)
        {
            Clscmd = new Commande();
            Clscmd.DATE_Commande = dateCommande;
            Clscmd.ID_Client = Idclient;
            Clscmd.Total_HT = totalht;
            Clscmd.TVA = tva;
            Clscmd.Total_TTC = totalttc;
            db.Commandes.Add(Clscmd);
            db.SaveChanges();
            IdCommande = Clscmd.ID_Commande;
        }

        //l'ajoute de detail d'un commande
        public void Ajouter_Detail( int Idproduit,string NomProduit ,int quantite,string prix, string remise,string total)
        {
            Clsd = new Details_Commande();
            // Clsd.ID_Commande = Idcommnade;
            Clsd.ID_Commande = IdCommande;
            Clsd.ID_Produit = Idproduit;
            Clsd.Nom_Produit = NomProduit;
            Clsd.Qantite = quantite;
            Clsd.Prix = prix;
            Clsd.Remise = remise;  
            Clsd.Total = total;
            db.Details_Commande.Add(Clsd);
            db.SaveChanges();
        }

    }
}
