using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_GS.BL
{
    class CLS_Connexion
    {
        //fonction pour verifier la connexion 
        public bool ConnexionValide(dbStockContext db,string Nom , string Mot_de_passe)
        {
            Utilisateur U = new Utilisateur(); //table utilisateur
            U.Nom_Utilisateur = Nom;
            U.Mot_De_Passe = Mot_de_passe;
            if(db.Utilisateurs.SingleOrDefault(s=>s.Nom_Utilisateur ==Nom && s.Mot_De_Passe ==Mot_de_passe)!=null) //si le nom est existe dans la base de donnée
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
    }
}
