using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_GS.BL
{
    class CLS_Produit
    {
        private dbStockContext db = new dbStockContext();
        private Produit PR;
        public bool Ajouter_Produit(string NomP,int Quantite,string prix,byte [] imageP,int idcategorie)//image sousforme de bits
        {
            PR = new Produit();
            PR.Nom_Produit = NomP;
            PR.Quantite_Produit = Quantite;
            PR.Prix_Produit = prix;
            PR.Image_Produit = imageP;
            PR.ID_Categorie = idcategorie;

            //verifier si le produit d'ja existe
            if(db.Produits.SingleOrDefault(a=>a.Nom_Produit==NomP && a.ID_Categorie==idcategorie)==null) //n'existe pas
            {
                db.Produits.Add(PR);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        //Modifier Produit
        public void Modifier_Produit(int IDP,string NomP, int Quantite, string prix, byte[] imageP, int idcategorie)
        {
            PR = new Produit();
            PR = db.Produits.SingleOrDefault(s => s.ID_Produit == IDP);//si ID de produit == Mon Id
            if(PR!=null)//si existe
            {
                PR.Nom_Produit = NomP;
                PR.Quantite_Produit = Quantite;
                PR.Prix_Produit = prix;
                PR.Image_Produit = imageP;
                PR.ID_Categorie = idcategorie;
                db.SaveChanges();
            }
        }

        //supprimer Produit
        public void Supprimer_Produit(int id)
        {
            PR = new Produit();
            PR = db.Produits.SingleOrDefault(s => s.ID_Produit == id);
            if(PR !=null)
            {
                db.Produits.Remove(PR);
                db.SaveChanges();
            }
        }
        
        public void Modifier_quantité(int id, int quantite)
        {
            PR = new Produit();
            PR = db.Produits.SingleOrDefault(s => s.ID_Produit == id);

            if (PR != null)
            {
                PR.Quantite_Produit -= quantite;
                db.SaveChanges();
            }

        }



    }
}
