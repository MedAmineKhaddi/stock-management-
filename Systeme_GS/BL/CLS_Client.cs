using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_GS.BL
{
    class CLS_Client
    {
        private dbStockContext db = new dbStockContext();
        private Client C;
        public bool Ajouter_Client(string Nom,string Prenom,string Adresse,string Telephone,string Email,string Pays,string Ville)
        {
            C = new Client();
            C.Nom_Client = Nom;
            C.Prenom_Client = Prenom;
            C.Adresse_Client = Adresse;
            C.Telephone_Client = Telephone;
            C.Emai_Client = Email;
            C.Pays_Client = Pays;
            C.Ville_Client = Ville;
            //Verifier si le nom et le prenom est existe dans DB
            if(db.Clients.SingleOrDefault(s=>s.Nom_Client==Nom && s.Prenom_Client==Prenom )==null)
            {
                db.Clients.Add(C); //Ajouter Client dans DB
                db.SaveChanges();
                return true;
            }
            else // si existe dans DB
            {
                return false;
            }
        }
        public void Modifier_Client(int id,string Nom, string Prenom, string Adresse, string Telephone, string Email, string Pays, string Ville)
        {
            C = new Client();
            C = db.Clients.SingleOrDefault(s => s.ID_Client == id); //verifier si ID de client est existe 
            if(C!=null) //existe
            {
                C.Nom_Client = Nom;
                C.Prenom_Client = Prenom;
                C.Adresse_Client = Adresse;
                C.Telephone_Client = Telephone;
                C.Emai_Client = Email;
                C.Pays_Client = Pays;
                C.Ville_Client = Ville;
                db.SaveChanges();
            }

            
            
        }

        //supprimer Client
        public void Suppimer_Client(int id)
        {
            C = new Client();
            C = db.Clients.SingleOrDefault(s => s.ID_Client == id);
            if(C!= null)
            {
                db.Clients.Remove(C);
                db.SaveChanges();
            }
            
        }
    }
}
