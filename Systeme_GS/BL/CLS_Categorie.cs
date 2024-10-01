using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_GS.BL
{
    class CLS_Categorie
    {
        private dbStockContext db = new dbStockContext();
        private Categorie Cat;

        //fonction ajouter categorie
        public bool Ajouter_Categorie(string NomCat)
        {
            Cat = new Categorie();
            Cat.Nom_Categorie = NomCat;
            if(db.Categories.SingleOrDefault(s=>s.Nom_Categorie == NomCat)==null) //si il existe 
            {
                db.Categories.Add(Cat);
                db.SaveChanges();
                return true;
            }
            else //si le nom de categorie existe d'eja
            {
                return false;
            }

        }
        //Modifer Categorie
       
        public void Modifier_Categorie(int idcat , string NomCat)
        {
            Cat = new Categorie();
            Cat = db.Categories.SingleOrDefault(s => s.ID_Categorie == idcat);
            if(Cat!=null)
            {
                Cat.Nom_Categorie = NomCat;
                db.SaveChanges();
            }
        }
        //Supprimer Categorie
        public void Supprimer_Categorie(int idcat)
        {
            Cat = new Categorie();
            Cat = db.Categories.SingleOrDefault(s => s.ID_Categorie == idcat);
            if(Cat!=null) //existe
            {
                db.Categories.Remove(Cat);
                db.SaveChanges();
            }
        }
       
    }
}
